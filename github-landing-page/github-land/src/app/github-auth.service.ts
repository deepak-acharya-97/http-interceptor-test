import { Injectable } from '@angular/core';
import { LocalStorageService } from 'ngx-webstorage';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GithubAuthService {
  client_id="Iv1.c540ce83a87ce61f";
  client_secret="1f3e6d08d4788c46d516a94e7b2f7e9a09487799";

  constructor(private localStorange: LocalStorageService, private http: HttpClient) { }

  authenticate(code, state) {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    // console.log("code",code);
    // console.log("client_id", this.client_id);
    // console.log("client_secret",this.client_secret);
    let _url="https://github.com/login/oauth/access_token";
    let header_body = {
      "client_id": this.client_id,
      "client_secret": this.client_secret,
      "code": code
    }
    // header_body= {
    //   "client_id": "Iv1.c540ce83a87ce61f",
    //   "client_secret": "1f3e6d08d4788c46d516a94e7b2f7e9a09487799",
    //   "code": "5039ba1d04cd05e79961"
    // };
    var body ={
      "client_id": "Iv1.c540ce83a87ce61f",
      "client_secret": "1f3e6d08d4788c46d516a94e7b2f7e9a09487799",
      "code": "e8d66e8d1743ee468a00"
    };
    console.log(header_body);
    //return this.http.delete(_url);
    return this.http.post(_url, body, httpOptions);
  }
}
