using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
namespace WebApplication7.Views.wodili
{

    public abstract class data
    {
        public double dolgota;
        public double shirota;
    }
    public class driwer_download_data
    {

        public string color = "#ffff00";
        public string terminal;

        public string name;
        public string name_in_watsapp;
        public string location_in_startH;
        public string location_in_startD;


        // ОГРАНИЧЕНИЯ ПО ГРУЗУ на единицу
        public double max_obiome;
        public int max_kg;


        public int max_lengh;
        // ОГРАНИЧЕНИЯ ПО ГРУЗУ на всё загруженное
        public int max_obiome2;
        public int max_kg2;
        public int max_lengh2;
    }

    //класс для управления данными заказов
    public static class data_manager {

        //магазины москвы и области

        public static List<string> ALLOBL = new List<string>();
        public static List<string> MSK = new List<string>();
        public static List<string> ISTR = new List<string>();
        public static List<string> KOL = new List<string>();
        public static List<string> OREH = new List<string>();

        //водители
        public static List<driwer_download_data> from_pk = new List<driwer_download_data>();
        public static List<driwer_download_data> TEK = new List<driwer_download_data>();

        //магазины
        public static List<magaz> magazini = new List<magaz>();
        public static void start()
        {
            new download_reestr();
            //     new download_wodili();
            new download_magaz();

            WebApplication1.Controllers.loger_.save_download_reestr ff =
                   new WebApplication1.Controllers.loger_.save_download_reestr();
            foreach (magaz oo in magazini)
            {
               ff.sawe_reestr(oo.zakazi);
              
            }


        }
        public static void psevdo_dell(string zakaz)
        {
            foreach (magaz oo in magazini)
            {
                foreach (zakaz aa in oo.zakazi)
                {
                    if (zakaz == aa.id_zak)
                        aa.show = false;
                }
            }
        }
        public static zakaz get(string id)
        {
            foreach (magaz oo in magazini)
            {
                foreach (zakaz aa in oo.zakazi)
                {
                    if (id == aa.id_zak) return aa;
                }
            }
            return null;
        }
        static object ff=new object();
        public static void set_status(string id, status_ inp)
        {
            lock (ff)
            {
                foreach (magaz oo in magazini)
                {
                    foreach (zakaz aa in oo.zakazi)
                    {
                        if (id == aa.id_zak) aa.status.Add(inp);
                    }
                }
            }           
        }
        //получаю дату заказа
        public static string get_data(string id)
        {
            foreach (magaz oo in magazini)
            {
                foreach (zakaz aa in oo.zakazi)
                {
                    if (id == aa.id_zak) return aa.data_dost;
                }
            }
            return null;
        }
        public static string get_market(string id)
        {
            foreach (magaz oo in magazini)
            {
                foreach (zakaz aa in oo.zakazi)
                {
                    if (id == aa.id_zak) return aa.MAGAZIN;
                }
            }
            return null;
        }

        public static void clear_reestr()
        {
            WebApplication1.Models.driver_manager.clear_();

            magazini.Clear();
            WebApplication7.Views.download_reestr.zakazi.Clear();
            WebApplication7.Views.download_reestr.dowload_error.Clear();
            WebApplication7.Views.download_reestr.finded2.Clear();
            download_reestr.indexer = 0;

            // new download_reestr();
        }
    }
    public class magaz : data
    {
        public magaz()
        {
            zakazi = new List<zakaz>();
        }
        public string adr { get; set; }
        public string mag { get; set; }

        public int count_poz { get; set; }
        public int count_zak { get; set; }


        public int kbt { get; set; }
        public int mbt { get; set; }

        public int nalog { get; set; }
        public int oplach { get; set; }

        public List<zakaz> zakazi { get; set; } //
    }

    public class zakaz : data, IComparable
    {
        public zakaz()
        {
            text_zakaza = new List<pozicii>();
            status = new List<status_>();
            foto = new List<string>();
        }
        public bool kbt { get; set; }
        public string MAGAZIN { get; set; }
        public string ADRES { get; set; }

        public string id_zak { get; set; }
        public List<pozicii> text_zakaza { get; set; } //= new List<pozicii>();


        public int count_zakazow { get; set; }
        public int count_pozic { get; set; }

        public string ADRES_dostawki { get; set; }

        public bool oplach { get; set; }
        public string oplata { get; set; }

        public string agent_type { get; set; } //Тип контрагента    
        public string data_dost { get; set; }   // Дата доставки
        public string time_dost_up { get; set; } //Время доставки верхний лимит
        public string time_dost_down { get; set; } //Время доставки нижний лимит
        public List<status_> status { get; set; }  //только для записи статуса из файла

        public string status_cur { get; set; }
        public string status_log { get; set; }
        public string status_sks { get; set; }

        public List<string> foto { get; set; }  //только для записи статуса из файла
        public bool show = true;
        public string number_tell_clienta { get; set; }
        public string coment { get; set; }


       public int CompareTo(object o)
        {
           
            zakaz p = o as zakaz;
            if (p != null)
            {
              
                    return this.MAGAZIN.CompareTo(p.MAGAZIN);
                
            }
            else
            {
                throw new Exception("Невозможно сравнить два объекта");
            }

        }
    }


     
   
    
    //новое!!!!!!!!!!!!! незакончено нужно инициировтаь список
    public class status_
    {
        //список статусов и их продолжительность
      
        public string status{ get; set; }//статус 
        public string data_time{ get; set; }//время создания статуса
        public string status_long{ get; set; }//до скольки статус валиден
        public string status_json {get; set; } 
       
        public status_()
        {

        }
public status_(string status)
        {
             this.status = status;

            data_time = DateTime.Now.ToString();
           status_long =   (DateTime.Now.AddMinutes( status_list.get(status))).ToString();

            //  data_time = DateTime.Now.Hour.ToString()+" "+ DateTime.Now.Minute.ToString() + " " ;
            //   status_long = DateTime.Now.Hour.ToString() + " " + (DateTime.Now.Minute+  status_list.get(status)).ToString()+ " ";
            this.status_json = JsonSerializer.Serialize(this);
        }

        public status_(string status,string data_time, string status_long)
        {
             
            this.status = status; 
            this.data_time = data_time; 
            this.status_long = status_long;
            this.status_json = JsonSerializer.Serialize(this);
        }



        public override string ToString()
        {
            return status + " " + data_time;
        }
    }
  
    // класс описывает статусы в магазине у курьера и тд... сколько они должны быть по длительности и  какое окно
    //должно соответствовать какому статусу
    public class status_list
    {
       
        //лист со списком статусов и их нормативной длинной по времени

        public static Dictionary<string, int> status_lengh = new Dictionary<string, int>();
        //окно которое должно отображаться при таком статусе
        public static Dictionary<string, string> status_frame = new Dictionary<string, string>();
      

        //проверяет существует ли статус 
        public static bool chek(string name)
        {
            foreach (KeyValuePair<string, int> keyValue in status_lengh)
            {

                if (name == keyValue.Key) return true;
            }
            return false;
        }
        // возвращает время которое должен длиться статус

        public static int  get(string name)
        {
          

            foreach (KeyValuePair<string, int> keyValue in status_lengh)
            {

                if (name == keyValue.Key) return keyValue.Value;
            }
             
            return 15;

        }


        public static string get_frame(string name)
        {


            foreach (KeyValuePair<string, string> keyValue in status_frame)
            {

                if (name == keyValue.Key) return keyValue.Value;
            }

            return null;

        }

        //добавляю статусы в список
        public status_list()
        {
            status_lengh.Add("в магазине", 15);
            status_lengh.Add("курьер забрал заказ", 40);
            status_lengh.Add("доставил", 60);
            
        }
    }
    
    public class pozicii
    {
        public string text { get; set; }
        public double m { get; set; }
        public double o { get; set; }
        public int count { get; set; }
        

    }

}
