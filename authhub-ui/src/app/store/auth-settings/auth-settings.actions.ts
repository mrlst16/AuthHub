import { createAction, props } from "@ngrx/store"
import { AuthSettings } from "src/app/models/AuthSettings"

export const getAuthSettings = createAction("[Auth Settings] Get")
export const getAuthSettingsSuccess = createAction("[Auth Settings] Get Success", props<{response: AuthSettings}>())
export const getAuthSettingsError = createAction("[Auth Settings] Get Error")

export const saveAuthSettings = createAction("[Auth Settings] Save", props<{request: AuthSettings}>())
export const saveAuthSettingsSuccess = createAction("[Auth Settings] Save Success")
export const saveAuthSettingsError = createAction("[Auth Settings] Save Error")