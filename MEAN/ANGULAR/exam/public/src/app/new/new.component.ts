import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from '../http.service';
import {Observable} from 'rxjs/Rx';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {
  formData: any;
  errors: any;
  exists: any;
  constructor( private _route: ActivatedRoute, private _router: Router, private _httpService: HttpService) { }

  ngOnInit() {
    this.formData = {name: "", cuisine: ""};
  }
  submitForm() {
    this._httpService.getAllRestauraunts().subscribe(all => {
      this._httpService.createRestauraunt(this.formData).subscribe(data => {
        for(var x in all) {
          if(this.formData['name'] == all[x].name) {
            this.exists = false;
            data['status'] = false;
          }
        }
        if(data['status']) {
          this.formData = {name: "", cuisine: ""}
          this._router.navigate(['/restauraunts']);
        } else {
          this.errors = data['errors'];
          this.formData = {name: "", cuisine: ""}
        }
      })
      
    })
    
  }
}