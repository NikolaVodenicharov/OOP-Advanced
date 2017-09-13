
    using System;
    using System.Collections.Generic;

    public class CoffeeMachine
    {
        private List<Coin> coins;

        public CoffeeMachine()
        {
            this.coins = new List<Coin>();
            this.CoffeesSold = new List<CoffeeType>();
        }

        public List<CoffeeType> CoffeesSold { get; }

        public void BuyCoffee (string size, string type)
        {
            var coinAmount = 0;
            foreach (var coin in this.coins)
            {
                coinAmount += (int)coin;
            }

            CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
            if (coinAmount >= (int)coffeePrice)
            {
                CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);
                this.CoffeesSold.Add(coffeeType);
                this.coins.Clear();
            }
        }

        public void InsertCoin (string inputCoin)
        {
            // try-catch for invalid inputCoin
            Coin coin = (Coin)Enum.Parse(typeof(Coin), inputCoin);
            this.coins.Add(coin);
        }
    }

