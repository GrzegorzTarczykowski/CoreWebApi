import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { TopbarComponent } from './topbar/topbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { MainContentComponent } from './main-content/main-content.component';
import { MaterialDepdendenciesModule } from '../material-depdendencies/material-depdendencies.module';
import { PostModule } from '../post/post.module';

@NgModule({
  declarations: [
    LayoutComponent,
    TopbarComponent,
    SidebarComponent,
    MainContentComponent],
  imports: [
    CommonModule,
    MaterialDepdendenciesModule,
    PostModule
  ],
  exports: [
    LayoutComponent
  ]
})
export class LayoutModule { }
