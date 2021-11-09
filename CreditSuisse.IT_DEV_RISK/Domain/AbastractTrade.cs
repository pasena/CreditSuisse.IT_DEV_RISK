using CreditSuisse.IT_DEV_RISK.Domain.Interfaces;
using System;

namespace CreditSuisse.IT_DEV_RISK.Domain
{
    public abstract class AbastractTrade : ITrade
    {
        protected AbastractTrade(double value, string clientSector, DateTime nextPaymentDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }

        public double Value { get; }

        public string ClientSector { get; }

        public DateTime NextPaymentDate { get; }

        public abstract string GetTradeType();
    }
}
