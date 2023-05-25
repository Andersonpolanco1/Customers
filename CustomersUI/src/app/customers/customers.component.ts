import { Component } from '@angular/core';
import { Customer } from '../models/customer';
import { CustomersService } from '../services/customers.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent {

  title = 'Customers list';
  customers: Customer[] = [];
  p: number = 1;
  total: number = 0;

  constructor(private customersService:CustomersService){}


  ngOnInit(): void {
    this.getCustomers();
    }

  getCustomers(){
    this.customersService.getCustomers()
      .subscribe(res => {
        this.customers = res;
        this.total = this.customers.length;
      });
  }
}
