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

//Reducers
import { organizationReducer } from './store/organization/organization.reducers';
import { apiKeyReducer } from './store/apikey/apikey.reducer';
import { claimsReducer } from './store/claims/claims.reducers';
//Effects
import * as organizationEffects from './store/organization/organization.effects';
import * as apiKeyEffects from './store/apikey/apikeys.effects'
import * as claimsEffects from './store/claims/claims.effects'

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    RegistrationComponent,
    LoginComponent,
    ApiKeysComponent,
    ClaimsTemplateListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    StoreModule.forRoot(
      {
        organization: organizationReducer, 
        apikey: apiKeyReducer,
        claims: claimsReducer
      },
    ),
    EffectsModule.forRoot(organizationEffects, apiKeyEffects, claimsEffects)
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }