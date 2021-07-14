import { Component } from '@angular/core';
import { OktaAuthService } from '@okta/okta-angular';
import { from } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  isAuthenticated = false;
  username: string | undefined;

  constructor(
    private readonly oktaAuth: OktaAuthService,
    ) {

  }

  async ngOnInit() {
    this.isAuthenticated = await this.oktaAuth.isAuthenticated();
    this.getUser();

    this.oktaAuth.$authenticationState.subscribe(
      (isAuthenticated: boolean) => {
        this.isAuthenticated = isAuthenticated;

        if (isAuthenticated) {
          this.getUser();
        }
      }
    );
  }

  getUser = () => {
    from(this.oktaAuth.getUser())
    .subscribe(userClaims => {
      this.username = userClaims.name;
    })
  }

   logout = async () => {
    await this.oktaAuth.signOut();
  }

  login = () => {
    this.oktaAuth.signInWithRedirect({
      originalUri: '/home'
    });
  }

}
