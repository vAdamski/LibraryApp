import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReaderViewModel } from '../Models/reader-view-model.model';

@Component({
  selector: 'app-edit-borrower',
  templateUrl: './edit-borrower.component.html',
  styleUrls: ['./edit-borrower.component.css']
})
export class EditBorrowerComponent implements OnInit {



  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

}
