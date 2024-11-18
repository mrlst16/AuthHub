import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, GuardResult, MaybeAsync, Router, RouterStateSnapshot } from "@angular/router";
import { AuthenticationService } from "../services/AuthenticationService";

@Injectable({
    providedIn: 'root'
})
export class LoginActivate implements CanActivate{

    constructor(
        private readonly authService: AuthenticationService,
        private readonly router: Router
    ){
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): MaybeAsync<GuardResult> {
        if(!this.authService.IsLoggeedIn()){
            this.router.navigate(["login"]);
        }
        return true;
    }

}