using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1.Controllers
{
    public class HomeController1 : Controller
    {
        //преобразует строку приходящюю с андроида у неё странный формат \u0015 за место \u04015
        string convert(string fileName)
        {
            char[] chars = fileName.ToCharArray();
            for (int x = 0; x < chars.Length; x++)
            {
                if ((16 < chars[x]) && (chars[x] < 47))
                {
                    //если это управляющий символ то
                    byte[] bytesUtf16 = Encoding.Unicode.GetBytes("" + chars[x]);
                    bytesUtf16[1] = 0x04;
                    string good = System.Text.Encoding.Unicode.GetString(bytesUtf16);
                    chars[x] = good[0];
                }

            }
            return new String(chars);

        }
        public HomeController1()
        {
            
 
           
            if (zakazi.Count == 4324324)
            {
                zakazi.Add(new Models.zakaz_staus("kal0", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "fewf"));
                zakazi.Add(new Models.zakaz_staus("kal1", "dwdd", "fewf"));
                zakazi.Add(new Models.zakaz_staus("kal2", "dwdd", "fewf"));
                zakazi.Add(new Models.zakaz_staus("kal3", "dwdd", "fewf"));

            }
          


        }
        static int ggr = 0;
        // GET: HomeController1
        public ActionResult Index()
        {
            return View();
        }
       
        private static string _myProperty;
        private static readonly object _myPropertyLock = new object();
       /* public static string MyProperty
        {
            get
            {
                lock (_myPropertyLock)
                    return _myProperty;

            }
            set
            {
                lock (_myPropertyLock)
                {
                    // Какой-то код

                    _myProperty = value;

                    // Какой-то код
                }
            }
        }
       */
        static string token_sess;
        // GET: HomeController1/Details/5
       public static List<Models.zakaz_staus> zakazi = new List<Models.zakaz_staus>();

        public  static string dolgoto="", shirota = "";
     

        public static DateTime current;

        static int idw = 0; 
        public string Details(string id)
        {//удалить!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
              
            string pass = Request.Form["pass"];
      
      
            //авторизация
            if (pass!=null) {
                if (Models.driver_manager.add(pass))
                { 
                    return "AV_IN";
                }
                else return "E_PAS";
            }
 
 

            return "N_COM";
        }
     

        //отправл заказы курьерам АНДРОЙД!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
       //данные для андроида
         
        public string send_inp()
        { 
            string pass = Request.Form["pass"];
            Models.driver driver = WebApplication1.Models.driver_manager.get(pass);
            List<WebApplication7.Views.wodili.zakaz> zakaz_list = new List<WebApplication7.Views.wodili.zakaz>();
            if (driver != null)
            {
                  
                foreach (WebApplication1.Models.zakaz_upr pp in driver.zakazi)
                {
                    
                    WebApplication7.Views.wodili.zakaz zakaz= WebApplication7.Views.wodili.data_manager.get(pp.id);
                    
                        zakaz_list.Add(zakaz);
                    

                }
                string outrput_data = JsonSerializer.Serialize<List<WebApplication7.Views.wodili.zakaz>>(zakaz_list);
                return outrput_data;
            }
            return null;
        }
        //данные от андроида

        //если будет криво работать то установлю принудительное обновление интерфейса раз в н секунд
        public string send_out()
        {

            return "Dsd";

        }













        
        //новое!!!!!!!!!!!!!принимаю кнопку нажатую(статус) возвращаю действие

        public string inp_status(string status)
        {
            return WebApplication7.Views.wodili.status_list.get_frame(status);
             

        }


        //обновляю информацию о статусе заказа!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        class id_status {
            public string id { set; get; }
            public string status { set; get; }
            public id_status(string id,string status)
            {
                this.id = id;
                this.status = status;

            }
        }
        /*
        @Override
            public void onClick(View v)
        {
            long data = viewHolder.CALENDAR_VIEW.getDate();
            new sender("&id=" + product.id_zak +
                    "&status=перенос&data=" + data
                    , pr, "zakazi_status_android/");

            frizing();

        }
    });

        viewHolder.SEND_MESS.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
    {
        String data = "&text=" + viewHolder.MESS_TEXT.getText();
        new sender("&id=" + product.id_zak +
                "&status=другая" + data
                , pr, "zakazi_status_android/");
*/


        /*

            case "курьер забрал заказ" :return 2;
            case "фото заказа" :return 1;
            case "не смог" :return 4;
     
            case "не выдал магазин" :return 1;
            case "доставил" :return 1;
            case "недоставлен недозвон" :return 1;
            case "недоставлен отказ клиента" :return 1;
            case "недоставлен вне зоны" :return 1;
            case "недоставлен перенос клиентом" :return 1;
            case "недоставлен другая причина" :return 1;
            case "недоставлен курьер не успел" :return 1;
           


       */
        public string zakazi_status_android()
        {
            string id = Request.Form["id"];
            string status = Request.Form["status"];
            string data;
            string text;


            WebApplication1.Models.driver_manager.update_data(id, status);
            id_status or = new id_status(id, status);

            if (status == "недоставлен перенос клиентом")
            {
                data = Request.Form["data"];
                status += " "+data;
                or.status = "недоставлен перенос клиентом";
            }
            if (status == "недоставлен другая причина")
            {
                text = Request.Form["text"];
                status += ": " + text;
                or.status = "недоставлен другая причина";
            }
         




            string return_d = JsonSerializer.Serialize<id_status>(or);

         
            loger_.loger.sawe_status(id, status);

            return return_d;
        }

        public static string anti_perezapis(string fileName, string direktory)
        {
          
            string[] allFoundFiles = Directory.GetFiles(direktory);

            string okonch = "";
            int index = 0;
        powtor: bool nashel = false;
            for (int x = 0; x < allFoundFiles.Length; x++)
            {
                if (allFoundFiles[x].IndexOf(fileName + okonch) != -1)
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
                fileName = fileName + okonch;
            }
            return fileName;
        }
        public string Download_ing(IEnumerable<IFormFile> fileUpload)
        {
            var file3 = Request.Form.Files;


          
            foreach (IFormFile file in Request.Form.Files)
            {

              
                
                
                string fileName = file.FileName ;
                string fileNamPure = file.FileName;
                loger_.loger.sawe_status(fileName, "курьер прислал фото");
              
                // var fileName = Path.GetFileName(file.FileName);
                //проверка есть ли фото с таким именем
                string data = WebApplication7.Views.wodili.data_manager.get_data(fileName);
             
                string direktory = Directory.GetCurrentDirectory() + "\\Files\\FOTO\\" + data + "\\";
              
                if (!Directory.Exists(direktory))
                    Directory.CreateDirectory(direktory);


                fileName= anti_perezapis(fileName,direktory);

                    //WebApplication1.Models.driver_manager.add_pfoto(fileName);

                    //Добавляем к старому содержимому файла


                    var fileStream = file.OpenReadStream();
                    using (var memoryStream = new MemoryStream())
                    {
                          fileStream.CopyTo(memoryStream);
                       
                         byte[] arr = new byte[memoryStream.Length];
                         arr = memoryStream.ToArray();
                        System.IO.File.WriteAllBytes(direktory+ fileName+".jpg", arr);
                       loger_.loger.sawe_foto(fileNamPure, direktory + fileName + ".jpg");
                       Models.driver_manager.add_pfoto(fileNamPure, direktory + fileName + ".jpg");

                }
                
            }
            
            return "OK_OK";
        }
        public IActionResult SendResponse()
        {
            Response.Headers.Add("X-Total-Count", "20");

            return Ok();
        }
        class geo_dat {
          public  string dolgoto{ set; get; }
          public string shirota { set; get; }
        }
        public string GEO(string id)
        {





     

            geo_dat pre = new geo_dat();
            pre.dolgoto = dolgoto;
            pre.shirota = shirota;
            string json = JsonSerializer.Serialize<geo_dat>(pre);


            return json;


        }
        
        public string geo_data()
        {
            string pass = Request.Form["pass"];
            string dolg = Request.Form["dolg"];
            string shir = Request.Form["shir"];
            if ((dolg != null)&& (shir != null))
            {



                Models.driver_manager.update(pass, dolg, shir);


                return "OK_OK";

            }
            return "N_COM";
        }
    }
}
