import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookingRequest } from 'src/app/shared/models/bookingRequest';
import { Location } from 'src/app/shared/models/location';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-booking-menu1',
  templateUrl: './booking-menu1.component.html',
  styleUrls: ['./booking-menu1.component.scss'],
})
export class BookingMenu1Component implements OnInit {
  times = ['5am - 9am', '9am - 12pm', '12pm - 3pm', '3pm - 6pm', '6pm - 9pm'];

  locations: Location[] = [];

  bookingRequest: BookingRequest=
  {
    bookerId: 1,
    from: 6,
    to: 7,
    date: '',
    time: '',
    seatsRequired: 1,
  };

  constructor(private dataService: DataService, private router: Router, private toastr:ToastrService) {
    this.dataService.getLocations().subscribe((responseData) => {
      this.locations = responseData.data;
      this.dataService.locations = responseData.data;
    });
  }

  ngOnInit(): void {
    this.dataService.matches=[];
  }

  submitForm(bookingForm: NgForm) {
    this.bookingRequest.bookerId = this.dataService.loggedinUser.id;
    this.dataService.bookRide(this.bookingRequest).subscribe(responseData => {
      responseData.data.booker="";
      responseData.data.toLocation="";
      responseData.data.fromLocation="";
      this.dataService.bookingResponse = responseData.data;
      this.toastr.success("booking done!");
      this.dataService.findMatches(responseData.data).subscribe(response=>this.dataService.matches=response.data);
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

  toggle(){
    this.router.navigate(["/acc/offer"]);  
  }
}
