
export class ResetPasswordRequest{
    UserId: number | null | undefined;
    Password: string | null | undefined;
    ConfirmPassword: string | null | undefined;
    VerificationCode: string | null | undefined;

    constructor(init?: Partial<ResetPasswordRequest>){
        Object.assign(this, init)
    }
}