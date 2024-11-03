import { ApiKey } from "../models/ApiKey";
import { Organization } from "../models/Organization";
import { Token } from "../models/Token";

export class AuthHubState{
    Organization?: Organization
    Token? : Token
    Key? : ApiKey
}

export const initalState: AuthHubState = {
    
}