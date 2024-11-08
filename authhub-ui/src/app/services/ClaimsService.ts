import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiResponse } from "../models/responses/ApiResponse";
import { ClaimsTemplateListItem } from "../models/ClaimsTemplateListItem";
import { HttpClient } from "@angular/common/http";
import { AuthenticationService } from "./AuthenticationService";
import { environment } from "src/environments/environment";
import { AddClaimsTemplateRequest } from "../models/requests/AddClaimsTemplateRequest";
import { ClaimsTemplate } from "../models/ClaimsTemplate";
import { AddClaimsKeysRequest } from "../models/requests/AddClaimsKeysRequest";
import { RemoveClaimsKeysRequest } from "../models/requests/RemoveClaimsKeysRequest";

@Injectable({
    providedIn: 'root'
})
export class ClaimsService{

    constructor(
        private readonly http: HttpClient,
        private readonly authenticationService: AuthenticationService
    ){
    }

    GetClaimsTemplateList(): Observable<ApiResponse<ClaimsTemplateListItem[]>> {
        return this.http.get<ApiResponse<ClaimsTemplateListItem[]>>(
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

    GetClaimsTemplate(name: string): Observable<ApiResponse<ClaimsTemplate>> {
        return this.http.get<ApiResponse<ClaimsTemplate>>(
            `${environment.apiUrl}/api/claims/template?name=${name}`,
            {headers: this.authenticationService.GetAuthorizationHeader()}
        );
    }

    AddClaimsKey(request: AddClaimsKeysRequest):Observable<ApiResponse<boolean>>{
        return this.http.post<ApiResponse<boolean>>(
            `${environment.apiUrl}/api/claims/keys`,
            request,
            {headers: this.authenticationService.GetAuthorizationHeader()}
        );
    }

    RemoveClaimsKey(request: RemoveClaimsKeysRequest):Observable<ApiResponse<boolean>>{
        return this.http.delete<ApiResponse<boolean>>(
            `${environment.apiUrl}/api/claims/keys`,
            {
                body: request,
                headers: this.authenticationService.GetAuthorizationHeader()
            }
        );
    }
}