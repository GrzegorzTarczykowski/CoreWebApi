import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from '../post/post.component';
import { CommentComponent } from './comment/comment.component';
import { MaterialDepdendenciesModule } from '../material-depdendencies/material-depdendencies.module';



@NgModule({
  declarations: [PostComponent, CommentComponent],
  imports: [
    CommonModule,
    MaterialDepdendenciesModule
  ],
  exports: [
    PostComponent
  ]
})
export class PostModule { }
