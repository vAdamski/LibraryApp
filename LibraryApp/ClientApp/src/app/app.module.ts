import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BookListComponent } from './book-list/book-list.component';
import { AddBookComponent } from './add-book/add-book.component';
import { EditBookComponent } from './edit-book/edit-book.component';
import { ReaderListComponent } from './reader-list/reader-list.component';
import { AddReaderComponent } from './add-reader/add-reader.component';
import { EditReaderComponent } from './edit-reader/edit-reader.component';
import { AddBorrowerComponent } from './add-borrower/add-borrower.component';
import { EditBorrowerComponent } from './edit-borrower/edit-borrower.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BookListComponent,
    AddBookComponent,
    EditBookComponent,
    ReaderListComponent,
    AddReaderComponent,
    EditReaderComponent,
    AddBorrowerComponent,
    EditBorrowerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'bookList', component: BookListComponent },
      { path: 'addBook', component: AddBookComponent },
      { path: 'editBook', component: EditBookComponent },
      { path: 'readerList', component: ReaderListComponent },
      { path: 'addReader', component: AddReaderComponent },
      { path: 'editReader', component: EditReaderComponent },
      { path: 'addBorrower', component: AddBorrowerComponent },
      { path: 'editBorrower', component: EditBorrowerComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
