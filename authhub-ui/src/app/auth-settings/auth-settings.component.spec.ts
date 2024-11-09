import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthSettingsComponent } from './auth-settings.component';

describe('AuthSettingsComponent', () => {
  let component: AuthSettingsComponent;
  let fixture: ComponentFixture<AuthSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuthSettingsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
