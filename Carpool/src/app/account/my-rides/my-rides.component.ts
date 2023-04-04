import { Component, OnInit } from '@angular/core';
import { BookingResponse } from 'src/app/shared/models/bookingResponse';
import { OfferResponse } from 'src/app/shared/models/offerResponse';
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
    this.dataService.fetchBookings(this.dataService.loggedinUser).subscribe(responseData=>this.myBookings=responseData.data);
    this.dataService.fetchOffers(this.dataService.loggedinUser).subscribe(responseData=>this.myOffers=responseData.data);
  }
}
