import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';

const EMPLOYEES_ROUTES: Routes = [
  {
    path: 'employees/list',
    component: EmployeeListComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(EMPLOYEES_ROUTES)],
})
export class EmployeeRoutingModule {}
