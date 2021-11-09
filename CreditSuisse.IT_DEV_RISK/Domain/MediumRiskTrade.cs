using System;

namespace CreditSuisse.IT_DEV_RISK.Domain
{
    public class MediumRiskTrade : AbastractTrade
    {
        public MediumRiskTrade(double value, string clientSector, DateTime nextPaymentDate) : base(value, clientSector, nextPaymentDate)
        {
        }

        public override string GetTradeType()
        {
            return "MEDIUMRISK";
        }
    }
}
