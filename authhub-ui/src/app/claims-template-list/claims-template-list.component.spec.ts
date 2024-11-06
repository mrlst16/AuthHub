import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClaimsTemplateListComponent } from './claims-template-list.component';

describe('ClaimsTemplateListComponent', () => {
  let component: ClaimsTemplateListComponent;
  let fixture: ComponentFixture<ClaimsTemplateListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClaimsTemplateListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClaimsTemplateListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
