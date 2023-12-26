import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { GenericInputComponent } from './generic-input/generic-input.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [NavBarComponent, FooterComponent, GenericInputComponent],
  imports: [
    CommonModule,
    RouterModule,
    PaginationModule.forRoot(),
    ReactiveFormsModule,
  ],
  exports: [
    NavBarComponent,
    FooterComponent,
    PaginationModule,
    GenericInputComponent,
  ],
})
export class SharedModule {}
