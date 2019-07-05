import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Article } from '../../shared/article.model';
import { ArticleService } from '../../shared/services/article.service';

@Component({
  selector: 'app-article-detail',
  templateUrl: './article-detail.component.html',
  styleUrls: ['./article-detail.component.scss']
})
export class ArticleDetailComponent implements OnInit {
  private slug: string;
  article: Article;
  constructor(private route: ActivatedRoute, private articleService: ArticleService) { }

  ngOnInit() {
    this.route.params.subscribe(params => this.slug = params['slug']);
    this.getArticle();
  }

  getArticle() : void{
    this.articleService.getArticleDetail(this.slug)
      .subscribe(article => this.article = article);
  }
}
