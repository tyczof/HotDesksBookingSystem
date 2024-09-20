import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeDeskFormComponent } from './change-desk-form.component';

describe('ChangeDeskFormComponent', () => {
  let component: ChangeDeskFormComponent;
  let fixture: ComponentFixture<ChangeDeskFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChangeDeskFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangeDeskFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
