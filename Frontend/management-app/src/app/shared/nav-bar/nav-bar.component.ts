import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core/models/user.model';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent implements OnInit {
  constructor(public authService: AuthService) {}

  ngOnInit(): void {
    this.setLoggedUser();
  }

  setLoggedUser(): void {
    const user: User = JSON.parse(localStorage.getItem('user') || '');
    this.authService.setLoggedUser(user);
  }

  logout(): void {
    this.authService.logout();
  }
}
