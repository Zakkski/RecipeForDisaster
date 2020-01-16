import { Component, OnInit } from '@angular/core';
import { UserListService } from '../services/userList.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.scss']
})
export class ShoppingListComponent implements OnInit {
    list: any;
    // TODO: create model for this

  constructor(private userListService: UserListService, private route: ActivatedRoute) { }

  ngOnInit() {
      this.userListService.getUserList(this.route.snapshot.params.id).subscribe(list => {
          this.list = list;
          console.log(this.list);
      });
  }

}
