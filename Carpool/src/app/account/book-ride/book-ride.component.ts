import { Component, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingResponse } from 'src/app/shared/models/bookingResponse';
import { OfferRequest } from 'src/app/shared/models/offerRequest';
import { RideRequest } from 'src/app/shared/models/rideRequest';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-book-ride',
  templateUrl: './book-ride.component.html',
  styleUrls: ['./book-ride.component.scss']
})
export class BookRideComponent implements OnInit{

  loginResponseData:any;
  matches:BookingResponse[]=[];
  rideRequest:RideRequest={
    // id:-1,
    offerId:-1,
    bookingId:-1,
    tripStart:"",
    tripEnd:"",
    price:-1,
    distance:-1
  };

  constructor(public dataService:DataService, private router:Router) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
    this.matches=this.dataService.bookingResponse;
    console.log(this.matches);
  }

  cardClicked(currentOfferMatch:BookingResponse)
  {
    console.log("current Match: ", currentOfferMatch);
    console.log("LoggedIn User: ", this.dataService.loggedinUser);

    const date = new Date();
    const formattedTime = date.toLocaleTimeString('en-US', {
      hour: 'numeric',
      minute: 'numeric',
      second: 'numeric',
      hour12: true
    });

    this.rideRequest.bookingId=this.dataService.loggedinUser.id;
    this.rideRequest.offerId=currentOfferMatch.id;
    this.rideRequest.tripStart=formattedTime;
    this.rideRequest.tripEnd=formattedTime;
    this.rideRequest.price=180;
    this.rideRequest.distance=140;

    this.dataService.logRideTransaction(this.rideRequest).subscribe(responseData=>{
      console.log("ride transaction response: ", responseData);

      alert("Ride successfully booked, thankyou!");
      this.router.navigate(['/acc/menu']);
    });

    
  }
}
