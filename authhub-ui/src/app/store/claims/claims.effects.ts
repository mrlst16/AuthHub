import { inject } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { ClaimsService } from "src/app/services/ClaimsService";
import { addClaimsTemplate, addClaimsTemplateSuccess, getClaimsTemplates, getClaimsTemplatesSuccess } from "./claims.actions";
import { exhaustMap, map } from "rxjs";
import { ClaimesTemplateListItem } from "src/app/models/ClaimsTemplateListItem";

export const getClaimsTemplatesEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ClaimsService)
    )=> {
        return actions$.pipe(
            ofType(getClaimsTemplates, addClaimsTemplateSuccess),
            exhaustMap(()=> {
                return service.GetClaimsTemplateList().pipe(
                    map((response)=> {
                        return getClaimsTemplatesSuccess({response: response.Data as ClaimesTemplateListItem[]})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});


export const addClaimsTemplateEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ClaimsService)
    )=> {
        return actions$.pipe(
            ofType(addClaimsTemplate),
            exhaustMap(({request})=> {
                return service.AddClaimsTemplate(request).pipe(
                    map((response)=> {
                        return addClaimsTemplateSuccess()
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});