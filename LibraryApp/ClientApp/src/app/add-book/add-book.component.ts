import { HttpClient } from '@angular/common/http';
import { conditionallyCreateMapObjectLiteral } from '@angular/compiler/src/render3/view/util';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookViewModel } from '../Models/book-view-model.model';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  book = new BookViewModel();

  constructor(private http: HttpClient, private router: Router) {
  }

  ngOnInit() {
    this.book.isAvailable = true;
    this.book.title = '';
    this.book.author = '';
    this.book.isbn = '';
  }



  onItemChange(event: any) {

    if (event.target.value === 'true') {
      this.book.isAvailable = true;
      console.log(this.book);
    }
    else {
      this.book.isAvailable = false;
      console.log(this.book);
    }
  }

  addBookToDatabase() {
    if (!(this.book.author === '' || this.book.title === '' || this.book.isbn === '')) {
      this.http.post("https://localhost:44327/" + "book/" + "addBookToDatabase", this.book).subscribe(response => {
        this.router.navigate(['/bookList']);
      },
        error => {
        });
    } else {
      console.log("bad object data");
    }
  }
}
