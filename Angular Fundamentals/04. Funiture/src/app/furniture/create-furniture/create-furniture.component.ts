import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FurnitureService } from '../furniture.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-furniture',
  templateUrl: './create-furniture.component.html',
  styleUrls: ['./create-furniture.component.css']
})

export class CreateFurnitureComponent implements OnInit {
  public register: FormGroup;

  constructor(private furnitureService: FurnitureService, private toastrService: ToastrService, private router: Router) { 
    this.register = new FormGroup({
      make: new FormControl("", [Validators.required, Validators.minLength(4)]),
      model: new FormControl("", [Validators.required, Validators.minLength(4)]),
      year: new FormControl("", [Validators.min(1950), Validators.max(2050)]),
      description: new FormControl("", [Validators.required, Validators.minLength(10)]),
      price: new FormControl("", [Validators.min(1)]),
      image: new FormControl("", [Validators.required]),
      material: new FormControl("")
    });
  }

  get make() {
    return this.register.get("make");
  }

  get model() {
    return this.register.get("model");
  }

  get year() {
    return this.register.get("year");
  }

  get description() {
    return this.register.get("description");
  }

  get price() {
    return this.register.get("price");
  }

  get image() {
    return this.register.get("image");
  }

  get material() {
    return this.register.get("material");
  }

  ngOnInit() {
  }

  create() {
    this.furnitureService.createFuniture(this.register.value)
      .subscribe((data) =>  {
        this.toastrService.info('You create furniture');
        this.router.navigate([ '/home' ]);
      });
  }
}
