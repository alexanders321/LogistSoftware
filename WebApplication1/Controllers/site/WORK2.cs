using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.site
{
    //контроллер js для сайта
    public class WORK2 : Controller
    {
        // GET: WORK2
        public ActionResult Index()
        {
            return View();
        }
        public List<string> data_out(string paket)
        {
         return   driweri.driver_controller.send_data();
        }
    }
}
