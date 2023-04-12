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
import { environment } from 'src/environments/environment.prod';
import { ConfigService } from '../config.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = ConfigService.getBaseUrl();

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
  apiURL:string = environment.domain;


  constructor(private http: HttpClient) { }

  signupUser(user: Signup) {
    return this.http.post<APIResponse<Login>>('https://localhost:7021/api/authentication/signup', user);
  }

  loginUser(user: Login) {
    return this.http.post<APIResponse<string>>('https://localhost:7021/api/authentication/login', user);
  }

  fetchOffers(user: User) {
    // return this.http.post<APIResponse<OfferResponse[]>>(`${this.apiURL}/Offer/GetOffers`, user);
    return this.http.post<APIResponse<OfferResponse[]>>(`https://localhost:7021/api/Offer/GetOffers`, user);
  }

  fetchBookings(user: User) {
    return this.http.post<APIResponse<BookingResponse[]>>('https://localhost:7021/api/Booking/GetBookings', user);
  }
  
  getLocations() {
    return this.http.get<APIResponse<Location[]>>('https://localhost:7021/api/Location');
  }

  bookRide(request:BookingRequest){
    return this.http.post<APIResponse<BookingResponse>>('https://localhost:7021/api/Booking', request);
  }

  findMatches(booking:BookingResponse){
    return this.http.post<APIResponse<OfferResponse[]>>('https://localhost:7021/api/Offer/FindMatches', booking);
  }

  offerRide(request:OfferRequest){
    return this.http.post<APIResponse<OfferResponse>>('https://localhost:7021/api/Offer', request);
  }

  logRideTransaction(transaction:RideRequest){
    return this.http.post<APIResponse<RideResponse>>('https://localhost:7021/api/Ride', transaction);
  }

  updateUser(user:User){
    return this.http.put<APIResponse<User>>('https://localhost:7021/api/User', user);
  }

}
