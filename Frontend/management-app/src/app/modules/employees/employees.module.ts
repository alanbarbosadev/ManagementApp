import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeComponent } from './employee-list/employee/employee.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';



@NgModule({
  declarations: [
    EmployeeListComponent,
    EmployeeComponent,
    EmployeeDetailComponent
  ],
  imports: [
    CommonModule
  ]
})
export class EmployeesModule { }
