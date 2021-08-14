import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReaderViewModel } from '../Models/reader-view-model.model';

@Component({
  selector: 'app-reader-list',
  templateUrl: './reader-list.component.html',
  styleUrls: ['./reader-list.component.css']
})
export class ReaderListComponent implements OnInit {

  readers: Array<ReaderViewModel>;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.getAllReaders();
  }

  getAllReaders() {
    this.http.get<Array<ReaderViewModel>>("https://localhost:44327/" + "reader/" + "getAllReaders").subscribe(response => {
      this.readers = response;
    },
      error => {
        console.log(error);
      });
  }

  deleteReaderFromDatabase(readerId) {
    this.http.get("https://localhost:44327/" + "reader/" + "deleteReaderFromDatabase" + "?id=" + readerId).subscribe(response => {
      location.reload();
    },
      error => {
        console.log(error);
      });
  }

  editReader(readerObject) {
    this.router.navigate(['/editReader'], { state: { data: readerObject } });
  }
}
