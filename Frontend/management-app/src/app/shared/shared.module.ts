import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [NavBarComponent, FooterComponent],
  imports: [CommonModule, RouterModule, PaginationModule.forRoot()],
  exports: [NavBarComponent, FooterComponent, PaginationModule],
})
export class SharedModule {}
