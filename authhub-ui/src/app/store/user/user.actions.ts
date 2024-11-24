import { createAction, props } from "@ngrx/store";
import { ResetPasswordRequest } from "src/app/models/requests/ResetPasswordRequest";

export const resetUserPassword = createAction("[User] Reset Password", props<{request: ResetPasswordRequest}>());
export const resetUserPasswordSuccess = createAction("[User] Reset Password Success", props<{response: boolean}>());
export const resetUserPasswordError = createAction("[User] Reset Password Error");