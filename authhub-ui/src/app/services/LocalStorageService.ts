
import { Injectable } from "@angular/core";
import { Token } from "../models/Token";

@Injectable({
    providedIn: 'root'
})
export class LocalStorageService {
    Save<T>(key: string, object: T | any){
        localStorage.setItem(key, JSON.stringify(object))
    }

    Get<T>(key: string): T | null{
        const json: string | null = localStorage.getItem(key);
        if(json == null)
            return null;
        return JSON.parse(json) as T;
    }

    SaveToken(token: Token){
        this.Save("token", token);
    }

    GetToken() : Token | null{
        return this.Get("token");
    }
}