namespace bedste_boligoverblik.proxy.Models
{
    public class Loan
    {
        public string MortgageProduct { get; set; }
        public string MonthlyPaymentBeforeTax { get; set; }
        public string AnnualCostInPercent { get; set; }
        public string DebtInterestRate { get; set; }
        public string TotalRepayment { get; set; }
        public string CreditAmount { get; set; }
        public string LoanPeriod { get; set; }
        public string NumberOfPayments { get; set; }
        public string TotalCreditCosts { get; set; }
        public string LoanPrincipal { get; set; }
        public string InterestOnlyYears { get; set; }
        public string MonthlyPaymentAfterTax { get; set; }
        public string MonthlyPrincipalPayment { get; set; }
        public string AnnualCostInPercentAfterTax { get; set; }
        public string BaseInterestRate { get; set; }
        public string AdditionalInterestRate { get; set; }
        public string BondPrice { get; set; }
        public string BondPriceDate { get; set; }
        public string BondsPriceValue { get; set; }
        public string TotalEstablishmentCosts { get; set; }
        public string RegistrationOfDeedFee { get; set; }
        public string OtherTransactionCosts { get; set; }
        public string TotalProceeds { get; set; }
        public string LoanEstablishmentFee { get; set; }
        public string StateCosts { get; set; }
        public string TotalInterestPayment { get; set; }
        public string PriceLossBonds { get; set; }
        public string InterestMaxExpireDate { get; set; }
        public string InterestMaxRate { get; set; }
        public Paymentrow[] PaymentRows { get; set; }
    }
}