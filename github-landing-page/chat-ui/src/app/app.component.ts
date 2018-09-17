import { Component } from '@angular/core';
import { LocalStorageService } from 'ngx-webstorage';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'github-land';

  constructor(private storage: LocalStorageService) {}

  endSession () {
    this.storage.clear("token");
    alert("You have been logged out");
  }
}
