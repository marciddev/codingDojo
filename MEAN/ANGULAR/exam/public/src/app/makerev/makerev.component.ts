import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-makerev',
  templateUrl: './makerev.component.html',
  styleUrls: ['./makerev.component.css']
})
export class MakerevComponent implements OnInit {
  id: any;
  formData: any;
  errors: any;
  constructor(private _router: Router,  private _route: ActivatedRoute,private _httpService: HttpService) { }

  ngOnInit() {
    this.formData = {name: "", stars: null, description: ""}
    this._route.params.subscribe(data => {
      this.id = data['id'];
    })
  }
  formSubmit() {
    let observe = this._httpService.createReview(this.id, this.formData);
    observe.subscribe(data => {
      console.log(data);
      console.log(data['status']);
      if(data['status']) {
        this._router.navigate(['/reviews/' + this.id]);
      } else {
        this.errors = data['errors'];
      }
    })
  }

}
