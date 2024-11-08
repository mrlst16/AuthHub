import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthHubState } from "../AuthHubState";
import { ClaimsTemplateListItem } from "src/app/models/ClaimsTemplateListItem";
import { ClaimsTemplate } from "src/app/models/ClaimsTemplate";
import { ClaimsKey } from "src/app/models/ClaimsKey";


const claimsFeatureSelector = createFeatureSelector<AuthHubState>("claims")
export const claimsTemplateListItemsSelector = createSelector(claimsFeatureSelector, (state: AuthHubState)=> state.ClaimsTemplates as ClaimsTemplateListItem[])
export const claimsTemplateSelector = createSelector(claimsFeatureSelector, (state: AuthHubState)=> state.ClaimsTemplate as ClaimsTemplate)
export const claimsTemplateKeysSelector = createSelector(claimsFeatureSelector, (state: AuthHubState)=> state.ClaimsTemplate?.Keys as ClaimsKey[])
