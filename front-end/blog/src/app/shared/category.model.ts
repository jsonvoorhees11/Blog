export class Category {
  id: string;
  alias: string;
  description: string;
  subCategory: Category[];
  createdDate: number;
  lastModifiedDate: number;
}
