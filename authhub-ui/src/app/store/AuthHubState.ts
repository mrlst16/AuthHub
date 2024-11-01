import { Organization } from "../models/Organization";
import { Token } from "../models/Token";

export class AuthHubState{
    Organization?: Organization
    Token? : Token
}

export const initalState: AuthHubState = {
    
}