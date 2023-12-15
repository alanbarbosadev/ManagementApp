import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/core/models/Pagination';
import { Employee } from 'src/app/core/models/employee.mode';
import { EmployeeService } from 'src/app/core/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.employeeService
      .getEmployees()
      .subscribe((response: Pagination<Employee>) => {
        this.employees = response.data;
        console.log(this.employees);
      });
  }
}
