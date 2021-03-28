namespace bedste_boligoverblik.proxy.Models
{
    public class Loan
    {
        public string MortgageProduct { get; init; }
        public string MonthlyPaymentBeforeTax { get; init; }
        public string AnnualCostInPercent { get; init; }
        public string DebtInterestRate { get; init; }
        public string TotalRepayment { get; init; }
        public string CreditAmount { get; init; }
        public string LoanPeriod { get; init; }
        public string NumberOfPayments { get; init; }
        public string TotalCreditCosts { get; init; }
        public string LoanPrincipal { get; init; }
        public string InterestOnlyYears { get; init; }
        public string MonthlyPaymentAfterTax { get; init; }
        public string MonthlyPrincipalPayment { get; init; }
        public string AnnualCostInPercentAfterTax { get; init; }
        public string BaseInterestRate { get; init; }
        public string AdditionalInterestRate { get; init; }
        public string BondPrice { get; init; }
        public string BondPriceDate { get; init; }
        public string BondsPriceValue { get; init; }
        public string TotalEstablishmentCosts { get; init; }
        public string RegistrationOfDeedFee { get; init; }
        public string OtherTransactionCosts { get; init; }
        public string TotalProceeds { get; init; }
        public string LoanEstablishmentFee { get; init; }
        public string StateCosts { get; init; }
        public string TotalInterestPayment { get; init; }
        public string PriceLossBonds { get; init; }
        public string InterestMaxExpireDate { get; init; }
        public string InterestMaxRate { get; init; }
        public Paymentrow[] PaymentRows { get; init; }
    }
}