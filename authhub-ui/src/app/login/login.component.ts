import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { OrganizationLoginRequest } from '../models/requests/OrganizationLoginRequest';
import { loginOrganization } from '../store/organization/organization.actions';
import { Observable } from 'rxjs';
import { Token } from '../models/Token';
import { AuthHubState } from '../store/AuthHubState';
import { tokenSelector } from '../store/organization/organization.selectors';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  form = this.formBuilder.group({
    Name: ['', Validators.required],
    Password: ['', Validators.required]
  })

  token$: Observable<Token>;

  constructor(
    private formBuilder: FormBuilder,
    private store: Store
  ){
    this.token$ = this.store.select(tokenSelector)
  }

  onSubmit(){
    let request: OrganizationLoginRequest = new OrganizationLoginRequest(this.form.value)
    this.store.dispatch(loginOrganization({request: request}))
  }
}