import { Component, OnInit } from '@angular/core';
import { OfferRequest } from 'src/app/shared/models/offerRequest';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-offer-ride',
  templateUrl: './offer-ride.component.html',
  styleUrls: ['./offer-ride.component.scss']
})
export class OfferRideComponent implements OnInit{

  loginResponseData:any;
  enableMenu2:boolean=false;
  
  offerRequest: OfferRequest = {
    offererId: 1,
    from: 6,
    to: 7,
    date: '',
    time: '',
    stops:'',
    seatsAvailable: 1,
  };

  constructor(private dataService:DataService) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
  }

  respondToMenu1Event(eventData:boolean)
  {
    this.enableMenu2=eventData;
  }

  respondToOfferObjTransferEvent(eventData:OfferRequest)
  {
    this.offerRequest=eventData;
  }
}
