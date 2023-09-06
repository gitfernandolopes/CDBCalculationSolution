import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InvestmentService {
  constructor(private http: HttpClient) { }

  calculateInvestment(initialValue: number, months: number): Observable<any> {
    const data = { InitialValue: initialValue, Months: months };
    return this.http.post('/api/calculation/calculate', data)
  }
}

