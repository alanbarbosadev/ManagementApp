import { AuthRoutingModule } from './../auth/auth-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivityDetailComponent } from './activity-detail/activity-detail.component';
import { ActivityComponent } from './activity-list/activity/activity.component';
import { ActivityListComponent } from './activity-list/activity-list.component';
import { ActivityRoutingModule } from './activity-routing.module';

@NgModule({
  declarations: [
    ActivityDetailComponent,
    ActivityListComponent,
    ActivityComponent,
  ],
  imports: [CommonModule, AuthRoutingModule],
  exports: [ActivityRoutingModule],
})
export class ActivitiesModule {}
