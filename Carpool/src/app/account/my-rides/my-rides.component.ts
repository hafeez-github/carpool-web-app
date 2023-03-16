import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-my-rides',
  templateUrl: './my-rides.component.html',
  styleUrls: ['./my-rides.component.scss']
})
export class MyRidesComponent implements OnInit{

  loginResponseData:any;
  constructor(private dataService:DataService) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
  }
}
