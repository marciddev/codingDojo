import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title : String;
  tasks = [];
  constructor(private _httpService: HttpService) {
    
  }
  ngOnInit() {
    this.getTasksFromService();
    this.title = "hello";
  }
  getTasksFromService() {
    let observe = this._httpService.getTasks();
    observe.subscribe(data => {
      console.log("got our tasks,!!! ", data);
      for(var x in data) {
        this.tasks.push({title: data[x].title, description: data[x].description})
      }
    })
  }
}
