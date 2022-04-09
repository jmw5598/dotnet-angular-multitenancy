import { ColumnType } from "./column-type.enum";

export interface ColumnDefinition {
  label: string,
  property: string,
  type: ColumnType,
  align?: string,
  width?: number,
  isVisible?: boolean,
  canModify?: boolean
}
