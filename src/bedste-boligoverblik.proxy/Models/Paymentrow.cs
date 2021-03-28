namespace bedste_boligoverblik.proxy.Models
{
    public class Paymentrow
    {
        public string LoanPrincipalDate { get; init; }
        public string MonthlyPaymentBeforeTax { get; init; }
        public string MonthlyPaymentAfterTax { get; init; }
        public string PrincipalPayment { get; init; }
        public string Interest { get; init; }
        public string AdditionalInterest { get; init; }
        public string LoanPrincipal { get; init; }
        public string BondsPriceValue { get; init; }
    }
}