import { inject } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { exhaustMap, map } from "rxjs";
import { UserService } from "src/app/services/UserService";
import { resetUserPassword, resetUserPasswordSuccess } from "./user.actions";

export const resetUserPasswordEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(UserService)
    )=> {
        return actions$.pipe(
            ofType(resetUserPassword),
            exhaustMap(({request})=> {
                return service.resetPassword(request).pipe(
                    map((response)=> {
                        return resetUserPasswordSuccess({response: response.Data as boolean})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});
