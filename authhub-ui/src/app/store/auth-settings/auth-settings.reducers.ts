import { createReducer, on } from "@ngrx/store"
import { initalState } from "../AuthHubState"
import { getAuthSettingsSuccess } from "./auth-settings.actions"

export const authSettingsReducer = createReducer(
    initalState,
    on(getAuthSettingsSuccess, (state, {response})=>{
        return {
            ...state,
            AuthSettings: response
        }
    })
 )