import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import {HttpService} from '.././http.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  city: any;
  constructor(
    private _httpService: HttpService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit() {
    this.city = {city: ''}
    this._route.params.subscribe((params: Params) => {
      console.log(params['id']);
      let observe = this._httpService.grabCity(params['id']);
      observe.subscribe(data => {
        console.log(data);
        this.city = data;
      })
    })

  }
  onClick(name) {
    let observer = this._httpService.grabCity(name);
    console.log(name);
    console.log("inside observer before subscribe");
    observer.subscribe(data => {
      console.log(data);
      this.city= {city: ''};
    })
  }
  

}
