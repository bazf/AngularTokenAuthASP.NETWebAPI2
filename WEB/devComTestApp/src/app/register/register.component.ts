import { Component, OnInit } from '@angular/core';

import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {

  userName: string = "aaa";
  password: string = "qazwsx";
  confirmPassword: string = "qazwsx";

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register(): void {
    this.authService.register(this.userName, this.password, this.confirmPassword);
  }
}
