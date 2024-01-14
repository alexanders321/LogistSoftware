using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class DRIVER_DATA_BASE : Controller
    {
        // GET: DRIVER_DATA_BASE
        public ActionResult Index()
        {
            return View();
        }
        string remove_all_space(string ima)
        {
            if (ima == null) return null;
            while (true)
            {

                int index = ima.IndexOf(" ");
                if (index != -1)
                {
                    ima = ima.Remove(index,1);
                }
                else break;
            }
            return ima;
        }
        public string get_driver()
        {
            string ima = null;
            string pass = null;
            try
            {
                ima = Request.Form["ima"];
                pass = Request.Form["pass"];
              
            }
            catch
            {

            }
            if((ima==null)||(pass==null))
            return "ошибка сервера";


            ima=remove_all_space(ima);
            pass= remove_all_space(pass);
           
            if (ima == "ИМЯ")
                return "ошибка имя недоступно";
            if (ima.Length==0)
                return "ошибка имя недоступно";
            if (pass == "ПАРОЛЬ")
                return "ошибка пароль недоступно";
            if (pass.Length == 0)
                return "ошибка имя недоступно";


            if (Models.driver_manager.chek_name_curent(ima))
            {
                return "нельзя поментяь пароль водителю вышедшему на смену";
            }
            if (Models.driver_manager.chek_pass_database(pass))
            {

                Models.driver_manager.add_to_database(new Models.driver(ima, pass, "0", "0", "0"));
                Models.driver_manager.download_();

                return "добавлено";
            }
           
            return "ошибка нельзя дать одинаковый пароль нескольким курьерам";
        }
      public static Models.driver_database tekushiu;
      public ActionResult option_driver_database(string data)
        {
           
                tekushiu = Models.driver_manager.get_driver_database(data);
            return View();
        }

        public string add_driver_data(string data)
        {
            string ima = null;
            string text = null;
            string remuve = null;


            try
            {
                ima = Request.Form["ima"];
                text = Request.Form["text"];
                remuve = Request.Form["remuve"];

            }
            catch
            {

            }


            if ((ima != null) && (text != null))
            {
                ima = remove_all_space(ima);
                text = remove_all_space(text);
                remuve = remove_all_space(remuve);
                if (remuve == "false")
                {
                    Models.driver_manager.add_block(data, new Models.driver_data(ima, text));
                }
                if (remuve == "true")
                {
                    Models.driver_manager.remove_block(data, new Models.driver_data(ima, text));
                }
            }
            return "добавлено";
        }

    }
}
