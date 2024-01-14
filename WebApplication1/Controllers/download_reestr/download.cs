using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace WebApplication7.Views
{
    public abstract class download
    {
        public download(string direct)
        {
            find(direct);

         }

        public delegate void post_call();
        public post_call end;
        public download(string direct, post_call s)
        {
            end = s;
            find(direct);

        }
     
        


        public static List<string> dowload_error = new List<string>();
        public string tek;
       public static List<string> finded2= new List<string>();
        void clear_powtor(List<string> path_new)
        {
            if (finded2 == null) return;
            foreach (string pathh in finded2)
            {
                for(int x = 0;x<path_new.Count;x++)
                {
                    if(pathh== path_new[x])
                    {
                        path_new.RemoveAt(x);
                        clear_powtor(path_new);
                        return;
                    }
                }
            }
        }
        void find(string path)
        {
             
            string[] allFoundFiles = Directory.GetFiles(Directory.GetCurrentDirectory()+ "\\Files\\" + path);
            List<string> finded = new List<string>();
            for (int x = 0; x < allFoundFiles.Length; x++)
            {
                if (allFoundFiles[x].IndexOf("~") == -1)
                    finded.Add(allFoundFiles[x]);
            }
            //не гружу реестры которые уже были
            if ("\\REESTR\\" == path)
            {
                clear_powtor(finded);
                foreach(string zz in finded)
                finded2.Add(zz);

            }
            foreach (string path_ in finded)
            {
                tek = path_;
                _download(path_);
                analitick();
                clear();
            }
           if( end!=null) end();
        }

        public Excel.Workbook xlWB;
        public Excel.Worksheet xlSht;
        public Excel.Application xlApp;
        public Excel.Range Rng;
        void _download(string xlFileName)
        {
            xlApp = new Excel.Application(); //создаём приложение Excel
            xlWB = xlApp.Workbooks.Open(xlFileName); //открываем наш файл            
            xlSht = (Excel.Worksheet)xlWB.ActiveSheet;//активный лист
            long fe = (long)xlSht.Rows.CountLarge;
            Excel.Range ff = (Excel.Range)xlSht.Cells[1, 1];
            Excel.Range ff2 = (Excel.Range)xlSht.Cells[1000, 1000];
            Rng = xlSht.Range[ff, ff2];
        }

        public abstract void analitick();

        void clear()
        {
            xlWB.Close(true); //сохраняем и закрываем файл
            xlApp.Quit();

            releaseObject(xlSht);
            releaseObject(xlWB);
            releaseObject(xlApp);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;

            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
