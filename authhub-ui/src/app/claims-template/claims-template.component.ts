import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { addClaimsKey, getClaimsTemplate, removeClaimsKey } from '../store/claims/claims.actions';
import { Observable } from 'rxjs';
import { ClaimsTemplate } from '../models/ClaimsTemplate';
import { claimsTemplateKeysSelector, claimsTemplateSelector } from '../store/claims/claims.selectors';
import { ClaimsKey } from '../models/ClaimsKey';
import { FormBuilder, Validators } from '@angular/forms';
import { AddClaimsKeysRequest } from '../models/requests/AddClaimsKeysRequest';
import { RemoveClaimsKeysRequest } from '../models/requests/RemoveClaimsKeysRequest';

@Component({
  selector: 'app-claims-template',
  templateUrl: './claims-template.component.html',
  styleUrl: './claims-template.component.scss'
})
export class ClaimsTemplateComponent {
  //Component Input
  name: string | null = null;

  //Forms
  form = this.formBuilder.group({
    name: ['', Validators.required],
    defaultValue: ['']
  });

  //Observables
  template$: Observable<ClaimsTemplate>;
  keys$: Observable<ClaimsKey[]>

  constructor(
    private readonly route: ActivatedRoute,
    private readonly store: Store,
    private readonly formBuilder: FormBuilder
  ){
    this.template$ = this.store.select(claimsTemplateSelector)
    this.keys$ = this.store.select(claimsTemplateKeysSelector)
  }

  ngOnInit(){
    this.name = this.route.snapshot.paramMap.get('name')
    this.store.dispatch(getClaimsTemplate({name: this.name as string}))
  }

  addClaimsKey(){
    let key: ClaimsKey = new ClaimsKey();
    key.Name = this.form.value.name as string
    key.DefaultValue = this.form.value.defaultValue as string
    let request: AddClaimsKeysRequest = new AddClaimsKeysRequest();
    request.TemplateName = this.name as string
    request.Keys = [key]
    this.store.dispatch(addClaimsKey({request: request}))
  }

  removeClaimsKey(name: string | undefined){
    if(name == undefined) return;

    let request: RemoveClaimsKeysRequest = new RemoveClaimsKeysRequest();
    request.TemplateName = this.name as string;
    request.KeyNames = [name]
    
    this.store.dispatch(removeClaimsKey({request: request}));
  }
}