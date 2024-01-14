using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
 

namespace WebApplication1.Controllers
{
    public class FILE : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Reestr()
        {
            
            return View();
        }
        public IActionResult Foto()
        {
            return View();
        }
     public static  string[] file;
        //все файлы в папке
        public IActionResult foto_kurera(string path)
        {
            file = Directory.GetFiles(path+"\\");
            return View();
        }
      //отправляет вместо дефолтного ответа фото
        public IActionResult Foto_pokaz(string path)
        {
                Byte[] b;
            
            b = System.IO.File.ReadAllBytes(path); 
            return File(b, "image/jpeg");
        }
       
        public IActionResult Delete_all()
        {
            if (once)
            {
                once = false;
                delete_all_file_in_reestr();
                once = true;
            }
            return View("Reestr");
        }
      public static  bool once = true;
        public IActionResult Download([FromForm(Name = "uploads")] IFormFileCollection file, int brandId)
        {
            if (once)
            {
                once = false;
               // WebApplication7.Views.wodili.data_manager.clear_reestr();
                foreach (IFormFile ffe in file)
                {
                    string directory = Environment.CurrentDirectory + "/Files/REESTR/";
                    string new_file_name = anti_perezapis(ffe.FileName, directory);
                    // путь к папке Files

                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (FileStream fstream = new FileStream(directory + new_file_name, FileMode.OpenOrCreate))
                    {
                        ffe.CopyTo(fstream);
                    }



                }
                WebApplication7.Views.wodili.data_manager.start();
                once = true;
            }
                return RedirectToAction("Reestr");
            
        }

        public static string anti_perezapis(string fileName, string direktory)
        {

            string[] allFoundFiles = Directory.GetFiles(direktory);

            string okonch = "";
            int index = 0;
        powtor: bool nashel = false;
            for (int x = 0; x < allFoundFiles.Length; x++)
            {
                if (allFoundFiles[x].IndexOf(fileName.Replace(".xlsx", "") + okonch+ ".xlsx") != -1)
                {
                    nashel = true;
                    index++;
                    break;//увеличиваю инедекс
                }
            }

            if (nashel)
            {
                okonch = "_" + index;
                goto powtor;
            }


            if (!nashel)
            {
                fileName = fileName.Replace(".xlsx","");

                fileName = fileName + okonch+ ".xlsx";
            }
            return fileName;
        }
        public static   string[] find_file(string path)
        {
           
            string[] allFoundFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Files\\" + path);
            List<string> finded = new List<string>();
            for (int x = 0; x < allFoundFiles.Length; x++)
            {
                if (allFoundFiles[x].IndexOf("~") == -1)
                    finded.Add(allFoundFiles[x]);
            }
           
            return allFoundFiles;
        }
        public static string[] find_dir()
        {
            //удаляю индекс фото
           
            string[] allFoundFiles = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\Files\\FOTO\\");

            return allFoundFiles;
         }
        public static void delete_all_file_in_reestr()
        {
            string[] allFoundFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Files\\REESTR\\");
            
            for (int x = 0; x < allFoundFiles.Length; x++)
            {
                

                    FileInfo fileInf = new FileInfo(allFoundFiles[x]);
                    fileInf.Delete();
                

            }
            WebApplication7.Views.wodili.data_manager.clear_reestr();
        }






        //остановка скрипта на сайте
        public static bool koord_gotowi = false;
        private void in_database(WebApplication7.Views.wodili.data in_d, string s, string d)
        {

            string ss = s.Replace('.', ',');
            in_d.shirota = Convert.ToDouble(ss);
            string dd = d.Replace('.', ',');
            in_d.dolgota = Convert.ToDouble(dd);
        }
        public ActionResult take_coord()
        {

            Microsoft.Extensions.Primitives.StringValues ff;
            bool gf = Request.Form.TryGetValue("MAHG", out ff);
            string ggt = ff;
            string[] gre = ggt.Split(",");

            WebApplication7.Views.wodili.magaz[] prg = WebApplication7.Views.wodili.data_manager.magazini.ToArray();


            int ggre = 0;
            for (int ffe = 0; ffe < WebApplication7.Views.wodili.data_manager.magazini.Count; ffe++)
            {

                in_database(WebApplication7.Views.wodili.data_manager.magazini[ffe], gre[ggre], gre[ggre + 1]);
                ggre += 2;

            }


            gf = Request.Form.TryGetValue("ZAK", out ff);
            ggt = ff;
            gre = ggt.Split(",");

            ggre = 0;
            for (int ffe = 0; ffe < WebApplication7.Views.wodili.data_manager.magazini.Count; ffe++)
            {
                for (int ffe2 = 0; ffe2 < WebApplication7.Views.wodili.data_manager.magazini[ffe].zakazi.Count; ffe2++)
                {

                    in_database(WebApplication7.Views.wodili.data_manager.magazini[ffe].zakazi[ffe2], gre[ggre], gre[ggre + 1]);
                    ggre += 2;
                }
            }
            koord_gotowi = true;


            return RedirectToAction("Index");
        }


    }
}
