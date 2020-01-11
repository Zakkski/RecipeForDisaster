import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    baseUrl = 'http://localhost:5000/api/users/';
    jwtHelper: JwtHelperService;
    decodedToken: any;
    currentUser: any;
    // currentUser: User;

    constructor(private http: HttpClient) { }

    login(model: any) {
        return this.http.post(this.baseUrl + 'login', model)
            .pipe(
                map((response: any) => {
                    const user = response;
                    if (response) {
                        localStorage.setItem('token', user.token);
                        localStorage.setItem('user', JSON.stringify(user.user));
                        this.decodedToken = this.jwtHelper.decodeToken(user.token);
                        this.currentUser = user.user;
                    }
                })
            );
    }
}
