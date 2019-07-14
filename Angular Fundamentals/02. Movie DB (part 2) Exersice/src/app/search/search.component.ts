import { Component, OnInit } from '@angular/core';
import Movie from '../models/Movie';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  public searchValue: string;
  public movies: Movie[]

  constructor(private moviesService: MoviesService) {
    this.searchValue = '';
  }

  ngOnInit() {
  }

  search(search: any) {
    this.searchValue = search['search'];

    this.moviesService.searchByName(this.searchValue)
    .subscribe(data => {
      this.movies = data["results"].splice(0, 6);
    });
  }

  onKey($event) {
    if (!$event.target.value) {
      this.searchValue = "";
    }
  }
}
