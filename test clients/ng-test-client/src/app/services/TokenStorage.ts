import { Claim } from "../models/claims/Claim";
import { Token } from "../models/Token";

let TokenStorageMethod: "local" | "session" = "local"
const StorageTokenName: string = "";

export function SetTokenStorageMethod(method: "local"| "session"){
    TokenStorageMethod = method;
}

export function GetToken(): Token{
    let json: string| null = null;
    switch(TokenStorageMethod){
        case "local":
            json = localStorage.getItem(StorageTokenName);
            break;
        case "session":
            json = sessionStorage.getItem(StorageTokenName);
            break;
    }
    return JSON.parse(json as string);
}

export function SetToken(token: Token): void{
    switch(TokenStorageMethod){
        case "local":
            localStorage.setItem(StorageTokenName, JSON.stringify(token))
            break;
        case "session":
            sessionStorage.setItem(StorageTokenName, JSON.stringify(token))
    }
}

export function IsLoggedIn(): boolean{
    return GetToken() != null
}

//Based on the answer here (Green Checkmark): https://stackoverflow.com/questions/38552003/how-to-decode-jwt-token-in-javascript-without-using-a-library
export function GetClaims () {
    let result: Claim[] = [];
    
    let storedToken: Token = GetToken();
    if(storedToken == null) return result;

    let token: string = storedToken.Value as string;
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    let payload = JSON.parse(jsonPayload);
    Object.keys(payload).forEach(key=> {
        let claim: Claim = new Claim();
        claim.Name = key;
        claim.Value = payload[key];
        result.push(claim);
      });
    return result;
  }