import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReaderViewModel } from '../Models/reader-view-model.model';

@Component({
  selector: 'app-edit-reader',
  templateUrl: './edit-reader.component.html',
  styleUrls: ['./edit-reader.component.css']
})
export class EditReaderComponent implements OnInit {

  reader = new ReaderViewModel();

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.reader = history.state.data;
  }

  saveReaderChanges() {
    if (!(this.reader.name === '' || this.reader.surname === '' || this.reader.email === '' || this.reader.phoneNumber === '')) {
      this.http.post("https://localhost:44327/" + "reader/" + "editReaderInDatabase", this.reader).subscribe(response => {
        this.router.navigate(['/readerList']);
      },
        error => {
        });
    } else {
      console.log("bad object data");
    }
  }
}
