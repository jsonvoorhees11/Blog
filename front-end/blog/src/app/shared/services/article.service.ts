import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Article } from '../article.model';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  constructor(private httpClient: HttpClient) { }

  public getArticles() : Observable<Article[]>{
    return this.httpClient
            .get<Article[]>(environment.apiUrl+ 'articles');
  }

  public getArticlesByCategory(categoryId) : Observable<Article[]>{
    return this.httpClient
            .get<Article[]>(environment.apiUrl+`articles/category/${categoryId}`);
  }

  public getArticleDetail(slug: string) : Observable<Article>{
    return this.httpClient
            .get<Article>(environment.apiUrl + `articles/slug/${slug}`);
  }
}
