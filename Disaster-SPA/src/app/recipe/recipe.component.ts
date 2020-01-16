import { Component, OnInit } from '@angular/core';
import { UserListService } from '../services/userList.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.scss']
})
export class RecipeComponent implements OnInit {
    list: any;
    // TODO: create model for this

  constructor(private userListService: UserListService, private route: ActivatedRoute) { }

  ngOnInit() {
      this.userListService.getUserList(this.route.snapshot.params.id).subscribe(list => {
          this.list = list;
          console.log(this.list);
      });
  }

addToShoppingList(listId: number) {
    listId = 12; // TODO: This is hard coded until the user can select a list
    
}

}
