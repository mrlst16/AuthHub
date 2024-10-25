import { createReducer, on } from "@ngrx/store";
import { initalState } from "../AuthHubState";
import { registerOrganization, registerOrganizationSuccess } from "./registration.actions";


export const registerOrganizationReducer = createReducer(
    initalState,
    on(registerOrganization, (state, {request})=>{
        console.log("registerOrganizationReducer")
        return {
            ...state
        }
    }),
    on(registerOrganizationSuccess, (state, {response})=>{
        return {
            ...state,
            Organization: response
        }
    })

 )