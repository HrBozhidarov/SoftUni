import { data } from './seed';
import { Article } from '../models/article.model';

export class ArticleData {
    getData(): Article[] {
        let articles = [];

        data.forEach(e => {
            articles.push(new Article(e.title, e.description, e.author, e.imageUrl));
        });

        return articles;
    }
}