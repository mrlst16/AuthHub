import { NgModule } from '@angular/core';
import { provideRouter, RouterModule, Routes, withComponentInputBinding } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { ApiKeysComponent } from './api-keys/api-keys.component';
import { ClaimsTemplateListComponent } from './claims-template-list/claims-template-list.component';
import { ClaimsTemplateComponent } from './claims-template/claims-template.component';

const routes: Routes = [
  { path: "register", component: RegistrationComponent},
  { path: "login", component: LoginComponent},
  { path: "api-keys", component: ApiKeysComponent},
  { path: "claims-templates", component: ClaimsTemplateListComponent},
  { path: "claims-template/:name", component: ClaimsTemplateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [provideRouter(routes, withComponentInputBinding())]
})
export class AppRoutingModule { }
