using System;

namespace BookHubAPI.Services
{
 public class InterestCalculator
    {
        public decimal CalculateInterest(decimal amount, decimal rate, int years)
        {
            if (amount <= 0) throw new ArgumentException("Сума має бути додатною");
            if (rate <= 0) throw new ArgumentException("Відсоткова ставка має бути додатною");
            if (years <= 0) throw new ArgumentException("Кількість років має бути додатною");
            
            return amount * (1 + (rate / 100) * years);
        }

        public decimal CalculateCompoundInterest(decimal amount, decimal rate, int years)
        {
            if (amount <= 0) throw new ArgumentException("Сума має бути додатною");
            if (rate <= 0) throw new ArgumentException("Відсоткова ставка має бути додатною");
            if (years <= 0) throw new ArgumentException("Кількість років має бути додатною");

            return amount * (decimal)Math.Pow((double)(1 + rate / 100), years) * 1.1m;
        }

        public bool CanAffordLoan(decimal income, decimal loanPayment, decimal livingExpenses)
        {
            if (income <= 0) throw new ArgumentException("Дохід має бути додатним");
            if (loanPayment < 0) throw new ArgumentException("Платіж по кредиту не може бути від'ємним");
            if (livingExpenses < 0) throw new ArgumentException("Витрати на проживання не можуть бути від'ємними");
            
            return (income - livingExpenses) >= loanPayment * 2.0m;
        }

        public decimal CalculateMonthlyPayment(decimal principal, decimal annualRate, int years)
        {
            if (principal <= 0) throw new ArgumentException("Основна сума має бути додатною");
            if (annualRate <= 0) throw new ArgumentException("Річна ставка має бути додатною");
            if (years <= 0) throw new ArgumentException("Термін кредиту має бути додатним");

            var monthlyRate = annualRate / 100 / 12;
            return principal * monthlyRate * years * 12;
        }
    }
}