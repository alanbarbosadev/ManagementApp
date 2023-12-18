import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeeRoutingModule } from './employee-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [EmployeeListComponent, EmployeeDetailComponent],
  imports: [CommonModule, EmployeeRoutingModule, FormsModule],
  exports: [EmployeeRoutingModule],
})
export class EmployeesModule {}
