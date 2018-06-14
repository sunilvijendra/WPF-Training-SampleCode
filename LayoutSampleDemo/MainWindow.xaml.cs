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

namespace LayoutSampleDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> myProducts = new List<string>() { "iPhone", "Redmi", "Sony TV" };

            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            for (int i = 0; i < myProducts.Count; i++)
            {
                string cat = GetCategory(myProducts[i]);
                ComboBoxItem cb = new ComboBoxItem();
                cb.Content = cat;

                int cnt = comboBoxItems.Count(x => (string) x.Content == cat);
 
                if (cnt == 0)
                {
                    cb.IsEnabled = false;
                    cb.FontWeight = FontWeights.Bold;
                    comboBoxItems.Add(cb);
                    cmbProducts.Items.Add(cb);
                }

                cb = new ComboBoxItem();
                cb.Content = myProducts[i];
                comboBoxItems.Add(cb);
                cmbProducts.Items.Add(cb);
            }

        }

        private string GetCategory(string p)
        {
            if (p.Equals("iPhone") || p.Equals("Redmi"))
                return "Mobiles";
            return "Television";
           
        }

        private void cmbProducts_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
