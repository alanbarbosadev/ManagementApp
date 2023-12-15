import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, map } from 'rxjs';
import { User } from '../models/user.model';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loggedUserData: ReplaySubject<User | null> =
    new ReplaySubject<User | null>(1);
  loggedUser$ = this.loggedUserData.asObservable();

  constructor(private http: HttpClient, private router: Router) {}

  login(model: any): Observable<User | void> {
    return this.http
      .post<User>(`${environment.baseApiUrl}Auth/login`, model)
      .pipe(
        map((response: User) => {
          const user = response;
          if (user) {
            localStorage.setItem('user', JSON.stringify(user));
            this.loggedUserData.next(user);
            this.router.navigate(['/employees']);
          }
        })
      );
  }

  logout(): void {
    localStorage.removeItem('user');
    this.loggedUserData.next(null);
    this.router.navigate(['']);
  }

  setLoggedUser(user: User): void {
    this.loggedUserData.next(user);
  }
}
