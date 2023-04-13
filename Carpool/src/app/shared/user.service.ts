import { Injectable } from '@angular/core';
import { User } from './models/user';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() {

  }

  // static loggedinUser:User={
  //   id:1,
  //   firstName:'',
  //   lastName:'',
  //   username:'',
  //   type:1,
  //   email:'',
  //   password:'',
  //   mobile:'',
  //   isActive:false
  // };


  storeInLocalStorage(key:string, value:any){
    if(typeof value=='string'){
    }
    else{
      value= JSON.stringify(value);
    }
    localStorage.setItem(key, value);
  }

  getFromLocalStorage(key:string){
    let temp=localStorage.getItem(key);
    if(temp!=null){
      return JSON.parse(temp);
    }
    else{
      return null;
    }
  }

  // getPropertyFromLocalStorage(key:string, property:string){
  //   return this.getFromLocalStorage(key)[property];
  // }

  clearLocalStorage(){
    localStorage.clear();
  }


  getDecodedToken(token: string) {
    try {
      let helper= new JwtHelperService();
      return helper.decodeToken(token);
    } 
    catch(Error) {
      return null;
    }
  }
}
