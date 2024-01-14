using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json;
namespace WebApplication1.Controllers.loger_
{
    public class loger
    {
        static object locker2 = new object();
        //сохраняет !!!текст заказа  !!!по дате и !!!айди
        public static void sawe_reestr(WebApplication7.Views.wodili.zakaz zakazi, string data, string id)
        {
              string text = JsonSerializer.Serialize(zakazi);


                lock (locker2)
                {
                    if (!Directory.Exists("Files\\HIDTORY\\" + data + "\\"))
                        Directory.CreateDirectory("Files\\HIDTORY\\" + data + "\\");

                    using (var writer = new StreamWriter("Files\\HIDTORY\\" + data + "\\" + id + ".txt", false))
                    {
                        //Добавляем к старому содержимому файла
                        writer.WriteLine(text);
                    }
                }
            
        }
      
        //загрузить реестры с даты по дату
     
        static DateTime convert_data2(string started)
        {
            string day = started[8].ToString() + started[9].ToString() + "";
            string mounth = started[5].ToString() + started[6].ToString() + "";
            string yer = started[0].ToString() + started[1].ToString() + started[2].ToString() + started[3].ToString() + "";



            DateTime dateOne = new DateTime(Convert.ToInt32(yer), Convert.ToInt32(mounth), Convert.ToInt32(day)).Date;
            return dateOne;
        }
        //загрузка реестров между датами
        //static string path= "C:\\Users\\alexx\\Desktop\\20.11\\HIDTORY\\";
        static string path = @"C:\Users\alexx\Desktop\20.11\04.10\WebApplication1\Files\HIDTORY\";
        public static List<WebApplication7.Views.wodili.zakaz> download_reestr(string started, string end)

        {
            lock (locker2)
            {
              

                DateTime dateOne = convert_data2( started);


                
                DateTime thisDay = convert_data2(end);



              
                List<DateTime> datesBetween = new List<DateTime>();
                for (DateTime d = dateOne; d <= thisDay; d = d.AddDays(1))
                {
                     datesBetween.Add(d);
                }

                List<WebApplication7.Views.wodili.zakaz> pp = new List<WebApplication7.Views.wodili.zakaz>();

                for (int x = 0; x < datesBetween.Count; x++)
                {
                    string data = datesBetween[x].ToString();
                    string[] data_ = data.Split(" ");
                    data = data_[0];
                    if (Directory.Exists(path + data + "\\"))
                    {
                        string[] zakazi = Directory.GetFiles(path + data + "\\");
                        for (int ofds = 0; ofds < zakazi.Length; ofds++)
                        {

                            string zaaak = "";
                            using (var writer = new StreamReader(zakazi[ofds], true))
                            {
                                //отсеиваю файлы с тегом _status


                                zaaak += writer.ReadLine();
                            }
                            int fdsf = 0;

                            pp.Add(JsonSerializer.Deserialize<WebApplication7.Views.wodili.zakaz>(zaaak));



                        }
                    }
                }
                return pp;
            }
        }
        //загрузка даты точное
      
        public static List<WebApplication7.Views.wodili.zakaz> download_data(string id)

        {
            lock (locker2)
            {

              
                List<WebApplication7.Views.wodili.zakaz> pp = new List<WebApplication7.Views.wodili.zakaz>();

                string[] datesBetween = Directory.GetDirectories(path);
                for (int x = 0; x < datesBetween.Length; x++)
                {
                    string data = datesBetween[x].ToString();
                    string[] data_ = data.Split(" ");
                    data = data_[0];
                    if (Directory.Exists(data ))
                    {
                        string[] zakazi = Directory.GetFiles( data );
                        for (int ofds = 0; ofds < zakazi.Length; ofds++)
                        {
                            string[] id_zakaza = zakazi[ofds].Split("\\");
                            string id_zakazad = id_zakaza[id_zakaza.Length-1].Replace(".txt", "");
                            if (id == id_zakazad)
                            {
                                string zaaak = "";
                                using (var writer = new StreamReader(zakazi[ofds], true))
                                {
                                    //отсеиваю файлы с тегом _status


                                    zaaak += writer.ReadLine();
                                }


                                pp.Add(JsonSerializer.Deserialize<WebApplication7.Views.wodili.zakaz>(zaaak));

                            }

                        }
                    }
                }
                return pp;
            }
        }

        public static void sawe_status(string id, string status)
        {
            string data = WebApplication7.Views.wodili.data_manager.get_data(id);
            lock (locker2)
            {
                if (!Directory.Exists("Files\\HIDTORY\\" + data + "\\"))
                {
                    int fe = 0;//ошибка
                }
                string zaaak = "";
                using (var writer = new StreamReader("Files\\HIDTORY\\" + data + "\\" + id + ".txt", true))
                {
                   

                        zaaak += writer.ReadLine();
                    
                    
                }

                WebApplication7.Views.wodili.zakaz pp = JsonSerializer.Deserialize<WebApplication7.Views.wodili.zakaz>(zaaak);
                pp.status.Add(new WebApplication7.Views.wodili.status_( status) );

                using (var writer = new StreamWriter("Files\\HIDTORY\\" + data + "\\" + id  + ".txt", false))
                {
                    //устанавливаю статус 
                 
                    writer.WriteLine(JsonSerializer.Serialize(pp));
                }
            }
        }

        public static void sawe_foto(string id, string foto_path)
        {
            string data = WebApplication7.Views.wodili.data_manager.get_data(id);
            lock (locker2)
            {
                if (!Directory.Exists("Files\\HIDTORY\\" + data + "\\"))
                {
                    int fe = 0;//ошибка
                }
                string zaaak = "";
                using (var writer = new StreamReader("Files\\HIDTORY\\" + data + "\\" + id + ".txt", true))
                {


                    zaaak += writer.ReadLine();


                }

                WebApplication7.Views.wodili.zakaz pp = JsonSerializer.Deserialize<WebApplication7.Views.wodili.zakaz>(zaaak);
                pp.foto.Add( foto_path );

                using (var writer = new StreamWriter("Files\\HIDTORY\\" + data + "\\" + id + ".txt", false))
                {
                    //устанавливаю статус 

                    writer.WriteLine(JsonSerializer.Serialize(pp));
                }
            }
        }
    }
}
