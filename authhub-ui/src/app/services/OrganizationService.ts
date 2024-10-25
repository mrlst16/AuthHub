import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Organization } from "../models/Organization";
import { Observable } from "rxjs";
import { CreateOrganizationRequest } from "../models/requests/CreateOrganizationRequest";

@Injectable({
    providedIn: 'root'
})
export class OrganizationService{

    constructor(private readonly http: HttpClient){
    }

    register(request: CreateOrganizationRequest): Observable<Organization>{
        return this.http.post<Organization>("http://localhost:50931/api/organization/create", request);
    }
}