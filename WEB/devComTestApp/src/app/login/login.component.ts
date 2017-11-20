import { Component, OnInit, Input } from '@angular/core';

import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  userName: string = "aaa";
  password: string = "qazwsx";

  authMessage: string = "";


  test: TestClass = new TestClass();

  constructor(private authService: AuthService, private router: Router, private dataService: DataService) { }

  ngOnInit() {
  }

  login(): void {
    this.authService.login(this.userName, this.password).then(r => {
      if (r === "success") {
        this.authMessage = r;
        this.router.navigate(['home']);
      }
    },
      e => {
        this.authMessage = e;
      });
  }


  testData(): void {
    var G = this.dataService.get<string>("values/one").subscribe(r => {
      this.test.name = r;
    });
  }

  onChange(): void {
    this.authMessage = "";
  }
}

export class TestClass {
  id: number;
  name: string;
}
