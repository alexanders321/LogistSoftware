using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.loger_
{
    public class save_download_reestr
    {
 
        public bool sawe_reestr(List<WebApplication7.Views.wodili.zakaz> zakazi)
        {
            
                foreach (WebApplication7.Views.wodili.zakaz zakaz in zakazi)
                  {

                 if(!sawe_reestr(zakaz))return false;


                }
            return true;
            
        }
          
        

        public void delete_reestr(WebApplication7.Views.wodili.zakaz zakaz)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                var sushet=   db.order.Where(u => u.id_ == zakaz.id_zak& u.data == zakaz.data_dost);
                
                 foreach(var ob in sushet){
                    db.Remove(ob);
                }
                db.SaveChanges();

            }
        }


        public bool sawe_reestr(WebApplication7.Views.wodili.zakaz zakaz)

        {

            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {

                    db.order.Add(zakaz);
                    db.SaveChanges();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
         /*

        public List<WebApplication7.Views.wodili.zakaz> get_by_id()
        {

        }
        public WebApplication7.Views.wodili.zakaz get_by_id()
        {

        }
        public WebApplication7.Views.wodili.zakaz get_by_data()
        {

        }

        public WebApplication7.Views.wodili.zakaz get_by_mark()
        {

        }
        public WebApplication7.Views.wodili.zakaz get_by_driwer()
        {

        }
         */
    }
}
