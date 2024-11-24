import { Injectable } from "@angular/core";
import { ResetPasswordRequest } from "../models/requests/ResetPasswordRequest";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Organization } from "../models/Organization";
import { ApiResponse } from "../models/responses/ApiResponse";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class UserService{

    constructor(
        private readonly http: HttpClient
    ){
    }

    resetPassword(request: ResetPasswordRequest): Observable<ApiResponse<boolean>>{
        return this.http.post<ApiResponse<boolean>>(`${environment.apiUrl}/api/password_reset`, request);
    }
}