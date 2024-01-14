using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
namespace WebApplication1.Controllers.loger_
{
    public class order_in_database
    {


    public string data { set; get; }
        public string id_ { set; get; }
        public string market { set; get; }
    public string driver { set; get; }
    public string zakaz_jsong { set; get; }

        public static implicit operator order_in_database(WebApplication7.Views.wodili.zakaz x)
        {
            return new order_in_database { id_ = x.id_zak, market = x.MAGAZIN, driver = null ,data=x.data_dost ,zakaz_jsong=JsonSerializer.Serialize(x)};
        }
    }
}
