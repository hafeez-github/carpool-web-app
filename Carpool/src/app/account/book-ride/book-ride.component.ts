import { Component, OnChanges, OnInit } from '@angular/core';
import { OfferRequest } from 'src/app/shared/models/offerRequest';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-book-ride',
  templateUrl: './book-ride.component.html',
  styleUrls: ['./book-ride.component.scss']
})
export class BookRideComponent implements OnInit{

  loginResponseData:any;
  matches:OfferRequest[]=[];

  constructor(public dataService:DataService) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser.firstName;
    this.matches=this.dataService.bookingResponse;
    console.log(this.matches);
  }
}
