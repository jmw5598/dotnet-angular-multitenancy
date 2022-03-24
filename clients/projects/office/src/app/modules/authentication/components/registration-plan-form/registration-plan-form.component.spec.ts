import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrationPlanFormComponent } from './registration-plan-form.component';

describe('RegistrationPlanFormComponent', () => {
  let component: RegistrationPlanFormComponent;
  let fixture: ComponentFixture<RegistrationPlanFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistrationPlanFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationPlanFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
