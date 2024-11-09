import { createAction, props } from "@ngrx/store"
import { AuthSettings } from "src/app/models/AuthSettings"

export const updateAuthSettings = createAction("[Auth Settings] Update")
export const updateAuthSettingsSuccess = createAction("[Auth Settings] Update Success")
export const updateAuthSettingsError = createAction("[Auth Settings] Update Error")

export const getAuthSettings = createAction("[Auth Settings] Get")
export const getAuthSettingsSuccess = createAction("[Auth Settings] Get Success", props<{response: AuthSettings}>())
export const getAuthSettingsError = createAction("[Auth Settings] Get Error")