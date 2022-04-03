import { SortDirection } from './sort-direction.enum';

export class Sort {
  public direction: SortDirection;
  public column: string;

  constructor(column: string = 'id', direction: SortDirection = SortDirection.Ascending) {
    this.direction = direction; 
    this.column = column;
  }

  public static from(column: string, direction: string): Sort {
    switch (direction.toUpperCase()) {
      case 'ASC': return new Sort(column, SortDirection.Ascending);
      case 'DESC': return new Sort(column, SortDirection.Descending);
      default: return new Sort(column, SortDirection.Ascending);
    }
  }
}
