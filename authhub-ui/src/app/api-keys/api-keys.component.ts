import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiKey } from '../models/ApiKey';
import { Store } from '@ngrx/store';
import { apiKeySelector } from '../store/apikey/apikey.selectors';
import { generateApiKey } from '../store/apikey/apikey.actions';

@Component({
  selector: 'app-api-keys',
  standalone: false,
  templateUrl: './api-keys.component.html',
  styleUrl: './api-keys.component.scss'
})
export class ApiKeysComponent {

  key$: Observable<ApiKey>;

  constructor(
    private readonly store: Store
  ){
    this.key$ = this.store.select(apiKeySelector);
  }

  generate(){
    console.log("generate")
    this.store.dispatch(generateApiKey())
  }
}