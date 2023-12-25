import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/core/models/department';
import { Employee } from 'src/app/core/models/employee.mode';
import { Position } from 'src/app/core/models/position';
import { DepartmentService } from 'src/app/core/services/department.service';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { PositionService } from 'src/app/core/services/position.service';
import { EmployeeParams } from 'src/app/core/models/employeeParams';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  departments: Department[] = [];
  positions: Position[] = [];
  employeeParams = new EmployeeParams();
  currentPage!: number;
  pageSize!: number;
  count!: number;
  first: number = 0;
  rows: number = 10;

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
    this.employeeService.getEmployees(this.employeeParams).subscribe({
      next: (response) => {
        this.employees = response.data;
        this.employeeParams.currentPage = response.currentPage;
        this.employeeParams.pageSize = response.pageSize;
        this.count = response.count;
        console.log(response);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  loadDepartments(): void {
    this.departmentService.getDepartments().subscribe({
      next: (response) => {
        this.departments = [{ id: '0', name: 'All' }, ...response];
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  loadPositions(): void {
    this.positionService.getPositions().subscribe({
      next: (response) => {
        this.positions = [{ id: '0', name: 'All' }, ...response];
      },
      error: (error) => {
        console.log(error);
      },
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

  onSearch(): void {
    this.loadEmployees();
  }

  onPageChanged(event: any): void {
    if (this.employeeParams.currentPage != event.page) {
      this.employeeParams.currentPage = event.page;
      this.loadEmployees();
    }
  }

  getShowingResult(): number {
    if (
      this.employeeParams.currentPage * this.employeeParams.pageSize >
      this.count
    ) {
      return this.count;
    }
    return this.employeeParams.currentPage * this.employeeParams.pageSize;
  }
}
