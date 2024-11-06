import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AuthenticationService } from "./AuthenticationService";
import { Observable } from "rxjs";
import { ApiKey } from "../models/ApiKey";
import { environment } from "src/environments/environment";
import { ApiResponse } from "../models/responses/ApiResponse";

@Injectable({
    providedIn: 'root'
})
export class ApiKeysService{
    constructor(
        private readonly authenticationService: AuthenticationService,
        private readonly http: HttpClient
    ) {
    }

    GenerateApiKey() : Observable<ApiResponse<ApiKey>>{
        return this.http.post<ApiResponse<ApiKey>>(
            `${environment.apiUrl}/api/api-key/generate`, 
            null, 
            {headers: this.authenticationService.GetAuthorizationHeader()}
        );
    }
}