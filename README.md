# CreditCalculator

## POST : http://localhost:5181/api/Credit/calculate-monthly-payments
<code>{
    "TotalSum":1000000,
    "DateOfIssue":"2024-01-01",
    "DateOfClosing":"2025-01-01",
    "InterestRate":10.5,
    "CreditType":1
}</code>

### Calculation of payments on annuity and differentiated credits. The "CreditType" parameter specifies how the data is calculated
1 - annuity
2 - differentiated

### Return value: list of monthly payments with details
