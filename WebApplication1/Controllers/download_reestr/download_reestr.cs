using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebApplication7.Views
{
    public class download_reestr : download
    {

        public download_reestr( ) : base("\\REESTR\\", analitic2)
        {
            

        }
        public static List<WebApplication7.Views.wodili.zakaz> zakazi = new List<WebApplication7.Views.wodili.zakaz>();
        
        
        
        public override void analitick()
        {
            Excel.Range data = null;//время
            Excel.Range wes = null;//вес
            Excel.Range obiome = null;//обём 
            Excel.Range id = null;//айди заказа
            Excel.Range ADRES = null;//айди заказа
            Excel.Range FILIAL = null;//айди заказа
            Excel.Range Spisok = null;//айди заказа
            Excel.Range sposob_opl = null;//айди заказа
            Excel.Range ADRES_dost = null;//айди заказа

            Excel.Range time_dost = null;//айди заказа
            Excel.Range agent_type = null;//айди заказа
            Excel.Range kolich = null;//айди заказа
            Excel.Range numbr_clienta = null;//айди заказа
            Excel.Range coment = null;//айди заказа
            Excel.Range data_dost = null;//айди заказа
            
            FILIAL = Rng.Find("Филиал:");
            ADRES = Rng.Find("Адрес:");
            data = Rng.Find("Дата доставки");
            obiome = Rng.Find("Объем заказа");
            wes = Rng.Find("Вес заказа");
            id = Rng.Find("Номер заявки");
            Spisok = Rng.Find("Список товаров");
            sposob_opl = Rng.Find("Способ оплаты");
            ADRES_dost = Rng.Find("Адрес доставки");

            time_dost = Rng.Find("Время доставки");
            data_dost = Rng.Find("Дата доставки");
            agent_type = Rng.Find("Тип контрагента");
            kolich = Rng.Find("Кол-во товара");
            numbr_clienta = Rng.Find("Телефон клиента");
            coment = Rng.Find("Комментарий");

            if ((FILIAL == null) || (ADRES == null)
                || (data == null) || (obiome == null)
                || (wes == null) || (id == null) || (Spisok == null)
                || (time_dost == null) || (data_dost == null) || (agent_type == null)
                || (kolich == null) || (numbr_clienta == null) 
                )
            {
                dowload_error.Add(tek);
                return;
            }



            for (int str = 7; str < 1000; str++)
            {
                Excel.Range prrr = (Excel.Range)xlSht.Cells[str, 1];

                if ((bool)prrr.MergeCells) //если ячейка имеет объединённые ячейки
                {
                    str += prrr.MergeArea.Count - 1;
                    prrr = xlSht.Range[prrr.MergeArea.Address];
                }
                WebApplication7.Views.wodili.zakaz pfel = new WebApplication7.Views.wodili.zakaz();



                Excel.Range prrr2 = (Excel.Range)xlSht.Cells[2, 5];
                pfel.MAGAZIN = (string)prrr2.Value;
                //удаляю знаки ' "

                while (true)
                {
                    pfel.MAGAZIN= pfel.MAGAZIN.Replace("\'","");
                    if (pfel.MAGAZIN.IndexOf("\'") == -1) break;
                }
                while (true)
                {
                    pfel.MAGAZIN = pfel.MAGAZIN.Replace("\"", "");
                    if (pfel.MAGAZIN.IndexOf("\"") == -1) break;
                }

                

                prrr2 = (Excel.Range)xlSht.Cells[2, 19];
                pfel.ADRES = (string)prrr2.Value;



                Excel.Range erd;
                try
                {
                    
                    erd = (Excel.Range)xlSht.Cells[prrr.Row, id.Column];
                    pfel.id_zak = (string)erd.Value;
                    if (pfel.id_zak == null)
                    {
                        return;
                    }
                }



                catch (Exception e)
                {
                    dowload_error.Add(tek + " ошибка в числах");
                    return;
                }

                //контрагент
                try
                {

                    erd = (Excel.Range)xlSht.Cells[prrr.Row, agent_type.Column];
                    pfel.agent_type = (string)erd.Value;
                    if (pfel.agent_type == null)
                    {
                        return;
                    }
                }

                catch (Exception e)
                {
                    dowload_error.Add(tek + " ошибка в agent_type");
                    return;
                }

                //дата
                try
                {

                    erd = (Excel.Range)xlSht.Cells[prrr.Row, data_dost.Column];
                    pfel.data_dost = (string)erd.Value.ToString();

                    if (pfel.data_dost.Length == 18)
                    {
                        pfel.data_dost=pfel.data_dost.Remove(10);
                    }
                    
                    if (pfel.data_dost == null)
                    {
                        return;
                    }
                }

                catch (Exception e)
                {
                    dowload_error.Add(tek + " ошибка в data_dost");
                    return;
                }
                //время
                try
                {

                    erd = (Excel.Range)xlSht.Cells[prrr.Row, time_dost.Column];
                    //мой алгорит для определения времни
                    string ps = (string)erd.Value;

                    //формат
                     //чч:           мм 
                  
                    Regex regex = new Regex(@"[1-2]{1}[0-9]{1}:[0-6]{1}[0-9]{1}", RegexOptions.IgnoreCase);
                    MatchCollection matches = regex.Matches(ps);
                    if (matches.Count == 2)
                    {
                        pfel.time_dost_up= matches[0].Value;
                        pfel.time_dost_down = matches[1].Value;
                        if (pfel.time_dost_up == null) { 
                            dowload_error.Add(tek + " ошибка в формате времени"); 
                            return; 
                        }
                        if (pfel.time_dost_down == null)
                        {
                            dowload_error.Add(tek + " ошибка в формате времени");
                            return;
                        }
                    }
                    else
                    {
                        dowload_error.Add(tek + " ошибка в формате времени");
                        return;
                    }

                  
                      
                }

                catch (Exception e)
                {
                    dowload_error.Add(tek + " ошибка в time_dost");
                    return;
                }
                



                erd = (Excel.Range)xlSht.Cells[prrr.Row, sposob_opl.Column];
                pfel.oplata = (string)erd.Value;
                if ("Доставка полностью оплаченного товара" == (string)erd.Value)
                {
                    pfel.oplach = true;
                }
                else
                {
                    pfel.oplach = false;
                }

                erd = (Excel.Range)xlSht.Cells[prrr.Row, ADRES_dost.Column];
                pfel.ADRES_dostawki = (string)erd.Value;


                //докидываю номер телефона
                erd = (Excel.Range)xlSht.Cells[prrr.Row, numbr_clienta.Column];
                if (erd.Value == null)
                {
                    dowload_error.Add('\\' + tek + " НЕ УКАЗАН номер ");
                    return;

                }
                pfel.number_tell_clienta =""+ erd.Value;
                
                //докидываю коментарии к заказу 
                erd = (Excel.Range)xlSht.Cells[prrr.Row, coment.Column];
                if (erd.Value == null)
                {
                    dowload_error.Add('\\' + tek + " нет коментария к заказу");
                    return;

                }
                pfel.coment = ""+erd.Value;

                try
                {
                    for (int cogr = prrr.Cells.Count; cogr > 0; cogr--)
                {
                    WebApplication7.Views.wodili.pozicii fffe = new WebApplication7.Views.wodili.pozicii();

                    Excel.Range rr = (Excel.Range)prrr.Cells[cogr];
                    erd = (Excel.Range)xlSht.Cells[rr.Row, Spisok.Column];
                    fffe.text = (string)erd.Value;
                        //удаляю всю фигню
                        while (true)
                        {
                            fffe.text = fffe.text.Replace("\"", "");
                            if (fffe.text.IndexOf("\"") == -1) break;
                        }
                        while (true)
                        {
                            fffe.text = fffe.text.Replace("\'", "");
                            if (fffe.text.IndexOf("\'") == -1) break;
                        }


                        if (fffe.text != "Доставка товара клиенту")
                            {
                                erd = (Excel.Range)xlSht.Cells[rr.Row, wes.Column];
                            if (erd.Value == null)
                            {
                                dowload_error.Add('\\' + tek + " НЕ УКАЗАН ВЕС ");
                                return;

                            }
                                fffe.m = (double)erd.Value;

                                erd = (Excel.Range)xlSht.Cells[rr.Row, obiome.Column];
                            if (erd.Value == null)
                            {
                                dowload_error.Add('\\' + tek + " НЕ УКАЗАН объём  ");
                                return;

                            }

                              fffe.o = (double)erd.Value;

                          
                        }
                        //количество заказов
                        erd = (Excel.Range)xlSht.Cells[rr.Row, kolich.Column];
                         
                        fffe.count = int.Parse( erd.Value.ToString()); 
                         pfel.text_zakaza.Add(fffe);

                     


                    }
                }
                catch (Exception e)
                {
                    dowload_error.Add('\\' +tek + " ошибка в позициях ");
                    return;
                }
                bool nenashel = true;
                foreach (wodili.zakaz zakaz in zakazi)
                {
                    if (zakaz.id_zak == pfel.id_zak)
                    {
                        nenashel = false;
                        dowload_error.Add(pfel.id_zak + " id заказа уже было ");
                        break;
                    }
                }
                if(nenashel)
                zakazi.Add(pfel);

            }

            int dw = 0;


        }
        public static int indexer = 0;
        public static void analitic2()
        {
            // сортирую по магазинам
            for ( int x= indexer; x< zakazi.Count;x++)
            {
                WebApplication7.Views.wodili.zakaz ff = zakazi[x];
                bool nashel = false;
                foreach (WebApplication7.Views.wodili.magaz fpe in WebApplication7.Views.wodili.data_manager.magazini)
                {


                    if (fpe == null)
                    {
                        nashel = true;
                        break;
                    }
                    else
                    {
                        if (ff.MAGAZIN == fpe.mag)
                        {
                            nashel = true;
                            break;
                        }
                    }



                }
                WebApplication7.Views.wodili.magaz pr = new WebApplication7.Views.wodili.magaz();
                pr.adr = ff.ADRES;
                pr.mag = ff.MAGAZIN;
                if (!nashel) WebApplication7.Views.wodili.data_manager.magazini.Add(pr);
            }
            for (int xx = indexer; xx < zakazi.Count; xx++)
            {
                WebApplication7.Views.wodili.zakaz ff = zakazi[xx];

                for (int x = 0; x < WebApplication7.Views.wodili.data_manager.magazini.Count; x++)
                {


                    if (ff.MAGAZIN == WebApplication7.Views.wodili.data_manager.magazini[x].mag)
                    {


                        WebApplication7.Views.wodili.data_manager.magazini[x].zakazi.Add(ff);
                        WebApplication7.Views.wodili.data_manager.magazini[x].count_poz += ff.text_zakaza.Count;
                        WebApplication7.Views.wodili.data_manager.magazini[x].count_zak++;


                        break;
                    }

                }
            }

            foreach (WebApplication7.Views.wodili.magaz f in WebApplication7.Views.wodili.data_manager.magazini)
            {
                int kbt = 0, mbt = 0;



                foreach (WebApplication7.Views.wodili.zakaz es in f.zakazi)
                {
                    bool kkoe = false;
                    foreach (WebApplication7.Views.wodili.pozicii d in es.text_zakaza)
                    {

                        if ((d.m > 30.0) || (d.o > 0.2))
                        {
                            kkoe = true;

                            break;
                        }
                        else
                        {

                            kkoe = false;

                        }

                    }
                    if (kkoe) { 
                        kbt++;
                        es.kbt = true;
                    }
                    else {
                        mbt++;
                        es.kbt = false;
                    }
                   

                }


                f.mbt = mbt;
                f.kbt = kbt;
            }
            foreach (WebApplication7.Views.wodili.magaz f in WebApplication7.Views.wodili.data_manager.magazini)
            {
                int oplach = 0;
                int nalog=0;
                foreach (WebApplication7.Views.wodili.zakaz es in f.zakazi)
                {
                    if (es.oplach) oplach++; else nalog++;
                }
                f.oplach = oplach;
                f.nalog = nalog;
            }
            indexer = zakazi.Count ;
        }
    }
}
