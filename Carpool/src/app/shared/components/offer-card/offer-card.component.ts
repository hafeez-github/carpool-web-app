import { Component, Input, OnInit } from '@angular/core';
import { BookingResponse } from '../../models/bookingResponse';

@Component({
  selector: 'app-offer-card',
  templateUrl: './offer-card.component.html',
  styleUrls: ['./offer-card.component.scss']
})
export class OfferCardComponent implements OnInit{
  @Input()
  currentMatch:BookingResponse={
    id:-1,
    bookerId:-1,
    from:-1,
    to:-1,
    time:"",
    date:"",
    seatsRequired:-1,
    bookedDateTime:"",
    booker:"",
    fromLocation:"",
    toLocation:""
  };

  ngOnInit(): void {
      
  }
}
