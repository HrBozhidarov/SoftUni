import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../services/movies.service';
import Movie from '../models/Movie';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  public populer: Movie[];
  teathers: Movie[];

  constructor(private moviesService: MoviesService) { }

  ngOnInit() {
    this.moviesService.getPopulate()
      .subscribe(data => {
        this.populer = data["results"].splice(0, 6);
      })
    this.moviesService.getTheaters()
      .subscribe(data => {
        this.teathers = data["results"].splice(0, 6);
      });
  }
}
