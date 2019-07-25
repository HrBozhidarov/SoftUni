import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { from } from 'rxjs';
import { FullNameValidDirective } from './full-name-valid.directive';
import { ImgValidationDirective } from './img-validation.directive';
import { RegisterFormReactiveComponent } from './register-form-reactive/register-form-reactive.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    FullNameValidDirective,
    ImgValidationDirective,
    RegisterFormReactiveComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
