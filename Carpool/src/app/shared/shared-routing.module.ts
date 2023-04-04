import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../authentication/login/login.component';
import { MyRidesComponent } from '../account/my-rides/my-rides.component';
import { ProfileComponent } from '../account/profile/profile.component';

const routes: Routes = [
  {
    path: 'auth/login',
    component:LoginComponent
  },
  {
    path: 'acc/myrides',
    component:MyRidesComponent
  },
  {
    path: 'acc/profile',
    component:ProfileComponent
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SharedRoutingModule { }