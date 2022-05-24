import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateModulePermissionNameUpdateFormComponent } from './template-module-permission-name-update-form.component';

describe('TemplateModulePermissionNameUpdateFormComponent', () => {
  let component: TemplateModulePermissionNameUpdateFormComponent;
  let fixture: ComponentFixture<TemplateModulePermissionNameUpdateFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TemplateModulePermissionNameUpdateFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateModulePermissionNameUpdateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
