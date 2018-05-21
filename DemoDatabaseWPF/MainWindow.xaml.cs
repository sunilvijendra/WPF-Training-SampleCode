using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DemoDatabaseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyData myData;

        public MainWindow()
        {
            InitializeComponent();

            myData = new MyData();
            this.DataContext = myData;
        }

        private void btnFetchFromDB_Click(object sender, RoutedEventArgs e)
        {
        }

        private void cmbProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Collection<Product> prodList = DatabaseAccess.GetProducts("select * from Product");
            string selName = (string) cmbProductList.Items[cmbProductList.SelectedIndex];

            myData.CurrentProductId = prodList.First(x => x.name == selName).id;

            dgOrders.ItemsSource = myData.OrderList;
           
        }
    }

    public class MyData
    {   
        public int CurrentProductId { get; set; }

        public List<string> ProductNames
        {
            get
            {
                Collection<Product> prodList = DatabaseAccess.GetProducts("select * from Product");
                //Collection<PurchaseOrder> orderList = dbAccess.GetOrders("select * from PurchaseOrder");

                List<string> lstProductNames = new List<string>();
                foreach (Product p in prodList)
                {
                    lstProductNames.Add(p.name);
                }
                return lstProductNames;
            }
        }

        public List<PurchaseOrder> OrderList
        {
            get
            {
                Collection<PurchaseOrder> orderList = DatabaseAccess.GetOrders(
                                        "select * from PurchaseOrder where ProductId=" + CurrentProductId );

                return orderList.ToList();
            }
        }
    }
}