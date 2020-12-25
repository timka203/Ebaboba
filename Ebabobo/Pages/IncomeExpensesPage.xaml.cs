using Ebabobo.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Ebabobo.Pages
{
    /// <summary>
    /// Логика взаимодействия для IncomeExpensesPage.xaml
    /// </summary>
    public partial class IncomeExpensesPage : Page
    {
        DataTable incomeClone = null;
        DataTable outcomeClone = null;
        public IncomeExpensesPage()
        {
            InitializeComponent();
            ShowIncomeMethod();
        }

        public void ShowIncomeMethod()
        {
            DataTable incomeOutcome = new Schedule().SelectByCardId(MainWindow.CARDID.ToString());

            var income = from row in incomeOutcome.AsEnumerable()
                         where row.Field<bool>("IsIncome") == true
                         select row;

            incomeClone = incomeOutcome.Clone();
            foreach (DataRow dr in income)
            {
                incomeClone.ImportRow(dr);
            }

            var outcome = from row in incomeOutcome.AsEnumerable()
                          where row.Field<bool>("IsIncome") == false
                          select row;
            outcomeClone = incomeOutcome.Clone();
            foreach (DataRow dr in outcome)
            {
                outcomeClone.ImportRow(dr);
            }

            listOfIncome.DataContext = incomeClone.DefaultView;
            listOfOutcome.DataContext = outcomeClone.DefaultView;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

    }
}
