namespace Vending
{
    public static class VendingLib
    {
        private static int _moneyEntered = 0;
        private static readonly List<int> coinsList = Enum.GetValues(typeof(Coins)).Cast<int>().Select(coin => (int)coin).ToList();
        private static readonly Dictionary<string, int> drinks = Enum.GetValues(typeof(Drinks)).Cast<Drinks>()
            .ToDictionary(key => key.ToString(), value => (int) value);
        private static readonly Dictionary<string, int> addings = Enum.GetValues(typeof(Additional)).Cast<Additional>()
            .ToDictionary(key => key.ToString(), value => (int)value);

        public static Status EnterMoney(int moneyEntered)
        {
            if (coinsList.Contains(moneyEntered))
                _moneyEntered += moneyEntered;
            return Status.MONEY_ENTERED_SUCCESSFULLY;
        }

        public static int GetCurrentBalance()
        {
            return _moneyEntered;
        }

        public static Status ReturnMoney()
        {
            _moneyEntered = 0;
            return Status.MONEY_RETURNED_TO_USER;          
        }

        public static void ShowManu()
        {
            Console.WriteLine("Optional drinks are: ");
            Console.WriteLine(String.Join(Environment.NewLine, drinks));
            Console.WriteLine("Optional drinks are: ");
            Console.WriteLine(String.Join(Environment.NewLine, addings));
        }

        public static Status BuyProduct(Drinks drink)
        {
            int drinkPrice = Convert.ToInt32(drink);

            if (_moneyEntered < drinkPrice)
            {
                return Status.NOT_ENOUGH_MONEY;
            }

            _moneyEntered -= drinkPrice;

            return Status.PRODUCT_SUPPLIED;
        }

        public static Status BuyProduct(Drinks drink, params Additional[] add)
        {
            int drinkPrice = Convert.ToInt32(drink);

            foreach (Additional additional in add) {
                drinkPrice += Convert.ToInt32(additional);
            }

            if (_moneyEntered < drinkPrice)
            {
                return Status.NOT_ENOUGH_MONEY;
            }

            _moneyEntered -= drinkPrice;

            return Status.PRODUCT_SUPPLIED;
        }

        public static Dictionary<string, int> GetDrinkMap()
        {
            return drinks;
        }

        public static Dictionary<string, int> GetAddingsMap()
        {
            return addings;
        }

        public static int GetDrinkPrice(string key)
        {
            int price = 0;
            drinks.TryGetValue(key, out price);
            return price;
        }

        public static int GetAdditionPrice(string key)
        {
            int price = 0;
            addings.TryGetValue(key, out price);
            return price;
        }
    }
}