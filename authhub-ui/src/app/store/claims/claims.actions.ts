import { createAction, props } from "@ngrx/store";
import { ClaimesTemplateListItem } from "src/app/models/ClaimsTemplateListItem";
import { AddClaimsTemplateRequest } from "src/app/models/requests/AddClaimsTemplateRequest";

export const getClaimsTemplates = createAction("[Claims] Get Template List Items");
export const getClaimsTemplatesSuccess = createAction("[Claims] Get Template List Items Success", props<{response:ClaimesTemplateListItem[]}>());
export const getClaimsTemplatesError = createAction("[Claims] Get Template List Items Error");

export const addClaimsTemplate = createAction("[Claims] Add Template", props<{request: AddClaimsTemplateRequest}>());
export const addClaimsTemplateSuccess = createAction("[Claims] Add Template Success");
export const addClaimsTemplateError = createAction("[Claims] Add Template Error");