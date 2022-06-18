import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';

export const defaultUserAccountsTableDefinition: TableDefinition = {
    title: 'User Accounts',
    columns: [
      {
        label: '',
        property: 'avatarUrl',
        type: ColumnType.IMAGE,
        width: '75px'
      },
      {
        label: 'User Name',
        property: 'userName',
        type: ColumnType.TEXT,
        width: '200px',
        sortable: true

      } as ColumnDefinition,
      {
        label: 'Email',
        property: 'email',
        type: ColumnType.EMAIL,
        width: '200px',
        sortable: true
      } as ColumnDefinition,
      {
        label: 'First name',
        property: 'profile.firstName',
        type: ColumnType.TEXT,
        width: '200px',
        sortable: true
      } as ColumnDefinition,
      {
        label: 'Last Name',
        property: 'profile.lastName',
        type: ColumnType.TEXT,
        width: '200px',
        sortable: true
      } as ColumnDefinition,
    ]
  } as TableDefinition;
