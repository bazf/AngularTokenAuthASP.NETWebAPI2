import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';

import { AuthService } from '../services/auth.service';

@Injectable()
export class AdminGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    return this.checkRole();
  }

  checkRole(): boolean {
    if (this.authService.isInRole("admin")) {
      return true;
    }

    this.router.navigate(['home/my-notes']);
    return false;
  }
}
