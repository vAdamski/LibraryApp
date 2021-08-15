import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookViewModel } from '../Models/book-view-model.model';
import { BorrowerViewModel } from '../Models/borrower-view-model.model';
import { ReaderViewModel } from '../Models/reader-view-model.model';

@Component({
  selector: 'app-add-borrower',
  templateUrl: './add-borrower.component.html',
  styleUrls: ['./add-borrower.component.css']
})
export class AddBorrowerComponent implements OnInit {


  borrower = new BorrowerViewModel();

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.getAllReaders();
    this.getAllBooks();
  }

  getAllReaders() {
    this.http.get<Array<ReaderViewModel>>("https://localhost:44327/" + "reader/" + "getAllReaders").subscribe(response => {
      this.readers = response;
    },
      error => {
        console.log(error);
      });
  }

  getAllBooks() {
    this.http.get<Array<BookViewModel>>("https://localhost:44327/" + "book/" + "getAllBooks").subscribe(response => {
      this.books = response;
    },
      error => {
        console.log(error);
      });
  }

}
