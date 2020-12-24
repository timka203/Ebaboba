using Ebabobo.Pages;
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

namespace Ebabobo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object OperationsPage = new OperationsPage();
        private object IncomeExpensesPage = new IncomeExpensesPage();
        private object InfoPage = new InfoPage();
        private object TransactionPage = new TransactionPage();
        public MainWindow()
        {
            InitializeComponent();
            InfoFrame.Navigate(InfoPage);
        }

        private void IncomeExpenses_MouseLeave(object sender, MouseEventArgs e)
        {
            if (IncomeExpenses.IsSelected)
            {
                IncomeExpensesFrame.Navigate(IncomeExpensesPage);
            }
        }

        private void Info_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Info.IsSelected)
            {
                InfoFrame.Navigate(InfoPage);
            }
        }

        private void Operations_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Operations.IsSelected)
            {
                OperationsFrame.Navigate(OperationsPage);
            }
        }

        private void Transaction_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Transaction.IsSelected)
            {
                TransactionFrame.Navigate(TransactionPage);
            }
        }

        private void createCardBtn(object sender, RoutedEventArgs e)
        {
            CreateAccount window = new CreateAccount();
            window.Show();
        }

        private void SendBtn(object sender, RoutedEventArgs e)
        {

        }
    }
}
