import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentListComponent } from './department-list/department-list.component';
import { DepartmentDetailComponent } from './department-detail/department-detail.component';

const DEPARTMENTS_ROUTES: Routes = [
  {
    path: 'departments/list',
    component: DepartmentListComponent,
  },
  {
    path: 'departments/detail/:id',
    component: DepartmentDetailComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(DEPARTMENTS_ROUTES)],
})
export class DepartmentRoutingModule {}
