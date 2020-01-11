import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
    ing: any;
    username: string;
    password: string;

  constructor(private http: HttpClient, private authService: AuthService) { }

  ngOnInit() {
      this.http.get('http://localhost:5000/api/ingredients').subscribe(ing => {
        this.ing = ing;
        console.log(this.ing);
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
