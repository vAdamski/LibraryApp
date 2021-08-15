import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookViewModel } from '../Models/book-view-model.model';
import { BorrowerViewModel } from '../Models/borrower-view-model.model';
import { ReaderViewModel } from '../Models/reader-view-model.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-add-borrower',
  templateUrl: './add-borrower.component.html',
  styleUrls: ['./add-borrower.component.css']
})
export class AddBorrowerComponent implements OnInit {

  books: Array<BookViewModel>;
  readers: Array<ReaderViewModel>;


  borrower = new BorrowerViewModel();

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.getAllReaders();
    this.getAllAvailableBooks();
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

  getAllAvailableBooks() {
    this.http.get<Array<BookViewModel>>("https://localhost:44327/" + "book/" + "getAllUnborrowedBooks").subscribe(response => {
      this.books = response;
      console.log(response);
    },
      error => {
        console.log(error);
      });
  }

  addBorrowerToDatabase() {
    this.http.post("https://localhost:44327/" + "borrower/" + "addBorrowerToDatabase", this.borrower).subscribe(response => {
      this.router.navigate(['']);
    },
      error => {
        console.log(error);
      });
  }

  test() {
    console.log(this.borrower);
  }

}
