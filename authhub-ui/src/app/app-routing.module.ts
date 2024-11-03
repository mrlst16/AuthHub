import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { ApiKeysComponent } from './api-keys/api-keys.component';

const routes: Routes = [
  { path: "register", component: RegistrationComponent},
  { path: "login", component: LoginComponent},
  { path: "api-keys", component: ApiKeysComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
