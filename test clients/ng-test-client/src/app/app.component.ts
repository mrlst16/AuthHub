import { Component, InjectionToken } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthhubLoginComponent } from './authhub-login/authhub-login.component';
import { CommonModule } from '@angular/common';
import { NavigationComponent } from './navigation/navigation.component';
import { provideAuthHubServiceFromEnvironment } from './providers/authHubServiceProviders';
import { environment } from '../environments/environment';

let loginRedirectUrlToken: InjectionToken<string> = new InjectionToken("loginUrl")

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  standalone: true,
  imports: [CommonModule, RouterOutlet, AuthhubLoginComponent, NavigationComponent],
  providers: [
    {provide: loginRedirectUrlToken, useValue:""},
    provideAuthHubServiceFromEnvironment(environment)
  ]
})
export class AppComponent {
  title = 'AuthHub Demo';
  mode: "dev" | "prod" = "dev"
  showStuff: boolean = false;
  stuffMessage?: string;

  ngOnInit(){
    
  }

  onLogin(){
    this.showStuff = true;
    this.stuffMessage = "onLogin";

    let self = this;
    setTimeout(function(){
      self.showStuff = false
    }, 2000)
  }

  onLogout(){
    this.showStuff = true;
    this.stuffMessage = "onLogout";

    let self = this;
    setTimeout(function(){
      self.showStuff = false
    }, 2000)
  }
}