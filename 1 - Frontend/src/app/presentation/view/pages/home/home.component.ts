import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  isLoading: boolean;
  displayedColumns: string[] = ['name', 'phone', 'birth_date', 'documents', 'action'];
  dataSource: any;

  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit() {

  }
}
