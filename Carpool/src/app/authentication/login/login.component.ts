import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/shared/models/login';
import { DataService } from 'src/app/shared/services/data.service';

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

  responseData:any;

  constructor(private dataService:DataService, private router:Router) {
    
  }

  submitForm(loginForm:NgForm){
    let user:Login={
      email:this.login.email,
      password:this.login.password
    };

    this.dataService.loginUser(user).subscribe(
      responseData=>{
        console.log(responseData);
        this.handleResponse(responseData);
        this.login.email='';
        this.login.password='';  
        loginForm.form.reset();

        if(this.responseData.data!=null){
          this.router.navigate(['/acc/menu']);
        }
        else{
          alert("Error! Wrong Credentials!");
        }
      }
     );
  }

  handleResponse(responseData:any){
    this.responseData=responseData;
    this.dataService.loggedinUser=responseData.data;
    localStorage.setItem(responseData.data.email, JSON.stringify(responseData));
  }

}
