import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }
  getAllAuthors() {
    console.log("inside of getAllAuthors inside service");
    return this._http.get('/api');
  }
  deleteOneAuthor(id) {
    console.log("inside of delete service");
    return this._http.delete(`/api/delete/${id}`);
  }
  createOneAuthor(body) {
    console.log("inside of create author");
    let observer = body;
    console.log(body);
    let observer2 = this._http.post('/api', body);
    console.log(observer2);
    return observer2;
  }
  editOne(id, body) {
    return this._http.put('/edit/' + id, body);
  }
}
