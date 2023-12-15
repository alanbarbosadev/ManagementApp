import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';

const EMPLOYEES_ROUTES: Routes = [
  {
    path: 'employees/list',
    component: EmployeeListComponent,
  },
  {
    path: 'employees/detail/:id',
    component: EmployeeDetailComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(EMPLOYEES_ROUTES)],
})
export class EmployeeRoutingModule {}
