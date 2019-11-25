import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RestaurauntsComponent } from './restauraunts/restauraunts.component';
import { NewComponent } from './new/new.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { MakerevComponent } from './makerev/makerev.component';


const routes: Routes = [
  {path: "", pathMatch: 'full', redirectTo: "restauraunts"},
  {path: "restauraunts/new", component: NewComponent},
  {path: 'restauraunts', component: RestaurauntsComponent},
  {path: 'reviews/:id', component: ReviewsComponent},
  {path: 'reviews/:id/review', component: MakerevComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
