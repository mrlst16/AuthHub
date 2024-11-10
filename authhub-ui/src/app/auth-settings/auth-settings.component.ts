import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthSettings } from '../models/AuthSettings';
import { Store } from '@ngrx/store';
import { authSettingsSelector } from '../store/auth-settings/auth-settings.selectors';
import { getAuthSettings } from '../store/auth-settings/auth-settings.actions';
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
    saltLength: false
  }

  form = this.fb.group({
    key: ['', Validators.required],
    issuer: ['', Validators.required],
    audience: ['', Validators.required],
    expirationMinutes: [0, Validators.required],
    hashLength: [0, Validators.required],
    saltLength: [0, Validators.required]
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
        key: x.Key,
        issuer: x.Issuer,
        audience: x.Audience,
        expirationMinutes: x.ExpirationMinutes,
        hashLength: x.HashLength,
        saltLength: x.SaltLength
      })
    })
  }

  saveAuthSettings(){
    

    //Trun edit mode off for every field
    this.editing.key = false;
    this.editing.issuer = false;
    this.editing.audience = false;
    this.editing.expirationMinutes = false;
    this.editing.hashLength = false;
    this.editing.saltLength = false;
  }
}
