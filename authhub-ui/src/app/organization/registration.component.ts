import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { CreateOrganizationRequest } from '../models/requests/CreateOrganizationRequest';
import { registerOrganization } from '../store/organization/organization.actions';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {

  form = this.formBuilder.group({
    Name: ['', Validators.required],
    Password: ['', Validators.required],
    ConfirmPassword: ['', Validators.required],
    Email: ['', Validators.required]
  })

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly store: Store
  ){
    
  }

  onSubmit(){
    console.log(this.form)
    let createOrganizationReqest: CreateOrganizationRequest = new CreateOrganizationRequest(this.form.value)
    console.log("createOrganizationReqest", createOrganizationReqest);
    this.store.dispatch(registerOrganization({request: createOrganizationReqest}));
  }
}
