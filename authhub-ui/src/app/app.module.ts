import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './registration/registration.component';
import { NavigationComponent } from './navigation/navigation.component';
import { ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { provideHttpClient } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { ApiKeysComponent } from './api-keys/api-keys.component';
import { ClaimsTemplateListComponent } from './claims-template-list/claims-template-list.component';
import { ClaimsTemplateComponent } from './claims-template/claims-template.component';
import { RouterLink } from '@angular/router';
import { AuthSettingsComponent } from './auth-settings/auth-settings.component';

//Reducers
import { organizationReducer } from './store/organization/organization.reducers';
import { apiKeyReducer } from './store/apikey/apikey.reducer';
import { claimsReducer } from './store/claims/claims.reducers';
import { authSettingsReducer } from './store/auth-settings/auth-settings.reducers';

//Effects
import * as organizationEffects from './store/organization/organization.effects';
import * as apiKeyEffects from './store/apikey/apikeys.effects'
import * as claimsEffects from './store/claims/claims.effects'
import * as authSettingsEffects from './store/auth-settings/auth-settings.effects'
import * as userEffects from './store/user/user.effects'
import { ResetUserPasswordComponent } from './reset-user-password/reset-user-password.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    RegistrationComponent,
    LoginComponent,
    ApiKeysComponent,
    ClaimsTemplateListComponent,
    ClaimsTemplateComponent,
    AuthSettingsComponent,
    ResetUserPasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterLink,
    ReactiveFormsModule,
    StoreModule.forRoot(
      {
        organization: organizationReducer, 
        apikey: apiKeyReducer,
        claims: claimsReducer,
        authSettings: authSettingsReducer
      },
    ),
    EffectsModule.forRoot(organizationEffects, apiKeyEffects, claimsEffects, authSettingsEffects, userEffects)
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }