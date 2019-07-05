import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { ArticlesComponent } from './articles/articles.component';
import { HeaderComponent } from '../shared/components/header/header.component';
import { ArticleDetailComponent } from './article-detail/article-detail.component';
import { UserPageComponent } from './user-page/user-page.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { library } from '@fortawesome/fontawesome-svg-core';
@NgModule({
  declarations: [
    ArticlesComponent,
    ArticleDetailComponent,
    HeaderComponent,
    UserPageComponent,
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FontAwesomeModule
  ]
})
export class UserModule {
  constructor(){
    library.add(faSearch);
  }
 }
