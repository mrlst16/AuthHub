import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AuthHubService } from '../services/AuthHubService';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-authhub-login',
  templateUrl: './authhub-login.component.html',
  styleUrl: './authhub-login.component.scss',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule]
})
export class AuthhubLoginComponent {

  @Input("organization-id") organizationId?: number;
  @Input("api-key") apiKey?: string;
  @Input("api-secret") apiSecret?: string;
  @Input("mode") mode : "dev" | "prod" = "prod";

  @Input("storage") storage: "local" | "none" = "local";

  @Output("onLogin") onLogin: EventEmitter<any> = new EventEmitter<any>();
  @Output("onLogout") onLogoout: EventEmitter<any> = new EventEmitter<any>();

  service?: AuthHubService;
  showForm: boolean = false;
  loggedIn: boolean = false;

  form = this.fb.group({
    Username: ['', Validators.required],
    Password: ['', Validators.required]
  });
  
  constructor(
    private readonly http: HttpClient,
    private readonly fb: FormBuilder,
  ){}

  ngOnInit(){
    this.service = new AuthHubService(this.http, this.mode, this.organizationId as number, this.apiKey as string, this.apiSecret as string)
    this.loggedIn = this.service.IsLoggedIn()
  }

  login(){
    this.service?.Login(
      this.form.value.Username as string, 
      this.form.value.Password as string
    )
    .subscribe(x=> {
      this.service?.SetToken(x);
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
