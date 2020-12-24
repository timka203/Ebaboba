using Ebabobo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DrawIncomeChart(2);
            DrawOutcomeChart(2);
        }

        private void DrawIncomeChart(int cardId)
        {
            var allHistory = new History().GetHistoryByCard(cardId.ToString(), true);
            ((ColumnSeries)ChartIncome.Series[0]).ItemsSource = allHistory;
        }
        private void DrawOutcomeChart(int cardId)
        {
            var allHistory = new History().GetHistoryByCard(cardId.ToString(), false);
            ((ColumnSeries)ChartOutcome.Series[0]).ItemsSource = allHistory;
        }
    }

}
