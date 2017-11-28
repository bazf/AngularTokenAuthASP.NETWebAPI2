import { Component, OnInit } from '@angular/core';

import { DataService } from '../services/data.service';
import { Note } from '../custom-types/note';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-my-notes',
  templateUrl: './my-notes.component.html',
  styleUrls: ['./my-notes.component.less']
})
export class MyNotesComponent implements OnInit {

  newNote: Note = new Note();

  result: boolean;
  isAdmin: boolean = false;
  notes: Note[] = [];

  constructor(private dataService: DataService, private authService: AuthService) { }

  ngOnInit() {
    this.getNotes();
    this.isAdmin = this.authService.isInRole("admin");
  }

  getNotes(): void {
    this.dataService.get<Note[]>("note/all-my").subscribe(r => {
      this.notes = r;
    });
  }

  addNote(): void {
    this.dataService.post<boolean>("note/add", { "title": this.newNote.title, "text": this.newNote.text }).subscribe(r => {
      this.result = r;
      if (r) {
        this.notes.push(this.newNote);
        this.newNote = new Note();

      }
    });
  }

  removeNote(id: number): void {
    this.dataService.delete<boolean>("note/remove", id).subscribe(r => {
      var index = this.notes.findIndex(n => n.id == id);
      this.notes.splice(index, 1);
    });
  }

}


