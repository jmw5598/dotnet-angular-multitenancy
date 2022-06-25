import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';

export const defaultBillingInvoicesTableDefinition: TableDefinition = {
  title: 'Billing Invoices',
  columns: [
    {
      label: 'Transaction Date',
      property: 'transactionDate',
      type: ColumnType.DATE_TIME,
      isVisible: true,
      canModify: false,
      sortable: true,
      width: '200px',
    } as ColumnDefinition,
    {
      label: 'Status',
      property: 'status',
      type: ColumnType.TITLE,
      isVisible: true,
      canModify: false,
      sortable: true,
      width: '150px',
    } as ColumnDefinition,
    {
      label: 'Amount Paid',
      property: 'amountPaid',
      type: ColumnType.CURRENCY,
      isVisible: true,
      canModify: false,
      width: '100px',
    } as ColumnDefinition,
    {
      label: 'Amount Due',
      property: 'amountDue',
      type: ColumnType.CURRENCY,
      isVisible: true,
      canModify: true,
      width: '100px',
    } as ColumnDefinition,
    {
      label: 'Period Start',
      property: 'periodStartDate',
      type: ColumnType.DATE,
      isVisible: true,
      canModify: true,
      width: '200px',
    } as ColumnDefinition,
    {
      label: 'Period End',
      property: 'periodEndDate',
      type: ColumnType.DATE,
      isVisible: true,
      canModify: true,
      width: '200px',
    } as ColumnDefinition,
    {
      label: 'Paid On',
      property: 'paidDate',
      type: ColumnType.DATE_TIME,
      isVisible: true,
      canModify: true,
      width: '200px',
    } as ColumnDefinition,
    {
      label: 'Billing Reason',
      property: 'billingReason',
      type: ColumnType.TITLE,
      isVisible: false,
      canModify: true,
      sortable: true,
      width: '150px',
    } as ColumnDefinition
  ]
} as TableDefinition;

export const getDefaultBillingInvoicesTableDefinition = (): TableDefinition => {
  return JSON.parse(JSON.stringify(defaultBillingInvoicesTableDefinition)) as TableDefinition
};
