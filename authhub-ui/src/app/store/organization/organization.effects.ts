import { inject } from "@angular/core";
import { createEffect, Actions, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, map, mergeMap, of, switchMap, throwError } from "rxjs";
import { OrganizationService } from "src/app/services/OrganizationService";
import { loginOrganization, loginOrganizationSuccess, registerOrganization, registerOrganizationError, registerOrganizationSuccess } from "./organization.actions";
import { Organization } from "src/app/models/Organization";
import { Token } from "src/app/models/Token";

export const registerOrganizationEffect = createEffect(
    (actions$ = inject(Actions), service = inject(OrganizationService))=> {
        return actions$.pipe(
            ofType(registerOrganization),
            exhaustMap(({request})=> {
                return service.register(request).pipe(
                    map((response)=> registerOrganizationSuccess({response: response.Data as Organization})),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});

export const loginOrganizationEffect = createEffect(
    (actions$ = inject(Actions), service = inject(OrganizationService))=> {
        return actions$.pipe(
            ofType(loginOrganization),
            switchMap(({request})=> {
                return service.login(request).pipe(
                    map((response)=> {
                        console.log("response", response)
                        return loginOrganizationSuccess({response: response.Data as Token})
                    }),
                    catchError(({error})=> {
                        console.log("error", error)
                        return throwError(error);
                    })
                )
            })
        )
}, {
    functional: true
});