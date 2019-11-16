import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpService } from './http.service';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestComponent } from './test/test.component';
import { DetailsComponent } from './details/details.component';
import { BrandComponent } from './brand/brand.component';
import { CategoryComponent } from './category/category.component';
import { ProductsComponent } from './products/products.component';
import { PdetailsComponent } from './pdetails/pdetails.component';
import { AuthorComponent } from './author/author.component';
import { AllComponent } from './all/all.component';

@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    DetailsComponent,
    BrandComponent,
    CategoryComponent,
    ProductsComponent,
    PdetailsComponent,
    AuthorComponent,
    AllComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
