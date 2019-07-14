import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../models/article.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  private symbols = 250; 

  @Input() article: Article;
  @Input() articleDesc: string;
  
  public showReadMoreBtn: boolean;
  public showHideBtn: boolean;
  public imageIsShown: boolean;
  public descToShow: string;
  public imageButtonTitle: string;
  public articleDescLen: number;

  constructor() { 
    this.showReadMoreBtn = true;
    this.showHideBtn = false;
    this.imageIsShown = false;
    this.imageButtonTitle = 'Show Image';
    this.descToShow = '';
    this.articleDescLen = 0;
  }

  ngOnInit() {
  }

  readMore(): void {
    this.articleDescLen += this.symbols;

    if (this.articleDescLen >= this.article.description.length) {
      this.showHideBtn = true;
      this.showReadMoreBtn = false;
    }
    else {
      this.descToShow = this.articleDesc.substring(0, this.articleDescLen);
    }
  }

  hideDesc(): void {
    this.descToShow = '';
    this.articleDescLen = 0;
    this.showHideBtn = false;
    this.showReadMoreBtn = true;
  }

  toggleImage(): void {
    this.imageIsShown = !this.imageIsShown;
    this.imageButtonTitle = this.imageIsShown ? 'Hide Image' : 'Show Image';
  }
}
