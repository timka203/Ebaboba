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

namespace Ebabobo.Pages
{
    /// <summary>
    /// Логика взаимодействия для TransactionPage.xaml
    /// </summary>
    public partial class TransactionPage : Page
    {
        public TransactionPage()
        {
            InitializeComponent();
        }

        private void deleteSourceBtn(object sender, RoutedEventArgs e)
        {

        }

        private void deleteCategoryBtn(object sender, RoutedEventArgs e)
        {

        }

        private void addSourceBtn(object sender, RoutedEventArgs e)
        {

        }

        private void addCategoryBtn(object sender, RoutedEventArgs e)
        {
            CategoryWindow category = new CategoryWindow();
            category.Show();
        }
    }
}
