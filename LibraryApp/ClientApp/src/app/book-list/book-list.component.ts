import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BookViewModel } from '../Models/book-view-model.model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
})
export class BookListComponent implements OnInit {

  books: Array<BookViewModel>;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getAllBooks();
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
