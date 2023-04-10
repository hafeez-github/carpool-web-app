import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/shared/models/user';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent {
  isDisableEdit: boolean = true;
  // loggedinUser:User=this.dataService.loggedinUser;
  loggedinUser: User = {
    id: 1,
    firstName: '',
    lastName: '',
    username: '',
    type: 1,
    email: '',
    password: '',
    mobile: '',
    isActive: false,
  };

  constructor(private dataService: DataService) {}

  ngOnInit() {
    var temp = localStorage.getItem('loggedinUser');
    if (temp != null) {
      this.loggedinUser = JSON.parse(temp);
      console.log(this.loggedinUser);
    }
  }

  submitForm(loginForm: NgForm) {
    if (this.isDisableEdit) {
      this.dataService
        .updateUser(this.loggedinUser)
        .subscribe((responseData) => {
          this.dataService.loggedinUser = this.loggedinUser;
          alert('User updated');
        });
    }
  }
}
