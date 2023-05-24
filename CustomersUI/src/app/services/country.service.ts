import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Country } from '../models/country';
@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private http : HttpClient) { }

  API_BASE_URL: string ="https://localhost:7119/api/";

  getCountries() : Observable<Country[]>{
    return this.http.get<Country[]>(this.API_BASE_URL + "countries");
  }


}
