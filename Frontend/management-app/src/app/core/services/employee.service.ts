import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.mode';
import { environment } from 'src/environments/environment';
import { Pagination } from '../models/pagination';
import { EmployeeParams } from '../models/employeeParams';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getEmployees(
    employeeParams: EmployeeParams
  ): Observable<Pagination<Employee>> {
    let params = new HttpParams();

    if (employeeParams.departmentId && employeeParams.departmentId != '0') {
      params = params.append('departmentId', employeeParams.departmentId);
    }

    if (employeeParams.positionId && employeeParams.positionId != '0') {
      params = params.append('positionId', employeeParams.positionId);
    }

    if (employeeParams.search) {
      params = params.append('search', employeeParams.search);
    }

    if (employeeParams.sort) {
      params = params.append('sort', employeeParams.sort);
    }

    params = params.append('currentPage', employeeParams.currentPage);
    params = params.append('pageSize', employeeParams.pageSize);

    return this.http.get<Pagination<Employee>>(
      `${environment.baseApiUrl}Employee`,
      { params: params }
    );
  }
}
