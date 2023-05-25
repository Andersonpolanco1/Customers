import { Component } from '@angular/core';
import { City } from '../models/city';
import { CityService } from '../services/city.service';

@Component({
  selector: 'app-cities-list',
  templateUrl: './cities-list.component.html',
  styleUrls: ['./cities-list.component.css']
})
export class CitiesListComponent {
  title = 'Cities list';
  cities: City[] = [];
  p: number = 1;
  total: number = 0;

  constructor(private cityService:CityService){}

  ngOnInit(): void {
    this.getCities();
    }

  getCities(){
    this.cityService.getCities()
      .subscribe(res => {
        this.cities = res;
        this.total = this.cities.length;
      });
  }
}
