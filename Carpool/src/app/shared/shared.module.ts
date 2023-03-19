import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfferCardComponent } from './components/offer-card/offer-card.component';
import { BookingCardComponent } from './components/booking-card/booking-card.component';



@NgModule({
  declarations: [
    OfferCardComponent,
    BookingCardComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    BookingCardComponent
  ]
})
export class SharedModule { }
