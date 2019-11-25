import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }
  getAllRestauraunts() {
    return this._http.get('/restauraunts/list');
  }
  createRestauraunt(body) {
    return this._http.post('/restauraunts/create', body);
  }
  deleteRest(id) {
    return this._http.delete("/delete/" + id);
  }
  getOne(id) {
    return this._http.get('/rest/' + id);
  }
  update(id, body) {
    return this._http.put('/rest/' + id, body);
  }
  getAllReviews() {
    return this._http.get('/reviewsapi/all');
  }
  createReview(id, body) {
    return this._http.post('/reviewsapi/new/' + id, body);
  }
}
