import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthSettings } from "../models/AuthSettings";
import { ApiResponse } from "../models/responses/ApiResponse";
import { HttpClient } from "@angular/common/http";
import { AuthenticationService } from "./AuthenticationService";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class AuthSettingsService{

    constructor(
        private readonly http: HttpClient,
        private readonly authenticationService: AuthenticationService
    ){
    }

    GetAuthSettings() : Observable<ApiResponse<AuthSettings>>{
        return this.http.get<ApiResponse<AuthSettings>>(
            `${environment.apiUrl}/api/auth-settings`,
            {headers: this.authenticationService.GetAuthorizationHeader()}
        );
    }

    SaveAuthSettings(request: AuthSettings) : Observable<ApiResponse<boolean>>{
        return this.http.patch<ApiResponse<boolean>>(
            `${environment.apiUrl}/api/auth-settings`,
            request,
            {headers: this.authenticationService.GetAuthorizationHeader()}
        );
    }
}