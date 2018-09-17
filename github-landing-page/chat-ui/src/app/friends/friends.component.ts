import { Component, OnInit } from '@angular/core';
import { GithubAuthService } from '../github-auth.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {
  friend;
  error;

  constructor(private authservice: GithubAuthService) { }

  ngOnInit() {
    this.authservice.getAllFriends().subscribe(data => {
      this.friend = data;
    }, err => this.error = err);
  }

}
