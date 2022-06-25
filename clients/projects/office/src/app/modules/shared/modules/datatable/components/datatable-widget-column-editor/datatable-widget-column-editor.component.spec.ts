import { ComponentFixture, TestBed } from '@angular/core/testing';

import { XyzDatatableWidgetColumnEditorComponent } from './datatable-widget-column-editor.component';

describe('XyzDatatableWidgetColumnEditorComponent', () => {
  let component: XyzDatatableWidgetColumnEditorComponent;
  let fixture: ComponentFixture<XyzDatatableWidgetColumnEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ XyzDatatableWidgetColumnEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(XyzDatatableWidgetColumnEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
