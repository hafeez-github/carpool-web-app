import { Component, OnInit } from '@angular/core';
import { BookingResponse } from 'src/app/shared/models/bookingResponse';
import { OfferResponse } from 'src/app/shared/models/offerResponse';
import { User } from 'src/app/shared/models/user';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-my-rides',
  templateUrl: './my-rides.component.html',
  styleUrls: ['./my-rides.component.scss']
})
export class MyRidesComponent implements OnInit{

  loginResponseData:any;
  myOffers:OfferResponse[]=[]
  myBookings:BookingResponse[]=[];

  constructor(private dataService:DataService) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
    let user:User={
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
    
    let temp=localStorage.getItem('loggedinUser');
    if(temp!=null)
    {
      user=JSON.parse(temp);
    }

    // this.dataService.fetchBookings(this.dataService.loggedinUser).subscribe(responseData=>this.myBookings=responseData.data);
    // this.dataService.fetchOffers(this.dataService.loggedinUser).subscribe(responseData=>this.myOffers=responseData.data);
    
    this.dataService.fetchOffers(user).subscribe(responseData=>this.myOffers=responseData.data);
    this.dataService.fetchBookings(user).subscribe(responseData=>this.myBookings=responseData.data);
  }
}
