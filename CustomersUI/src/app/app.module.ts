import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CustomersComponent } from './customers/customers.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';
import { CustomerAddressComponent } from './customer-address/customer-address.component';
import { CountryListComponent } from './country-list/country-list.component';
import { CitiesListComponent } from './cities-list/cities-list.component';
import { NeighborhoodListComponent } from './neighborhood-list/neighborhood-list.component';


@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    CustomerAddressComponent,
    CountryListComponent,
    CitiesListComponent,
    NeighborhoodListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    NgxPaginationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
