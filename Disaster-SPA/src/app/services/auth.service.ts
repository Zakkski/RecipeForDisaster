import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    baseUrl = 'http://localhost:5000/api/users/';
    jwtHelper = new JwtHelperService();
    decodedToken: any;
    currentUser: User;

    constructor(private http: HttpClient) { }

    login(model: any) {
        return this.http.post(this.baseUrl + 'login', model)
            .pipe(
                map((response: any) => {
                    if (response) {
                        localStorage.setItem('token', response.token);
                        localStorage.setItem('user', JSON.stringify(response.user));
                        this.decodedToken = this.jwtHelper.decodeToken(response.token);
                        this.currentUser = response.user;
                    }
                })
            );
    }

    loggedIn() {
        const token = localStorage.getItem('token');
        return !this.jwtHelper.isTokenExpired(token);
    }
}
