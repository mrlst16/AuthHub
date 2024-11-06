import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiResponse } from "../models/responses/ApiResponse";
import { ClaimesTemplateListItem } from "../models/ClaimsTemplateListItem";
import { HttpClient } from "@angular/common/http";
import { AuthenticationService } from "./AuthenticationService";
import { environment } from "src/environments/environment";
import { AddClaimsTemplateRequest } from "../models/requests/AddClaimsTemplateRequest";

@Injectable({
    providedIn: 'root'
})
export class ClaimsService{

    constructor(
        private readonly http: HttpClient,
        private readonly authenticationService: AuthenticationService
    ){
    }

    GetClaimsTemplateList(): Observable<ApiResponse<ClaimesTemplateListItem[]>> {
        return this.http.get<ApiResponse<ClaimesTemplateListItem[]>>(
            `${environment.apiUrl}/api/claims/list_templates`,
            {headers: this.authenticationService.GetAuthorizationHeader()}
        );
    }

    AddClaimsTemplate(request: AddClaimsTemplateRequest):Observable<ApiResponse<number>>{
        return this.http.post<ApiResponse<number>>(
            `${environment.apiUrl}/api/claims/template`,
            request,
            {headers: this.authenticationService.GetAuthorizationHeader()}
        );
    }
}