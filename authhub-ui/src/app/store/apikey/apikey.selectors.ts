import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthHubState } from "../AuthHubState";
import { ApiKey } from "src/app/models/ApiKey";

const featureSelector = createFeatureSelector<AuthHubState>("apikey");

export const apiKeySelector = createSelector(
    featureSelector,
    (state: AuthHubState) => state.Key as ApiKey
)