import { User } from './user.model';
import { Tag } from './tag.model';

export class Article{
  id: string;
  title: string;
  slug: string;
  thumbnailImageUrl: string;
  recap: string;
  content: string;
  author: User;
  tags: Tag[];
  createdDate: number;
  lastModifiedDate: number;
}
