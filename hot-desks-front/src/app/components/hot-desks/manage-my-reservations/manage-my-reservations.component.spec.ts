import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageMyReservationsComponent } from './manage-my-reservations.component';

describe('ManageMyReservationsComponent', () => {
  let component: ManageMyReservationsComponent;
  let fixture: ComponentFixture<ManageMyReservationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ManageMyReservationsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageMyReservationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
