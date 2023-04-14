import { Component } from '@angular/core';
import { DataService } from '../../services/data.service';
import { UserService } from '../../user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  firstName=this.userService.getFromLocalStorage('user').firstName;

  constructor(private dataService: DataService, private userService: UserService) {
  }

  ngOnInit(){
  }

  logout(){
    this.userService.clearLocalStorage();
  }
}
