import { Component, OnInit, Input } from '@angular/core';

import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  userName: string = "administrator";
  password: string = "administrator";

  authMessage: string = "";

  constructor(private authService: AuthService,
              private router: Router,
              private dataService: DataService) { }

  ngOnInit() {
  }

  login(): void {
    this.authService.login(this.userName, this.password).then(r => {
      if (r === "success") {
        this.authMessage = r;
        this.router.navigate(['home/my-notes']);
      }
    },
      e => {
        this.authMessage = e;
      });
  }

  onChange(): void {
    this.authMessage = "";
  }
}
