export class OrganizationLoginRequest{
    Name: string | null | undefined;
    Password: string | null | undefined;

    constructor(init?: Partial<OrganizationLoginRequest>){
        Object.assign(this, init)
    }
}