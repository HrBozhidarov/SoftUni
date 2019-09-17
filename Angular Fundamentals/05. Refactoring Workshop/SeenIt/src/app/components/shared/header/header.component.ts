import { Component, Input } from "@angular/core";
import { AuthService } from 'src/app/core/services/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent {
    @Input() username: string = '';
    @Input() isLoggedIn: boolean;

    constructor(
        private authService: AuthService,
        private router: Router
      ) { }

    logout() {
        this.authService.logout()
          .subscribe(() => {
            localStorage.clear();
            this.router.navigate([ '/login' ])
          })
      }
}