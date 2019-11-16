import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestComponent } from "./test/test.component";
import { DetailsComponent } from './details/details.component';
import { BrandComponent } from './brand/brand.component';
import { CategoryComponent } from './category/category.component';
import { ProductsComponent } from './products/products.component';
import { PdetailsComponent } from './pdetails/pdetails.component';
import { AuthorComponent } from './author/author.component';
import { AllComponent } from './all/all.component';


const routes: Routes = [
  {path: 'reviews', component: TestComponent, children: [
    {path: 'details/:id', component: DetailsComponent},
    {path: 'brand/:brand', component: BrandComponent},
    {path: 'category/:cat', component: CategoryComponent}
  ]},
  {path: 'products', component: ProductsComponent, children: [
    {path: 'details/:id', component: PdetailsComponent},
    {path: 'author/:id', component: AuthorComponent},
    {path: 'all/:id', component: AllComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
