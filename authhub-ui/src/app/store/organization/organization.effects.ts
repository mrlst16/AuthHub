import { inject } from "@angular/core";
import { createEffect, Actions, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, map, mergeMap, of, switchMap, throwError } from "rxjs";
import { OrganizationService } from "src/app/services/OrganizationService";
import { loginOrganization, loginOrganizationSuccess, logoutOrganization, logoutOrganizationSuccess, registerOrganization, registerOrganizationError, registerOrganizationSuccess } from "./organization.actions";
import { Organization } from "src/app/models/Organization";
import { Token } from "src/app/models/Token";
import { AuthenticationService } from "src/app/services/AuthenticationService";

export const registerOrganizationEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(OrganizationService)
    )=> {
        return actions$.pipe(
            ofType(registerOrganization),
            exhaustMap(({request})=> {
                return service.register(request).pipe(
                    map((response)=> {
                        return registerOrganizationSuccess({response: response.Data as Organization})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});

export const loginOrganizationEffect = createEffect(
    (
        actions$ = inject(Actions), 
        service = inject(OrganizationService),
        authenticationService = inject(AuthenticationService)
    )=> {
        return actions$.pipe(
            ofType(loginOrganization),
            switchMap(({request})=> {
                return service.login(request).pipe(
                    map((response)=> {
                        const token: Token = response.Data as Token;
                        authenticationService.SaveToken(token)
                        console.log("response", response)
                        return loginOrganizationSuccess({response: token})
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


export const logoutOrganizationEffect = createEffect(
    (
        actions$ = inject(Actions), 
        authenticationService = inject(AuthenticationService)
    )=> {
        return actions$.pipe(
            ofType(logoutOrganization),
            switchMap(()=> {
                authenticationService.RemoveToken();
                return of().pipe(map(()=> logoutOrganizationSuccess()));
            })
        )
}, {
    functional: true
});