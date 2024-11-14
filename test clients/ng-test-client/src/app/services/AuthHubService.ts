import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { Token } from "../models/Token";

export class AuthHubService{

    private readonly LocalStorageTokenName = "authhub-token";

    constructor(
        private readonly http: HttpClient,
        private readonly mode: "dev" | "prod" = "prod",
        private readonly organizationId: number,
        private readonly apiKey: string,
        private readonly apiSecret: string
    ){
    }

    private BaseUrl(): string {
        switch (this.mode) {
            case "dev":
                return "https://localhost:50930";
            case "prod":
                return "https://{SOMEURLHERE}";
        }
    }

    // x-authhub-organizationid
    // x-authhub-apikey
    // x-authhub-apisecret
    // x-authhub-username
    // x-authhub-password
    Login(username: string, password: string): Observable<Token>{
        let headers = new HttpHeaders()
        .append("x-authhub-organizationid", this.organizationId.toString())
        .append("x-authhub-apikey", this.apiKey)
        .append("x-authhub-apisecret", this.apiSecret)
        .append("x-authhub-username", username)
        .append("x-authhub-password", password)
        
        return this.http.get<{
            Data: Token
        }>(`${this.BaseUrl()}/api/token`, {
            headers: headers
        })
        .pipe(map(x=> x.Data));
    }

    GetToken(): Token{
        let json = localStorage.getItem(this.LocalStorageTokenName)
        return JSON.parse(json as string);
    }

    SetToken(token: Token): void{
        localStorage.setItem(this.LocalStorageTokenName, JSON.stringify(token))
    }

    AuthorizationHeader(): HttpHeaders{
        let token = this.GetToken();
        if(token == null)
            throw "user is not logged in";

        let headers = new HttpHeaders();
        headers.append("x-authhub-organizationid", this.organizationId.toString())
        headers.append("x-authhub-apikey", this.apiKey)
        headers.append("x-authhub-apisecret", this.apiSecret)
        headers.append("Authorization", "Bearer " + token.Value);
        return headers;
    }

    Logout(): void{
        localStorage.removeItem(this.LocalStorageTokenName);
    }

    IsLoggedIn(): boolean{
        return this.GetToken() != null
    }
}