import { Component } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  public UserName!: string;
  public Department!: string;
  public Level!: string;
  public UserID!: string;

  constructor (){

  }

  AddUser() {
    console.log("user: " + this.UserID);
  }
}
