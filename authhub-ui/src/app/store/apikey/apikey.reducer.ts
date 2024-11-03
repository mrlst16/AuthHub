import { createReducer, on } from "@ngrx/store"
import { initalState } from "../AuthHubState"
import { generateApiKey, generateApiKeySuccess } from "./apikey.actions"


export const apiKeyReducer = createReducer(
    initalState,
    on(generateApiKey, (state)=>{
        return {
            ...state
        }
    }),
    on(generateApiKeySuccess, (state, {response})=>{
        return {
            ...state,
            Key: response
        }
    })
 )