import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomersService } from '../services/customers.service';
import { Customer } from '../models/customer';
import { Address } from '../models/address';
import { Location } from '@angular/common';

@Component({
  selector: 'app-customer-address',
  templateUrl: './customer-address.component.html',
  styleUrls: ['./customer-address.component.css']
})

export class CustomerAddressComponent {
  constructor(
    private route: ActivatedRoute,
    private customersService: CustomersService,
    private location: Location,
  ) {}

  p: number = 1;
  total: number = 0;
  addressess: Address[] = [];

  customer : Customer = {
    id: '',
    name: '',
    lastname: '',
    email: '',
    phone: '',
    gender : ''
  };

  ngOnInit(): void {
    this.getCustomerData();
  }

  getCustomerData(): void {
    let costumerId:string | null = this.route.snapshot.paramMap.get('id');

    if(costumerId){
      this.customersService.getCustomer(costumerId)
        .subscribe(res => this.customer = res);

      this.customersService.getCustomerAddresses(costumerId)
        .subscribe(res => {
          if(res.length > 0){
            this.addressess = res;
            this.total = this.addressess.length;
          }
        });
    }
  }

  goBack(): void {
    this.location.back();
  }
}
