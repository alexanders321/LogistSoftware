using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using WebApplication7.Views.wodili;

namespace WebApplication7.Views
{
    public class download_wodili : download
    {
       public download_wodili( ) : base("\\WODILI\\")
        {


        }
        public override void analitick()
        {
           
            for (int f=1; true;f++)
            {
                driwer_download_data prom;
                Rng = (Excel.Range)xlSht.Range[xlSht.Cells[f, 1], xlSht.Cells[f, 7]];
                var dataArr = (object[,])Rng.Value;
                prom = new driwer_download_data();
                if (dataArr[1, 1] == null) break;

                prom.name = dataArr[1, 1].ToString();
                prom.location_in_startD = dataArr[1, 3].ToString();
                prom.location_in_startH = dataArr[1, 4].ToString();

                prom.max_obiome = Convert.ToDouble(dataArr[1, 5].ToString());
                prom.max_kg = Convert.ToInt32(dataArr[1, 6].ToString());
                if (prom.max_kg > 35) prom.color = "#ff0000";
                data_manager.from_pk.Add(prom);
            }

              
        }
    }
}
