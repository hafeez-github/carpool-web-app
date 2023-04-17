import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/shared/models/user';
import { DataService } from 'src/app/shared/services/data.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent {
  isDisableEdit: boolean = true;
  loggedinUser: User =new User();

  constructor(private dataService: DataService, private userService:UserService) {}

  ngOnInit() {
    this.loggedinUser=this.userService.getFromLocalStorage('user');
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
