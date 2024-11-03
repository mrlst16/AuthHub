import { createAction, props } from "@ngrx/store";
import { ApiKey } from "src/app/models/ApiKey";

export const generateApiKey = createAction("[ApiKey] Generate");
export const generateApiKeySuccess = createAction("[ApiKey] Generate Success", props<{response: ApiKey}>());
export const generateApiKeyError = createAction("[ApiKey] Generate Success");