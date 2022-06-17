import { ColumnDefinition, ColumnType, TableDefinition } from "@xyz/office/modules/shared/modules/datatable";

export const defaultBillingInvoicesTableDefinition: TableDefinition = {
  title: 'Billing Invoices',
  columns: [
    {
      label: 'Transaction Date',
      property: 'transactionDate',
      type: ColumnType.DATE_TIME,
      width: '200px'
    } as ColumnDefinition,
    {
      label: 'Amount',
      property: 'amount',
      type: ColumnType.CURRENCY,
      width: '100px'
    } as ColumnDefinition,
    {
      label: 'Status',
      property: 'status',
      type: ColumnType.TITLE,
      width: '150px'
    } as ColumnDefinition,
  ]
} as TableDefinition;
