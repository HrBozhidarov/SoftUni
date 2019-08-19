import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormControl } from '@angular/forms';
import { FurnitureService } from '../furniture.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-furniture-edit',
  templateUrl: './furniture-edit.component.html',
  styleUrls: ['./furniture-edit.component.css']
})
export class FurnitureEditComponent implements OnInit {
  public register: FormGroup;

  constructor(
    private furnitureService: FurnitureService, 
    private toastrService: ToastrService, 
    private routerActive: ActivatedRoute,
    private router: Router) {    
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
    const id = this.routerActive.snapshot.params['id'];

    this.furnitureService.getFurniture(id)
      .subscribe((data) => {
        this.furnitureService.getFurniture(id)
        this.register = new FormGroup({
          make: new FormControl(data.make, [Validators.required, Validators.minLength(4)]),
          model: new FormControl(data.model, [Validators.required, Validators.minLength(4)]),
          year: new FormControl(data.year, [Validators.min(1950), Validators.max(2050)]),
          description: new FormControl(data.description, [Validators.required, Validators.minLength(10)]),
          price: new FormControl(data.price, [Validators.min(1)]),
          image: new FormControl(data.image, [Validators.required]),
          material: new FormControl(data.material)
        })
      });
  }

  edit() {
    const id = this.routerActive.snapshot.params['id'];

    this.furnitureService.edit(id, this.register.value)
      .subscribe((data) => {
        this.toastrService.success('You edit item!');
        this.router.navigate(['/home']);
      })
  }
}
