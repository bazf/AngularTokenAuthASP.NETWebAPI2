import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { MyNotesComponent } from './my-notes/my-notes.component';
import { AllNotesComponent } from './all-notes/all-notes.component';
import { AdministrationComponent } from './administration/administration.component';
import { AuthGuard } from './services/auth.guard.service';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'my-notes', component: MyNotesComponent },
      { path: 'all-notes', component: AllNotesComponent },
      { path: 'administration', component: AdministrationComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
