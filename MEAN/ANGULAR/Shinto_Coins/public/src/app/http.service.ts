import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  value = 1;
  coins_owned : number;

  constructor(private _http: HttpClient) { }
  showVal() {
    return this.value;
  }
  addToVal() {
    this.value++;
  }
  addCoin(val) {
    this.coins_owned += val;
  }
  showCoins() {
    return this.coins_owned;
  }
}
