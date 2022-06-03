export type XyzDatatableSize = 'middle' | 'small' | 'default';

export interface XyzDatatableScrollConfig {
  x?: string,
  y?: string
}

export interface XyzDatatablePageSizeChanger {
  show: boolean,
  options: number[]
}

export interface XyzDatatableSettings {
  bordered: boolean,
  size: XyzDatatableSize,
  scroll: XyzDatatableScrollConfig,
  pageSizeChanger: XyzDatatablePageSizeChanger
}

export const DEFAULT_XYZ_DATATABLE_SETTINGS: XyzDatatableSettings = {
  bordered: true,
  size: 'middle',
  scroll: {
    y: '500px'
  },
  pageSizeChanger: {
    show: true,
    options: [10, 25, 50, 100]
  }
};
