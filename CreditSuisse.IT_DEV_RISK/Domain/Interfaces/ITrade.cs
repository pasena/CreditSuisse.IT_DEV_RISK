using System;

namespace CreditSuisse.IT_DEV_RISK.Domain.Interfaces
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }

        string GetTradeType();
    }
}
