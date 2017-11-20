import { Component, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

  ngOnInit() {
  }

  constructor(private authService: AuthService) {

  }

  logout(): void {
    this.authService.logout();
  }

}
