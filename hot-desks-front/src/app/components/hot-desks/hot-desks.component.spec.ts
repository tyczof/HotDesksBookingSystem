import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotDesksComponent } from './hot-desks.component';

describe('HotDesksComponent', () => {
  let component: HotDesksComponent;
  let fixture: ComponentFixture<HotDesksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotDesksComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotDesksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
