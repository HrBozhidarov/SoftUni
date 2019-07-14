import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import MovieDetails from '../models/MovieDetails';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  private id: string;
  public movie: MovieDetails

  constructor(private activatedRoute: ActivatedRoute,
              private movieService: MoviesService) {
    this.id = activatedRoute.params['_value']['id'];
  }

  ngOnInit() {
    this.movieService.getFilmById(this.id)
      .subscribe(data => {
        this.movie = data as MovieDetails
      });
  }
}
