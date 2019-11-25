import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpService } from './http.service';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { RestaurauntsComponent } from './restauraunts/restauraunts.component';
import { NewComponent } from './new/new.component';
import { EditComponent } from './edit/edit.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { MakerevComponent } from './makerev/makerev.component';

@NgModule({
  declarations: [
    AppComponent,
    RestaurauntsComponent,
    NewComponent,
    EditComponent,
    ReviewsComponent,
    MakerevComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
