import { inject } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { ClaimsService } from "src/app/services/ClaimsService";
import { getClaimsTemplates, getClaimsTemplatesSuccess } from "./claims.actions";
import { exhaustMap, map } from "rxjs";
import { ClaimesTemplateListItem } from "src/app/models/ClaimsTemplateListItem";

export const registerOrganizationEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ClaimsService)
    )=> {
        return actions$.pipe(
            ofType(getClaimsTemplates),
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