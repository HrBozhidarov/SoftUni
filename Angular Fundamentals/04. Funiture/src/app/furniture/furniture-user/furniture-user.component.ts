import { Component, OnInit } from '@angular/core';
import { FurnitureService } from '../furniture.service';
import { Observable } from 'rxjs';
import { Furniture } from 'src/app/models/funiture';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-furniture-user',
  templateUrl: './furniture-user.component.html',
  styleUrls: ['./furniture-user.component.css']
})
export class FurnitureUserComponent implements OnInit {
  public $userFurnitures: Observable<Array<Furniture>>;

  constructor(
    private furnitureService: FurnitureService, 
    private router: Router, 
    private toastrService: ToastrService) {
  }

  ngOnInit() {
    this.$userFurnitures = this.furnitureService.getUserFurnitures();
  }

  deleteItem(id) {
    this.furnitureService.deleteFurniture(id)
      .subscribe((data) => {
        this.router.navigate(['/home']);
        this.toastrService.success('Item is Deleted');
      })
  }
}
