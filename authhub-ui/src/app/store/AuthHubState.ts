import { ApiKey } from "../models/ApiKey";
import { ClaimesTemplateListItem } from "../models/ClaimsTemplateListItem";
import { Organization } from "../models/Organization";
import { Token } from "../models/Token";

export class AuthHubState{
    Organization?: Organization
    Token? : Token
    Key? : ApiKey
    ClaimsTemplates?: ClaimesTemplateListItem[]
}

export const initalState: AuthHubState = {
    
}