import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LogInComponent } from './log-in/log-in.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [
    SignUpComponent,
    LogInComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule
  ],
  exports:[
    LogInComponent,
    SignUpComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    HomeComponent
  ]
})
export class AuthenticationModule { }
