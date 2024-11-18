import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { IsLoggedIn } from "../services/AuthHubService";


export const isLoggedInActivate: CanActivateFn = (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,
  ) => {
    let router = inject(Router);
    let result: boolean = IsLoggedIn();
    if(!result)
        router.navigate([""])
    return result;
  };