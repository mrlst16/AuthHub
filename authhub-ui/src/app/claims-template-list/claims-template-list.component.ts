import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { claimsTemplateSelector } from '../store/claims/claims.selectors';
import { ClaimesTemplateListItem } from '../models/ClaimsTemplateListItem';
import { FormBuilder, Validators } from '@angular/forms';
import { AddClaimsTemplateRequest } from '../models/requests/AddClaimsTemplateRequest';
import { addClaimsTemplate, getClaimsTemplates } from '../store/claims/claims.actions';

@Component({
  selector: 'app-claims-template-list',
  templateUrl: './claims-template-list.component.html',
  styleUrl: './claims-template-list.component.scss'
})
export class ClaimsTemplateListComponent {

  templates$: Observable<ClaimesTemplateListItem[]>;
  form = this.formBuilder.group({
    Name: ['', Validators.required],
    Description: ['']
  })

  constructor(
    private readonly store: Store,
    private readonly formBuilder: FormBuilder
  ){
    this.templates$ = this.store.select(claimsTemplateSelector)
  }

  ngOnInit(){
    this.store.dispatch(getClaimsTemplates())
  }

  public addClaimsTemplate(){
    let request: AddClaimsTemplateRequest = new AddClaimsTemplateRequest(this.form.value)
    this.store.dispatch(addClaimsTemplate({request: request}))
  }
}