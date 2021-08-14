import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBorrowerComponent } from './edit-borrower.component';

describe('EditBorrowerComponent', () => {
  let component: EditBorrowerComponent;
  let fixture: ComponentFixture<EditBorrowerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditBorrowerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditBorrowerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
