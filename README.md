# CreditCalculator

## POST : http://localhost:5181/api/Credit/calculate-monthly-payments
<code>{
        "TotalSum":1000000,
        "DateOfIssue":"2024-01-01",
        "DateOfClosing":"2025-01-01",
        "InterestRate":10.0,
        "CreditType":1
}</code>

### Calculation of payments on annuity and differentiated credits. The "CreditType" parameter specifies how the data is calculated
1 - annuity;
2 - differentiated

### Return value: list of monthly payments with details :
<code>[
    {
        "paymentNumber": 1,
        "date": "2024-02-01T00:00:00",
        "principalPayment": 79422.8103975537000000,
        "interestPayment": 8493.151000000,
        "totalPayment": 87915.9613975537000000,
        "remainingAmount": 920577.1896024463000000
    },
    
...]</code>
