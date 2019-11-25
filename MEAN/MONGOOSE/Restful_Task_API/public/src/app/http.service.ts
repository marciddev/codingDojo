import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private _http: HttpClient) { 
  }
  getTasks() {
    return this._http.get('/tasks');
  }
  postToServer(d) {
    return this._http.post('/tasks', d);
  }
  getAllTasks() {
    return this._http.get('/tasks');
  }
  getOneTask(id) {
    return this._http.get(`/tasks/${id}`)
  }
  addTask(newtask) {
    console.log("in addtask");
    return this._http.post('/tasks', newtask);
  }
  deleteTask(newtask) {
    console.log("in deletetask");
    return this._http.delete(`/tasks/${newtask}`);
  }
  editTask(task1, task2) {
    console.log("in edittask");
    return this._http.put(`/tasks/${task1}`, task2);
  }
  createTask(body) {
    return this._http.post("/tasks/new", body);
  }
}