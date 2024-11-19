import { Claim } from "./Claim";

export class AddClaimsRequest{
    UserId?: number;
    Claims?: Claim[];
}