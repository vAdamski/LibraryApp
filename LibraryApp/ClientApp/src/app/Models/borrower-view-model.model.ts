import { BookViewModel } from "./book-view-model.model";
import { ReaderViewModel } from "./reader-view-model.model";

export class BorrowerViewModel {
  public id: number;
  public readerId: number;
  public bookId: number;
  public reader: ReaderViewModel;
  public book: BookViewModel;
  public borrowDate: Date;
  public returnDate: Date;
  public comments: string;
}
