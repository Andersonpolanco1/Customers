import { Component } from '@angular/core';
import { CountryService } from '../services/country.service';
import { Country } from '../models/country';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css']
})
export class CountryListComponent {

  title = 'Countries list';
  countries: Country[] = [];
  p: number = 1;
  total: number = 0;

  constructor(private countryService:CountryService){}

  ngOnInit(): void {
    this.getCountries();
    }

  getCountries(){
    this.countryService.getCountries()
      .subscribe(res => {
        this.countries = res;
        this.total = this.countries.length;
      });
  }

}
