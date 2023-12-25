export class EmployeeParams {
  departmentId: string = '0';
  positionId: string = '0';
  search: string = '';
  sort: string = 'byName';
  currentPage: number = 1;
  pageSize: number = 5;
}
