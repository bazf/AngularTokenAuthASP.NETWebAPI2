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

  private newNote: Note = new Note();
  private isAdmin: boolean = false;
  private notes: Note[] = [];

  constructor(private dataService: DataService, private authService: AuthService) { }

  ngOnInit() {
    this.getNotes();
    this.isAdmin = this.authService.isInRole("admin");
  }

  private getNotes(): void {
    this.dataService.get<Note[]>("note/all-my").subscribe(r => {
      this.notes = r;
    });
  }

  private addNote(): void {
    this.dataService.post<number>("note/add", { "title": this.newNote.title, "text": this.newNote.text }).subscribe(r => {
      if (r) {
        this.newNote.id = r;
        this.notes.push(this.newNote);
        this.newNote = new Note();
      }
    });
  }

  private removeNote(id: number): void {
    this.dataService.delete<boolean>("note/remove", id).subscribe(r => {
      var index = this.notes.findIndex(n => n.id == id);
      this.notes.splice(index, 1);
    });
  }

}


