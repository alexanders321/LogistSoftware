using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.loger_
{
    interface download_save
    {
    void  sawe_reestr(WebApplication7.Views.wodili.zakaz zakaz);
    List<WebApplication7.Views.wodili.zakaz> download_reestr(string started, string end);

    List<WebApplication7.Views.wodili.zakaz> download_reestr(string id);
    }
}
