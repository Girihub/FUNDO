import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConstituencyWiseComponent } from './constituency-wise.component';

describe('ConstituencyWiseComponent', () => {
  let component: ConstituencyWiseComponent;
  let fixture: ComponentFixture<ConstituencyWiseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConstituencyWiseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConstituencyWiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
