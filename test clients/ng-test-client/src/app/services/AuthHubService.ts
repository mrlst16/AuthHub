import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { Token } from "../models/Token";
import { AddClaimsRequest } from "../models/claims/AddClaimsRequest";
import { RemoveClaimsRequest } from "../models/claims/RemoveClaimsRequest";
import { SetClaimsRequest } from "../models/claims/SetClaimsRequest";
import { Claim } from "../models/claims/Claim";
import { GetToken, SetToken } from "./TokenStorage";

export class AuthHubService{

    public static readonly StorageTokenName = "authhub-token";

    constructor(
        private readonly http: HttpClient,
        private readonly mode: "dev" | "prod",
        private readonly organizationId: number,
        private readonly apiKey: string,
        private readonly apiSecret: string,
        private readonly tokenStorageMode: "local" | "session" = "local"
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

        return new HttpHeaders()
        .append("x-authhub-organizationid", this.organizationId.toString())
        .append("x-authhub-apikey", this.apiKey)
        .append("x-authhub-apisecret", this.apiSecret)
        .append("Authorization", "Bearer " + token.Value);
    }

    RefreshToken() :Observable<Token>{
        let token: Token = GetToken();
        
        return this.http.get<{
            Data: Token
        }>(`${this.BaseUrl()}/api/token/refresh?refreshToken=${token.RefreshToken}`, {
            headers: this.AuthorizationHeaders()
        })
        .pipe(map(x=> x.Data));
    }

    Logout(): void{
        localStorage.removeItem(AuthHubService.StorageTokenName);
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
    
    RequestPasswordReset(username: string) :Observable<boolean>{
        return this.http.post<{
            Data: {},
            Success: boolean
        }>(`${this.BaseUrl()}/api/password_reset/request_user_password_reset`,
            {
                Username: username
            },
        {
            headers: this.AuthorizationHeaders()
        })
        .pipe(map(x=> x.Success));
    }
}