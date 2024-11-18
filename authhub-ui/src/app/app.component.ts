import { Component } from '@angular/core';
import { AuthenticationService } from './services/AuthenticationService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'authhub-ui';

  constructor(
    private readonly authService: AuthenticationService,
    private readonly router: Router
  ){
    
  }
}