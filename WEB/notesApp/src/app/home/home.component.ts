import { Component, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

  isAdmin: boolean = false;

  ngOnInit() {
    this.isAdmin = this.authService.isInRole("admin");
  }

  constructor(private authService: AuthService) {

  }

  logout(): void {
    this.authService.logout();
  }

}
