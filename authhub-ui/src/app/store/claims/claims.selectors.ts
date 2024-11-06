import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthHubState } from "../AuthHubState";
import { ClaimesTemplateListItem } from "src/app/models/ClaimsTemplateListItem";


const claimsFeatureSelector = createFeatureSelector<AuthHubState>("claims")
export const claimsTemplateSelector = createSelector(claimsFeatureSelector, (state: AuthHubState)=> state.ClaimsTemplates as ClaimesTemplateListItem[])