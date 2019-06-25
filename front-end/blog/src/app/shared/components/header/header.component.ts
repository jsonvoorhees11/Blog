import { Component, OnInit } from '@angular/core';
import { Category } from '../../category.model';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public categoryList: Category[];
  constructor(private categoryService: CategoryService) { }

  ngOnInit() {
    this.getCategories();
  }

  getCategories(): void{
    this.categoryService
      .getCategories().subscribe(categories => this.categoryList = categories);
  }
}
