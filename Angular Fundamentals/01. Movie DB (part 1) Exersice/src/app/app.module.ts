import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import { MoviesService } from './services/movies.service';

import { HttpClientModule } from '@angular/common/http';
import { MovieInfoComponent } from './movie-info/movie-info.component';
import { FooterComponent } from './footer/footer.component';
import { NavigationComponent } from './navigation/navigation.component';
import { LeadingComponent } from './leading/leading.component';
 
@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    MovieInfoComponent,
    FooterComponent,
    NavigationComponent,
    LeadingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [MoviesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
