import { Injectable } from '@angular/core';
import { LocalStorageService } from 'ngx-webstorage';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GithubAuthService {
  client_id="Iv1.c540ce83a87ce61f";
  client_secret="1f3e6d08d4788c46d516a94e7b2f7e9a09487799";

  constructor(private localStorange: LocalStorageService, private http: HttpClient) { }

  login(credentials): Observable<any> {
    console.log(credentials);
    var httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post("http://localhost:2720/api/credentials/login", credentials);
  }

  getAllFriends(): Observable<any>{
    return this.http.get("http://localhost:2720/api/friends/1ddb92e8-11e4-4b6c-be96-ffb8eb00c5e9").pipe(catchError(this.handleError));
  }

  handleError(err: HttpErrorResponse) {
    console.log("Error Occurred");
    return throwError(err.message || "Error");
  }
}
