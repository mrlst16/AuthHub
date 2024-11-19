import { Provider } from "@angular/core";
import { AuthHubService } from "../services/AuthHubService";
import { HttpClient } from "@angular/common/http";

export function provideAuthHubService (
    mode: "dev" | "prod",
    organizationId: number,
    apiKey: string,
    apiSecret: string
) 
    :Provider
{
    return {
        provide: AuthHubService,
        useFactory: (http: HttpClient)=> new AuthHubService(http, mode, organizationId, apiKey, apiSecret), 
        deps:[HttpClient]
      }
}

export function provideAuthHubServiceFromEnvironment(environment: any){
    return provideAuthHubService(environment.mode, environment.organizationId, environment.apiKey, environment.apiSecret);
}