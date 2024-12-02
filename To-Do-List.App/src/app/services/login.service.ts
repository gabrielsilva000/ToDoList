import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl = `${environment.apiUrl}/Auth/register`

  constructor(private http: HttpClient) { }

  RegisterLogin(login: Login): Observable<Login> {
    return this.http.post<Login>(`${this.apiUrl}`, login);
  }
}
