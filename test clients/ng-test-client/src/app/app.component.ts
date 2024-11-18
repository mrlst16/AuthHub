import { Component, InjectionToken } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthhubLoginComponent } from './authhub-login/authhub-login.component';
import { CommonModule } from '@angular/common';
import { NavigationComponent } from './navigation/navigation.component';
import { environment } from '../environments/environment';
import { provideAuthHubService } from './providers/provideAuthHubService';

let loginRedirectUrlToken: InjectionToken<string> = new InjectionToken("loginUrl")

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  standalone: true,
  imports: [CommonModule, RouterOutlet, AuthhubLoginComponent, NavigationComponent],
  providers: [
    {provide: loginRedirectUrlToken, useValue:""},
    provideAuthHubService("dev", 2, "i6hmvzj54lwzom4e5d8nwlwtfr7bk77v9fjzb3iqhmrq5ug055jto4tyh5uqn41e", "yz8xey6qxo5o0wgmv5bg48oxhqlmmiy698homh2fx8n2ha4ry5chsjdol0dot2xw")
  ]
})
export class AppComponent {
  title = 'AuthHub Demo';
  mode: "dev" | "prod" = "dev"
  organizationId: number = 2
  apiKey: string = "i6hmvzj54lwzom4e5d8nwlwtfr7bk77v9fjzb3iqhmrq5ug055jto4tyh5uqn41e"
  apiSecret: string = "yz8xey6qxo5o0wgmv5bg48oxhqlmmiy698homh2fx8n2ha4ry5chsjdol0dot2xw"

  showStuff: boolean = false;
  stuffMessage?: string;

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