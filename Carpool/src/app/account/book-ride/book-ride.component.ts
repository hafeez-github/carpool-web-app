import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-book-ride',
  templateUrl: './book-ride.component.html',
  styleUrls: ['./book-ride.component.scss']
})
export class BookRideComponent implements OnInit{

  loginResponseData:any;
  constructor(private dataService:DataService) {
  }

  ngOnInit(){
    this.loginResponseData=this.dataService.loggedinUser;
  }
}
