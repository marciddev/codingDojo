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
  edit = false;
  newTask: any;
  editTaskTemplate;
  constructor(private _httpService: HttpService) {
    
  }
  ngOnInit() {
    this.getTasksFromService();
    this.title = "hello";
    this.newTask = { title: "", description: "" }
    this.getAllTasks();
    this.editTaskTemplate = {title: "", description: ""}
  }
  getAllTasks() {
    let observer = this._httpService.getAllTasks();
    observer.subscribe(data => {
      this.all_tasks=data;
    })
    
  }
  deleteTask(task) {
    let observe = this._httpService.deleteTask(task);
    observe.subscribe(data => {
      console.log("inside delete task subscribe method");
    })
  }
  editT() {
    this.edit = true;
  }
  onEdit(task) {
    console.log("in onEdit");
    let observer = this._httpService.editTask(task, this.editTaskTemplate);
    observer.subscribe(data => {
      console.log("in subscribe method");
      this.edit = false;
      this.editTaskTemplate = {title: "", description: ""}
    })
  }
  onSubmit() {
    console.log("in onSubmit()");
    let observable = this._httpService.addTask(this.newTask);
    console.log(this.newTask);
    observable.subscribe(data => {
      console.log("inside subscribe, route completed", data);
      this.newTask = { title: "", description: ""}
      
    })
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
