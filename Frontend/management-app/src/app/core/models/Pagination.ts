export interface Pagination<T> {
  currentPage: number;
  pageSize: number;
  count: number;
  data: T[];
}
