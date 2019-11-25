import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MakerevComponent } from './makerev.component';

describe('MakerevComponent', () => {
  let component: MakerevComponent;
  let fixture: ComponentFixture<MakerevComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MakerevComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MakerevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
