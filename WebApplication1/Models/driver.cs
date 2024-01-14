using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class zakaz_upr{
        public string id { get; set; }
        public List< WebApplication7.Views.wodili.status_> status { get; set; }
   
        public string magaz { get; set; }
        
        public List<string> foto { get; set; }
     
        public zakaz_upr()
        {
            if (this.status == null) this.status = new List<WebApplication7.Views.wodili.status_>();

            chek_powtor( new WebApplication7.Views.wodili.status_( "в магазине"));
            foto = new List<string>();
        }
        public zakaz_upr(string id,string status)
        {
            if (this.status == null) this.status = new List<WebApplication7.Views.wodili.status_>();

            this.id = id;
            chek_powtor(new WebApplication7.Views.wodili.status_( status));

            foto = new List<string>();
        }
        //коррекция!!!!!!!!!!!!!!!!!!!!!!!!!!!
      
        public zakaz_upr(string id, string status,string magaz)
        {
            
           

            if (this.status == null) this.status = new List<WebApplication7.Views.wodili.status_>();

            this.id = id;
            chek_powtor( new WebApplication7.Views.wodili.status_(status));
            this.magaz = magaz;
            foto = new List<string>();
   

        }
        public static zakaz_upr zakaz_upr_chek_powt(string id, string status, string magaz)
        {
           var otw= driver_manager.get_zakaz_(id);
            if (otw != null) return otw;
            
            return new zakaz_upr(id, status, magaz);
        }
        private void chek_powtor(WebApplication7.Views.wodili.status_ status)
        {
            foreach(WebApplication7.Views.wodili.status_ pr in this.status)
            {
                if (pr.status_json == status.status_json) return ;
            }
            this.status.Add(status);
        }
    }
    class kurier_s_sita
    {
        public string zakaz { get; set; }
        public string curier { get; set; }
        public string zabral { get; set; }

    }
    public class driver
    {
      
        public List<zakaz_upr> zakazi { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string wremya_wihoda { get; set; }//когда вышел на смену
        public string wremya_uhoda { get; set; }//когда вышел на смену
        public string shir { get; set; }
        public string dolg { get; set; } 


        public string data_last_update_coord { get; set; }
        public driver()
        {

        }
        public driver(string name,string id,string wremya_wihoda,string shir, string dolgota)
        {
            zakazi = new List<zakaz_upr>();
            this.name = name;
            this.id = id;
            this.wremya_wihoda = wremya_wihoda;
            this.shir = shir;
            this.dolg = dolgota; 
        }
        public driver(string name, string id, string wremya_wihoda, string shir, string dolgota, string data_last_update_coord)
        {
            zakazi = new List<zakaz_upr>();
            this.name = name;
            this.id = id;
            this.wremya_wihoda = wremya_wihoda;
            this.shir = shir;
            this.dolg = dolgota;
            this.data_last_update_coord =  data_last_update_coord;
        }
    }
}
