import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingMenu1Component } from './booking-menu1.component';

describe('BookingMenuComponent', () => {
  let component: BookingMenu1Component;
  let fixture: ComponentFixture<BookingMenu1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookingMenu1Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookingMenu1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
