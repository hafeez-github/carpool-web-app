import { Component } from '@angular/core';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  loginResponseData:any;
  constructor(private dataService: DataService) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
  }

  dropMenu(){
    
  }
}
