import { NgModule } from '@angular/core';
import {HomeComponent} from './home/home.component';
import {MineComponent} from './mine/mine.component';
import { Routes, RouterModule } from '@angular/router';
import { BuyComponent } from './buy/buy.component'

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '' , redirectTo: '/home', pathMatch: 'full'},
  { path: 'mine', component: MineComponent},
  { path: 'buy', component: BuyComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
