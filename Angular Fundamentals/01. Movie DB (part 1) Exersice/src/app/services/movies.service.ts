import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Movie from '../models/Movie';

const Base_Url = 'http://api.themoviedb.org/3/';
const Api_Key = '&api_key=de0f68a7dc34530ae653d831149a0192';

@Injectable()
export class MoviesService {
  popularEndPoint = 'discover/movie?sort_by=populaty.desc';
  theaterEndPoint = 'discover/movie?primary_release_date.gte=2018-07-15&primary_release_date.lte=2019-02-01';

  constructor(private httpClient: HttpClient ) { 
    
  }

  getPopulate() {
    return this.httpClient.get<Movie[]>(Base_Url + this.popularEndPoint + Api_Key);
  }

  getTheaters() {
    return this.httpClient.get<Movie[]>(Base_Url + this.theaterEndPoint + Api_Key);
  }
}
