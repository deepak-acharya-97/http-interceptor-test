import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { GithubAuthService } from '../github-auth.service';
import { LocalStorageService } from 'ngx-webstorage';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm;
  constructor(private fb: FormBuilder, private authservice: GithubAuthService, private localStorage: LocalStorageService, private router: Router) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      UserName: [''],
      Password: ['']
    });
  }

  onSubmit() {
    this.authservice.login(this.loginForm.value).subscribe(tokenInfo => {
      console.log(tokenInfo);
      this.localStorage.store("token", tokenInfo["token"]);
      this.router.navigate(['/friends']);
    })
  }

}
