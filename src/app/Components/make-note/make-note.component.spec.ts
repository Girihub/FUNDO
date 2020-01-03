import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MakeNoteComponent } from './make-note.component';

describe('MakeNoteComponent', () => {
  let component: MakeNoteComponent;
  let fixture: ComponentFixture<MakeNoteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MakeNoteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MakeNoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
