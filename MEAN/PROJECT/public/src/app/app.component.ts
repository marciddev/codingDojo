import {
  Component,
  OnInit
} from '@angular/core';
import {
  HttpService
} from './http.service';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = "public"
  name = {
    name: ""
  }
  online: any;
  logged_users_name: any;
  message = {
    msg: ""
  }
  messages: any;
  date: any;
  constructor(private _httpService: HttpService) {

  }
  ngOnInit() {
    if(JSON.parse(localStorage.getItem('msgs')).length > 0) {
      this.messages = JSON.parse(localStorage.getItem('msgs'));
    } 
    this._httpService.listen('numOnline').subscribe(data => {
      this.online = data;
    })
    this.message = {msg: ""};
    this._httpService.listen('message_back_to_client').subscribe(data => {
      console.log(data);
      this.messages.push(data);
      console.log(this.messages);
      localStorage.setItem('msgs', JSON.stringify(this.messages));
    })
    }
    submit() {
      this._httpService.emit('message_sent', this.message.msg);
      this.date = new Date();
    }
}
