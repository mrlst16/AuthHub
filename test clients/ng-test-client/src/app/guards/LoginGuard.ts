import { inject } from "@angular/core";
import { AuthHubService } from "../services/AuthHubService";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";


export const isLoggedInActivate: CanActivateFn = (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,
  ) => {
    return true;
    // let service = inject(AuthHubService);
    // let router = inject(Router);
    // let result: boolean = service.IsLoggedIn();
    // if(!result)
    //     router.navigate([""])
    // return result;
    //.canActivate(inject(UserToken), route.params['id']);
  };