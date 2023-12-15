import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () =>
      import('./modules/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'employees',
    loadChildren: () =>
      import('./modules/employees/employees.module').then(
        (m) => m.EmployeesModule
      ),
  },
  {
    path: 'activities',
    loadChildren: () =>
      import('./modules/activities/activities.module').then(
        (m) => m.ActivitiesModule
      ),
  },
  {
    path: 'departments',
    loadChildren: () =>
      import('./modules/departments/departments.module').then(
        (m) => m.DepartmentsModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
