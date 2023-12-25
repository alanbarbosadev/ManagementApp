import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeeRoutingModule } from './employee-routing.module';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [EmployeeListComponent, EmployeeDetailComponent],
  imports: [CommonModule, EmployeeRoutingModule, FormsModule, SharedModule],
  exports: [EmployeeRoutingModule],
})
export class EmployeesModule {}
