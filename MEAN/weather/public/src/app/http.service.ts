import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }
  grabCity(name: String) {
    return this._http.get(`https://api.openweathermap.org/data/2.5/weather?q=${name}&APPID=96d65c2196cb978153a88922511fe66d`);
  }
}