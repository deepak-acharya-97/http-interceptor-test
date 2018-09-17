import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LocalStorageService } from 'ngx-webstorage';
import { GithubAuthService } from '../github-auth.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {
  code;

  constructor(private route: ActivatedRoute, private localStorage: LocalStorageService, private authservice: GithubAuthService) { }

  ngOnInit() {
    // this.route.queryParamMap.subscribe(params => {
    //   this.code = {...params.keys, ...params};
    //   console.log(this.code.params.code);
    //   this.localStorage.store("code",this.code.params.code);
    //   this.authservice.authenticate(this.code.params.code,this.code.params.code).subscribe(data => {
    //     console.log("Response");
    //     console.log(data);
    //   });
    // });
  }

}
