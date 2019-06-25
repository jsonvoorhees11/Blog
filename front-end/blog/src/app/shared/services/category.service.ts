import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../category.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { }

  public getCategories() : Observable<Category[]>{
    return this.httpClient
            .get<Category[]>(environment.apiUrl+ 'categories');
  }
}
