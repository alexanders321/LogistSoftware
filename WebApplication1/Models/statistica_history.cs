using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class statistica_history
    {

        int ne_widal = 0;
        int dostaw = 0;
        int nedozwon = 0;
        int otkaz = 0;
        int wne_zoni = 0;

        int oplachen = 0;
        int nalogka = 0;

        int roznica = 0;
        int org = 0;


        public bool analize(string inp)
        {
            switch (inp)
            {
                case "не выдал тц":
                    ne_widal++;
                    return true;
                case "доставил":
                    dostaw++;
                    return true;
                case "недоставлен недозвон":
                    nedozwon++;
                    return true;
                case "недоставлен отказ клиента":
                    otkaz++;
                    return true;
                case "недоставлен вне зоны":
                    wne_zoni++;
                    return true;
                case "Доставка полностью оплаченного товара":
                    oplachen++;
                    return true;




                case "Организация":
                    org++;
                    return true;
                case "Розничные продажи":
                    roznica++;
                    return true;



            }

            return false;
        }
    }
}
