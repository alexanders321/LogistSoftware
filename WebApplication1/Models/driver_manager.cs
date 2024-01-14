using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections.Concurrent;

namespace WebApplication1.Models
{
    public class driver_manager
    {
        // все водители существующие
        public static List<Models.driver_database> worker_base = new List<Models.driver_database>();
        static object locker243 = new object();

        const string data_path = "Files\\DRIWER\\";

        public static void add_block(string name, driver_data block)
        {
            driver_database dr = get_driver_database(name);
            dr.bloki.Add(block);
        }
        public static void remove_block(string name, driver_data block)
        {
            driver_database dr = get_driver_database(name);
        eshe: for (int x = 0; x < dr.bloki.Count; x++)
            {
                if (dr.bloki[x].zagolow == block.zagolow)
                {
                    dr.bloki.RemoveAt(x);
                    goto eshe;
                }
            }

        }
        public static Models.driver_database get_driver_database(string name)
        {

            foreach (driver_database ret in worker_base)
            {
                if (ret.name == name) return ret;
            }
            return null;
        }
        public static Models.driver_database get_driver_database_id(string id)
        {

            foreach (driver_database ret in worker_base)
            {
                if (ret.id == id) return ret;
            }
            return null;
        }
        public static List<driver_database> download_()
        {
            List<driver_database> pp = new List<driver_database>();

            lock (locker243)
            {
                string[] zakazi = Directory.GetFiles(data_path);
                for (int ofds = 0; ofds < zakazi.Length; ofds++)
                {

                    string zaaak = "";
                    using (var writer = new StreamReader(zakazi[ofds], true))
                    {
                        //отсеиваю файлы с тегом _status


                        zaaak += writer.ReadLine();
                    }

                    driver_database ot = JsonSerializer.Deserialize<Models.driver_database>(zaaak);
                    ot.download_coord_curier();
                    pp.Add(ot);



                }

            }

            worker_base = pp;


            return pp;



        }
        public static bool add_to_database(Models.driver wodila)
        {

            lock (locker243)
            {

                using (var writer = new StreamWriter(data_path + wodila.name + ".txt", false))
                {
                    //Добавляем к старому содержимому файла
                    writer.WriteLine(JsonSerializer.Serialize(wodila));
                }
            }
            return false;
        }
        //проверка можно ли использовать пароль
        public static bool chek_pass_database(string pass)
        {
            foreach (Models.driver_database fef in worker_base)
            {
                if (fef.id == pass) return false;
            }
            return true;
        }

        //все водители работающие
        public static ConcurrentBag<Models.driver> worker = new ConcurrentBag<Models.driver>();

        //!!! возвращаю водителя по id
        public static Models.driver get(string id)
        {
            foreach (Models.driver prom in driver_manager.worker)
            {
                if (prom.id == id)
                {//обновляю
                    return prom;
                }
            }
            return null;
        }
        //добавляю с проверкой на пароля и поиском в базе
        public static bool add(string pass)
        {
            foreach (Models.driver_database prom in worker_base)
            {
                if (prom.id == pass)
                {

                    Models.driver prom2 = new Models.driver(prom.name, pass,
         DateTime.Now.ToString(), " ", " ", DateTime.Now.ToString());
                    add_(prom2);
                    return true;
                }
            }
            return false;
        }
        //добавляю 
        public static void add_(Models.driver input)
        {
            lock (worker)
            {
                bool nashsel = false;
                foreach (Models.driver prom in driver_manager.worker)
                {
                    if (prom.id == input.id)
                    {//обновляю
                        nashsel = true;
                        break;
                    }
                }
                if (!nashsel)
                    driver_manager.worker.Add(input);
                else update(input);
            }

        }
        //обновляю
        private static void update(Models.driver input)
        {
            lock (worker)
            {
                foreach (Models.driver prom in driver_manager.worker)
                {
                    if (prom.id == input.id)
                    {//обновляю
                        prom.name = input.name;
                        prom.id = input.id;
                        prom.wremya_wihoda = input.wremya_wihoda;
                        prom.wremya_uhoda = input.wremya_uhoda;
                        prom.shir = input.shir;
                        prom.dolg = input.dolg;
                        prom.data_last_update_coord = input.data_last_update_coord;


                    }
                }
            }
        }
        public static void update(string id, string shir, string dolg)
        {
            lock (worker)
            {
                foreach (Models.driver prom in driver_manager.worker)
                {
                    if (prom.id == id)
                    {//обновляю



                        if ((prom.dolg != dolg) || (prom.shir != shir))
                        {
                            driver_database db = get_driver_database_id(id);
                            if (db != null)
                                db.save_coord_curier(shir, dolg);

                            prom.shir = shir;
                            prom.dolg = dolg;
                            prom.data_last_update_coord = DateTime.Now.ToString();
                            //сюда вставить логгер!!!!!!!!!!!!!
                        }

                    }
                }
            }
        }
        public static void clear_()
        {
            lock (worker)
            {
                foreach (Models.driver sp in worker)
                {
                    sp.zakazi.Clear();
                }
            }
        }
        //заказы
        public static void update_data(string id, string status)
        {
            lock (worker)
            {
                foreach (Models.driver sp in worker)
                {
                    foreach (Models.zakaz_upr pr in sp.zakazi)
                    {//добавляю ссылку на фото только если её нет
                        if (pr.id == id)
                        {
                            WebApplication7.Views.wodili.status_ dd = new WebApplication7.Views.wodili.status_(status);
                            pr.status.Add(dd);
                            WebApplication7.Views.wodili.data_manager.set_status(id, dd);
                        }
                    }
                }
            }
        }

        public static void del_data(string id)
        {
            lock (worker)
            {
                foreach (Models.driver sp in worker)
                {
                    foreach (Models.zakaz_upr pr in sp.zakazi)
                    {//добавляю ссылку на фото только если её нет
                        if (pr.id == id)
                        {
                            sp.zakazi.Remove(pr);
                            return;
                        }
                    }
                }
            }
        }

        public static string get_status(string id)
        {
            lock (worker)
            {
                foreach (Models.driver sp in worker)
                {
                    foreach (Models.zakaz_upr pr in sp.zakazi)
                    {//добавляю ссылку на фото только если её нет
                        if (pr.id == id)
                            return pr.status[pr.status.Count - 1].status;
                    }
                }
            }
            return "в магазине";
        }
        public List<WebApplication7.Views.wodili.status_> get_status_list(string id)
        {
            lock (worker)
            {
                foreach (Models.driver sp in worker)
                {
                    foreach (Models.zakaz_upr pr in sp.zakazi)
                    {//добавляю ссылку на фото только если её нет
                        if (pr.id == id)
                            return pr.status;
                    }
                }
            }
            return null;
        }

        public static zakaz_upr get_zakaz_(string id)
        {
            lock (worker)
            {
                foreach (Models.driver sp in worker)
                {
                    foreach (Models.zakaz_upr pr in sp.zakazi)
                    {//добавляю ссылку на фото только если её нет
                        if (pr.id == id)
                            return pr;
                    }
                }
            }
            return null;
        }
        //добавляю фото водителю
        static object locker2 = new object();
        public static void add_pfoto(string id, string Url_foto)
        {
            lock (worker)
            {
                foreach (Models.driver sp in worker)
                {
                    foreach (Models.zakaz_upr pr in sp.zakazi)
                    {//добавляю ссылку на фото только если её нет
                        if (pr.id == id)
                        {
                            if (pr.foto.IndexOf(Url_foto) == -1)
                                pr.foto.Add(Url_foto);
                        }
                    }
                }
            }
        }

        public static bool chek_name_curent(string pass)
        {
            lock (worker)
            {
                foreach (Models.driver sp in worker)
                {
                    if (pass == sp.name) return true;
                }
            }
            return false;

        }



        public static string site_data(string paket)
        {
            lock (worker)
            {

                List<kurier_s_sita> pr2 = null;
                try
                {
                    pr2 = JsonSerializer.Deserialize<List<kurier_s_sita>>(paket);

                    foreach (Models.driver driver_main in driver_manager.worker)
                    {

                        List<zakaz_upr> promeg = new List<zakaz_upr>();
                        //пробегаю по пакетам с курьерами+ и заказами
                        foreach (kurier_s_sita driver_site in pr2)
                        {
                            if (driver_site.curier == driver_main.name)
                            {
                                WebApplication1.Controllers.loger_.loger.sawe_status(driver_site.zakaz, "логист отдал заказ курьеру: " + driver_main.name);
                                promeg.Add(
                                     zakaz_upr.zakaz_upr_chek_powt(driver_site.zakaz,
                                    driver_manager.get_status(driver_site.zakaz),
                                    WebApplication7.Views.wodili.data_manager.get_market(driver_site.zakaz)));

                            }
                        }

                        driver_main.zakazi = promeg;

                    }
                }
                catch
                {

                }
             return  JsonSerializer.Serialize<ConcurrentBag<Models.driver>>(driver_manager.worker);


            }
        }
    }
}
