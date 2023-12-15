import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './modules/auth/auth.module';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { EmployeesModule } from './modules/employees/employees.module';
import { ActivitiesModule } from './modules/activities/activities.module';
import { DepartmentsModule } from './modules/departments/departments.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    AuthModule,
    EmployeesModule,
    ActivitiesModule,
    DepartmentsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
