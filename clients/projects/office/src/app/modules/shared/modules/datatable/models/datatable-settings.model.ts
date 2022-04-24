export type XyzDatatableSize = 'middle' | 'small' | 'default';

export interface XyzDatatableScrollConfig {
  x?: string,
  y?: string
}

export interface XyzDatatableSettings {
  bordered: boolean,
  size: XyzDatatableSize,
  scroll: XyzDatatableScrollConfig
}

export const DEFAULT_XYZ_DATATABLE_SETTINGS: XyzDatatableSettings = {
  bordered: true,
  size: 'middle',
  scroll: {
    y: '240px'
  }
};
