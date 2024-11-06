export class AddClaimsTemplateRequest{
    Name: string | null | undefined
    Description: string | null | undefined

    constructor(init?:Partial<AddClaimsTemplateRequest>){
        Object.assign(this, init);
    }
}