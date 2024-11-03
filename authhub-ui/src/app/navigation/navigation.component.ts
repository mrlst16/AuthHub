import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Token } from '../models/Token';
import { Store } from '@ngrx/store';
import { tokenSelector } from '../store/organization/organization.selectors';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {
  token$: Observable<Token | null>;
  
  constructor(private readonly store: Store){
    this.token$ = this.store.select(tokenSelector);
  }
}
