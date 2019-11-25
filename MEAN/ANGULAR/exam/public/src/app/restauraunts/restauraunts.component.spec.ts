import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurauntsComponent } from './restauraunts.component';

describe('RestaurauntsComponent', () => {
  let component: RestaurauntsComponent;
  let fixture: ComponentFixture<RestaurauntsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RestaurauntsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurauntsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
