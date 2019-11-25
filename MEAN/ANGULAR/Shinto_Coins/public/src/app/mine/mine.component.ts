import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { HttpService } from './../http.service';

@Component({
  selector: 'app-mine',
  templateUrl: './mine.component.html',
  styleUrls: ['./mine.component.css']
})
export class MineComponent implements OnInit {
  correct : boolean;
  pass: any;
  val: any;
  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _httpService: HttpService
  ) {}

  ngOnInit() {
    this.pass = "";
  }
  onSubmit(val) {
    if(val == "codingDojo007") {
      this.correct = true;
      this._httpService.addToVal();
    } else {
      this.correct = false;
    }
  }

}
