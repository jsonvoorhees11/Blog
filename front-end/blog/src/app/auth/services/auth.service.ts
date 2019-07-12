import { Injectable } from '@angular/core';
import { Observable, from, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  login( email: string,username: string, password: string) : Observable<boolean>{
    let headers = new HttpHeaders();
    return this.httpClient.post<any>(`${environment.securityApiUrl}auth/login`,{email,username,password}, {headers:headers})
  }
}
