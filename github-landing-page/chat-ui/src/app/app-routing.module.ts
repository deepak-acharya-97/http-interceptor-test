import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { FriendsComponent } from './friends/friends.component';

const routes: Routes = [{
  path: 'landing', component: LandingComponent
}, {
  path: 'login', component: LoginComponent
}, {
  path: 'friends', component: FriendsComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
