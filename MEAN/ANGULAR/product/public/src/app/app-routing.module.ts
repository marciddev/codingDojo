import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductspageComponent } from './productspage/productspage.component';
import { NewprodComponent } from './newprod/newprod.component';
import { EditproductComponent } from './editproduct/editproduct.component';


const routes: Routes = [
  {path: '', pathMatch: 'full', component: HomeComponent},
  {path: 'products', component: ProductspageComponent, children: [
    {path: 'edit/:id', component: EditproductComponent}
  ]},
  {path: 'newproduct', component: NewprodComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
