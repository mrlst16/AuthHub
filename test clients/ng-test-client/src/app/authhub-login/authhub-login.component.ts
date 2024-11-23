import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AuthHubService } from '../services/AuthHubService';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IsLoggedIn, SetToken } from '../services/TokenStorage';

@Component({
  selector: 'app-authhub-login',
  templateUrl: './authhub-login.component.html',
  styleUrl: './authhub-login.component.scss',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule]
})
export class AuthhubLoginComponent {

  @Output("onLogin") onLogin: EventEmitter<any> = new EventEmitter<any>();
  @Output("onLogout") onLogoout: EventEmitter<any> = new EventEmitter<any>();

  showForm: boolean = false;
  loggedIn: boolean = false;

  form = this.fb.group({
    Username: ['', Validators.required],
    Password: ['', Validators.required]
  });
  
  constructor(
    private readonly http: HttpClient,
    private readonly fb: FormBuilder,
    private readonly service: AuthHubService
  ){}

  ngOnInit(){
    this.loggedIn = IsLoggedIn()
  }

  login(){
    this.service?.Login(
      this.form.value.Username as string, 
      this.form.value.Password as string
    )
    .subscribe(x=> {
      SetToken(x);
      this.loggedIn = true;
      this.onLogin.emit();
    });
  }

  logout(){
    this.service?.Logout();
    this.loggedIn = false;
    this.onLogoout.emit();
  }
}
