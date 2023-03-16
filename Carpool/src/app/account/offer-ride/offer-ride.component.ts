import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-offer-ride',
  templateUrl: './offer-ride.component.html',
  styleUrls: ['./offer-ride.component.scss']
})
export class OfferRideComponent implements OnInit{

  loginResponseData:any;
  constructor(private dataService:DataService) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
  }
}
