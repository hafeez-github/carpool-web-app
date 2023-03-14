import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './menu/menu.component';
import { OfferRideComponent } from './offer-ride/offer-ride.component';
import { BookRideComponent } from './book-ride/book-ride.component';
import { ProfileComponent } from './profile/profile.component';
import { MyRidesComponent } from './my-rides/my-rides.component';

const routes: Routes = [
  {
    path: 'menu', component: MenuComponent
  },
  {
    path: 'offer', component: OfferRideComponent
  },
  {
    path: 'book', component: BookRideComponent
  },
  {
    path: 'profile', component: ProfileComponent
  },
  {
    path: 'myrides', component: MyRidesComponent
  },
  {
    path: '', component: MenuComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
