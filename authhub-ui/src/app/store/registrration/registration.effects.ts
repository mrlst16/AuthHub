import { inject } from "@angular/core";
import { createEffect, Actions, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, map, mergeMap, of } from "rxjs";
import { OrganizationService } from "src/app/services/OrganizationService";
import { registerOrganization, registerOrganizationError, registerOrganizationSuccess } from "./registration.actions";

export const registerOrganizationEffect = createEffect(
    (actions$ = inject(Actions), service = inject(OrganizationService))=> {
        return actions$.pipe(
            ofType(registerOrganization),
            exhaustMap(({request})=> {
                return service.register(request).pipe(
                    map((response)=> registerOrganizationSuccess({response: response})),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});