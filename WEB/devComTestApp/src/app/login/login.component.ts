import { Component, OnInit, Input } from '@angular/core';

import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  userName: string = "aaa";
  password: string = "qazwsx";

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login(): void {
    this.authService.login(this.userName, this.password);
  }
}
