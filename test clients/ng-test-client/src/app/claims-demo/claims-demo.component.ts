import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthHubService, GetToken, SetToken } from '../services/AuthHubService';
import { Token } from '../models/Token';
import { AddClaimsRequest } from '../models/claims/AddClaimsRequest';
import { Claim } from '../models/claims/Claim';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RemoveClaimsRequest } from '../models/claims/RemoveClaimsRequest';

@Component({
  selector: 'app-claims-demo',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './claims-demo.component.html',
  styleUrl: './claims-demo.component.scss'
})
export class ClaimsDemoComponent {

  tab = "";

  form = this.fb.group({
    name: ['', Validators.required],
    value: ['']
  })

  token?: Token;

  claims: Claim[] = [];

  constructor(
    private readonly fb: FormBuilder,
    private readonly service: AuthHubService,
    private readonly http: HttpClient
  ){
  }

  ngOnInit(){
    this.token = GetToken();
    this.getClaims();
  }

  setTab(tab: string){
    this.tab = tab;
    
  }

  private getClaimsFromForm(): Claim[] {
    let result: Claim[] = [];
    let newClaim: Claim = new Claim();
    newClaim.Name = this.form.value.name as string;
    newClaim.Value = this.form.value.value as string;
    result.push(newClaim);
    return result;
  }

  addFromClient(){
    let request: AddClaimsRequest = new AddClaimsRequest();
    request.UserId = this.token?.UserId;
    request.Claims = this.getClaimsFromForm();
    this.service.AddClaims(request).subscribe(res=> {
      this.service.RefreshToken().subscribe(x=> {
        SetToken(x);
        this.getClaims();
      });
    });
  }

  removeFromClient(){
    let request: RemoveClaimsRequest = new RemoveClaimsRequest();
    request.ClaimsKeys = [];
    request.ClaimsKeys.push(this.form.value.name as string);
    this.service.RemoveClaims(request).subscribe(res=> {
      this.service.RefreshToken().subscribe(x=> {
        SetToken(x);
        this.getClaims();
      });
    });
  }

  getClaims(){
    let headers: HttpHeaders = this.service.AuthorizationHeaders();
    console.log("headers", headers);
    this.http.get<Claim[]>("https://localhost:7201/api/claimsdemo", 
        {headers: headers}
      )
      .subscribe(x=> this.claims = x);
  }
}