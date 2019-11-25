import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpService } from '../http.service';
import { Router} from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  @Input() formStuff;
  @Output() hideForm = new EventEmitter();
  errors: any;
  constructor(private _httpService: HttpService,private  _router: Router) { }

  ngOnInit() {
  }
  update(id, body) {
    let observe = this._httpService.update(id, body);
    observe.subscribe(data => {
      if(data['status']) {
        this._router.navigate(['/restauraunts']);
        this.trigger();
      } else {
        this.errors = data['errors'];
      }
    })
  }
  trigger() {
    this.hideForm.emit();
  }

}
