import { inject } from "@angular/core";
import { createEffect, Actions, ofType } from "@ngrx/effects";
import { exhaustMap, map } from "rxjs";
import { ApiKeysService } from "src/app/services/ApiKeysService";
import { generateApiKey, generateApiKeySuccess } from "./apikey.actions";
import { ApiKey } from "src/app/models/ApiKey";

export const generateApiKeyEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ApiKeysService)
    )=> {
        return actions$.pipe(
            ofType(generateApiKey),
            exhaustMap(()=> {
                return service.GenerateApiKey().pipe(
                    map((response)=> {
                        console.log("Effect")
                        return generateApiKeySuccess({response: response.Data as ApiKey})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});