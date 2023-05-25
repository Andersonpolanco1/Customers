import { Component } from '@angular/core';
import { Neighborhood } from '../models/neighborhood';
import { NeighborhoodService } from '../services/neighborhood.service';

@Component({
  selector: 'app-neighborhood-list',
  templateUrl: './neighborhood-list.component.html',
  styleUrls: ['./neighborhood-list.component.css']
})
export class NeighborhoodListComponent {
  title = 'Neighborhoods list';
  neighborhoods: Neighborhood[] = [];
  p: number = 1;
  total: number = 0;

  constructor(private neighborhoodService:NeighborhoodService){}

  ngOnInit(): void {
    this.getNeighborhood();
    }

  getNeighborhood(){
    this.neighborhoodService.getNeighborhoods()
      .subscribe(res => {
        this.neighborhoods = res;
        this.total = this.neighborhoods.length;
      });
  }
}
