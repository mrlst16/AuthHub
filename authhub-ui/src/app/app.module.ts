import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './registration/registration.component';
import { NavigationComponent } from './navigation/navigation.component';
import { ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import * as organizationEffects from './store/organization/organization.effects';
import { organizationReducer } from './store/organization/organization.reducers';
import { provideHttpClient } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { apiKeyReducer } from './store/apikey/apikey.reducer';
import { ApiKeysComponent } from './api-keys/api-keys.component';
import * as apiKeyEffects from './store/apikey/apikeys.effects'

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    RegistrationComponent,
    LoginComponent,
    ApiKeysComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    StoreModule.forRoot(
      {
        organization: organizationReducer, 
        apikey: apiKeyReducer
      },
    ),
    EffectsModule.forRoot(organizationEffects, apiKeyEffects)
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }