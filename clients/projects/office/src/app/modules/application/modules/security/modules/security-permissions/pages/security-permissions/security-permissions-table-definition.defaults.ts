import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';

export const defaultSecurityPermissionsTableDefinition: TableDefinition = {
  title: 'Named Template Permisssions',
  columns: [
    {
      label: 'Name',
      property: 'name',
      type: ColumnType.TEXT,
      width: '300px',
      sortable: true
    } as ColumnDefinition,
    {
      label: 'Description',
      property: 'description',
      type: ColumnType.TEXT,
      width: '400px',
      sortable: true
    } as ColumnDefinition,
    {
      label: 'Created On',
      property: 'createdOn',
      type: ColumnType.DATE,
      width: '125px'
    } as ColumnDefinition,
    {
      label: 'Created By',
      property: 'createdBy.userName',
      type: ColumnType.EMAIL,
      width: '200px'
    } as ColumnDefinition,
    {
      label: 'Updated On',
      property: 'updatedOn',
      type: ColumnType.DATE,
      width: '125px'
    } as ColumnDefinition,
    {
      label: 'Updated By',
      property: 'updatedBy.userName',
      type: ColumnType.EMAIL,
      width: '200px'
    } as ColumnDefinition,
  ]
} as TableDefinition;
