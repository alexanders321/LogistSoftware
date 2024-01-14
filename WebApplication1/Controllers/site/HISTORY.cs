using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace WebApplication1.Controllers
{
    public class HISTORY : Controller
    {
     
        public IActionResult Index()
        {
           
            return View();
        }
        public static string find_rez = "";
        public static List<WebApplication7.Views.wodili.zakaz> formated_data=new List<WebApplication7.Views.wodili.zakaz>();
        public static List<statistica> formated_data2=new List<statistica>();
        public IActionResult formated_history(string id)
        {
           
            string id_ = id;

            List<string> data = new List<string>();

            try
            { 
                  id_ = Request.Form["id"]; 
            }
            catch
            {

            } 
            formated_data = loger_.loger.download_data(id_);
            if (id == null) return View(zakaz_sort());
             //statistica_history();
             return View(data); 
        }

        public IActionResult history_po_date()
        {
            try
            {

                string data_e = Request.Form["raz"];
          
                switch (data_e)
                {
                    case "mag": return View(sortstr("сортировка по магазинам", (x, y) => x.ADRES == y.ADRES));
                    case "data": return View(sortstr("сортировка по дате", (x, y) => x.data_dost == y.data_dost));
                    case "zak": zakaz_sort(); return View();
               
               
                
                }

            }
            catch
            {

            }


            return null;
          //  return View(sortstr("сортировка по магазинам", (x, y) => x.ADRES == y.ADRES));
        }

        Dictionary<string, statistica> sortstr(string tupe, System.Func<WebApplication7.Views.wodili.zakaz, WebApplication7.Views.wodili.zakaz, bool> funl_anal)
        {
            string data_s = null;
            string data_e = null;
            
            List<WebApplication7.Views.wodili.zakaz> data = new List<WebApplication7.Views.wodili.zakaz>();

            try
            {
                data_s = Request.Form["data_s"];
                data_e = Request.Form["data_e"];
           

            }
            catch
            {

            }

            if (data_s != null)
            {
                data = loger_.loger.download_reestr(data_s, data_e);

            }

            List<List<WebApplication7.Views.wodili.zakaz>> oo = sort_po_date(data, funl_anal);
            //сортировка по магазинам по дате 
            Dictionary<string, statistica> outp = new Dictionary<string, statistica>();
            foreach (List<WebApplication7.Views.wodili.zakaz> pp in oo)
            {
                if(tupe!= "сортировка по дате")
                outp.Add(pp[0].MAGAZIN,statistica_history(pp));
                else outp.Add(pp[0].data_dost, statistica_history(pp));

            }
            //сортировка по заказам


            ViewData["Message"] = tupe;
            return outp;
        }
        

        public List<WebApplication7.Views.wodili.zakaz> zakaz_sort()
        {
            //с какое число по какое
            string data_s = null;
            string data_e = null;
 
            try
            {
                data_s = Request.Form["data_s"];
                data_e = Request.Form["data_e"];

            }
            catch
            {

            }

            if (data_s != null)
            {
                //несортированно
               
                formated_data = loger_.loger.download_reestr(data_s, data_e);
                List<WebApplication7.Views.wodili.zakaz> sotr = new List<WebApplication7.Views.wodili.zakaz>();
                List<WebApplication7.Views.wodili.zakaz> outp = new List<WebApplication7.Views.wodili.zakaz>();

                string data = null;


                 for(int x=0;  x<formated_data.Count;x++) {

                    if(data==null)
                    {
                        data = formated_data[x].data_dost;
                    }

                   if (formated_data[x].data_dost== data)
                    {
                        sotr.Add(formated_data[x]);
                    }
                    else
                    {
                        data = formated_data[x].data_dost;
                        x--;
                        sotr.Sort();
                        outp= outp.Concat(sotr).ToList();
                        sotr.Clear();
                    }

                  }
                 if(sotr.Count>0)
                outp = outp.Concat(sotr).ToList();

                formated_data = outp;
                formated_data2.Clear();
                foreach (WebApplication7.Views.wodili.zakaz zak in formated_data) {
                statistica stata2 = statistica_history(zak);
                formated_data2.Add(stata2);
                }

            }

           
            return null;
        }
          

        public class statistica
        {

            public  int ne_widal = 0;
            public int dostaw = 0;
            public int nedozwon = 0;
            public int otkaz = 0;
            public int wne_zoni = 0;

            public int oplachen = 0;
            public int nalogka = 0;

            public int roznica = 0;
            public int org = 0;
            public int obshee_count = 0;
            public int kbt = 0;
            public int mbt = 0;


            public bool analize(string inp)
            {
                switch (inp)
                {
                    case "не выдал тц":
                        ne_widal++;
                        return true;
                    case "доставил":
                        dostaw++;
                        return true;
                    case "недоставлен недозвон":
                        nedozwon++;
                        return true;
                    case "недоставлен отказ клиента":
                        otkaz++;
                        return true;
                    case "недоставлен вне зоны":
                        wne_zoni++;
                        return true;
                    case "Доставка полностью оплаченного товара":
                        oplachen++;
                        return true;




                    case "Организация":
                        org++;
                        return true;
                    case "Розничные продажи":
                        roznica++;
                        return true;



                }

                return false;
            }
        }

        public static statistica stata;


       
        statistica statistica_history(List<WebApplication7.Views.wodili.zakaz> pull)
        {

              

            stata = new statistica();

            foreach (WebApplication7.Views.wodili.zakaz zz in pull)
            {
                if (zz.kbt) stata.kbt++;
                else stata.mbt++;
                stata.obshee_count++;
                foreach (WebApplication7.Views.wodili.status_ pp in zz.status)
                {
                 if(stata.analize(pp.status))break;
                }
                stata.analize(zz.oplata);
                stata.analize(zz.agent_type);
            }
            return stata;
        }

        statistica statistica_history(WebApplication7.Views.wodili.zakaz zz)
        {



            stata = new statistica();

             
            
                if (zz.kbt) stata.kbt++;
                else stata.mbt++;
                stata.obshee_count++;
                foreach (WebApplication7.Views.wodili.status_ pp in zz.status)
                {
                    if (stata.analize(pp.status)) break;
                }
                stata.analize(zz.oplata);
                stata.analize(zz.agent_type);
             
            return stata;
        }

        //сортировка по дате магазину и можно ещё по чему то реализоватью........
        private bool Have(List<WebApplication7.Views.wodili.zakaz> pull, WebApplication7.Views.wodili.zakaz znach, System.Func<WebApplication7.Views.wodili.zakaz, WebApplication7.Views.wodili.zakaz,bool> funl_anal)
        {

            foreach (WebApplication7.Views.wodili.zakaz zak in pull)
            {
             //   if (zak.data_dost == znach.data_dost) return true;
               // else return false;

                return funl_anal(zak,znach);
            }
            return false;
        }
        List<List<WebApplication7.Views.wodili.zakaz>> sort_po_date(List<WebApplication7.Views.wodili.zakaz> pull, System.Func<WebApplication7.Views.wodili.zakaz, WebApplication7.Views.wodili.zakaz, bool> funl_anal)
        {
            // создаю список сортированых списков 
            List<List<WebApplication7.Views.wodili.zakaz>> outp = new List<List<WebApplication7.Views.wodili.zakaz>>();
           
            /*
             * list    list
             21.02  zakaz zakaz
             22.03  zakaz zakaz
             */
            foreach (WebApplication7.Views.wodili.zakaz zz in pull)
            {
                
                bool sushest = false;
                //докидываю если раздел существует
                foreach (List<WebApplication7.Views.wodili.zakaz> kk in outp)
                {
                    sushest= Have(kk, zz, funl_anal);
                    if (sushest)
                    {
                        kk.Add(zz);
                        break;
                    }
                }
                //создаю раздел и уже закидываю
                if (!sushest)
                {
                    outp.Add(new List<WebApplication7.Views.wodili.zakaz> { zz });
                }

            }
            return outp;
        
        
        }
      
        public IActionResult otchet()
        {
            return View();
        }
    }
}
