import { Component } from '@angular/core';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  firstName=localStorage.getItem("firstName");

  constructor(private dataService: DataService) {
  }

  ngOnInit(){
  }

  logout(){
    localStorage.clear();
  }
}
