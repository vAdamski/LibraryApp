import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookViewModel } from '../Models/book-view-model.model';
import { BorrowerViewModel } from '../Models/borrower-view-model.model';
import { ReaderViewModel } from '../Models/reader-view-model.model';

@Component({
  selector: 'app-edit-borrower',
  templateUrl: './edit-borrower.component.html',
  styleUrls: ['./edit-borrower.component.css']
})
export class EditBorrowerComponent implements OnInit {

  borrower = new BorrowerViewModel();
  books: Array<BookViewModel>;
  readers: Array<ReaderViewModel>;
  oldBookId: number;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.borrower = history.state.data;
    this.getAllReaders();
    this.getAllBooks();
    this.oldBookId = this.borrower.bookId;
  }

  getAllReaders() {
    this.http.get<Array<ReaderViewModel>>("https://localhost:44327/" + "reader/" + "getAllReaders").subscribe(response => {
      this.readers = response;
      console.log(response);
    },
      error => {
        console.log(error);
      });
  }

  getAllBooks() {
    this.http.get<Array<BookViewModel>>("https://localhost:44327/" + "book/" + "getAllBooks").subscribe(response => {
      this.books = response;
      console.log(response);
    },
      error => {
        console.log(error);
      });
  }

  saveBorrowerChanges() {
    if (this.oldBookId != this.borrower.bookId) {
      this.http.get("https://localhost:44327/" + "book/" + "changeBookBorrowed" + "?bookId=" + this.oldBookId).subscribe(response => {
      },
        error => {
        });
    }
    this.http.post("https://localhost:44327/" + "borrower/" + "editBorrowerInDatabase", this.borrower).subscribe(response => {
        this.router.navigate(['']);
      },
        error => {
        });
  }

}
