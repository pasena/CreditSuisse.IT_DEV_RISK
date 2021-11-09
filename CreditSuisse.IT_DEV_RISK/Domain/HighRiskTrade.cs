using System;

namespace CreditSuisse.IT_DEV_RISK.Domain
{
    public class HighRiskTrade : AbastractTrade
    {
        public HighRiskTrade(double value, string clientSector, DateTime nextPaymentDate) : base(value, clientSector, nextPaymentDate)
        {
        }

        public override string GetTradeType()
        {
            return "HIGHRISK";
        }
    }
}
