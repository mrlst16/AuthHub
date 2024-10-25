import { createAction, props } from "@ngrx/store";
import { Organization } from "src/app/models/Organization";
import { CreateOrganizationRequest } from "src/app/models/requests/CreateOrganizationRequest";

export const registerOrganization = createAction("[Organization] Register", props<{request: CreateOrganizationRequest}>());
export const registerOrganizationSuccess = createAction("[Organization] Register Success", props<{response:Organization}>());
export const registerOrganizationError = createAction("[Organization] Register Error");