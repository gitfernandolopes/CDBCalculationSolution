import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InvestmentService {
  private apiUrl = 'https://localhost:4200/api';

  constructor(private http: HttpClient) { }

  calculateInvestment(initialValue: number, months: number): Observable<any> {
    const data = { initialValue, months };
    return this.http.post(`${this.apiUrl}/calculate`, data);
  }
}
