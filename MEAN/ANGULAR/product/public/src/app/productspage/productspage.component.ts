import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-productspage',
  templateUrl: './productspage.component.html',
  styleUrls: ['./productspage.component.css']
})
export class ProductspageComponent implements OnInit {
  products: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    this.getProducts();
  }
  getProducts() {
    this._httpService.getAllProducts().subscribe(data => {
      this.products = data;
    })
  }
  removeProduct(id) {
    console.log("inside removeproduct");
    console.log(id);
    let observe = this._httpService.deleteProduct(id);
    observe.subscribe(data => {
      console.log(data);
      this._httpService.getAllProducts().subscribe(data => {
        this.products = data;
      });
    })
  }

}
