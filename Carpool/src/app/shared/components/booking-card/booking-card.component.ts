import { Component, Input, OnInit } from '@angular/core';
import { OfferRequest } from '../../models/offerRequest';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-booking-card',
  templateUrl: './booking-card.component.html',
  styleUrls: ['./booking-card.component.scss']
})
export class BookingCardComponent implements OnInit {
  matchesList:OfferRequest[]=[];
  constructor(private dataService:DataService) {}

  @Input()
  currentMatch:any;

  bookingResponse:OfferRequest[]=this.dataService.bookingResponse;

  ngOnInit(){
    this.matchesList=this.dataService.bookingResponse;
  }

}
