using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class MAIN : Controller
    {
        
        public IActionResult Index()
        {
           // WebApplication1.Controllers.sms.SmsAero.ExampleUsage();


            string fileName;//надо поменять на андроиде!!!!!!!
            //fileName = System.Text.RegularExpressions.Regex.Unescape(@"ewqe\u0015");
            fileName = System.Text.RegularExpressions.Regex.Unescape(@"\u0015");

            string stringWithUnicodeSymbols = fileName;// @"{""id"": 10440119, ""photo"": 10945418, ""first_name"": ""\u0415\u0432\u0433\u0435\u043d\u0438\u0439""}";
            var splitted = Regex.Split(stringWithUnicodeSymbols, @"\\u([a-fA-F\d]{4})");
            string outString = "";
            foreach (var s in splitted)
            {
                try
                {
                    if (s.Length == 4)
                    {
                        var decoded = ((char)Convert.ToUInt16(s, 16)).ToString();
                        outString += decoded;
                    }
                    else
                    {
                        outString += s;
                    }
                }
                catch (Exception e)
                {
                    outString += s;
                }
            }
            return View();
        }
    }
}
