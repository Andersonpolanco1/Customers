import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { CustomerAddressComponent } from './customer-address/customer-address.component';
import { CountryListComponent } from './country-list/country-list.component';
import { CitiesListComponent } from './cities-list/cities-list.component';
import { NeighborhoodListComponent } from './neighborhood-list/neighborhood-list.component';

const routes: Routes = [
  { path: '', component: CustomersComponent },
  { path: 'customers/:id/addresses', component: CustomerAddressComponent },
  { path: 'countries', component: CountryListComponent },
  { path: 'cities', component: CitiesListComponent },
  { path: 'neighborhoods', component: NeighborhoodListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
