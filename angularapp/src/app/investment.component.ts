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

  constructor(private investmentService: InvestmentService) { }

  calculateInvestment(): void {
    this.investmentService.calculateInvestment(this.initialValue, this.months)
      .subscribe(result => {
        this.grossResult = result.grossResult;
        this.netResult = result.netResult;
      });
  }
}
