import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Location } from 'src/app/shared/models/location';
import { OfferRequest } from 'src/app/shared/models/offerRequest';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-offer-menu2',
  templateUrl: './offer-menu2.component.html',
  styleUrls: ['./offer-menu2.component.scss'],
})
export class OfferMenu2Component implements OnInit {
  array = [1];

  times = ['5am - 9am', '9am - 12pm', '12pm - 3pm', '3pm - 6pm', '6pm - 9pm'];

  locations: Location[] = [];

  @Input()
  offerRequest: OfferRequest = {
    offeredTime: '12AM',
    offererId: 1,
    from: 6,
    to: 7,
    date: '',
    time: '',
    seatsAvailable: 1,
  };

  toggleMenu: boolean = false;
  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.locations = this.dataService.locations;
    console.log(this.offerRequest);
  }

  addStop() {
    this.array.push(this.array[this.array.length - 1] + 1);
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
    // this.offerRequest.from = this.locations.find(location => location.name == loc)!.id;
  }

  mapLocTo(loc: any) {
    // let data=loc.value;
    // this.offerRequest.to = this.locations.find(location => location.name == data)!.id;
  }

  @Output() menu1Event: EventEmitter<boolean> = new EventEmitter();

  displayMenu2() {
    this.toggleMenu = !this.toggleMenu;
    this.menu1Event.emit(this.toggleMenu);
  }
}
