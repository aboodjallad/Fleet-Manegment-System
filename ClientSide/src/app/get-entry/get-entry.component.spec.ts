import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetEntryComponent } from './get-entry.component';

describe('GetEntryComponent', () => {
  let component: GetEntryComponent;
  let fixture: ComponentFixture<GetEntryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetEntryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
