using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebApplication7.Views
{
    public class download_magaz:download
    {
        public download_magaz() : base("\\MAGAINI\\")
        {


        }
        public override void analitick()
        {
            //мск
            for (int f = 2; true; f++)
            {
                var ff= ((Excel.Range)xlSht.Cells[f, 1]).Value;
                if (ff == null) break;
                WebApplication7.Views.wodili.data_manager.MSK.Add(ff.ToString());
             
            }
            //орехово
            for (int f = 2; true; f++)
            {
                var ff = ((Excel.Range)xlSht.Cells[f, 2]).Value;
                if (ff == null) break;
                WebApplication7.Views.wodili.data_manager.OREH.Add(ff.ToString());
                WebApplication7.Views.wodili.data_manager.ALLOBL.Add(ff.ToString());
            }

            //истра
            for (int f = 2; true; f++)
            {
                var ff = ((Excel.Range)xlSht.Cells[f, 3]).Value;
                if (ff == null) break;
                WebApplication7.Views.wodili.data_manager.ISTR.Add(ff.ToString());
                WebApplication7.Views.wodili.data_manager.ALLOBL.Add(ff.ToString());
            }

            //коломна
            for (int f = 2; true; f++)
            {
                var ff = ((Excel.Range)xlSht.Cells[f, 4]).Value;
                if (ff == null) break;
                WebApplication7.Views.wodili.data_manager.KOL.Add(ff.ToString());
                WebApplication7.Views.wodili.data_manager.ALLOBL.Add(ff.ToString());
            }

        }
    }
}
