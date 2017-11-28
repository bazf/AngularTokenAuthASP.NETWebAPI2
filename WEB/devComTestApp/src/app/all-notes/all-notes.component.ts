import { Component, OnInit } from '@angular/core';

import { Note } from '../custom-types/note';
import { DataService } from '../services/data.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-all-notes',
  templateUrl: './all-notes.component.html',
  styleUrls: ['./all-notes.component.less']
})
export class AllNotesComponent implements OnInit {

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
    this.dataService.get<Note[]>("note/all").subscribe(r => {
      this.notes = r;
    });
  }

  removeNote(id: number): void {
    this.dataService.delete<boolean>("note/remove", id).subscribe(r => {
      var index = this.notes.findIndex(n => n.id == id);
      this.notes.splice(index, 1);
    });
  }
}
