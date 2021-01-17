import { Comment } from '../comment/shared/comment.model'

export interface Post {
    userId: number;
    id: number;
    title: string;
    body: string;
    comments?: Comment[];
}