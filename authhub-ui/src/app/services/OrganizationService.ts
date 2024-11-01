import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Organization } from "../models/Organization";
import { Observable } from "rxjs";
import { CreateOrganizationRequest } from "../models/requests/CreateOrganizationRequest";
import { environment } from "src/environments/environment";
import { ApiResponse } from "../models/responses/ApiResponse";
import { Token } from "../models/Token";
import { OrganizationLoginRequest } from "../models/requests/OrganizationLoginRequest";

@Injectable({
    providedIn: 'root'
})
export class OrganizationService{

    constructor(private readonly http: HttpClient){
    }

    register(request: CreateOrganizationRequest): Observable<ApiResponse<Organization>>{
        return this.http.post<ApiResponse<Organization>>(`${environment.apiUrl}/api/organization/create`, request);
    }

    login(request: OrganizationLoginRequest): Observable<ApiResponse<Token>>{
        return this.http.post<ApiResponse<Token>>(`${environment.apiUrl}/api/organization/login`, request);
    }
}