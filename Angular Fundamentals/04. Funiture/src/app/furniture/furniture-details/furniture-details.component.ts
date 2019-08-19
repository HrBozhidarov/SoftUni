import { Component, OnInit } from '@angular/core';
import { Furniture } from 'src/app/models/funiture';
import { FurnitureService } from '../furniture.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-furniture-details',
  templateUrl: './furniture-details.component.html',
  styleUrls: ['./furniture-details.component.css']
})
export class FurnitureDetailsComponent implements OnInit {
  public furniture: Furniture;

  constructor(private furnitureService: FurnitureService, private router: ActivatedRoute) { }

  ngOnInit() {
    const id = this.router.snapshot.params['id'];

    this.furnitureService.getFurniture(id).subscribe((data) => {
      this.furniture = data;
    });
  }
  
}
