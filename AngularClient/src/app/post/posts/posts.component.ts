import { Component, Input, OnInit } from '@angular/core';
import { Post } from '../shared/post.model';
import { timer } from 'rxjs';
import { PostService } from '../shared/post.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent implements OnInit {

  @Input() posts: Post[];

  loading = true;

  constructor(private postService: PostService) { }

  ngOnInit(): void {
    // timer(3000).subscribe(() => this.loading = false);
    this.postService.getPosts().subscribe(
      posts => {
        this.posts = posts; 
        this.loading = false; 
    });
  }
}
