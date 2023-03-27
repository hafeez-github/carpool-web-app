import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OfferMenu1Component } from './offer-menu1.component';

describe('OfferMenu1Component', () => {
  let component: OfferMenu1Component;
  let fixture: ComponentFixture<OfferMenu1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OfferMenu1Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OfferMenu1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
