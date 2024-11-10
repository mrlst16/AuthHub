import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthSettings } from '../models/AuthSettings';
import { Store } from '@ngrx/store';
import { authSettingsSelector } from '../store/auth-settings/auth-settings.selectors';
import { getAuthSettings, saveAuthSettings } from '../store/auth-settings/auth-settings.actions';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth-settings',
  templateUrl: './auth-settings.component.html',
  styleUrl: './auth-settings.component.scss'
})
export class AuthSettingsComponent {
  authSettings$: Observable<AuthSettings> = new Observable<AuthSettings>();
  editing = {
    key: false,
    issuer: false,
    audience: false,
    expirationMinutes: false,
    hashLength: false,
    saltLength: false,
    iterations: false
  }

  form = this.fb.group({
    Key: ['', Validators.required],
    Issuer: ['', Validators.required],
    Audience: ['', Validators.required],
    ExpirationMinutes: [0, Validators.required],
    HashLength: [0, Validators.required],
    SaltLength: [0, Validators.required],
    Iterations: [0, Validators.required]
  });

  constructor(
    private readonly fb: FormBuilder,
    private readonly store: Store
  ){
    this.authSettings$ = this.store.select(authSettingsSelector)
  }

  ngOnInit(){
    this.store.dispatch(getAuthSettings())
    this.authSettings$?.subscribe(x=> {
      if(!x) return;

      this.form.patchValue({
        Key: x.Key,
        Issuer: x.Issuer,
        Audience: x.Audience,
        ExpirationMinutes: x.ExpirationMinutes,
        HashLength: x.HashLength,
        SaltLength: x.SaltLength,
        Iterations: x.Iterations
      })
    })
  }

  saveAuthSettings(){
    
    let request: AuthSettings = new AuthSettings(this.form.value);

    //Trun edit mode off for every field
    this.editing.key = false;
    this.editing.issuer = false;
    this.editing.audience = false;
    this.editing.expirationMinutes = false;
    this.editing.hashLength = false;
    this.editing.saltLength = false;
    this.editing.iterations = false;

    this.store.dispatch(saveAuthSettings({request: request}))
  }
}