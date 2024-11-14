import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthhubLoginComponent } from './authhub-login.component';

describe('AuthhubLoginComponent', () => {
  let component: AuthhubLoginComponent;
  let fixture: ComponentFixture<AuthhubLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuthhubLoginComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuthhubLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
