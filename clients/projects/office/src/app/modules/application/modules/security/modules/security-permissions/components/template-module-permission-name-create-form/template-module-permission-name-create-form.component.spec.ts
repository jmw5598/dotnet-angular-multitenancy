import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateModulePermissionNameCreateFormComponent } from './template-module-permission-name-create-form.component';

describe('TemplateModulePermissionNameCreateFormComponent', () => {
  let component: TemplateModulePermissionNameCreateFormComponent;
  let fixture: ComponentFixture<TemplateModulePermissionNameCreateFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TemplateModulePermissionNameCreateFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateModulePermissionNameCreateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
