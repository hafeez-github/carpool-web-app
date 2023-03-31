import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OfferMenu2Component } from './offer-menu2.component';

describe('OfferMenu2Component', () => {
  let component: OfferMenu2Component;
  let fixture: ComponentFixture<OfferMenu2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OfferMenu2Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OfferMenu2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
