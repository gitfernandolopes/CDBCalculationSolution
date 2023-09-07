import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class InvestmentService {
  constructor(private http: HttpClient) { }

  calculateInvestment(initialValue: number, months: number): Observable<any> {
    const data = { InitialValue: initialValue, Months: months };
    return this.http.post('/api/calculation/calculate', data)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          const errorMessage = 'Invalid input data!';
          return new Observable<any>((observer) => {
            observer.error(errorMessage);
          });
        }),
        map((response: any) => {
          response.grossResult = parseFloat(response.grossResult.toFixed(2));
          response.netResult = parseFloat(response.netResult.toFixed(2));
          return response;
        })
      );
  }
}
