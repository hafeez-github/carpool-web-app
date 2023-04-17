import { Component, OnDestroy } from '@angular/core';
import { DataService } from '../../services/data.service';
import { UserService } from '../../user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent{

  firstName=this.userService.getFromLocalStorage('user').firstName;

  constructor(private dataService: DataService, private userService: UserService, private toastr:ToastrService) {
  }

  ngOnInit(){
  }

  logout(){
    this.userService.clearLocalStorage();
    this.toastr.success("Logged out successfully");
  }

}
