import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {


  loggedinUser:User={
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
  
  submitForm(loginForm:NgForm){
    // let user:Login={
    //   email:this.login.email,
    //   password:this.login.password
    // };

    // this.dataService.loginUser(user).subscribe(
    //   responseData=>{
    //     console.log(responseData);
    //     this.handleResponse(responseData);
    //     this.login.email='';
    //     this.login.password='';  
    //     loginForm.form.reset();

    //     if(this.responseData.data!=null){
    //       this.router.navigate(['/acc/menu']);
    //     }
    //     else{
    //       alert("Error! Wrong Credentials!");
    //     }
    //   }
    //  );
  }

}
