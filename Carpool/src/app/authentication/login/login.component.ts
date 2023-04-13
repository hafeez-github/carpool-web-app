import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/shared/models/login';
import { DataService } from 'src/app/shared/services/data.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from 'src/app/shared/models/user';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  login:Login={
    email:'',
    password:'',
  };

  decodedToken:any;

  user:User={
    id:1,
    firstName:'',
    lastName:'',
    username:'',
    type:1,
    email:'',
    password:'',
    mobile:'',
    isActive:false
  };

  constructor(private dataService:DataService, private userService:UserService, private router:Router) {
    
  }

  submitForm(loginForm:NgForm){
    let user:Login={
      email:this.login.email,
      password:this.login.password
    };

    this.dataService.loginUser(user).subscribe(
      responseData=>{
        this.handleResponse(responseData);
        this.login.email='';
        this.login.password='';  
        loginForm.form.reset();

        if(this.decodedToken!=null){
          this.router.navigate(['/acc/menu']);
        }
        else{
          alert("Error! Wrong Credentials!");
        }
      }
     );
  }

  handleResponse(responseData:any){
    this.userService.storeInLocalStorage('token', responseData.data);
    this.decodedToken=this.userService.getDecodedToken(responseData.data);
    
    this.user.id=parseInt(this.decodedToken.id);
    this.user.email=this.decodedToken.email;
    this.user.firstName=this.decodedToken.firstName;
    this.user.lastName=this.decodedToken.lastName;
    this.user.password=this.decodedToken.password;
    this.user.mobile=this.decodedToken.mobile;
    this.user.username=this.decodedToken.username;
    this.user.isActive=(this.decodedToken.isActive)=="True";
    this.user.type=this.checkUserType(this.decodedToken.type);

    this.dataService.loggedinUser=this.user;
    
    this.userService.storeInLocalStorage('token', responseData.data);
    this.userService.storeInLocalStorage('user', this.user);
  }


  checkUserType(type:string){
    if(type=="AppUser")
    {
      return 1;
    }
    else if(type=="DbAdmin"){
      return 2;
    }
    else return 3;
  }

}
