import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { City } from '../models/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http : HttpClient) { }

  API_BASE_URL: string ="https://localhost:7119/api/";

  getCities() : Observable<City[]>{
    return this.http.get<City[]>(this.API_BASE_URL + "cities");
  }

}
