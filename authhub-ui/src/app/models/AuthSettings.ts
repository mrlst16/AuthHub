import { AuthSchemeEnum } from "./AuthSchemeEnum";
import { ClaimsKey } from "./ClaimsKey";

export interface AuthSettings {
    id: number; // Assuming EntityBase<int> translates to an `id` property
    name: string;
    organizationId: number;
    authScheme: AuthSchemeEnum; // Ensure AuthScheme is defined elsewhere
    authSchemeId: number;
    saltLength: number;
    hashLength: number;
    iterations: number;
    key: string; // You might want to handle MinLength validation in your forms
    issuer: string;
    audience: string;
    expirationMinutes?: number; // Optional property with default value
    availableClaimsKeys?: ClaimsKey[]; // Ensure ClaimsKey is defined elsewhere
    passwordResetTokenExpirationMinutes?: number; // Optional property with default value
    passwordResetFormUrl?: string;
    requireVerification?: boolean; // Optional property with default value
}