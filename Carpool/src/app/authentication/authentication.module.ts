import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { AccountRoutingModule } from '../account/account-routing.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SignupComponent,
    LoginComponent,
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    AccountRoutingModule,
    FormsModule
  ],
  exports:[
    SignupComponent,
    LoginComponent,
  ]
})
export class AuthenticationModule { }
