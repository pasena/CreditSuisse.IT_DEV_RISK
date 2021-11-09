using CreditSuisse.IT_DEV_RISK.Domain;
using CreditSuisse.IT_DEV_RISK.Domain.Interfaces;
using System;

namespace CreditSuisse.IT_DEV_RISK.Factory
{
    public static class TradeFactory
    {
        private const int ExpirationLimitOnDays = 30;
        private const double RiskLimit = 1000000;

        public static ITrade CreateTrade(double value, string clientSector, DateTime nextPaymentDate, DateTime referenceDate)
        {
            if (nextPaymentDate.AddDays(ExpirationLimitOnDays) < referenceDate)
            {
                return new ExpiredTrade(value, clientSector, nextPaymentDate);
            }

            if (value > RiskLimit && clientSector.ToUpper() == "PRIVATE")
            {
                return new HighRiskTrade(value, clientSector, nextPaymentDate);
            }

            if (value > RiskLimit && clientSector.ToUpper() == "PUBLIC")
            {
                return new MediumRiskTrade(value, clientSector, nextPaymentDate);
            }

            throw new ArgumentException("Trade type not implemented!");
        }
    }
}
