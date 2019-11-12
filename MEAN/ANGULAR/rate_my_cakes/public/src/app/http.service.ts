import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }

  getCakesFromService() {
    return this._http.get('/cakes');
  }
  createCake(body) {
    return this._http.post('/', body);
  }
  createReview(body, id) {
    return this._http.post('/review/' + id, body);
  }
  findReview(id) {
    return this._http.get('/cakes/' + id);
  }
}
