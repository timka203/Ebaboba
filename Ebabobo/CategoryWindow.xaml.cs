using Ebabobo.Models;
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
using System.Windows.Shapes;

namespace Ebabobo
{
    /// <summary>
    /// Логика взаимодействия для CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow()
        {
            InitializeComponent();
        }

        private void addCategoryBtn(object sender, RoutedEventArgs e)
        {
            TransactionType transactionType = new TransactionType();
            transactionType.Name = tb_categoryName.Text;
            transactionType.IsIncome = cbCurrency.SelectedIndex.ToString();

            if (transactionType.Name != "")
            {
                if (transactionType.IsIncome == "0" || transactionType.IsIncome == "1")
                {
                    transactionType.Insert();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Выберите расход это или доход.");
                }
            }
            else
            {
                MessageBox.Show("Введите Название категорий и расход это или доход.");
            }
        }
    }
}
