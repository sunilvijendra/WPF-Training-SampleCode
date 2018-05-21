using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        public List<Product> GetAllProducts()
        {
            List<Product> prodLst = new List<Product>();

            prodLst.Add(new Product() { ProductId = 1, ProductName = "Mobile" });
            prodLst.Add(new Product() { ProductId = 2, ProductName = "Television" });

            return prodLst;
        }
    }
}
