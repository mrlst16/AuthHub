import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { Token } from "../models/Token";
import { AddClaimsRequest } from "../models/claims/AddClaimsRequest";
import { RemoveClaimsRequest } from "../models/claims/RemoveClaimsRequest";
import { SetClaimsRequest } from "../models/claims/SetClaimsRequest";

export class AuthHubService{

    public static readonly LocalStorageTokenName = "authhub-token";

    constructor(
        private readonly http: HttpClient,
        private readonly mode: "dev" | "prod",
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
                return "https://buzzauth.com";
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

    SetupRefreshTimeout(minutesBeforeExpiration: number = 5): void{
        minutesBeforeExpiration = Math.max(minutesBeforeExpiration, 5);
        let token: Token = GetToken();
        if(token == null || token.ExpirationDate == null) 
            return;
            
        let now: Date = new Date();
        let utc: number = Date.UTC(now.getUTCFullYear(), now.getUTCMonth(), now.getUTCDay(), now.getUTCHours(), now.getUTCMinutes(), now.getUTCSeconds(), now.getUTCMilliseconds())
        let delayMilliseconds =  token.ExpirationDate.getTime() - utc;
        if(delayMilliseconds < 0)
            return;

        let self = this;
        setTimeout(function(){
            self.RefreshToken()
                .subscribe(x=> {
                    SetToken(x)
                })
        }, delayMilliseconds);
    }


    AuthorizationHeaders(): HttpHeaders{
        let token = GetToken();
        if(token == null)
            throw "user is not logged in";

        let headers = new HttpHeaders();
        headers.append("x-authhub-organizationid", this.organizationId.toString())
        headers.append("x-authhub-apikey", this.apiKey)
        headers.append("x-authhub-apisecret", this.apiSecret)
        headers.append("Authorization", "Bearer " + token.Value);
        return headers;
    }

    RefreshToken() :Observable<Token>{
        return this.http.get<{
            Data: Token
        }>(`${this.BaseUrl()}/api/token/refresh`, {
            headers: this.AuthorizationHeaders()
        })
        .pipe(map(x=> x.Data));
    }

    Logout(): void{
        localStorage.removeItem(AuthHubService.LocalStorageTokenName);
    }

    AddClaims(request: AddClaimsRequest): Observable<boolean>{
        return this.http.post<{
            Data: boolean
        }>(`${this.BaseUrl()}/api/claims`,
            request,
        {
            headers: this.AuthorizationHeaders()
        })
        .pipe(map(x=> x.Data));
    }

    RemoveClaims(request: RemoveClaimsRequest): Observable<boolean>{
        return this.http.patch<{
            Data: boolean
        }>(`${this.BaseUrl()}/api/claims`,
            request,
        {
            headers: this.AuthorizationHeaders()
        })
        .pipe(map(x=> x.Data));
    }

    SetClaims(request: SetClaimsRequest): Observable<boolean>{
        return this.http.put<{
            Data: boolean
        }>(`${this.BaseUrl()}/api/claims`,
            request,
        {
            headers: this.AuthorizationHeaders()
        })
        .pipe(map(x=> x.Data));
    }
}


export function GetToken(): Token{
    let json = localStorage.getItem(AuthHubService.LocalStorageTokenName)
    return JSON.parse(json as string);
}

export function SetToken(token: Token): void{
    localStorage.setItem(AuthHubService.LocalStorageTokenName, JSON.stringify(token))
}

export function IsLoggedIn(): boolean{
    return GetToken() != null
}