import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthHubState } from "../AuthHubState";
import { Token } from "src/app/models/Token";
import { LocalStorageService } from "src/app/services/LocalStorageService";

const localStorageService: LocalStorageService = new LocalStorageService();

export const organizationFeatureSelector = createFeatureSelector<AuthHubState>("organization");
export const tokenSelector = createSelector(organizationFeatureSelector, (state: AuthHubState)=> {
    let token: Token | null = null;
    token = localStorageService.GetToken();
    return token;
});