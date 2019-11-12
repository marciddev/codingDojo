import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-tasks-component',
  templateUrl: './tasks-component.component.html',
  styleUrls: ['./tasks-component.component.css']
})
export class TasksComponentComponent implements OnInit {
  @Input() taskToShow: any;
  constructor() { }

  ngOnInit() {
  }

}
