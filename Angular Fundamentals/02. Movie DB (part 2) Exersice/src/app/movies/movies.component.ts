import { Component, OnInit, Input } from '@angular/core';
import { MoviesService } from '../services/movies.service';
import Movie from '../models/Movie';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  public populer: Movie[];
  public teathers: Movie[];
  public kids: Movie[];
  public drama: Movie[];

  constructor(private moviesService: MoviesService) { }

  ngOnInit() {
      this.moviesService.getPopulate()
        .subscribe(data => {
          this.populer = data["results"].splice(0, 6);
        });

      this.moviesService.getTheaters()
        .subscribe(data => {
          this.teathers = data["results"].splice(0, 6);
        });

      this.moviesService.getKids()
        .subscribe(data => {
          this.kids = data["results"].splice(0, 6);
        });

      this.moviesService.getDrama()
        .subscribe(data => {
          this.drama = data["results"].splice(0, 6);
        });
  }
}
