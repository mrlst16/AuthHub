import { inject } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { ClaimsService } from "src/app/services/ClaimsService";
import { addClaimsKey, addClaimsKeySuccess, addClaimsTemplate, addClaimsTemplateSuccess, getClaimsTemplate, getClaimsTemplates, getClaimsTemplatesSuccess, getClaimsTemplateSuccess, removeClaimsKey, removeClaimsKeySuccess } from "./claims.actions";
import { exhaustMap, map } from "rxjs";
import { ClaimsTemplateListItem } from "src/app/models/ClaimsTemplateListItem";
import { ClaimsTemplate } from "src/app/models/ClaimsTemplate";

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
                        return getClaimsTemplatesSuccess({response: response.Data as ClaimsTemplateListItem[]})
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

export const getClaimsTemplateEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ClaimsService)
    )=> {
        return actions$.pipe(
            ofType(getClaimsTemplate),
            exhaustMap(({name})=> {
                return service.GetClaimsTemplate(name).pipe(
                    map((response)=> {
                        return getClaimsTemplateSuccess({response: response.Data as ClaimsTemplate})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});


export const addClaimsKeyEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ClaimsService)
    )=> {
        return actions$.pipe(
            ofType(addClaimsKey),
            exhaustMap(({request})=> {
                return service.AddClaimsKey(request).pipe(
                    map((response)=> {
                        return addClaimsKeySuccess({templateName: request.TemplateName as string})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});

export const addClaimsKeySuccessEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ClaimsService)
    )=> {
        return actions$.pipe(
            ofType(addClaimsKeySuccess),
            exhaustMap(({templateName})=> {
                return service.GetClaimsTemplate(templateName).pipe(
                    map((response)=> {
                        return getClaimsTemplateSuccess({response: response.Data as ClaimsTemplate})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});


export const removeClaimsKeySuccessEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ClaimsService)
    )=> {
        return actions$.pipe(
            ofType(removeClaimsKeySuccess),
            exhaustMap(({templateName})=> {
                return service.GetClaimsTemplate(templateName).pipe(
                    map((response)=> {
                        return getClaimsTemplateSuccess({response: response.Data as ClaimsTemplate})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});


export const removeClaimsKeyEffect = createEffect(
    (
        actions$ = inject(Actions),
        service = inject(ClaimsService)
    )=> {
        return actions$.pipe(
            ofType(removeClaimsKey),
            exhaustMap(({request})=> {
                return service.RemoveClaimsKey(request).pipe(
                    map((response)=> {
                        return removeClaimsKeySuccess({templateName: request.TemplateName as string})
                    }),
                    // catchError(({error})=> registerOrganizationError(error))
                )
            })
        )
}, {
    functional: true
});