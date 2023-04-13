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
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataService {

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
  
  locations:Location[]=[];
  bookingResponse:BookingResponse = new BookingResponse();

  matches:OfferResponse[]=[];
  users:User[]=[];
  apiURL:string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  signupUser(user: Signup) {
    return this.http.post<APIResponse<Login>>(`${this.apiURL}/authentication/signup`, user);
  }

  loginUser(user: Login) {
    return this.http.post<APIResponse<string>>(`${this.apiURL}/authentication/login`, user);
  }

  fetchOffers(user: User) {
    return this.http.post<APIResponse<OfferResponse[]>>(`${this.apiURL}/Offer/GetOffers`, user);
  }

  fetchBookings(user: User) {
    return this.http.post<APIResponse<BookingResponse[]>>(`${this.apiURL}/Booking/GetBookings`, user);
  }
  
  getLocations() {
    return this.http.get<APIResponse<Location[]>>(`${this.apiURL}/Location`);
  }

  bookRide(request:BookingRequest){
    return this.http.post<APIResponse<BookingResponse>>(`${this.apiURL}/Booking`, request);
  }

  findMatches(booking:BookingResponse){
    return this.http.post<APIResponse<OfferResponse[]>>(`${this.apiURL}/Offer/FindMatches`, booking);
  }

  offerRide(request:OfferRequest){
    return this.http.post<APIResponse<OfferResponse>>(`${this.apiURL}/Offer`, request);
  }

  logRideTransaction(transaction:RideRequest){
    return this.http.post<APIResponse<RideResponse>>(`${this.apiURL}/Ride`, transaction);
  }

  updateUser(user:User){
    return this.http.put<APIResponse<User>>(`${this.apiURL}/User`, user);
  }

}
