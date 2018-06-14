using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace MSAccessExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = D:\\Database1.accdb";
            string strSQL = "SELECT * FROM Developer";
            // create Objects of ADOConnection and ADOCommand  
            OleDbConnection myConn = new OleDbConnection(strDSN);
            OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, myConn);

            myConn.Open();

            DataSet dtSet = new DataSet();

            myCmd.Fill(dtSet, "Developer");
            DataTable dTable = dtSet.Tables[0];
            
            foreach (DataRow dr in dTable.Rows)
            {
                Console.WriteLine(dr.Field<string>("VersionNumber"));
            }

            myConn.Close();
        }
    }
}
