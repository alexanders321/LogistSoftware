using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
namespace WebApplication1.Models
{
    //для андроида данные
    public class zakaz_staus
    {
        public string id{ get; set; }
        public string data_magaz { get; set; }
        public string data_cletn { get; set; }
        //окно 1
        public bool zabral { get; set; }
        public bool ne_vidal { get; set; }
        //окно 2
        public bool dostavil { get; set; }
        public bool nesmog { get; set; }
        //окно 4
        public bool foto_zakr { get; set; }
        public bool send_day_zakaz { get; set; }
        //окно 3
        public bool pricina_nedozwon { get; set; }
        public bool pricina_otaz { get; set; }
        public bool pricina_wne_zoni { get; set; }

        public zakaz_staus(string id,string data_magaz,string data_cletn):base()
        {
            
            this.id = id;
            this.data_magaz = data_magaz;
            this.data_cletn = data_cletn;

            zabral = false;
            ne_vidal = false;
            dostavil = false;
            nesmog = false;
            foto_zakr = false;
            send_day_zakaz = false;

            pricina_nedozwon = false;
            pricina_otaz = false;
            pricina_wne_zoni = false;

        }
        public zakaz_staus() : base()
        {

           
            zabral = false;
            ne_vidal = false;
            dostavil = false;
            nesmog = false;
            foto_zakr = false;
            send_day_zakaz = false;

            pricina_nedozwon = false;
            pricina_otaz = false;
            pricina_wne_zoni = false;

        }

        public string pars()
        {
            
            string json = JsonSerializer.Serialize<WebApplication1.Models.zakaz_staus>(this);

           
            return json;
        }
        
        //делает объект из строки
        public zakaz_staus pars(string zap)
        {

            zakaz_staus pr = JsonSerializer.Deserialize<WebApplication1.Models.zakaz_staus>(zap);


            return pr;
        }
        

       


         
        //проверяю есть ли такие id
        public static bool operator !=(zakaz_staus c1, zakaz_staus c2)
        {
            if (c1.id != c2.id)
                return true;
            else
                return false;
        }
        public static bool operator ==(zakaz_staus c1, zakaz_staus c2)
        {
            if(c1.id==c2.id)
            return true;
            else
            return false;
        }
        
    }
}
