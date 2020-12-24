using System;
using System.Collections.Generic;
using System.ComponentModel;
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

public partial class CategoryWindow : Window, INotifyPropertyChanged
{

    #region ViewModelProperty: Background
    private Brush _background;
    public Brush TheBackground
    {
        get
        {
            return _background;
        }

        set
        {
            _background = value;
            OnPropertyChanged("Background");
        }
    }
    #endregion



    public CategoryWindow()
    {
        InitializeComponent();
        DataContext = this;

        TheBackground = new SolidColorBrush(Colors.Red);
     

        

    }
    private void addCategoryBtn(object sender, RoutedEventArgs e)
    {
            TheBackground = new SolidColorBrush(Colors.Aquamarine);

    }

    #region INotifiedProperty Block
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;

        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion

}
}