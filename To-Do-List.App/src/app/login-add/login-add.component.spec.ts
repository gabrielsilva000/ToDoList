import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginAddComponent } from './login-add.component';

describe('LoginAddComponent', () => {
  let component: LoginAddComponent;
  let fixture: ComponentFixture<LoginAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginAddComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
