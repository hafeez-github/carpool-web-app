import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../models/api-response';
import { Signup } from '../models/signup';
import { Location } from '../models/location';
import { BookingRequest } from '../models/bookingRequest';
import { OfferRequest } from '../models/offerRequest';
import { User } from '../models/user';
import { BookingResponse } from '../models/bookingResponse';
import { OfferResponse } from '../models/offerResponse';
import { RideResponse } from '../models/rideResponse';
import { RideRequest } from '../models/rideRequest';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  loggedinUser:User={
    id:1,
    firstName:'',
    lastName:'',
    username:'',
    userType:3,
    email:'',
    password:'',
    mobile:'',
    isActive:false
    

    
  };
  locations:Location[]=[];
  bookingResponse:BookingResponse[]=[];

  constructor(private http: HttpClient) { }

  signupUser(user: Signup) {
    return this.http.post<APIResponse<Login>>('https://localhost:7021/api/authentication/signup', user);
  }

  loginUser(user: Login) {
    // console.log(user);
    return this.http.post<APIResponse<Login>>('https://localhost:7021/api/authentication/login', user);
  }
  
  getLocations() {
    // console.log(user);
    return this.http.get<APIResponse<Location[]>>('https://localhost:7021/api/Location');
  }

  bookRide(request:BookingRequest){
    return this.http.post<APIResponse<BookingResponse[]>>('https://localhost:7021/api/Booking', request);
  }

  offerRide(request:OfferRequest){
    return this.http.post<APIResponse<OfferResponse>>('https://localhost:7021/api/Offer', request);
  }

  logRideTransaction(transaction:RideRequest){
    return this.http.post<APIResponse<RideResponse>>('https://localhost:7021/api/Ride', transaction);
  }

}
