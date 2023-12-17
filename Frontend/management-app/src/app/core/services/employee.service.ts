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
    positionId?: string
  ): Observable<Pagination<Employee>> {
    let params = new HttpParams();

    if (departmentId) params = params.append('departmentId', departmentId);

    if (positionId) params = params.append('positionId', positionId);

    return this.http.get<Pagination<Employee>>(
      `${environment.baseApiUrl}Employee`,
      { params: params }
    );
  }
}
