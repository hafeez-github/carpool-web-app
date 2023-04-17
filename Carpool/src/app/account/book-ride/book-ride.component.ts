import { Component, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OfferResponse } from 'src/app/shared/models/offerResponse';
import { RideRequest } from 'src/app/shared/models/rideRequest';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-book-ride',
  templateUrl: './book-ride.component.html',
  styleUrls: ['./book-ride.component.scss']
})
export class BookRideComponent implements OnInit{

  loginResponseData:any;
  matches:OfferResponse[]=[];
  rideRequest:RideRequest={
    offerId:-1,
    bookingId:-1,
    tripStartDateTime:"",
    tripEndDateTime:"",
    price:-1,
    distance:-1
  };

  constructor(public dataService:DataService, private router:Router, private toastr:ToastrService) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
    this.matches=this.dataService.matches;
  }

  cardClicked(currentOfferMatch:OfferResponse)
  {
    const date = new Date();
    const formattedTime = date.toLocaleTimeString('en-US', {
      hour: 'numeric',
      minute: 'numeric',
      second: 'numeric',
      hour12: true
    });

    this.rideRequest.bookingId=this.dataService.bookingResponse.id;
    this.rideRequest.offerId=currentOfferMatch.id;
    this.rideRequest.price=180;
    this.rideRequest.distance=140;

    this.dataService.logRideTransaction(this.rideRequest).subscribe(responseData=>{
      this.toastr.success("Ride successfully booked", "thankyou!");
      this.router.navigate(['/acc/menu']);
    });

    
  }
}
