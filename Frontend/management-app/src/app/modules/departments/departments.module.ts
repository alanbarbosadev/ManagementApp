import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentListComponent } from './department-list/department-list.component';
import { DepartmentComponent } from './department-list/department/department.component';
import { DepartmentDetailComponent } from './department-detail/department-detail.component';
import { DepartmentRoutingModule } from './department-routing.module';

@NgModule({
  declarations: [
    DepartmentListComponent,
    DepartmentComponent,
    DepartmentDetailComponent,
  ],
  imports: [CommonModule, DepartmentRoutingModule],
  exports: [DepartmentRoutingModule],
})
export class DepartmentsModule {}
