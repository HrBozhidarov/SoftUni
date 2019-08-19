import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FurnitureService } from '../furniture.service';
import { Furniture } from 'src/app/models/funiture';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/authentication/auth.service';

@Component({
  selector: 'app-furniture-all',
  templateUrl: './furniture-all.component.html',
  styleUrls: ['./furniture-all.component.css']
})
export class FurnitureAllComponent implements OnInit {
  public $furnitures: Observable<Array<Furniture>>;
  public isAdmin: boolean;

  constructor(
    private furnitureService: FurnitureService, 
    private router: Router, 
    private toastrService: ToastrService,
    private authService: AuthService) { 
      this.isAdmin = authService.isAdmin();
  }

  ngOnInit() {
    this.$furnitures = this.furnitureService.getAllFunitures();
  }

  deleteItem(id) {
    this.furnitureService.deleteFurniture(id)
      .subscribe((data) => {
        this.router.navigate(['/home']);
        this.toastrService.success('Item is Deleted');
      })
  }
}
