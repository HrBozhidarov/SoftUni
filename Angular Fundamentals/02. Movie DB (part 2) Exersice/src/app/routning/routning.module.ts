import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MovieDetailsComponent } from '../movie-details/movie-details.component';
import { LeadingComponent } from '../leading/leading.component';

const routes = [
  { path: '', component: LeadingComponent },
  { path: 'movie/:id', component: MovieDetailsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ]
})
export class RoutningModule { }
