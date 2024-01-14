using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class pass
    {
        struct id_token
        {
            public string pass;
            public string token;
        }
        static List<id_token> ff = new List<id_token>();
        public static void inic()
        {
            if (ff.Count == 0)
            {
                id_token ppp;
                ppp.pass = "4425";
                ppp.token = null;
                ff.Add(ppp);
            }
        }
        //проверяет пароль если его нету то добавляет
        // если есть то обновляет токен
        //вернёт  true если пароль найден
        public static bool chek_pass(string pass, string token)
        {
            inic();
            bool nashel = false;
            for (int x = 0; x < ff.Count; x++)
            {
                if (ff[x].pass == pass)
                {
                    ff.RemoveAt(x);
                    id_token ppp;
                    ppp.pass = pass;
                    ppp.token = token;

                    ff.Add(ppp);
                    nashel = true;
                }

            }
            return nashel;

        }
        //возвращает пароль соответствующий токену
        //или null если ничего не нашел
        public static string token_to_pass( string token)
        {

            inic();
            
            for (int x = 0; x < ff.Count; x++)
            {
                if (ff[x].token == token)
                {
                    return ff[x].pass;
                }

            }
            return null;
        }
    }
}
