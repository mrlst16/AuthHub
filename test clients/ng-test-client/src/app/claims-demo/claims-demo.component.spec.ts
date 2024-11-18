import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClaimsDemoComponent } from './claims-demo.component';

describe('ClaimsDemoComponent', () => {
  let component: ClaimsDemoComponent;
  let fixture: ComponentFixture<ClaimsDemoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClaimsDemoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClaimsDemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
