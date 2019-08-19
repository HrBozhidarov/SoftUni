import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthService {
  private readonly loginUrl = 'http://localhost:5000/auth/login';
  private readonly registerUrl = 'http://localhost:5000/auth/register';

  constructor(
    private http : HttpClient
  ) {  }

  register(body) {
    return this.http.post(this.registerUrl, body);
  }

  login(body) {
    return this.http.post(this.loginUrl, body);
  }

  logout() {
    localStorage.clear();
  }

  isAuthenticated() {
    return this.getToken() !== null;
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isAdmin() {
    return localStorage.getItem('isAdmin') === "true" // is not a correct because everyone can become admin
  }
}