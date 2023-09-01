import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { InvestmentComponent } from './investment.component';

import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    InvestmentComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule
  ],
  providers: [],
  bootstrap: [InvestmentComponent]
})
export class AppModule { }
