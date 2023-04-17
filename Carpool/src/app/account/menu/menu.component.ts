import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { DataService } from 'src/app/shared/services/data.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  firstName:string='';
  constructor(private dataService:DataService, private userService:UserService, private toastr:ToastrService) {
  }

  ngOnInit(){
    this.firstName=this.userService.getFromLocalStorage('user').firstName;
  }
  

}
