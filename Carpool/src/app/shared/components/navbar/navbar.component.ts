import { Component } from '@angular/core';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  // loginResponseData:any;
  firstName=localStorage.getItem("firstName");

  constructor(private dataService: DataService) {
  }

  ngOnInit(){
    // console.log(localStorage.getItem(this.dataService.loggedinUser.email));
    // this.loginResponseData=this.dataService.loggedinUser;
    
    // var local=localStorage.getItem(this.dataService.loggedinUser.email);
    // let result;
    // if(local!=null){
    //   result=JSON.parse(local);
    //   this.loginResponseData=result.data;
    // }

  }
}
