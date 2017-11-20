import { Component, OnInit } from '@angular/core';

import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {

  userName: string = "aaa";
  password: string = "qazwsx";
  confirmPassword: string = "qazwsx";

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  register(): void {
    this.authService.register(this.userName, this.password, this.confirmPassword)
      .then(r => {
        if (r === "success") {
          this.authService.login(this.userName, this.password).then(lr => {
            if (lr === "success") {
              this.router.navigate(['home']);
            }
          });
        }
      });
  }
}
