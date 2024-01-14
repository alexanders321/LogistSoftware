using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class android : Controller
    {
        string pass = "1212";
        public string Index(string ff2)
        {
            string ff = "DSDfff";

            return ff;
        }
        public string Details(string id)
        {
            string oldProductName = Request.Form["token"];
            if (oldProductName == "4425")
                return "OK_OK";
            else return "E_PAS";
        }
    }
}
