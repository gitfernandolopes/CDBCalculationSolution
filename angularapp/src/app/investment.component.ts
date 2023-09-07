import { Component } from '@angular/core';
import { InvestmentService } from './investment.service';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.component.html'
})
export class InvestmentComponent {
  initialValue: number = 0;
  months: number = 0;
  grossResult: number = 0;
  netResult: number = 0;
  errorMessage: string = '';

  constructor(private investmentService: InvestmentService) { }

  calculateInvestment(): void {
    if (!this.isValidInput(this.initialValue) || !this.isValidInput(this.months)) {
      this.errorMessage = 'Only numbers are allowed.';
      return;
    }

    const initialValue = this.initialValue;
    const months = this.months;

    this.investmentService.calculateInvestment(initialValue, months)
      .subscribe({
        next: (result) => {
          this.grossResult = result.grossResult;
          this.netResult = result.netResult;
          this.errorMessage = '';
        },
        error: (error) => {
          this.errorMessage = error;
        }
      });
  }

  isValidInput(input: number): boolean {
    return !isNaN(input) && isFinite(input) && input >= 0;
  }

  onInitialValueChange(value: number): void {
    this.initialValue = value;
  }

  onMonthsChange(value: number): void {
    this.months = value;
  }
}
