import { createReducer, on } from "@ngrx/store";
import { initalState } from "../AuthHubState";
import { loginOrganization, loginOrganizationSuccess, logoutOrganization, logoutOrganizationSuccess, registerOrganization, registerOrganizationSuccess } from "./organization.actions";


export const organizationReducer = createReducer(
    initalState,
    on(registerOrganization, (state)=>{
        return {
            ...state
        }
    }),
    on(registerOrganizationSuccess, (state, {response})=>{
        return {
            ...state,
            Organization: response
        }
    }),
    on(loginOrganization, (state)=>{
        return {
            ...state
        }
    }),
    on(loginOrganizationSuccess, (state, {response})=>{
        return {
            ...state,
            Token: response
        }
    }),
    on(logoutOrganization, (state)=>{
        console.log("logoutOrganization")
        return {
        }
    }),
    on(logoutOrganizationSuccess, (state)=>{
        console.log("logoutOrganizationSuccess")
        return {
        }
    })
 )