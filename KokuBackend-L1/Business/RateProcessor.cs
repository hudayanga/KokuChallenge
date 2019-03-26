using System;
using System.Collections.Generic;
using System.Linq;
using KokuBackend_L1.Business;
using KokuBackend_L1.Data;

namespace KokuBackend.Business
{
    public class RateProcessor
    {
        private readonly IList<RateL2> ratesList = null;
        private readonly ForexDbContext context = null;

        private int qty = 0;
        private int originalQuantity = 0;
        private decimal bestRate = 0;

        private List<RateL3> rates = null;
        private List<RateL3> newRates = null;
        public List<RateL3> Rates { get; set; }

        public RateProcessor()
        {
            ratesList = new List<RateL2>
            {
                new RateL2()
                {
                    Id = 1,
                    Partner = "A",
                    Supply = 100,
                    ForexRate = 1.3M
                },

                new RateL2()
                {
                    Id = 2,
                    Partner = "B",
                    Supply = 50,
                    ForexRate = 1.35M
                },

                new RateL2()
                {
                    Id = 3,
                    Partner = "C",
                    Supply = 20,
                    ForexRate = 1.37M
                },

            };

            context = new ForexDbContext();

        }

        public RateProcessor(int quantity)
        {
            context = new ForexDbContext();
            newRates = new List<RateL3>();

            rates = context.L3Rates.ToList();

            originalQuantity = quantity;
            qty = quantity;

        }

        private void PrepareRateStructure()
        {
            int index = 0;
            int takenQuantity = 0;

            while (index < rates.Count)
            {
                rates[index].EffectiveRate = rates[index].Supply > qty ? (rates[index].Rate) - (rates[index].ServiceCharge / qty) :
                                                                               (rates[index].Rate) - (rates[index].ServiceCharge / rates[index].Supply);
                index = index + 1;
            }

            var item = rates.OrderByDescending(rate => rate.EffectiveRate).First();
            takenQuantity = item.Supply <= qty ? item.Supply : qty;
            qty = qty - takenQuantity;
            bestRate = bestRate + (takenQuantity * item.EffectiveRate);

            //insert to collection
            newRates.Add(new RateL3()
            {
                Id = item.Id,
                Partner = item.Partner,
                Supply = item.Supply,
                TakenQuantity = takenQuantity,
                Rate = item.Rate,
                EffectiveRate = item.EffectiveRate,
                ServiceCharge = item.ServiceCharge
            });

            //remove from the collection
            rates.Remove(item);
        }
        public decimal GetRatesWithFee()
        {
            while (qty != 0)
            {
                PrepareRateStructure();
            }

            //return newRates;
            Rates = newRates;
            return bestRate / originalQuantity;
        }


        public decimal FindBestRate(int amount)
        {
            var sorted = ratesList.OrderByDescending(x => x.ForexRate);

            var bestrate = CalcBestRate(sorted, amount);

            return bestrate;
        }

        public decimal FindBestRateFromDb(int amount)
        {

            var sorted = context.L2Rates.OrderByDescending(x => x.ForexRate);

            var bestrate = CalcBestRate(sorted, amount);

            return bestrate;
        }

        private decimal CalcBestRate(IEnumerable<RateL2> rates, int amount)
        {
            for (int i = 1; i < rates.Count() + 1; i++)
            {
                var sumSupply = rates.Take(i).Sum(x => x.Supply);

                if (sumSupply >= amount)
                {
                    var final = 0M;
                    var balance = amount;

                    for (int j = 0; j < i; j++)
                    {
                        var currSupply = (rates.ElementAt(j).Supply);
                        var currRate = (rates.ElementAt(j).ForexRate);

                        if (balance > currSupply)
                        {
                            final = final + (currRate * currSupply);
                        }
                        else
                        {
                            final = final + (balance * currRate);
                        }

                        balance = balance - currSupply;

                    }

                    var bestRate = final / amount;

                    return bestRate;
                }
                else
                {
                    continue;
                }

            }

            return 0;

        }
    }
}
