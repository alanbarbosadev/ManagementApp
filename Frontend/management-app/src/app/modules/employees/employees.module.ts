import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeeRoutingModule } from './employee-routing.module';

@NgModule({
  declarations: [EmployeeListComponent, EmployeeDetailComponent],
  imports: [CommonModule, EmployeeRoutingModule],
  exports: [EmployeeRoutingModule],
})
export class EmployeesModule {}
