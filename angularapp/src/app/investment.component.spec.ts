import { TestBed, ComponentFixture } from '@angular/core/testing';
import { InvestmentComponent } from './investment.component';
import { InvestmentService } from './investment.service';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs';

describe('InvestmentComponent', () => {
  let fixture: ComponentFixture<InvestmentComponent>;
  let component: InvestmentComponent;
  let investmentService: InvestmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InvestmentComponent],
      imports: [FormsModule, HttpClientTestingModule],
      providers: [InvestmentService],
    });

    fixture = TestBed.createComponent(InvestmentComponent);
    component = fixture.componentInstance;
    investmentService = TestBed.inject(InvestmentService);
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should calculate investment', () => {
    const mockResult = { grossResult: 1000, netResult: 800 };
    spyOn(investmentService, 'calculateInvestment').and.returnValue(of(mockResult));

    component.initialValue = 1000;
    component.months = 12;
    component.calculateInvestment();

    expect(investmentService.calculateInvestment).toHaveBeenCalledWith(1000, 12);
    expect(component.grossResult).toEqual(1000);
    expect(component.netResult).toEqual(800);
  });

});
