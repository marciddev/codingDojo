import { Component, OnInit } from '@angular/core';
import { HttpService } from './../http.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  allAuthors: any;
  input: any;
  showEdit: any;
  editInfo: any;
  editInput: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    this.grabAllAuthors();
    this.input = {name: ""};
    this.editInput = {name: ""}
    this.showEdit = false;
  }
  grabAllAuthors() {
    console.log("inside of grabAllAuthors in home component");
    let observer = this._httpService.getAllAuthors();
    observer.subscribe(data => {
      console.log("inside of subscribe method in grabAllAuthors");
      this.allAuthors = data;
      console.log(data);
    })
  }
  deleteAuthor(id) {
    console.log("inside of delete component before subscribe");
    this._httpService.deleteOneAuthor(id).subscribe(data => {
      console.log(data);
      this.grabAllAuthors();
    });
  }
  submitAuthor() {
    console.log("inside of submit authro");
    let observe = this._httpService.createOneAuthor(this.input);
    observe.subscribe(data => {
      console.log(data);
      this.input = {name: ""}
      this.grabAllAuthors();
    })
  }
  showEditForm(data) {
    console.log(data);
    this.showEdit = true;
    this.editInfo = data;
  }
  updateForm() {
    let observer = this._httpService.editOne(this.editInfo._id, this.editInput);
    console.log(`${this.editInfo} is editinfo and ${this.editInput} is editInput`);
    observer.subscribe(data => {
      console.log(data);
      this.grabAllAuthors();
      this.showEdit = false;
    })
  }

}
