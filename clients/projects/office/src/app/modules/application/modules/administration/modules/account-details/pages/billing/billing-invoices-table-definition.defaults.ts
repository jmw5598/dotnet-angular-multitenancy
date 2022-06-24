import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';

export const defaultBillingInvoicesTableDefinition: TableDefinition = {
  title: 'Billing Invoices',
  columns: [
    {
      label: 'Transaction Date',
      property: 'transactionDate',
      type: ColumnType.DATE_TIME,
      sortable: true,
      width: '200px'
    } as ColumnDefinition,
    {
      label: 'Status',
      property: 'status',
      type: ColumnType.TITLE,
      sortable: true,
      width: '150px'
    } as ColumnDefinition,
    {
      label: 'Amount Paid',
      property: 'amountPaid',
      type: ColumnType.CURRENCY,
      width: '100px'
    } as ColumnDefinition,
    {
      label: 'Amount Due',
      property: 'amountDue',
      type: ColumnType.CURRENCY,
      width: '100px'
    } as ColumnDefinition,
    {
      label: 'Period Start',
      property: 'periodStartDate',
      type: ColumnType.DATE,
      width: '200px'
    } as ColumnDefinition,
    {
      label: 'Period End',
      property: 'periodEndDate',
      type: ColumnType.DATE,
      width: '200px'
    } as ColumnDefinition,
    {
      label: 'Paid On',
      property: 'paidDate',
      type: ColumnType.DATE_TIME,
      width: '200px'
    } as ColumnDefinition,
    {
      label: 'Billing Reason',
      property: 'billingReason',
      type: ColumnType.TITLE,
      sortable: true,
      width: '150px'
    } as ColumnDefinition
  ]
} as TableDefinition;
