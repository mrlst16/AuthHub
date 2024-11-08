import { createAction, props } from "@ngrx/store";
import { ClaimsTemplate } from "src/app/models/ClaimsTemplate";
import { ClaimsTemplateListItem } from "src/app/models/ClaimsTemplateListItem";
import { AddClaimsKeysRequest } from "src/app/models/requests/AddClaimsKeysRequest";
import { AddClaimsTemplateRequest } from "src/app/models/requests/AddClaimsTemplateRequest";
import { RemoveClaimsKeysRequest } from "src/app/models/requests/RemoveClaimsKeysRequest";

export const getClaimsTemplates = createAction("[Claims] Get Template List Items");
export const getClaimsTemplatesSuccess = createAction("[Claims] Get Template List Items Success", props<{response:ClaimsTemplateListItem[]}>());
export const getClaimsTemplatesError = createAction("[Claims] Get Template List Items Error");

export const addClaimsTemplate = createAction("[Claims] Add Template", props<{request: AddClaimsTemplateRequest}>());
export const addClaimsTemplateSuccess = createAction("[Claims] Add Template Success");
export const addClaimsTemplateError = createAction("[Claims] Add Template Error");

export const getClaimsTemplate = createAction("[Claims] Get Claims Template", props<{name: string}>())
export const getClaimsTemplateSuccess = createAction("[Claims] Get Claims Template Success", props<{response: ClaimsTemplate}>())
export const getClaimsTemplateError = createAction("[Claims] Get Claims Template Error")

export const addClaimsKey = createAction("[Claims] Add Key", props<{request: AddClaimsKeysRequest}>())
export const addClaimsKeySuccess = createAction("[Claims] Add Key Success", props<{templateName: string}>())
export const addClaimsKeyError = createAction("[Claims] Add Key Error")

export const removeClaimsKey = createAction("[Claims] Remove Key", props<{request: RemoveClaimsKeysRequest}>())
export const removeClaimsKeySuccess = createAction("[Claims] Remove Key Success", props<{templateName: string}>())
export const removeClaimsKeyError = createAction("[Claims] Remove Key Error")