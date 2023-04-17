import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Location } from 'src/app/shared/models/location';
import { OfferRequest } from 'src/app/shared/models/offerRequest';
import { DataService } from 'src/app/shared/services/data.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-offer-menu2',
  templateUrl: './offer-menu2.component.html',
  styleUrls: ['./offer-menu2.component.scss'],
})
export class OfferMenu2Component implements OnInit {
  array = [1];

  times = ['5am - 9am', '9am - 12pm', '12pm - 3pm', '3pm - 6pm', '6pm - 9pm'];

  locations: Location[] = [];

  stops:string[]=[];

  @Input()
  offerRequest: OfferRequest = {
    offererId: 1,
    from: 6,
    to: 7,
    date: '',
    time: '',
    stops:'',
    seatsAvailable: 1,
  };

  toggleMenu: boolean = false;

  constructor(private dataService: DataService, private userService:UserService, private router:Router, private toastr:ToastrService) {}

  ngOnInit(): void {
    this.locations = this.dataService.locations;
  }

  addStop() {
    this.array.push(this.array[this.array.length - 1] + 1);
  }
  submitForm(offerForm: NgForm) {

    this.offerRequest.offererId=this.userService.getFromLocalStorage('user').id;
    
    this.dataService.offerRide(this.offerRequest).subscribe(
      responseData=>{
        this.stops=responseData.data.stops.split(', ');
        this.toastr.success("Ride successfully offered!");
        offerForm.reset();
        this.router.navigate(['/acc/menu']);
        
      }
    );
  }

  mapLocStops(loc: string) {
    let locId=this.locations.find(location => location.name == loc)!.id;
    this.offerRequest.stops+= locId+", ";
  }

  mapLocTo(loc: any) {
  }

  @Output() menu1Event: EventEmitter<boolean> = new EventEmitter();

  displayMenu2() {
    this.toggleMenu = !this.toggleMenu;
    this.menu1Event.emit(this.toggleMenu);
  }

  setSeatOffered(seatCount:number){
    this.offerRequest.seatsAvailable=seatCount;
  }

  setPrice(price:string){
  }

  toggle(){
    this.router.navigate(["/acc/book"]);  
  }
}
