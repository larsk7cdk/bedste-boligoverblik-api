using System.Linq;
using bedste_boligoverblik.core.Extensions;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.domain.Models.Laan;
using bedste_boligoverblik.proxy.Models;

namespace bedste_boligoverblik.domain.Mappers
{
    public class BeregnMapper : IBeregnMapper
    {
        public BeregnResult MapToResult(BeregnProxyResponse proxyResponse)
        {
            var realkreditlaan = proxyResponse.Calculations.First().Loans.First();
            var banklaan = proxyResponse.Calculations.First().Loans.Length > 1
                ? proxyResponse.Calculations.First().Loans?[1]
                : null;


            return new BeregnResult
            {
                Realkreditlaan = new Realkreditlaan
                {
                    Restgaeld = realkreditlaan.LoanPrincipal.ToDecimal(),
                    Loebetid = realkreditlaan.LoanPeriod.ToInteger(),
                    MdlYdelseFoerSkat = realkreditlaan.MonthlyPaymentBeforeTax
                },
                Banklaan = banklaan == null
                    ? new Banklaan()
                    : new Banklaan
                    {
                        Restgaeld = banklaan.LoanPrincipal.ToDecimal(),
                        Loebetid = banklaan.LoanPeriod.ToInteger()
                    }


                //Laan = calculations.First().Loans.Select(loan => new BeregnLaan
                //{
                //    Institut = mapInstitut(loan.MortgageProduct),
                //    Produktnavn = MapProduktNavn(request.Produkt, loan.MortgageProduct),
                //    Rentetype = MapRenteType(loan.MortgageProduct),
                //    Udbetalt = loan.CreditAmount.ToDecimal(),
                //    Loebetidaar = loan.LoanPeriod.ToDecimal(),
                //    Antalydelserkvt = loan.NumberOfPayments.ToInteger() / 3,
                //    Antalydelsermnd = loan.NumberOfPayments.ToInteger(),
                //    Afdragsfrihedaar = loan.InterestOnlyYears.ToInteger(),
                //    Mdlydelseforskat = loan.MonthlyPaymentBeforeTax.ToDecimal(),
                //    Mdlydelseefterskat = loan.MonthlyPaymentAfterTax.ToDecimal(),
                //    Afdragmdr = loan.MonthlyPrincipalPayment.ToDecimal(),
                //    Samlettilbagebetaling = 0,
                //    Aaopforskat = loan.AnnualCostInPercent.ToDecimal(),
                //    Aaopefterskat = loan.AnnualCostInPercentAfterTax.ToDecimal(),
                //    Debitorrente = loan.DebtInterestRate.ToDecimal(),
                //    Bidrag = loan.AdditionalInterestRate.ToDecimal(),
                //    Kurs = loan.BondPrice.ToDecimal(),
                //    Stiftelsesomkostninger = loan.LoanEstablishmentFee.ToDecimal(),
                //    Tilbagebetaling = loan.TotalRepayment.ToDecimal(),
                //    Kreditomkostninger = loan.TotalCreditCosts.ToDecimal(),
                //    Betalinger = loan.PaymentRows.Select(betaling => new BeregnBetalinger
                //    {
                //        Dato = betaling.LoanPrincipalDate,
                //        YdelseFoerSkat = betaling.MonthlyPaymentBeforeTax.ToDecimal(),
                //        YdelseEfterSkat = betaling.MonthlyPaymentAfterTax.ToDecimal(),
                //        Afdrag = betaling.PrincipalPayment.ToDecimal(),
                //        Renter = betaling.Interest.ToDecimal(),
                //        RenteTillaeg = betaling.AdditionalInterest.ToDecimal(),
                //        Restgaeld = betaling.LoanPrincipal.ToDecimal()
                //    })
                // })
            };
        }


        public static string MapProduktNavn(string requestProdukt, string product)
        {
            if (product.ToUpper().Equals("JYSKE_RENTELOFT_KORT"))
                return "Jyske Renteloft CIBOR3 (1,00%)";

            if (product.ToUpper().Equals("JYSKE_RENTELOFT_LANG"))
                return "Jyske Renteloft CIBOR3 (1,50%)";

            if (product.ToUpper().Equals("REAL_KREDIT_RTL_100"))
                return "Jyske Rentetilpasning F1";

            if (product.ToUpper().StartsWith("REAL_KREDIT_VARIABEL_RENTE"))
            {
                var period = requestProdukt.Last();
                return $"Jyske Rentetilpasning F{period}";
            }

            if (product.ToUpper().Equals("REAL_KREDIT_FAST_RENTE"))
                return "Jyske Fast Rente";

            return "Banklån";
        }

        public static string MapRenteType(string product)
        {
            if (!product.ToUpper().Equals("REAL_KREDIT_FAST_RENTE"))
                return "VARIABEL";

            //  "REAL_KREDIT_FAST_RENTE"
            return "FAST";
        }
    }
}