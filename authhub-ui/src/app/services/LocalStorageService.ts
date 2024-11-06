
import { Injectable } from "@angular/core";

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

    Remove(key: string){
        localStorage.removeItem(key);
    }
}