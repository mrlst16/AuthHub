import { createReducer, on } from "@ngrx/store";
import { initalState } from "../AuthHubState";
import { addClaimsTemplate, addClaimsTemplateSuccess, getClaimsTemplates, getClaimsTemplatesSuccess, getClaimsTemplateSuccess } from "./claims.actions";

export const claimsReducer = createReducer(
    initalState,
    on(getClaimsTemplates, (state)=>{
        return {
            ...state
        }
    }),
    on(getClaimsTemplatesSuccess, (state, {response})=>{
        return {
            ...state,
            ClaimsTemplates: response
        }
    }),
    on(addClaimsTemplate, (state)=>{
        return {
            ...state
        }
    }),
    on(addClaimsTemplateSuccess, (state)=>{
        return {
            ...state,
        }
    }),
    on(getClaimsTemplateSuccess, (state, {response})=>{
        return {
            ...state,
            ClaimsTemplate : response
        }
    })
 )