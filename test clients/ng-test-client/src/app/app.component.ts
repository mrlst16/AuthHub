import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthhubLoginComponent } from './authhub-login/authhub-login.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  standalone: true,
  imports: [RouterOutlet, AuthhubLoginComponent],
})
export class AppComponent {
  title = 'ng-test-client';
  mode: "dev" | "prod" = "dev"
  organizationId: number = 2
  apiKey: string = "i6hmvzj54lwzom4e5d8nwlwtfr7bk77v9fjzb3iqhmrq5ug055jto4tyh5uqn41e"
  apiSecret: string = "yz8xey6qxo5o0wgmv5bg48oxhqlmmiy698homh2fx8n2ha4ry5chsjdol0dot2xw"
}