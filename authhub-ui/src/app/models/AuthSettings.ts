import { AuthSchemeEnum } from "./AuthSchemeEnum";

export class AuthSettings {
    Id?: number; // Assuming EntityBase<int> translates to an `id` property
    Name?: string;
    AuthScheme?: AuthSchemeEnum; // Ensure AuthScheme is defined elsewhere
    SaltLength?: number;
    HashLength?: number;
    Iterations?: number;
    Key?: string; // You might want to handle MinLength validation in your forms
    Issuer?: string;
    Audience?: string;
    ExpirationMinutes?: number; // Optional property with default value
    PasswordResetTokenExpirationMinutes?: number; // Optional property with default value
    PasswordResetFormUrl?: string;
    RequireVerification?: boolean; // Optional property with default value

    constructor(init?: Partial<AuthSettings>){
        Object.assign(this, init);
        //TODO: this is hardcoded and probably bad practice, but let's just do it for now
        this.AuthScheme = AuthSchemeEnum.JWT;
    }
}