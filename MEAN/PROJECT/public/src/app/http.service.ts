import { Injectable } from '@angular/core';
import * as io from 'socket.io-client';
import { Observable, Subscriber } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor () {
    this.socket = io("http://localhost:1337");
    this.namespace = io('/test');
  }
  socket: any;
  namespace: any;
  listen(eventName: string) {
    return new Observable((subscriber) => {
      this.socket.on(eventName, (data) => {
        subscriber.next(data);
      })
    })
  }
  emit(eventName: string, data: any) {
    this.socket.emit(eventName, data);
  }
  nsListen(eventName: string) {
    return new Observable((subscriber) => {
      this.namespace.on(eventName, (data) => {
        subscriber.next(data);
      })
    })
  }
  nsEmit(eventName: string, data: any) {
    this.namespace.emit(eventName, data);
  }
  getNs() {
    return this.namespace;
  }
  join(name: string) {
    this.socket.join(name);
  }
}
