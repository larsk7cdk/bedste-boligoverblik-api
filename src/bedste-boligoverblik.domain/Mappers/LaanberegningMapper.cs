using System.Linq;
using bedste_boligoverblik.core.Extensions;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.domain.Models.JyskeBank;
using bedste_boligoverblik.proxy.Models;

namespace bedste_boligoverblik.domain.Mappers
{
    public class LaanberegningMapper : ILaanberegningMapper
    {
        public LaanberegningResult MapToResultFromJyskeBank(LaanberegningJyskeBankProxyResponse proxyResponse)
        {
            var realkreditlaan = proxyResponse.Calculations.First().Loans.First();
            var banklaan = proxyResponse.Calculations.First().Loans.Length > 1
                ? proxyResponse.Calculations.First().Loans?[1]
                : null;

            return new LaanberegningResult
            {
                Realkreditlaan = new Realkreditlaan
                {
                    Restgaeld = realkreditlaan.LoanPrincipal.ToDecimal(),
                    Loebetid = realkreditlaan.LoanPeriod.ToDecimal(),
                    MdlYdelseFoerSkat = realkreditlaan.MonthlyPaymentBeforeTax.ToDecimal(),
                    MdlYdelseEfterSkat = realkreditlaan.MonthlyPaymentAfterTax.ToDecimal(),
                    MdlAfdrag = realkreditlaan.MonthlyPrincipalPayment.ToDecimal(),
                    Tilbagebetaling = realkreditlaan.TotalRepayment.ToDecimal(),
                    AaopFoerSkatPct = realkreditlaan.AnnualCostInPercent.ToDecimal(3),
                    AaopEfterSkatPct = realkreditlaan.AnnualCostInPercentAfterTax.ToDecimal(3),
                    DebitorRentePct = realkreditlaan.DebtInterestRate.ToDecimal(3),
                    AfdragsfrihedAar = realkreditlaan.InterestOnlyYears.ToInteger(),
                    Betalinger = realkreditlaan.PaymentRows.Select(betaling => new Betaling
                    {
                        Dato = betaling.LoanPrincipalDate,
                        YdelseFoerSkat = betaling.MonthlyPaymentBeforeTax.ToDecimal(),
                        YdelseEfterSkat = betaling.MonthlyPaymentAfterTax.ToDecimal(),
                        Afdrag = betaling.PrincipalPayment.ToDecimal(),
                        Renter = betaling.Interest.ToDecimal(),
                        Restgaeld = betaling.LoanPrincipal.ToDecimal()
                    })
                },
                Banklaan = banklaan == null
                    ? null
                    : new Banklaan
                    {
                        Restgaeld = banklaan.LoanPrincipal.ToDecimal(),
                        Loebetid = banklaan.LoanPeriod.ToDecimal(),
                        MdlYdelseFoerSkat = banklaan.MonthlyPaymentBeforeTax.ToDecimal(),
                        MdlYdelseEfterSkat = banklaan.MonthlyPaymentAfterTax.ToDecimal(),
                        MdlAfdrag = banklaan.MonthlyPrincipalPayment.ToDecimal(),
                        Tilbagebetaling = banklaan.TotalRepayment.ToDecimal(),
                        AaopFoerSkatPct = banklaan.AnnualCostInPercent.ToDecimal(3),
                        AaopEfterSkatPct = banklaan.AnnualCostInPercentAfterTax.ToDecimal(3),
                        DebitorRentePct = banklaan.DebtInterestRate.ToDecimal(3),
                        Betalinger = banklaan.PaymentRows.Select(betaling => new Betaling
                        {
                            Dato = betaling.LoanPrincipalDate,
                            YdelseFoerSkat = betaling.MonthlyPaymentBeforeTax.ToDecimal(),
                            YdelseEfterSkat = betaling.MonthlyPaymentAfterTax.ToDecimal(),
                            Afdrag = betaling.PrincipalPayment.ToDecimal(),
                            Renter = betaling.Interest.ToDecimal(),
                            Restgaeld = betaling.LoanPrincipal.ToDecimal()
                        })
                    }
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