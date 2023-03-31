import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BookingRequest } from 'src/app/shared/models/bookingRequest';
import { Location } from 'src/app/shared/models/location';
import { User } from 'src/app/shared/models/user';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-booking-menu1',
  templateUrl: './booking-menu1.component.html',
  styleUrls: ['./booking-menu1.component.scss'],
})
export class BookingMenu1Component implements OnInit {
  times = ['5am - 9am', '9am - 12pm', '12pm - 3pm', '3pm - 6pm', '6pm - 9pm'];

  locations: Location[] = [];

  bookingRequest: BookingRequest = {
    bookedTime: '12AM',
    bookerId: 1,
    from: 6,
    to: 7,
    date: '',
    time: '',
    seatsRequired: 1,
  };

  constructor(private dataService: DataService, private router: Router) {
    this.dataService.getLocations().subscribe((responseData) => {
      this.locations = responseData.data;
      this.dataService.locations = responseData.data;
    });
  }

  ngOnInit(): void {}

  submitForm(bookingForm: NgForm) {
    const date = new Date();
    const formattedTime = date.toLocaleTimeString('en-US', {
      hour: 'numeric',
      minute: 'numeric',
      second: 'numeric',
      hour12: true,
    });

    this.bookingRequest.bookerId = this.dataService.loggedinUser.id;
    this.bookingRequest.bookedTime = formattedTime;
    console.log("Booking Request: ",this.bookingRequest);

    this.dataService.bookRide(this.bookingRequest).subscribe((responseData) => {
      this.dataService.bookingResponse = responseData.data;
      alert("Booking response received");

      // if(this.dataService.bookingResponse.length!=0){
      //   this.showResults=true;
      // }
      console.log("responseData: ", responseData);
      console.log("this.dataService.bookingResponse: ", this.dataService.bookingResponse);

      // bookingForm.reset();
      // this.router.navigate(['/acc/menu']);
    });
  }

  mapLocFrom(loc: string) {
    this.bookingRequest.from = this.locations.find(
      (location) => location.name == loc
    )!.id;
  }

  mapLocTo(loc: any) {
    let data = loc.value;
    this.bookingRequest.to = this.locations.find(
      (location) => location.name == data
    )!.id;
  }
}
