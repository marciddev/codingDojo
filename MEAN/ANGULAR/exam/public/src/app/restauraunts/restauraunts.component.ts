import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-restauraunts',
  templateUrl: './restauraunts.component.html',
  styleUrls: ['./restauraunts.component.css']
})
export class RestaurauntsComponent implements OnInit {
  all: any;
  edit: any;
  editData: any;
  editFormInfo: any;
  profile: any;
  deleteB: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    this._httpService.getAllRestauraunts().subscribe(data => {
      this.all = data;
    })
  }
  getOne(id) {
    this._httpService.getOne(id).subscribe(data => {
      this.profile = data;
    });
  }
  delete(id) {
    console.log("inside delete");
    console.log(id);
    this._httpService.deleteRest(id).subscribe(data => {
      console.log(data);
      this._httpService.getAllRestauraunts().subscribe(data2 => {
        this.all = data2;
      })
    })
  }
  showEdit(id) {
    this.edit = true;
    this._httpService.getOne(id).subscribe(data => {
      this.editData = data;
      console.log(this.editData);
      this.editFormInfo = {name: this.editData['name'], cuisine: this.editData['cuisine']}
    })
  }
  hideEdit() {
    this.edit = false;
    this._httpService.getAllRestauraunts().subscribe(data => {
      this.all = data;
    })
  }
  deleteBool() {
    this.deleteB = false;
  }
}