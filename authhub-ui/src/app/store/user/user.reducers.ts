import { createReducer, on } from "@ngrx/store"
import { resetUserPassword, resetUserPasswordSuccess } from "./user.actions"
import { initalState } from "../AuthHubState"


export const organizationReducer = createReducer(
    initalState,
    on(resetUserPassword, (state)=>{
        return {
            ...state
        }
    }),
    on(resetUserPasswordSuccess, (state, {response})=>{
        return {
            ...state
        }
    })
 )