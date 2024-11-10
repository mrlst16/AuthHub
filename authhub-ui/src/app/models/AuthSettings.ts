import { AuthSchemeEnum } from "./AuthSchemeEnum";

export class AuthSettings {
    Id: number | null | undefined; // Assuming EntityBase<int> translates to an `id` property
    Name: string | null | undefined;
    AuthScheme: AuthSchemeEnum | null | undefined; // Ensure AuthScheme is defined elsewhere
    SaltLength: number | null | undefined;
    HashLength: number | null | undefined;
    Iterations: number | null | undefined;
    Key: string | null | undefined; // You might want to handle MinLength validation in your forms
    Issuer: string | null | undefined;
    Audience: string | null | undefined;
    ExpirationMinutes: number | null | undefined; // Optional property with default value

    constructor(init?: Partial<AuthSettings>){
        Object.assign(this, init);
        //TODO: this is hardcoded and probably bad practice, but let's just do it for now
        this.AuthScheme = AuthSchemeEnum.JWT;
    }
}