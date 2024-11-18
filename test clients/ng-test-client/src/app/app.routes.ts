import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ClaimsDemoComponent } from './claims-demo/claims-demo.component';
import { isLoggedInActivate } from './guards/LoginGuard';
import { AboutComponent } from './about/about.component';

export const routes: Routes = [
    {path: '', component: AboutComponent},
    {path: 'claims_demo', component: ClaimsDemoComponent, canActivate:[isLoggedInActivate]}
];
