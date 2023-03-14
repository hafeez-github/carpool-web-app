import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LogInComponent } from './log-in/log-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';

const routes: Routes = [
  {path: '', component: HomeComponent, children: [
    {
      path: 'login', component: LogInComponent
    },
    {
      path: 'signup', component: SignUpComponent
    },
    {
      path: 'for', component: SignUpComponent
    },
    {
      path: 'signup', component: SignUpComponent
    }

  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
