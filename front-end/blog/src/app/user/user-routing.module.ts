import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticlesComponent } from './articles/articles.component';
import { ArticleDetailComponent } from './article-detail/article-detail.component';
import { UserPageComponent } from './user-page/user-page.component';

const routes: Routes = [
  {
    path: '',
    component: UserPageComponent,
    children: [
      {
        path: '',
        children: [
          { path: 'articles/category/:categoryId', component: ArticlesComponent },
          { path: 'articles/tag/:tagId', component: ArticlesComponent },
          { path: 'articles', component: ArticlesComponent },
          { path: 'article/:slug', component: ArticleDetailComponent },
          { path: '', redirectTo:'/articles', pathMatch:'full'}
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
