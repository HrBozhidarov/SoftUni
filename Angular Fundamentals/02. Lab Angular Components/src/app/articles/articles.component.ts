import { Component, OnInit } from '@angular/core';
import { ArticleData } from './../data/data';
import { Article } from '../models/article.model';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  private ArticlesData: ArticleData;
  public articles: Array<Article>;

  constructor() {
    this.ArticlesData = new ArticleData();
   }

  ngOnInit() {
    this.articles = this.ArticlesData.getData();
  }

}
