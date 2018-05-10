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

namespace BindingExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomNumber = 0;
        Random random;
        MyRandom myRandom;

        public MainWindow()
        {
            InitializeComponent();

            random = new Random(1);
            myRandom = new MyRandom();

            this.DataContext = myRandom;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myRandom.RandomNumber = random.Next();
        }

        private void TextBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            ;
        }
    }

    public class MyRandom : INotifyPropertyChanged
    {
        private int _randomNum;

        public MyRandom()
        {
            RandomNumber = 25;
        }

        public int RandomNumber
        {
            get { return _randomNum;  }
            set
            {
                _randomNum = value;
                OnPropertyChanged("RandomNumber");
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
