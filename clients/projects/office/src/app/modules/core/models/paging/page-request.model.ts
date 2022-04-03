import { Sort } from './sort.model';

export class PageRequest {
  public index: number;
  public size: number;
  public sort: Sort;

  constructor(index: number = 1, size: number = 10, sort: Sort = new Sort()) {
    this.index = index;
    this.size = size;
    this.sort = sort;
  }

  public static from(index: number, size: number, sortColumn: string, sortDirection: string): PageRequest {
    const sort: Sort = Sort.from(sortColumn, sortDirection);
    return new PageRequest(index, size, sort);
  }
}
