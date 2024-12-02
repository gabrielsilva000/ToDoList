import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

private apiUrl = `${environment.apiUrl}/Auth/login`
private token!: string;

constructor(private http: HttpClient, private router: Router) { }

login(username: string, password: string): Observable<string> {
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  return this.http.post<string>(this.apiUrl, { username, password }, { headers, responseType: 'text' as 'json' })
    .pipe(
      tap((response) => {
      const responseString = JSON.parse(response);
      this.token = responseString.token;
      localStorage.setItem('jwt', this.token);
      this.router.navigate(['/home']);
    })
  );
}

  logout() {
    this.token = '';
    localStorage.removeItem('jwt');
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return this.token !== null || localStorage.getItem('jwt') !== null;
  }

}
