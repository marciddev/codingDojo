import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }
  getAllProducts() {
    return this._http.get('/products/all');
  }
  createNewProduct(body) {
    return this._http.post('/products/new', body);
  }
  deleteProduct(id) {
    return this._http.delete(`/products/remove/${id}`);
  }
  editProduct(id, body) {
    return this._http.put('/products/editprod/' + id, body);
  }
  findProduct(id) {
    return this._http.get('/products/profile/' + id);
  }
}
