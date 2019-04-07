using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoinMidterm.Models
{
    [Serializable]
    public class CurrencyRepo : ICurrencyRepo
    {
        public static string SaveLocation = AppDomain.CurrentDomain.BaseDirectory + "CurrencyRepoSave.txt";
        public List<ICoin> Coins { get; set; }

        public CurrencyRepo()
        {
            Coins = new List<ICoin>();
        }
        public string About()
        {
            return ""; // Don't know what to return yet?
        }

        public void AddCoin(ICoin c)
        {
            Coins.Add(c);
        }

        public static ICurrencyRepo CreateChange(double Amount)
        {
            CurrencyRepo change = new CurrencyRepo();
            while(Amount > 0)
            {
                /* Used Math.Round() because for some reason, during the 11 cents test, 
                 0.11 - 0.10 = 0.00999999999995 which != 0.01. So my program would break. :( */
                Amount = Math.Round(Amount, 2);

                if(Amount - 1 >= 0)
                {
                    Amount -= 1.00;
                    DollarCoin c = new DollarCoin();
                    change.AddCoin(c);
                }
                else if(Amount - 0.5 >= 0)
                {
                    Amount -= 0.5;
                    HalfDollar c = new HalfDollar();
                    change.AddCoin(c);
                }
                else if (Amount - 0.25 >= 0)
                {
                    Amount -= 0.25;
                    Quarter c = new Quarter();
                    change.AddCoin(c);
                }
                else if (Amount - 0.1 >= 0)
                {
                    Amount -= 0.10;
                    Dime c = new Dime();
                    change.AddCoin(c);
                }
                else if (Amount - 0.05 >= 0)
                {
                    Amount -= 0.05;
                    Nickel c = new Nickel();
                    change.AddCoin(c);
                }
                else if (Amount - 0.01 >= 0)
                {
                    Amount -= 0.01;
                    Penny c = new Penny();
                    change.AddCoin(c);
                }
                else
                {
                    // Change made
                }
            }

            return change;
        }

        public static ICurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            if(TotalCost > AmountTendered)
            {
                // Customer didn't pay enough
                return CreateChange(AmountTendered);
            }
            else
            {
                // Customer did pay enough
                AmountTendered -= TotalCost;
                return CreateChange(AmountTendered);
            }
        }

        public int GetCoinCount()
        {
            return Coins.Count;
        }

        public ICurrencyRepo MakeChange(double Amount)
        {
            return CreateChange(Amount);
        }

        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            return CreateChange(AmountTendered, TotalCost);
        }

        public ICoin RemoveCoin(ICoin c)
        {
            if(Coins.Contains(c))
            {
                Coins.Remove(c);
            }
            else
            {
                // Do nothing? No coin of that type to remove.
            }

            return c;
        }

        public double TotalValue()
        {
            double aggregateValue = 0;
            foreach(Coin c in Coins)
            {
                aggregateValue += c.MonetaryValue;
            }
            return aggregateValue;
        }

        public string[] CoinNames()
        {

            List<string> Names = new List<string>();

            foreach(Coin c in Coins)
            {
                Names.Add(c.Name);
            }

            return Names.ToArray();
        }

        public void SaveRepo(CurrencyRepo SentRepo)
        {
            // At the risk of possible data loss, I have to clear the inventory save file in order to prevent the player
            // from basically never losing an item if the last item in their inventory happens to reach 0 durability
            //InventoryList.Reverse();
            //System.IO.File.Create(SaveInventorylocation);

            List<string> RepoData = new List<string>();

            foreach(USCoin c in SentRepo.Coins)
            {
                RepoData.Add(c.Name + ',' + c.MonetaryValue + ',' + c.Year);
            }

            //System.IO.File.AppendAllLines(SaveInventorylocation, ALLINVENTORYINFO);
            System.IO.File.WriteAllLines(SaveLocation, RepoData.ToArray());
        }

        public void LoadRepo()
        {
            try
            {
                // Get all the repo data and place it in a temporary string array;
                string[] RepoLoadedData = System.IO.File.ReadAllLines(SaveLocation);
                
                for (int CoinPosition = 0; CoinPosition < RepoLoadedData.Length; CoinPosition++)
                {
                    // Take a single loaded item from the array and separate the components into another array for transfer
                    string[] ReadCoin = RepoLoadedData[CoinPosition].Split(',');

                    // Check if the ReadCoin is blank. If not, add to repo;
                    if (ReadCoin[0] != "")
                    {
                        switch(ReadCoin[0])
                        {
                            case "Penny":
                                {
                                    Penny tempC = new Penny();
                                    tempC.Year = Convert.ToInt32(ReadCoin[2]);
                                    break;
                                }
                            case "Nickel":
                                {
                                    Nickel tempC = new Nickel();
                                    tempC.Year = Convert.ToInt32(ReadCoin[2]);
                                    break;
                                }
                            case "Dime":
                                {
                                    Dime tempC = new Dime();
                                    tempC.Year = Convert.ToInt32(ReadCoin[2]);
                                    break;
                                }
                            case "Quarter":
                                {
                                    Quarter tempC = new Quarter();
                                    tempC.Year = Convert.ToInt32(ReadCoin[2]);
                                    break;
                                }
                            case "Half Dollar":
                                {
                                    HalfDollar tempC = new HalfDollar();
                                    tempC.Year = Convert.ToInt32(ReadCoin[2]);
                                    break;
                                }
                            case "Dollar Coin":
                                {
                                    DollarCoin tempC = new DollarCoin();
                                    tempC.Year = Convert.ToInt32(ReadCoin[2]);
                                    break;
                                }
                        }

                    }
                }

                //loadInvSuccess = true;
            }
            catch (Exception e)
            {
                // Nothing to load?
                //ALLINVENTORYINFO.Initialize();
                //loadInvSuccess = false;
            }
        }
    }
}
