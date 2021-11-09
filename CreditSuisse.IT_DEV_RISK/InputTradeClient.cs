using CreditSuisse.IT_DEV_RISK.Domain.Interfaces;
using CreditSuisse.IT_DEV_RISK.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CreditSuisse.IT_DEV_RISK
{
    public class InputTradeClient
    {
        public void Run()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            Console.WriteLine("---------------------------- INPUT -------------------------------------");

            Console.WriteLine("Enter the reference date in the format mm/dd/yyyy");
            DateTime referenceDate = ReadReferenceDate();

            Console.WriteLine("Enter the number of trades");
            int tradesNumber = ReadTradeNumber();

            Console.WriteLine("Enter the trades in the format (amount client_sector next_pending_payment)");
            List<ITrade> trades = ReadTrades(referenceDate, tradesNumber);

            WriteTradeOperation(referenceDate, tradesNumber, trades);
        }

        private void WriteTradeOperation(DateTime referenceDate, int tradesNumber, List<ITrade> trades)
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------------- OUTPUT -------------------------------------");
            Console.WriteLine(referenceDate.ToShortDateString());
            Console.WriteLine(tradesNumber);

            foreach (ITrade trade in trades)
            {
                Console.WriteLine(trade.GetTradeType());
            }

            Console.ReadKey();
        }

        private List<ITrade> ReadTrades(DateTime referenceDate, int tradesNumber)
        {
            List<ITrade> trades = new();

            for (int i = 0; i < tradesNumber; i++)
            {
                ReadTrade(trades, referenceDate);
            }

            return trades;
        }

        private void ReadTrade(List<ITrade> trades, DateTime referenceDate)
        {
            string input = Console.ReadLine();

            if (ValidateTradeInput(input))
            {
                try
                {
                    trades.Add(CreateTrade(input, referenceDate));
                }
                catch (ArgumentException argex)
                {
                    Console.WriteLine(argex.Message);
                    Console.WriteLine("Enter the trades in the format (amount client_sector next_pending_payment) and press enter twice when done");
                    ReadTrade(trades, referenceDate);
                }
            }
            else
            {
                Console.WriteLine("Enter the trades in the format (amount client_sector next_pending_payment) and press enter twice when done");
                ReadTrade(trades, referenceDate);
            }
        }

        private bool ValidateTradeInput(string input)
        {
            string[] fields = input.Split(" ");

            return 
                fields.Length == 3 &&
                double.TryParse(fields[0], out _) && 
                (fields[1].ToUpper() == "PRIVATE" || fields[1].ToUpper() == "PUBLIC") &&
                DateTime.TryParse(fields[2], out _);
        }

        private ITrade CreateTrade(string input, DateTime referenceDate)
        {
            string[] fields = input.Split(" ");
            return TradeFactory.CreateTrade(double.Parse(fields[0]), fields[1], DateTime.Parse(fields[2]), referenceDate);
        }

        private int ReadTradeNumber()
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int tradeNumber))
            {
                Console.WriteLine("Trade number is in an incorrect format!");
                tradeNumber = ReadTradeNumber();
            }

            return tradeNumber;
        }

        private DateTime ReadReferenceDate()
        {
            string input = Console.ReadLine();

            if (!DateTime.TryParse(input, out DateTime refereceDate))
            {
                Console.WriteLine("The reference date is in an incorrect format!");
                Console.WriteLine("Enter the reference date in the format mm/dd/yyyy");
                refereceDate = ReadReferenceDate();
            }

            return refereceDate.Date;
        }
    }
}
