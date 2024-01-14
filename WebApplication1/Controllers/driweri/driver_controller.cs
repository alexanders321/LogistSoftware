using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.driweri
{
    public class driver_controller
    {
        void on_start()//загружаю данные связаные с курьерами из файлов
        {

        }
       
        void update(string data)//обновляю данные о курьерах
        {

           
        }
        public static   List<string> send_data(  )//отправляю на сайт
        {
            List<string>output= new List<string>();//формирую данные для отправки

            //отправляю данные один раз при загрузке сайта
            foreach (WebApplication7.Views.wodili.magaz pr in WebApplication7.Views.wodili.data_manager.magazini)
            {
                 
                output.Add(JsonSerializer.Serialize(pr));
            }
            return output;
        }
        void destr()//удалить курьера 
        {

        }
    }
}
