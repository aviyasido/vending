using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vending;

namespace VendingP
{
    public partial class MainWindow : Window
    {
        private int currentSum = 0;
        public MainWindow()
        {
            InitializeComponent();

            InitialCoffeeOptions();
            InitialAdditionOptions();
            currentBalance.Text = GetCurrentBalance();
            coffeeOptionsCombo.SelectionChanged += drinksCount_TextChanged;
            drinksCount.TextChanged += drinksCount_TextChanged;
            additionOptionsCombo.SelectionChanged += GetCurrentSumAddings;
        }

        private void InitialCoffeeOptions()
        {
            Dictionary<string, int> drinkMap = VendingLib.GetDrinkMap();
            foreach (KeyValuePair<string, int> drinks in drinkMap)
            {
                coffeeOptionsCombo.Items.Add(drinks.Key);
            }
        }

        private void InitialAdditionOptions()
        {
            Dictionary<string, int> addingsMap = VendingLib.GetAddingsMap();
            foreach (KeyValuePair<string, int> adding in addingsMap)
            {
                additionOptionsCombo.Items.Add(adding.Key);
            }
        }

        private string GetCurrentBalance()
        {
            return "Your current balance is " + VendingLib.GetCurrentBalance().ToString();
        }

        private void drinksCount_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (coffeeOptionsCombo.SelectedItem != null && !string.IsNullOrEmpty(textBox.Text))
            {
                int sum = int.Parse(((TextBox)sender).Text);
                if (sum < 0)
                {
                    priceToPay.Text = "Sum to pay is " + VendingLib.GetAdditionPrice(additionOptionsCombo.SelectedItem.ToString()) * sum;
                }
            }
        }

        private void GetCurrentSumAddings(object sender, SelectionChangedEventArgs e)
        {
            if (drinksCount != null && int.Parse(drinksCount.Text) > 0)
            {
                if (additionOptionsCombo.SelectedItem != null)
                {
                    int sum = int.Parse(additionsCount.Text);
                    priceToPay.Text = "Sum to pay is " + VendingLib.GetAdditionPrice(additionOptionsCombo.SelectedItem.ToString()) * sum;
                }
            }
        }

        private void drinksCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (coffeeOptionsCombo.SelectedItem != null && !string.IsNullOrEmpty(textBox.Text))
            {
                int sum = int.Parse(((TextBox)sender).Text);
                if (sum < 0)
                {
                    priceToPay.Text = "Sum to pay is " + VendingLib.GetAdditionPrice(additionOptionsCombo.SelectedItem.ToString()) * sum;
                }
            }
        }
    }
}
