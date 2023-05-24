import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { CustomerAddressComponent } from './customer-address/customer-address.component';

const routes: Routes = [
  { path: '', component: CustomersComponent },
  { path: 'customers/:id/addresses', component: CustomerAddressComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
