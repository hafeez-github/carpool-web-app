import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../models/api-response';
import { Signup } from '../models/signup';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  loggedinUser:string="";

  constructor(private http: HttpClient) { }

  signupUser(user: Signup) {
    return this.http.post<APIResponse<Login>>('https://localhost:7021/api/authentication/signup', user);
  }

  loginUser(user: Login) {
    // console.log(user);
    return this.http.post<APIResponse<Login>>('https://localhost:7021/api/authentication/login', user);
  }
  
}
