import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from '../post/post.component';
import { CommentComponent } from './comment/comment.component';
import { MaterialDepdendenciesModule } from '../material-depdendencies/material-depdendencies.module';
import { PostsComponent } from './posts/posts.component';



@NgModule({
  declarations: [PostComponent, CommentComponent, PostsComponent],
  imports: [
    CommonModule,
    MaterialDepdendenciesModule
  ],
  exports: [
    PostsComponent
  ]
})
export class PostModule { }
