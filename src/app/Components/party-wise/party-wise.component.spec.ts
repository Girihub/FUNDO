import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartyWiseComponent } from './party-wise.component';

describe('PartyWiseComponent', () => {
  let component: PartyWiseComponent;
  let fixture: ComponentFixture<PartyWiseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartyWiseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartyWiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
