import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthSettings } from '../models/AuthSettings';
import { Store } from '@ngrx/store';
import { authSettingsSelector } from '../store/auth-settings/auth-settings.selectors';
import { getAuthSettings } from '../store/auth-settings/auth-settings.actions';

@Component({
  selector: 'app-auth-settings',
  templateUrl: './auth-settings.component.html',
  styleUrl: './auth-settings.component.scss'
})
export class AuthSettingsComponent {
  authSettings$: Observable<AuthSettings>;

  constructor(
    private readonly store: Store
  ){
    this.authSettings$ = this.store.select(authSettingsSelector)
  }

  ngOnInit(){
    this.store.dispatch(getAuthSettings())
  }
}
