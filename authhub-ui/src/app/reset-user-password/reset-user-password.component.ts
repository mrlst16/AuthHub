import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { ResetPasswordRequest } from '../models/requests/ResetPasswordRequest';
import { ActivatedRoute } from '@angular/router';
import { resetUserPassword } from '../store/user/user.actions';

@Component({
  selector: 'app-reset-user-password',
  templateUrl: './reset-user-password.component.html',
  styleUrl: './reset-user-password.component.scss'
})
export class ResetUserPasswordComponent {

  form = this.fb.group({
    Password: ['', Validators.required],
    ConfirmPassword: ['', Validators.required]
  });

  userId?: number;
  verificationCode?: string;

  constructor(
    private readonly fb: FormBuilder,
    private readonly store: Store,
    private readonly activatedRoute: ActivatedRoute
  ){
  }

  ngOnInit(){
    this.activatedRoute.queryParams.subscribe(params => {
      this.userId = params["userid"]
      this.verificationCode = params["verificationCode"]
    });
  }

  onSubmit(){
    let request: ResetPasswordRequest = new ResetPasswordRequest();
    request.Password = this.form.value.Password;
    request.ConfirmPassword = this.form.value.ConfirmPassword;
    request.UserId = this.userId;
    request.VerificationCode = this.verificationCode;
    this.store.dispatch(resetUserPassword({request: request}))
  }
}
