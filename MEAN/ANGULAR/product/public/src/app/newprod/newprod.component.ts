import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-newprod',
  templateUrl: './newprod.component.html',
  styleUrls: ['./newprod.component.css']
})
export class NewprodComponent implements OnInit {

  constructor(private _httpService: HttpService, private _router: Router) { }
  newProd: any;
  errors: any;
  ngOnInit() {
    this.newProd = {name: '', price: null, image: ''}
  }
  createProd() {
    let observe = this._httpService.createNewProduct(this.newProd);
    observe.subscribe(data => {
      this.errors = data['errors'];
      console.log("THESE ARE THER RRORS " + this.errors);
      console.log(this.errors);
      this.goHome();
    })
  }
  goHome() {
    this._router.navigate(['/products'])
  }

}
