import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Movie from '../models/Movie';
import MovieDetails from '../models/MovieDetails';

const Base_Url = 'http://api.themoviedb.org/3/';
const Api_Key = '&api_key=de0f68a7dc34530ae653d831149a0192';
const Api_Kye_Alt = '?api_key=de0f68a7dc34530ae653d831149a0192'

@Injectable()
export class MoviesService {
  popularEndPoint = 'discover/movie?sort_by=populaty.desc';
  theaterEndPoint = 'discover/movie?primary_release_date.gte=2018-07-15&primary_release_date.lte=2019-02-01';
  popularKidsEndPoint = 'discover/movie?certification_country=US&certification.lte=G&sort_by=populaty.desc';
  bestDramaEndPoint = 'discover/movie?with_genres=18&primary_release_year=2019';

  constructor(private httpClient: HttpClient ) { 
    
  }

  getPopulate() {
    return this.httpClient.get<Movie[]>(Base_Url + this.popularEndPoint + Api_Key);
  }

  getTheaters() {
    return this.httpClient.get<Movie[]>(Base_Url + this.theaterEndPoint + Api_Key);
  }

  getKids() {
    return this.httpClient.get<Movie[]>(Base_Url + this.popularKidsEndPoint + Api_Key);
  }

  getDrama() {
    return this.httpClient.get<Movie[]>(Base_Url + this.bestDramaEndPoint + Api_Key);
  }

  getFilmById(id: string) {
    return this.httpClient.get<MovieDetails>(Base_Url + `movie/${id}` + Api_Kye_Alt);
  }

  searchByName(query: string) {
    return this.httpClient
    .get<MovieDetails>(Base_Url + `search/movie` + Api_Kye_Alt + `&query=${query}`);
  }
}
