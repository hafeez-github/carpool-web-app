import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { AccountRoutingModule } from '../account/account-routing.module';


@NgModule({
  declarations: [
    SignupComponent,
    LoginComponent,
    ResetPasswordComponent,
    ForgotPasswordComponent
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    AccountRoutingModule
  ],
  exports:[
    SignupComponent,
    LoginComponent,
    ResetPasswordComponent,
    ForgotPasswordComponent
  ]
})
export class AuthenticationModule { }
