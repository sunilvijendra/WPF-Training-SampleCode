using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutSampleDemo
{
    public class Product
    {
        string _categoryName;
        string _productName;

        public Product()
        {
        }

        public Product(string _category, string _name)
        {
            _categoryName = _category;
            _productName = _name;
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
    }
}
