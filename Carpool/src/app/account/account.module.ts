import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { MenuComponent } from './menu/menu.component';
import { OfferRideComponent } from './offer-ride/offer-ride.component';
import { BookRideComponent } from './book-ride/book-ride.component';
import { MyRidesComponent } from './my-rides/my-rides.component';
import { ProfileComponent } from './profile/profile.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    MenuComponent,
    OfferRideComponent,
    BookRideComponent,
    MyRidesComponent,
    ProfileComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule
  ]
})
export class AccountModule { }
