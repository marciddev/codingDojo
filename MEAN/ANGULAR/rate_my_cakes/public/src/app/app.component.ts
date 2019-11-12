import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'public';
  allcakes;
  newCake: any;
  newReview: any;
  cakeProfile;
  constructor(private _httpService: HttpService) {}
  ngOnInit() {
    this.getAllCakes();
    this.newCake = {baker: "", image: ""};
    this.newReview = {rating: null, comment: ""}
  }
  getAllCakes() {
    let observer = this._httpService.getCakesFromService();
    observer.subscribe(data => {
      this.allcakes=data;
    })
  }
  onCakeSubmit() {
    let observe = this._httpService.createCake(this.newCake);
    observe.subscribe(data => {
      this.newCake = {baker: "", image: ""};
    })
  }
  onReviewSubmit(id) {
    let observe = this._httpService.createReview(this.newReview, id);
    observe.subscribe(data => {
      this.newReview = {rating: null, comment: ""}
    })
  }
  imageClick(id) {
    let observe = this._httpService.findReview(id);
    observe.subscribe(data => {
      this.cakeProfile = data;
    })
  }
}
