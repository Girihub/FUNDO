import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetLabelComponent } from './get-label.component';

describe('GetLabelComponent', () => {
  let component: GetLabelComponent;
  let fixture: ComponentFixture<GetLabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetLabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetLabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
