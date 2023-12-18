import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.mode';
import { environment } from 'src/environments/environment';
import { Pagination } from '../models/pagination';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getEmployees(
    departmentId?: string,
    positionId?: string,
    sort?: string
  ): Observable<Pagination<Employee>> {
    let params = new HttpParams();

    if (departmentId && departmentId != '0') {
      params = params.append('departmentId', departmentId);
    }

    if (positionId && positionId != '0') {
      params = params.append('positionId', positionId);
    }

    if (sort) {
      params = params.append('sort', sort);
    }

    return this.http.get<Pagination<Employee>>(
      `${environment.baseApiUrl}Employee`,
      { params: params }
    );
  }
}
