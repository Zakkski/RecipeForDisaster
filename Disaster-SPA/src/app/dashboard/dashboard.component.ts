import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { UserListService } from '../services/userList.service';
import { List } from '../models/list';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
    username: string;
    password: string;
    recipes: any;
    userLists: any;
    // recipes: List[];
    // userLists: List[];

  constructor(private authService: AuthService, private userListService: UserListService) { }

  ngOnInit() {
    this.userListService.getUserLists(this.authService.decodedToken.nameid, false).subscribe(lists => {
        this.userLists = lists;
    });
    this.userListService.getUserLists(this.authService.decodedToken.nameid, true).subscribe(lists => {
        this.recipes = lists;
    });
  }

  onLogin() {
      const creds = {
          username: this.username,
          password: this.password
      };

      this.authService.login(creds).subscribe(next => {
          console.log('Logged in');
      }, error => {
          console.log('Log in failed', error);
      });
  }
}
