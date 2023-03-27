import { Component, Input, OnInit } from '@angular/core';
import { OfferRequest } from '../../models/offerRequest';
import { DataService } from '../../services/data.service';
import { BookingResponse } from '../../models/bookingResponse';

@Component({
  selector: 'app-booking-card',
  templateUrl: './booking-card.component.html',
  styleUrls: ['./booking-card.component.scss']
})
export class BookingCardComponent implements OnInit {
  matchesList:OfferRequest[]=[];
  constructor(private dataService:DataService) {}

  @Input()
  currentMatch:BookingResponse={
    offererId:-1,
    from:-1,
    to:-1,
    time:"",
    date:"",
    seatsAvailable:-1,
    stops:"", 
    offeredTime:""
  };

  bookingResponse:OfferRequest[]=this.dataService.bookingResponse;

  ngOnInit(){
    this.matchesList=this.dataService.bookingResponse;
  }

}
