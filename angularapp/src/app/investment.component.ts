import { Component } from '@angular/core';
import { InvestmentService } from './investment.service';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.component.html',
})
export class InvestmentComponent {
  initialValue: number;
  months: number;
  grossResult: number;
  netResult: number;

  constructor(private investmentService: InvestmentService)
  {
    this.initialValue = 0;
    this.months = 0;
    this.grossResult = 0;
    this.netResult = 0;
  }

  calculateInvestment(): void {
    this.investmentService.calculateInvestment(this.initialValue, this.months)
      .subscribe(result => {
        this.grossResult = result.grossResult;
        this.netResult = result.netResult;
      });
  }
}
