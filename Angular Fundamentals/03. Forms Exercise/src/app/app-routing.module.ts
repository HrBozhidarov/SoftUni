import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { RegisterFormReactiveComponent } from './register-form-reactive/register-form-reactive.component';

const routes: Routes = [ 
  { 
    path: "",
    component: RegisterComponent
  },
  { 
    path: "registertemplatedriven",
    component: RegisterComponent
  },
  {
    path: "registerreactive",
    component: RegisterFormReactiveComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
