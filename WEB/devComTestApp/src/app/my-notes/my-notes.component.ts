import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-my-notes',
  templateUrl: './my-notes.component.html',
  styleUrls: ['./my-notes.component.less']
})
export class MyNotesComponent implements OnInit {

  constructor(private dataService: DataService) { }

  ngOnInit() {
  }

}
