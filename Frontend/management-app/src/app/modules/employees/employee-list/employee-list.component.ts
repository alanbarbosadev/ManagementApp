import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/core/models/pagination';
import { Department } from 'src/app/core/models/department';
import { Employee } from 'src/app/core/models/employee.mode';
import { Position } from 'src/app/core/models/position';
import { DepartmentService } from 'src/app/core/services/department.service';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { PositionService } from 'src/app/core/services/position.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  departments: Department[] = [];
  positions: Position[] = [];
  currentPage?: number;
  pageSize?: number;
  count?: number;
  departmentIdSelected?: string = '0';
  positionIdSelected?: string = '0';
  sort?: string = 'byName';
  search?: string;

  constructor(
    private employeeService: EmployeeService,
    private departmentService: DepartmentService,
    private positionService: PositionService
  ) {}

  ngOnInit(): void {
    this.loadEmployees();
    this.loadDepartments();
    this.loadPositions();
  }

  loadEmployees(): void {
    this.employeeService
      .getEmployees(this.departmentIdSelected, this.positionIdSelected)
      .subscribe((response: Pagination<Employee>) => {
        this.employees = response.data;
      });
  }

  loadDepartments(): void {
    this.departmentService
      .getDepartments()
      .subscribe((response: Department[]) => {
        this.departments = [{ id: '0', name: 'All' }, ...response];
      });
  }

  loadPositions(): void {
    this.positionService.getPositions().subscribe((response: Position[]) => {
      this.positions = [{ id: '0', name: 'All' }, ...response];
    });
  }

  onOrderBySelected(): void {
    this.loadEmployees();
  }

  onDepartmentSelected(): void {
    this.loadEmployees();
  }

  onPositionSelected(): void {
    this.loadEmployees();
  }
}
