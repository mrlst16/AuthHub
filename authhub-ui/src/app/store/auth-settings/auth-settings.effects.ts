import { Actions, createEffect, ofType } from "@ngrx/effects";
import { getAuthSettings, getAuthSettingsSuccess } from "./auth-settings.actions";
import { inject } from "@angular/core";
import { exhaustMap, map } from "rxjs";
import { AuthSettingsService } from "src/app/services/AuthSettingsService";
import { AuthSettings } from "src/app/models/AuthSettings";


export const getAuthSettingsEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(AuthSettingsService)
    )=> {
        return actions$.pipe(
            ofType(getAuthSettings),
            exhaustMap(()=> {
                return service.GetAuthSettings().pipe(
                    map((response)=> {
                        return getAuthSettingsSuccess({response: response.Data as AuthSettings})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});