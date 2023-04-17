import { Component, OnInit } from '@angular/core';
import { BookingResponse } from 'src/app/shared/models/bookingResponse';
import { OfferResponse } from 'src/app/shared/models/offerResponse';
import { DataService } from 'src/app/shared/services/data.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-my-rides',
  templateUrl: './my-rides.component.html',
  styleUrls: ['./my-rides.component.scss']
})
export class MyRidesComponent implements OnInit{

  myOffers:OfferResponse[]=[]
  myBookings:BookingResponse[]=[];

  constructor(private dataService:DataService, private userService:UserService) {
  }

  ngOnInit(){
    let user=this.userService.getFromLocalStorage('user');
    this.dataService.fetchOffers(user).subscribe(responseData=>this.myOffers=responseData.data);
    this.dataService.fetchBookings(user).subscribe(responseData=>this.myBookings=responseData.data);
  }
}
