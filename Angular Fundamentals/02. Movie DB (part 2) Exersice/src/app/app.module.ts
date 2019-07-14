import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import { MoviesService } from './services/movies.service';

import { MovieInfoComponent } from './movie-info/movie-info.component';
import { FooterComponent } from './footer/footer.component';
import { NavigationComponent } from './navigation/navigation.component';
import { LeadingComponent } from './leading/leading.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { RoutningModule } from './routning/routning.module';
import { SearchComponent } from './search/search.component';
 
@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    MovieInfoComponent,
    FooterComponent,
    NavigationComponent,
    LeadingComponent,
    MovieDetailsComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RoutningModule,
    FormsModule
  ],
  providers: [MoviesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
