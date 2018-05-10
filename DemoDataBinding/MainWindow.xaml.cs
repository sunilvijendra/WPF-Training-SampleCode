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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product prod = null;

        public MainWindow()
        {
            InitializeComponent();

            prod  = new Product("Bottle", "Holds water, oil and etc.");

            this.DataContext = prod;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            //prod.Name = "Pen";
            //prod.Description = "To write";

            string message = "Product name = " + prod.Name + "; Desc = " + prod.Description;
            MessageBox.Show(message);
        }
    }

    public class Product : INotifyPropertyChanged
    {
        string _Name;
        string _Description;

        public Product(string _name, string _desc)
        {
            Name = _name;
            Description = _desc;
        }

        public string Name
        {
            get { return _Name; }
            set {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _Description; }
            set {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
