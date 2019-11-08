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
  all_tasks;
  taskProfile;
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
  onButtonClickParam():void {
    let observable = this._httpService.postToServer({title: "hello"});
    observable.subscribe(data => {
      console.log("Got our data!", data)
    });
  }
  onAllTasksClick(): void {
    let observe = this._httpService.getAllTasks();
    observe.subscribe(data => {
      this.all_tasks = data;
      console.log(data);
    })
  }
  onOneTaskClick(id): void {
    let observe = this._httpService.getOneTask(id);
    observe.subscribe(data => {
      this.taskProfile = data;
      console.log(data);
    })
  }
}
