using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxReaderConsoleApp
{
    class FoxDataAccess
    {
        public DataSet GetData(string dbfile)
        {
            using (var conn = new OleDbConnection()) {
                //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.12.0;Data Source=c:\foxfiles;Extended Properties=dBASE IV;User ID=Admin;Password=;";
                conn.ConnectionString = @"Provider=VFPOLEDB.1;Data Source=E:\BODIMP09;";
                var adapter = new OleDbDataAdapter($"select * from {dbfile}", conn);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }           

        }

    }
}
