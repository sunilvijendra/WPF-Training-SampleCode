using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutSampleDemo
{
    public class MyProducts
    {
        Dictionary<string, List<string>> productList = null;
        public MyProducts()
        {
            productList = new Dictionary<string, List<string>>();

            productList.Add("Mobiles", new List<string> {"iPhoneX", "Samsung S9", "OnePlus 6", "Redmi 5" });
            productList.Add("Television", new List<string> { "Sony 65 inch", "Samsung 59 inch", "Panasonic 60 inch" });
        }

       
        public Dictionary<string, List<string>> ProductList
        {
            get
            {
                return productList;
            }
            set
            {
                productList = value;
            }
        }

        public List<String> CategoryAndProducts
        {
            get {

                List<string> catAndProds = new List<string>();
                foreach (string cat in productList.Keys)
                {
                    catAndProds.Add(cat);
                    catAndProds.AddRange(productList[cat]);
                }

                return catAndProds;
            }
        }
    }
}
