import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { MenuComponent } from './menu/menu.component';
import { OfferRideComponent } from './offer-ride/offer-ride.component';
import { BookRideComponent } from './book-ride/book-ride.component';
import { MyRidesComponent } from './my-rides/my-rides.component';
import { ProfileComponent } from './profile/profile.component';
import { SharedModule } from '../shared/shared.module';
import { BookingMenu1Component } from './book-ride/booking-menu1/booking-menu1.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    MenuComponent,
    OfferRideComponent,
    BookRideComponent,
    MyRidesComponent,
    ProfileComponent,
    BookingMenu1Component,
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class AccountModule { }
