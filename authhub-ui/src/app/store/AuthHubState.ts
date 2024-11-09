import { ApiKey } from "../models/ApiKey";
import { AuthSettings } from "../models/AuthSettings";
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
    AuthSettings?: AuthSettings
}

export const initalState: AuthHubState = {
    
}