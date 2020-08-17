import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private accountService: AccountService) {
  }

  signInWithGoogle(): void{
    this.accountService.login();
  }

  ngOnInit(): void {

  }

}
