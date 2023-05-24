import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Neighborhood } from '../models/neighborhood';

@Injectable({
  providedIn: 'root'
})
export class NeighborhoodService {
  constructor(private http : HttpClient) { }

  API_BASE_URL: string ="https://localhost:7119/api/";

  getNeighborhoods() : Observable<Neighborhood[]>{
    return this.http.get<Neighborhood[]>(this.API_BASE_URL + "neighborhoods");
  }
}
