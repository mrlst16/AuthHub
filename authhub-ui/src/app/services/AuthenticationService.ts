import { Injectable } from "@angular/core";
import { LocalStorageService } from "./LocalStorageService";
import { Token } from "../models/Token";
import { HttpHeaders } from "@angular/common/http";
import { Observable, of } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService{

    constructor(
        private readonly localStorageService: LocalStorageService
    ) {
    }

    SaveToken(token: Token){
        this.localStorageService.Save("token", token);
    }

    RemoveToken(){
        this.localStorageService.Remove("token");
    }

    RemoveTokenObservable(): Observable<any>{
        this.RemoveToken();
        return of();
    }

    GetToken() : Token | null{
        return this.localStorageService.Get("token");
    }

    GetAuthorizationHeader(): HttpHeaders {
        let token: Token = this.GetToken() as Token;
        return new HttpHeaders({
            "Authorization": `Bearer ${token.Value}`
        })
    }

    IsLoggeedIn(): boolean{
        return this.GetToken() != null;
    }
}