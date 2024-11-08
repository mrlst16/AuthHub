import { ApiKey } from "../models/ApiKey";
import { ClaimsKey } from "../models/ClaimsKey";
import { ClaimsTemplate } from "../models/ClaimsTemplate";
import { ClaimsTemplateListItem } from "../models/ClaimsTemplateListItem";
import { Organization } from "../models/Organization";
import { Token } from "../models/Token";

export class AuthHubState{
    Organization?: Organization
    Token?: Token
    Key?: ApiKey
    ClaimsTemplates?: ClaimsTemplateListItem[]
    ClaimsTemplate?: ClaimsTemplate
}

export const initalState: AuthHubState = {
    
}