import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Location } from 'src/app/shared/models/location';
import { OfferRequest } from 'src/app/shared/models/offerRequest';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-offer-menu1',
  templateUrl: './offer-menu1.component.html',
  styleUrls: ['./offer-menu1.component.scss'],
})
export class OfferMenu1Component implements OnInit {
  times = ['5am - 9am', '9am - 12pm', '12pm - 3pm', '3pm - 6pm', '6pm - 9pm'];

  locations: Location[] = [];

  offerRequest: OfferRequest = {
    offeredTime: '12AM',
    offererId: 1,
    from: 6,
    to: 7,
    date: '',
    time: '',
    stops:'',
    seatsAvailable: 1,
  };

  toggleMenu: boolean = false;

  constructor(private dataService: DataService) {
    this.dataService.getLocations().subscribe((responseData) => {
      this.locations = responseData.data;
      this.dataService.locations = responseData.data;
    });
  }

  ngOnInit(): void {
    this.locations = this.dataService.locations;
  }

  submitForm(bookingForm: NgForm) {
    // this.bookingRequest.bookerId=this.dataService.loggedinUser.id;
    // this.dataService.bookRide(this.bookingRequest).subscribe(
    //   responseData=>{
    //     this.dataService.bookingResponse=responseData.data;
    //     bookingForm.reset();
    //   }
    // );
  }

  mapLocFrom(loc: string) {
    this.offerRequest.from = this.locations.find(location => location.name == loc)!.id;
  }

  mapLocTo(loc: string) {
    this.offerRequest.to = this.locations.find(location => location.name == loc)!.id;
  }

  @Output() menu1Event: EventEmitter<boolean> = new EventEmitter();
  @Output() offerObjTransferEvent: EventEmitter<OfferRequest> = new EventEmitter();

  displayMenu2() {
    this.toggleMenu = !this.toggleMenu;
    this.menu1Event.emit(this.toggleMenu);
    this.sendOfferObject();
  }

  sendOfferObject(){
    this.offerObjTransferEvent.emit(this.offerRequest);
  }
}
