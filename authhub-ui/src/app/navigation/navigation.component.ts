import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Token } from '../models/Token';
import { Store } from '@ngrx/store';
import { tokenSelector } from '../store/organization/organization.selectors';
import { logoutOrganization } from '../store/organization/organization.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {
  token$: Observable<Token | null>;
  
  constructor(
    private readonly store: Store,
    private readonly router: Router
  ){
    this.token$ = this.store.select(tokenSelector);
  }

  logout(){
    console.log("logout")
    this.store.dispatch(logoutOrganization())
    this.router.navigateByUrl("/")
  }
}
