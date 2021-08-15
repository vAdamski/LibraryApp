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
}
