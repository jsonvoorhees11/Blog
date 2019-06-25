import { Component, OnInit } from '@angular/core';
import { Article } from '../shared/article.model';
import { ArticleService } from '../shared/services/article.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.scss']
})
export class ArticlesComponent implements OnInit {
  articleList: Article[]=[];
  categoryId: string='';
  constructor(private route: ActivatedRoute,private articleService: ArticleService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.categoryId = params['categoryId'];
      if(!this.categoryId){
        this.getArticles();
      }
      else{
        this.getArticlesByCategory(this.categoryId);
      }});
  }

  getArticles() : void{
    this.articleService.getArticles()
      .subscribe(articles => this.articleList = articles);
  }

  getArticlesByCategory(categoryId:string): void{
    this.articleService.getArticlesByCategory(categoryId)
      .subscribe(articles => this.articleList = articles);
  }
}
