using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace WebApplication1.Models
{
    public class driver_database
    {
        public  class coord
        {
            public string shir { set; get; }
            public string dolg { set; get; }
            public string data { set; get; }
            public coord()
            {

            }
            public coord(string shir, string dolg)
            {
                this.shir = shir;
                this.dolg = dolg;
                data = DateTime.Now.ToString();
            }
        }
        public string id { set; get; }
        public string name { set; get; }
        public List<coord> coordinati { set; get; } 
        public List<driver_data> bloki { set; get; }
        public driver_database()
        {
            coordinati = new List<coord>();
            bloki = new List<driver_data>();
        }
        static object locker = new object();
        public  void save_coord_curier( string shir, string dolg)
        {

            lock (locker)
            {
                using (var writer = new StreamWriter(id + ".txt", true))
                {
                    //Добавляем к старому содержимому файла
                    coord pr = new coord(shir, dolg);
                    writer.WriteLine(JsonSerializer.Serialize(pr));
                }
            }
        }
        public void download_coord_curier()
        {
            lock (locker)
            {
               
                if (File.Exists(id + ".txt"))
                {
                    List<coord> coordinati2 = new List<coord>();
                    using (var writer = new StreamReader(id + ".txt", true))
                    {
                        //отсеиваю файлы с тегом _status
                        
                        while (!writer.EndOfStream) {
                            string zaaak = writer.ReadLine();
                            coord prome = JsonSerializer.Deserialize<coord>(zaaak);
                            coordinati2.Add(prome);
                        }
                        coordinati = coordinati2;
                    }
                    
                }
            }
        }
    }
    public class driver_data
    {
        public string zagolow { set; get; }
        public string iner_data { set; get; }
        public driver_data(string zagolow,string iner_data)
        {
            this.zagolow = zagolow;
            this.iner_data = iner_data;
        }
   public driver_data()
        {

        }
    }

   
 



}
