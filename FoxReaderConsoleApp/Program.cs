using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxReaderConsoleApp.FoxDSTableAdapters;
using FoxReaderConsoleApp.SqlServerDSTableAdapters;

namespace FoxReaderConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var foxDA = new FoxDataAccess();
            var data = foxDA.GetData("ORDENES.DBF");
            var ta = new ItemTableAdapter();
            var sqlta = new ITEMTableAdapter();
            var sqlDt = new SqlServerDS.ITEMDataTable();
            var foxDt = ta.GetDataItrm();

            foreach(FoxDS.ItemRow r in foxDt)
            {
                Console.WriteLine(string.Join(",",r.ItemArray));
                sqlDt.AddITEMRow(r.cod_item, r.cod_iten, r.nomb_item, r.cod_par, r.precio_pro, r.existe, r.precio_ult,
                    r.unidad, r.uti_item1, r.uti_item2, r.uti_item3, r.maximo, r.minimo, r.factor, r.prsocio, r.prventa,
                    r.protros, r.cta_mer, r.cta_vta, r.grupo, r.uso);

            }

            sqlta.Update(sqlDt);

            Console.ReadLine();
        }
    }
}
