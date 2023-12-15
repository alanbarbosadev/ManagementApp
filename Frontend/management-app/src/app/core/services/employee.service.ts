import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pagination } from '../models/Pagination';
import { Employee } from '../models/employee.mode';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getEmployees(): Observable<Pagination<Employee>> {
    return this.http.get<Pagination<Employee>>(
      `${environment.baseApiUrl}Employee`
    );
  }
}
