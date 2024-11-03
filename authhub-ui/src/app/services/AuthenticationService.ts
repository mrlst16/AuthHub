import { Injectable } from "@angular/core";
import { LocalStorageService } from "./LocalStorageService";
import { Token } from "../models/Token";
import { HttpHeaders } from "@angular/common/http";

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

    GetToken() : Token | null{
        return this.localStorageService.Get("token");
    }

    GetAuthorizationHeader(): HttpHeaders {
        let token: Token = this.GetToken() as Token;
        return new HttpHeaders({
            "Authorization": `Bearer ${token.Value}`
        })
    }
}