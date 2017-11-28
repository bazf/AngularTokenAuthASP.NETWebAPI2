import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

import { DataService } from '../services/data.service';
import { User } from '../custom-types/user';

@Component({
  selector: 'app-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.less']
})
export class AdministrationComponent implements OnInit {
  dataSource: MatTableDataSource<User>;

  users: User[] = [];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers(): void {
    this.dataService.get<User[]>("user/all").subscribe(r => {
      this.users = r;
      this.dataSource = new MatTableDataSource(this.users);
    });
  }

  displayedColumns = ['id', 'name'];

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }
}
