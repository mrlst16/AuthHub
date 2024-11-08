import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClaimsTemplateComponent } from './claims-template.component';

describe('ClaimsTemplateComponent', () => {
  let component: ClaimsTemplateComponent;
  let fixture: ComponentFixture<ClaimsTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClaimsTemplateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClaimsTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
