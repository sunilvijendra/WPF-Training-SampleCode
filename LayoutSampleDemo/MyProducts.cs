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
        Dictionary<string, List<string>> lst = null;
        public MyProducts()
        {
            lst = new Dictionary<string, List<string>>();

            lst.Add("Mobiles", new List<string> {"iPhoneX", "Samsung S9", "OnePlus 6", "Redmi 5" });
            lst.Add("Television", new List<string> { "Sony 65 inch", "Samsung 59 inch", "Panasonic 60 inch" });
        }

        public Dictionary<string, List<string>> ProductList
        {
            get { return lst; }
            set { lst = value;}
        }

        public List<String> CategoryAndProducts
        {
            get {

                List<string> catAndProds = new List<string>();
                foreach (string cat in lst.Keys)
                {
                    catAndProds.Add(cat);
                    catAndProds.AddRange(lst[cat]);
                }

                return catAndProds;
            }
        }
    }
}
