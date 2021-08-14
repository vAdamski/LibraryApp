import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReaderViewModel } from '../Models/reader-view-model.model';

@Component({
  selector: 'app-add-reader',
  templateUrl: './add-reader.component.html',
  styleUrls: ['./add-reader.component.css']
})
export class AddReaderComponent implements OnInit {

  reader = new ReaderViewModel();

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.reader.name = '';
    this.reader.surname = '';
    this.reader.email = '';
    this.reader.phoneNumber = '';
  }


  addReaderToDatabase() {
    if (!(this.reader.name === '' || this.reader.surname === '' || this.reader.email === '' || this.reader.phoneNumber === '')) {
      this.http.post("https://localhost:44327/" + "reader/" + "addReaderToDatabase", this.reader).subscribe(response => {
        this.router.navigate(['/readerList']);
      },
        error => {
        });
    } else {
      console.log("bad object data");
    }
  }
}
