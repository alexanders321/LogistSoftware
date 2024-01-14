using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class dr_contr : Controller
    {

        public IActionResult Index()
        {
            return View();
        }



        //ищу фото
        public string get_foto(string id_zak)
        {

            List<string> path = new List<string>();
            //ищу по реестрам загруженным что бы не пришлось всю базу капошить
            string data = WebApplication7.Views.wodili.data_manager.get_data(id_zak);

            string direktory = Directory.GetCurrentDirectory() + "\\Files\\FOTO\\" + data + "\\";
            if (Directory.Exists(direktory))
            {


                string[] allFoundFiles = Directory.GetFiles(direktory);

                for (int x = 0; x < allFoundFiles.Length; x++)
                {
                    if (-1 != allFoundFiles[x].IndexOf(id_zak))
                        path.Add(allFoundFiles[x]);
                }

            }
            return JsonSerializer.Serialize(path);

        }

    
        public void delete_zakaz(string id)
        {
            Models.driver_manager.del_data(id);
            WebApplication7.Views.wodili.data_manager.psevdo_dell(id);
        }
        //данные с сайта!!!!!!!!!!!!!!!!!!!!!!!
        //устанавливаю статус заказа проверяно логистом
        public void site_status_update(string paket)
        {
           driver_manager.update_data(paket, "логист проверил");
           loger_.loger.sawe_status(paket, "логист проверил");
             
        }
        //данные с сайта!!!!!!!!!!!!!!!!!!!!!!!

        public string site_data(string paket)
        {
             //данные с сайта о заказах и курьерах
           
            string json=null;

            //ошибка всё ещё срабатывает массив модифицируется вов время работы!!!!!!!!!!!!!!!!
            json=driver_manager.site_data( paket);

            return json;
        }



        public IActionResult android_data()
        {
            return View();
        }

        // функция что бы связать старые данные о водителях и новые
        

       
    }
}
