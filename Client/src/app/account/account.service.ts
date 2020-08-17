import { Injectable } from '@angular/core';
import { GoogleLoginProvider, SocialAuthService, SocialUser } from 'angularx-social-login';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { ReplaySubject } from 'rxjs';
import { IUser } from '../shared/models/user';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;

  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient,
              private router: Router,
              private authService: SocialAuthService) {
  }

  async login(): Promise<void> {
    const user: IUser = await this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);

    if (user) {
      localStorage.setItem('token', user.authToken);
      this.currentUserSource.next(user);
    }
  }

  signOut(): void {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

}
