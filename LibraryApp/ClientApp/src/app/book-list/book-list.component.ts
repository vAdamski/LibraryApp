import { HttpClient } from '@angular/common/http';
import { HtmlParser } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookViewModel } from '../Models/book-view-model.model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
})
export class BookListComponent implements OnInit {

  books: Array<BookViewModel>;

  constructor(private http: HttpClient, private router: Router) { }

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



  deleteBookFromDatabase(bookId) {
    this.http.get("https://localhost:44327/" + "book/" + "deleteBookFromDatabase" + "?id=" + bookId).subscribe(response => {
      location.reload();
    },
      error => {
        console.log(error);
      });
  }

  editBook(bookObject) {
    this.router.navigate(['/editBook'], { state: { data: bookObject } });
  }
}
