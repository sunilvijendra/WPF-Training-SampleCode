using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDatabaseWPF
{
    class DatabaseAccess
    {

        public static Collection<Product> GetProducts(string sqlQuery)
        {
            string m_connectionString = @"Data Source=C:\Users\sunilvijendra\Documents\rockwell_csharp\DemoPrograms\Demo_Database\testDB.db;Version=3;";

            IDbConnection connection = new SQLiteConnection(m_connectionString);

            Collection<Product> collection = new Collection<Product>();

            IDbCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;

            try
            {
                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            Product p = MapProduct(reader);
                            collection.Add(p);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;


                        // NOTE: 
                        // consider handling exeption here instead of re-throwing
                        // if graceful recovery can be accomplished
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;

                // NOTE: 
                // consider handling exeption here instead of re-throwing
                // if graceful recovery can be accomplished
            }
            finally
            {
                connection.Close();
            }
            return collection;
        }

        public static Collection<PurchaseOrder> GetOrders(string sqlQuery)
        {
            string m_connectionString = @"Data Source=C:\Users\sunilvijendra\Documents\rockwell_csharp\DemoPrograms\Demo_Database\testDB.db;Version=3;";

            IDbConnection connection = new SQLiteConnection(m_connectionString);
            Collection<PurchaseOrder> collection = new Collection<PurchaseOrder>();
            IDbCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;

            try
            {
                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            PurchaseOrder p = MapPurchaseOrder(reader);
                            collection.Add(p);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;


                        // NOTE: 
                        // consider handling exeption here instead of re-throwing
                        // if graceful recovery can be accomplished
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;

                // NOTE: 
                // consider handling exeption here instead of re-throwing
                // if graceful recovery can be accomplished
            }
            finally
            {
                connection.Close();
            }

            return collection;
        }

        private static Product MapProduct(IDataReader record)
        {
            Product prod = new Product();

            try
            {
                prod.id = (DBNull.Value == record["ProductID"]) ? 0 : (int)record["ProductId"];

                prod.name = (DBNull.Value == record["ProductName"]) ? "" : (string)record["ProductName"];
            }
            catch (Exception e)
            {
                throw e;
            }

            return prod;
        }

        private static PurchaseOrder MapPurchaseOrder(IDataReader record)
        {
            PurchaseOrder o = new PurchaseOrder();
            // Add mapping code
            try
            {
                o.orderId = (DBNull.Value == record["OrderId"]) ? 0 : (long)record["OrderId"];
                o.purchaserName = (DBNull.Value == record["PurchaserName"]) ? "" : (string)record["PurchaserName"];
                o.purchaserAddr = (DBNull.Value == record["PurchaserAddress"]) ? "" : (string)record["PurchaserAddress"];
                //o.purchaseDate = (DBNull.Value == record["PurchaseDate"]) ? new DateTime(0) : (DateTime)record["PurchaseDate"];
                o.Quantity = (DBNull.Value == record["Quantity"]) ? 0 : (int)record["Quantity"];
                o.Amount = (DBNull.Value == record["Amount"]) ? 0 : (double)record["Amount"];
                o.productId = (DBNull.Value == record["ProductId"]) ? 0 : (int)record["ProductId"];
                o.comments = (DBNull.Value == record["comments"]) ? "" : (string)record["comments"];
            }
            catch (Exception e)
            {
                throw e;
            }
            return o;
        }


        public static void InsertIntoOrder(string name, string addr, DateTime date, int productId, int quantity, double amount, string comment)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO PurchaseOrder ");
            sb.AppendFormat("VALUES('{0}','{1}','{2}','{3},'{4}','{5}','{6}','{7}')",
                               null,
                               name,
                               addr,
                               date,
                               productId,
                               quantity,
                               amount,
                               comment);

            string sqlQuery = sb.ToString();

            // Create connection
            // ExecutNonQuery
        }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PurchaseOrder
    {
        public long orderId { get; set; }
        public string purchaserName { get; set; }
        public string purchaserAddr { get; set; }
        public DateTime purchaseDate { get; set; }
        public int productId { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public string comments { get; set; }
    }
}
