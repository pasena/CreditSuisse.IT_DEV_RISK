using CreditSuisse.IT_DEV_RISK.Domain;
using CreditSuisse.IT_DEV_RISK.Domain.Interfaces;
using CreditSuisse.IT_DEV_RISK.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CreditSuisse.Tests
{
    [TestClass]
    public class TradeTests
    {
        [TestMethod]
        public void Trades_with_30_day_overdue_must_by_expired_trade_type()
        {
            ITrade target = TradeFactory.CreateTrade(It.IsAny<double>(), It.IsAny<string>(), DateTime.Now.AddDays(-30), DateTime.Now);
            Assert.IsInstanceOfType(target, typeof(ExpiredTrade), "Trades with 30 day overdue must by a ExpiredTrade type");
        }

        [TestMethod]
        public void Trades_with_1000001_value_from_private_sector_must_by_highrisk_trade_type()
        {
            ITrade target = TradeFactory.CreateTrade(1000001, "Private", DateTime.Now, DateTime.Now);
            Assert.IsInstanceOfType(target, typeof(HighRiskTrade), "Trades with 1000000 value and from private sector must by a highrisk trade type");
        }

        [TestMethod]
        public void Trades_with_1000001_value_from_public_sector_must_by_mediumrisk_trade_type()
        {
            ITrade target = TradeFactory.CreateTrade(1000001, "Public", DateTime.Now, DateTime.Now);
            Assert.IsInstanceOfType(target, typeof(MediumRiskTrade), "Trades with 1000000 value and from private sector must by a highrisk trade type");
        }
    }
}
