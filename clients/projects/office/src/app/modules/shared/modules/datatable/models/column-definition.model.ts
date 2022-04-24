import { ColumnType } from "./column-type.enum";

export interface ColumnDefinition {
  label: string,
  property: string,
  type: ColumnType,
  align?: string,
  width?: string | null,
  isVisible?: boolean,
  canModify?: boolean,
}
