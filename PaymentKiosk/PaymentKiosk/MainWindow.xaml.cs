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
using PaymentKiosk.Core.Domain;
using PaymentKiosk.Core.Services;

namespace PaymentKiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TransactionButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer
            {
                Name = CustomerBox.Text,
                Telephone = TelephoneBox.Text,
            };

            var creditCard = new CreditCard
            {
                CardNumber = CardNumberBox.Text,
                SecurityCode = SCodeBox.Text,
                ExpiryDate = DateTime.Parse(ExpiryBox.Text),
            };

            try
            {
                bool success = MoneyService.Charge(customer, creditCard, decimal.Parse(CreditBox.Text));

                if (success)
                {
                    MessageBox.Show("Payment successful!");
                    SmsService.SendSms($"+1{TelephoneBox.Text}", $"Payment successful!  You have paid {CreditBox.Text} dollars via your card.");
                }
                else
                {
                    MessageBox.Show("Payment not successful.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        }
    }
