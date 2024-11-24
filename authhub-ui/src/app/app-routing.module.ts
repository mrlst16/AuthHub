import { NgModule } from '@angular/core';
import { provideRouter, RouterModule, Routes, withComponentInputBinding } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { ApiKeysComponent } from './api-keys/api-keys.component';
import { ClaimsTemplateListComponent } from './claims-template-list/claims-template-list.component';
import { ClaimsTemplateComponent } from './claims-template/claims-template.component';
import { AuthSettingsComponent } from './auth-settings/auth-settings.component';
import { LoginActivate } from './misc/LoginActivate';
import { ResetUserPasswordComponent } from './reset-user-password/reset-user-password.component';

const routes: Routes = [
  { path: "register", component: RegistrationComponent},
  { path: "login", component: LoginComponent},
  { path: "api-keys", component: ApiKeysComponent, canActivate: [LoginActivate]},
  { path: "claims-templates", component: ClaimsTemplateListComponent, canActivate: [LoginActivate]},
  { path: "claims-template/:name", component: ClaimsTemplateComponent, canActivate: [LoginActivate]},
  { path: "auth-settings", component: AuthSettingsComponent, canActivate: [LoginActivate]},
  { path: "reset-user-password", component: ResetUserPasswordComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [provideRouter(routes, withComponentInputBinding())]
})
export class AppRoutingModule { }
