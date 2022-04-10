export type XyzDatatableSize = 'middle' | 'small' | 'default';

export interface XyzDatatableSettings {
  bordered: boolean,
  size: XyzDatatableSize
}

export const DEFAULT_XYZ_DATATABLE_SETTINGS: XyzDatatableSettings = {
  bordered: true,
  size: 'middle'
};
