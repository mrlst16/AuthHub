export class CreateOrganizationRequest{
    Name: string | null | undefined;
    Password: string | null | undefined;
    ConfirmPassword: string | null | undefined;
    Email: string | null | undefined;

    constructor(init?: Partial<CreateOrganizationRequest>){
        Object.assign(this, init)
    }
}