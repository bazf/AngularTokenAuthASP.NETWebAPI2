import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {

  userName: string = "user";
  password: string = "userpassword";
  confirmPassword: string = "userpassword";

  regMessage: string = "";

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  register(): void {
    this.authService.register(this.userName, this.password, this.confirmPassword)
      .then(r => {
        if (r === "success") {
          this.authService.login(this.userName, this.password).then(lr => {
            if (lr === "success") {
              this.router.navigate(['home/my-notes']);
            }
          });
        }
      },
      e => {
        this.regMessage = "Name user is already taken.";
      });
  }

  onChange(): void {
    this.regMessage = "";
  }
}
