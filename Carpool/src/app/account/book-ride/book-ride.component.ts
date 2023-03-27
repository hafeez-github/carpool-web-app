import { Component, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingResponse } from 'src/app/shared/models/bookingResponse';
import { OfferRequest } from 'src/app/shared/models/offerRequest';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-book-ride',
  templateUrl: './book-ride.component.html',
  styleUrls: ['./book-ride.component.scss']
})
export class BookRideComponent implements OnInit{

  loginResponseData:any;
  matches:BookingResponse[]=[];

  constructor(public dataService:DataService, private router:Router) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
    this.matches=this.dataService.bookingResponse;
    console.log(this.matches);
  }

  cardClicked()
  {
    alert("Ride successfully booked, thankyou!");
    this.router.navigate(['/acc/menu']);
  }
}
