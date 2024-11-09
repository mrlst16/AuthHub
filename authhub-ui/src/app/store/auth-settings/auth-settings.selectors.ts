import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthHubState } from "../AuthHubState";
import { AuthSettings } from "src/app/models/AuthSettings";

const featureSelector = createFeatureSelector<AuthHubState>("authSettings")
export const authSettingsSelector = createSelector(featureSelector, (state: AuthHubState)=> state.AuthSettings as AuthSettings);