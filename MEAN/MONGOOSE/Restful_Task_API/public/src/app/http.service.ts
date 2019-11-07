import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private _http: HttpClient) { 
    this.getTasks();
    this.getOneTask("5dc1ff6abd199d37801b2e24");
  }
  getTasks() {
    let tempObservable = this._http.get('/tasks');
    // subscribe to the Observable and provide the code we would like to do with our data from the response
    tempObservable.subscribe(data => console.log("Got our tasks!", data));
  }
  getOneTask(id) {
    let tempObservable = this._http.get(`/tasks/${id}`);
    tempObservable.subscribe(data => {
      console.log(data);
    })
  }
}
