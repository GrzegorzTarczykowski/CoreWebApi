import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/post/shared/post.model';

@Component({
  selector: 'app-main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {

  posts: Post[] = [
    {
      id: 1,
      body: 'post body',
      title: 'title',
      userId: 3,
      comments: [
        {
          body: 'sasdd',
          email: 'sd@sd',
          name: 'sadName',
          id: 4,
          postId: 5
        }
      ]
    },
    {
      id: 2,
      body: 'post body second',
      title: 'title second',
      userId: 3,
    },
    {
      id: 1,
      body: 'post body',
      title: 'title',
      userId: 3,
      comments: [
        {
          body: 'comment body',
          email: 'abc@o2.pl',
          id: 1,
          name: 'nickname',
          postId: 1
        },
        {
          body: 'comment body',
          email: 'abc@o2.pl',
          id: 1,
          name: 'nickname',
          postId: 1
        },
        {
          body: 'comment body',
          email: 'abc@o2.pl',
          id: 1,
          name: 'nickname',
          postId: 1
        }
      ]
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
