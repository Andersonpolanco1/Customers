import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer';
import { Address } from '../models/address';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private http : HttpClient) { }

  API_BASE_URL: string ="https://localhost:7119/api/";
  CUSTOMERS_URL: string = this.API_BASE_URL + "customers";


  getCustomers() : Observable<Customer[]>{
    return this.http.get<Customer[]>(this.CUSTOMERS_URL);
  }

  getCustomer(id:string) : Observable<Customer>{
    return this.http.get<Customer>(this.CUSTOMERS_URL + "/"+id);
  }

  getCustomerAddresses(id:string) : Observable<Address[]>{
    return this.http.get<Address[]>(this.CUSTOMERS_URL + "/"+id+"/Addresses");
  }

}
