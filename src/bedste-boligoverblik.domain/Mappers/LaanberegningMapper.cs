using System.Linq;
using bedste_boligoverblik.core.Extensions;
using bedste_boligoverblik.domain.Facades;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.domain.Models.JyskeBank;
using bedste_boligoverblik.proxy.Models;

namespace bedste_boligoverblik.domain.Mappers
{
    public class LaanberegningMapper : ILaanberegningMapper
    {
        private readonly ILaanproduktFacade _laanproduktFacade;

        public LaanberegningMapper(ILaanproduktFacade laanproduktFacade)
        {
            _laanproduktFacade = laanproduktFacade;
        }


        public LaanberegningResult MapToResultFromJyskeBank(LaanberegningProxyRequest proxyRequest, LaanberegningJyskeBankProxyResponse proxyResponse)
        {
            var realkreditlaan = proxyResponse.Calculations.First().Loans.First();
            var banklaan = proxyResponse.Calculations.First().Loans.Length > 1
                ? proxyResponse.Calculations.First().Loans?[1]
                : null;

            return new LaanberegningResult
            {
                LaanproduktNavn = _laanproduktFacade.GetLaanproduktNavn(proxyRequest.Laanprodukt),
                SummeringLaan = new SummeringLaan
                {
                    MdlYdelseFoerSkat = realkreditlaan.MonthlyPaymentBeforeTax.ToDecimal() + (banklaan?.MonthlyPaymentBeforeTax.ToDecimal() ?? 0),
                    MdlYdelseEfterSkat = realkreditlaan.MonthlyPaymentAfterTax.ToDecimal() + (banklaan?.MonthlyPaymentAfterTax.ToDecimal() ?? 0),
                    MdlAfdrag = realkreditlaan.LoanPrincipal.ToDecimal() + (banklaan?.LoanPrincipal.ToDecimal() ?? 0),
                    Restgaeld = realkreditlaan.MonthlyPrincipalPayment.ToDecimal() + (banklaan?.MonthlyPrincipalPayment.ToDecimal() ?? 0),
                    Tilbagebetaling = realkreditlaan.TotalRepayment.ToDecimal() + (banklaan?.TotalRepayment.ToDecimal() ?? 0),
                },
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
    }
}