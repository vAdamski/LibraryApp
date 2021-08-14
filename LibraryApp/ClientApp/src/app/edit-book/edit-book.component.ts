import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookViewModel } from '../Models/book-view-model.model';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {

  book = new BookViewModel();

  constructor(private http: HttpClient, private router: Router) { }

  

  ngOnInit() {
    this.book = history.state.data;
    console.log(this.book);
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

  saveBookChanges() {
    if (!(this.book.author === '' || this.book.title === '' || this.book.isbn === '')) {
      this.http.post("https://localhost:44327/" + "book/" + "editBookInDatabase", this.book).subscribe(response => {
        this.router.navigate(['/bookList']);
      },
        error => {
        });
    } else {
      console.log("bad object data");
    }
  }
}
