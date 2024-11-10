import { Actions, createEffect, ofType } from "@ngrx/effects";
import { getAuthSettings, getAuthSettingsSuccess, saveAuthSettings } from "./auth-settings.actions";
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


export const saveAuthSettingsEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(AuthSettingsService)
    )=> {
        return actions$.pipe(
            ofType(saveAuthSettings),
            exhaustMap(({request})=> {
                return service.SaveAuthSettings(request).pipe(
                    map((response)=> {
                        return getAuthSettings()
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});