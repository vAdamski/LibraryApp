import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BookViewModel } from '../Models/book-view-model.model';
import { BorrowerViewModel } from '../Models/borrower-view-model.model';
import { ReaderViewModel } from '../Models/reader-view-model.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  borrowers: Array<BorrowerViewModel>;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.getAllBorrowers();
  }

  getAllBorrowers() {
    this.http.get<Array<BorrowerViewModel>>("https://localhost:44327/" + "borrower/" + "getAllBorrowers").subscribe(response => {
      this.borrowers = response;
    },
      error => {
        console.log(error);
      });
  }

  deleteBorrowerFromDatabase(borrowerId, bookId) {
    this.http.get("https://localhost:44327/" + "borrower/" + "deleteBorrowerFromDatabase" + "?id=" + borrowerId + "&bookId=" + bookId).subscribe(response => {
      location.reload();
    },
      error => {
        console.log(error);
      });
  }

  editBorrower(borrowerObject) {
    this.router.navigate(['/editBorrower'], { state: { data: borrowerObject } });
  }
}
