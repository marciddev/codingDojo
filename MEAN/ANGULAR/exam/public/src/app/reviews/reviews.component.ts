import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Router, Params } from '@angular/router';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {

  constructor(private _httpService: HttpService, private _route: ActivatedRoute, private _router: Router) { }
  profile: String[] = [];
  ordered: String [] = [];
  id: any;
  ngOnInit() {
    console.log("inside init");
    this._route.params.subscribe(data => {
      this.id = data['id'];
      console.log(data['id']);
      this._httpService.getOne(data['id']).subscribe(data2 => {
        this.profile = data2[0]['reviews'];
        console.log(data2[0]['reviews'].sort(function(a, b) {
          if(a['stars'] < b['stars']) return -1;
          if (a['stars'] > b['stars']) return 1;
          return 0;
        }));
        data2[0]['reviews'].reverse();
      })
    })
  }

}
