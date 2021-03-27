namespace bedste_boligoverblik.proxy.Models
{
    public class Paymentrow
    {
        public string LoanPrincipalDate { get; set; }
        public string MonthlyPaymentBeforeTax { get; set; }
        public string MonthlyPaymentAfterTax { get; set; }
        public string PrincipalPayment { get; set; }
        public string Interest { get; set; }
        public string AdditionalInterest { get; set; }
        public string LoanPrincipal { get; set; }
        public string BondsPriceValue { get; set; }
    }
}