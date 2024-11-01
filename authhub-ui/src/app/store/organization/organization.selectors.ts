import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthHubState } from "../AuthHubState";
import { Token } from "src/app/models/Token";

export const organizationFeatureSelector = createFeatureSelector<AuthHubState>("organization");
export const tokenSelector = createSelector(organizationFeatureSelector, (state: AuthHubState)=> state.Token as Token);