import { createAction, props } from "@ngrx/store";
import { Organization } from "src/app/models/Organization";
import { CreateOrganizationRequest } from "src/app/models/requests/CreateOrganizationRequest";
import { OrganizationLoginRequest } from "src/app/models/requests/OrganizationLoginRequest";
import { Token } from "src/app/models/Token";

export const registerOrganization = createAction("[Organization] Register", props<{request: CreateOrganizationRequest}>());
export const registerOrganizationSuccess = createAction("[Organization] Register Success", props<{response:Organization}>());
export const registerOrganizationError = createAction("[Organization] Register Error");

export const loginOrganization = createAction("[Organization] Login", props<{request: OrganizationLoginRequest}>());
export const loginOrganizationSuccess = createAction("[Organization] Login Success", props<{response: Token}>());
export const loginOrganizationError = createAction("[Organization] Login Error");

export const logoutOrganization = createAction("[Organization] Logout");
export const logoutOrganizationSuccess = createAction("[Organization] Logout Success");
export const logoutOrganizationError = createAction("[Organization] Logout Error");