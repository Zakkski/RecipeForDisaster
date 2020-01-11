import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
    ing: any;
    username: string;
    password: string;

  constructor(private http: HttpClient) { }

  ngOnInit() {
      this.http.get('http://localhost:5000/api/ingredients').subscribe(ing => {
        this.ing = ing;
        console.log(this.ing);
    });
  }

  onLogin() {
      console.log(this.username, this.password);
  }
}
