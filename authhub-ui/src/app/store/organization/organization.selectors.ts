import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthHubState } from "../AuthHubState";
import { Token } from "src/app/models/Token";
import { LocalStorageService } from "src/app/services/LocalStorageService";
import { AuthenticationService } from "src/app/services/AuthenticationService";

const localStorageService: LocalStorageService = new LocalStorageService();
const authenticationService: AuthenticationService = new AuthenticationService(localStorageService);

export const organizationFeatureSelector = createFeatureSelector<AuthHubState>("organization");
export const tokenSelector = createSelector(organizationFeatureSelector, (state: AuthHubState)=> {
    let token: Token | null = null;
    token = authenticationService.GetToken();
    return token;
});