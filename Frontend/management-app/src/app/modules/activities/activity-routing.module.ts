import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ActivityDetailComponent } from './activity-detail/activity-detail.component';
import { ActivityListComponent } from './activity-list/activity-list.component';

const ACTIVITIES_ROUTES: Routes = [
  {
    path: 'activities/list',
    component: ActivityListComponent,
  },
  {
    path: 'activities/detail/:id',
    component: ActivityDetailComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(ACTIVITIES_ROUTES)],
})
export class ActivityRoutingModule {}
