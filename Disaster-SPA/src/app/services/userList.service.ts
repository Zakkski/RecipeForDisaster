import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserListService {
    baseUrl = 'http://localhost:5000/api/lists/';

    constructor(private http: HttpClient) { }

    getUserLists(userId: number, selectRecipes: boolean) {
        return this.http.get(this.baseUrl + userId, { params: { selectRecipes: selectRecipes.toString()}});
    }

    getUserList(listId: number) {
        return this.http.get(this.baseUrl + 'user/' + listId);
    }
}
