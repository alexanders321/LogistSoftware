// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let audio = new Audio('https://zvukipro.com/uploads/files/2020-07/1594182502_6a9eda36651d8d7.mp3');
var once = true;
var once2 = false;
var once3 = true;
var last;
var last2;
function sayHi(phrase) {
    var xhr = new XMLHttpRequest();
    let f = window.location.protocol + "//" + window.location.host + "/dr_contr/site_data?paket=" + phrase;
    // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
    xhr.open('GET', f, true);


    xhr.send();
    // chek();//нестоит
    xhr.onreadystatechange = function () { // (3)
        if (xhr.readyState != 4) return;
        if (xhr.status != 200) {

          //  alert("нет связи с сайтом1 " + xhr.status + ': ' + xhr.statusText); // 
        } else {
            //магазины инициализация
            manager_packet.zakaz();
            const obj2 = JSON.parse(xhr.responseText);
            
            draw_interf.clear_kratko();
            for (let ffeg = 0; ffeg < obj2.length; ffeg++) {

           
            var kur;
            //данные курьера 
            if (obj2.length != 0) {
                // var kur = new kurier(obj2[0].id, "" + (55.56), obj2[0].dolg);
                kur = new kurier(obj2[ffeg].name, obj2[ffeg].shir, obj2[ffeg].dolg, obj2[ffeg].data_last_update_coord);
                kur = kur.add_in_pull();//вернёт ссылку если объект уже существовал

                if (once) {

                    for (let x = 0; x < obj2[ffeg].zakazi.length; x++) {
                        var zak = new zakaz(obj2[ffeg].zakazi[x].id, 0, 0, 0, 0, obj2[ffeg].zakazi[x].status[obj2[ffeg].zakazi[x].status.length - 1].status);
                        
                        zak = zak.add_in_pull();
                        if (zak != null) {
                            zak.clear_all_poiuawleniuy();
                            kur.add_doch(zak);
                        }
                    }
                }
           
                
                draw_interf.draw(obj2[ffeg]);
                // kur.update();

            }

           

            //докидываю фото заказам из ответа сервака
                /*
            if (obj2.length != 0) {
                for (let x = 0; x < obj2[ffeg].zakazi.length; x++) {

                    var father = document.getElementById(obj2[ffeg].zakazi[x].id);
                    for (let xx = 0; xx < obj2[ffeg].zakazi[x].foto.length; xx++) {
                        if (father != null) {
                            var find = document.getElementById(obj2[ffeg].zakazi[x].foto[xx]);
                            if (find == null) {
                                var new_foto = document.createElement("img");
                                new_foto.id = obj2[ffeg].zakazi[x].foto[xx];
                                new_foto.className = "foto_razmeri";
                                new_foto.src = "/FILE/Foto_pokaz?path=" + obj2[ffeg].zakazi[x].foto[xx]; //phrase;

                                father.appendChild(new_foto);

                            }
                        }
                    }
                }
            }
            */
            //сравниваю время доставки заказов и текущее если оно не укладывается в рамки то окрашеваю

                var father = document.getElementsByClassName("zakazi2435235");
               
            for (let x = 0; x < father.length; x++) {


                var time_up = document.getElementById(father[x].id + "\'tttimesup\'");
                var time_dwn = document.getElementById(father[x].id + "\'tttimesdwn\'");
                // father[x].style.backgroundColor = "red";

            }
            geobase.pull_cur;

                draw_interf.cratko_wodit(obj2[ffeg].name, obj2[ffeg].data_last_update_coord);
            }
            once = false;
            //магазины
           
          
        }
    
        
    }

}

 


// полвеояю какой раздел водители курьеры или заказы и какие данные рисовать  
function chek() {

    var kurieri = document.getElementById("kurieri1112");
    var magazini212 = document.getElementById("magazini212");
    var zakazi323 = document.getElementById("zakazi323");

    if (kurieri.checked) {
        var block = document.getElementById("woditeli_wsee");
        block.removeAttribute("hidden");
        var block = document.getElementById("magazi");
        block.setAttribute("hidden", "hidden");
        pokaz_kurierow();

    } else {


        var block = document.getElementById("woditeli_wsee");
        block.setAttribute("hidden", "hidden");

    }
    if (magazini212.checked) {
        var block = document.getElementById("magazi");
        block.removeAttribute("hidden");
        pokaz_magazinow();

    } else {

    }

    if (zakazi323.checked) {
        var block = document.getElementById("magazi");
        block.removeAttribute("hidden");
        pokaz_magaz_zakazow();

    } else {

    }
}

function someFunk(a, b, event) {
    alert(a, b, event);
    var f = document.getElementById("magazi");
    b.appendChild(f);
}


//setTimeout(sayHi, 10000, "Привет");

class manager_packet {
   
    static zakaz() {
            var fer122 = document.getElementsByClassName('MAG_D2');
            var fer222 = document.getElementsByClassName('MAG_H2');
            var mag_data_count_k = document.getElementsByClassName('mag_data_count_k');
            var mag_data_count_m = document.getElementsByClassName('mag_data_count_m');
      

            var magaz_inner_dat = document.getElementsByClassName('magaz_inner_dat');

            //отрисовываю магазины у которых открыто описание
            for (var s = 0; s < fer122.length; s++) {

                var atr = magaz_inner_dat[s].getAttribute("hidden");
               
                   

                    // Создаем геообъект с типом геометрии "Точка".
                    //  myGeoObject.add(new ymaps.Placemark([fer1[s].innerHTML, fer2[s].innerHTML])) 

                    let k = Number(mag_data_count_k[s].value);
                    let ms = Number(mag_data_count_m[s].value);


                    var prom1 = fer122[s].value;
                    var prom2 = fer222[s].value;
                    var pr = new ymaps.Placemark([prom1, prom2], {
                        // Данные для построения диаграммы.
                        data: [
                            { weight: ms, color: '#008000' },
                            { weight: k, color: '#ff0000' }

                        ],
                        iconCaption: fer0[s].value
                    }, {
                        // Зададим произвольный макет метки.
                        iconLayout: 'default#pieChart',
                        iconPieChartRadius: 20,
                        iconPieChartCoreRadius: 10

                    });
 

                    var mark = new market(fer0[s].value, fer122[s].value, fer222[s].value);
                    mark.add_in_pull();


                    var zakazi = new Array();
                    //ищу заказы
                    var zakaz_child = magaz_inner_dat[s].childNodes;
                    for (var x = 0; x < zakaz_child.length; x++) {
                        if ("zakazi2435235" == zakaz_child[x].className) {
                            zakazi.push(zakaz_child[x].id);


                        }
                    }

                    for (var x = 0; x < zakazi.length; x++) {

                        var dd = zakazi[x] + "'D'";
                        var hh = zakazi[x] + "'H'";
                        var kbt_or_mbtzakaz1 = zakazi[x] + "'kbt_or_mbtzakaz'";
                        var MAG_D2 = document.getElementsByClassName(dd);
                        var MAG_H2 = document.getElementsByClassName(hh);
                        var kbt_or_mbtzakaz = document.getElementsByClassName(kbt_or_mbtzakaz1);
                        //  myMap.geoObjects.add(new ymaps.Placemark([MAG_D2[0].value, MAG_H2[0].value], { iconCaption: zakazi[x] }));
                        
                        var zak = new zakaz(zakazi[x], MAG_D2[0].value, MAG_H2[0].value, mark, kbt_or_mbtzakaz[0].innerHTML);
                     

                       

                        if (geobase.get_by_name(zak.id) == null) {
                            zak.add_in_pull();

                            mark.add_doch(zak);

                        }
                    }

                geobase.pull_cur
            }






        
    }
    
    static send_pak() {

        var out_str = new Array();
        for (let x = 0; x<kurier.pull_cur.length; x++) {
            if (kurier.pull_cur[x].kurierLI == true) {
                //ЕСЛИ КУРЬЕР 
                for (let y = 0; y < kurier.pull_cur[x].pull_zakazow.length; y++) {

                    var pk = new pak(kurier.pull_cur[x].pull_zakazow[y].id, kurier.pull_cur[x].id, false);
                    out_str.push(pk.toString());
                }

              
            }
        }


        //пакет
        alert("успешно");

        sayHi("[" + out_str.toString() + "]");

    }
}



//базовый класс
class geobase {
    static infdsf = 4;
    constructor(id, shir, dolg, placemark) {
        this.id = id;
        this.shir = shir;
        this.dolg = dolg;
        this.placemark = placemark;

    }
    //все курьеры
    static pull_cur = new Array();
    //добавляю курьера если есть уже курьер то обновляю
     
    add_in_pull() {

         let nashel = false;
         let  index =0;
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (geobase.pull_cur[x].id == this.id) {
                nashel = true;
                index = x;
                this.index2 = x;
                break;
            }
        }
        if (nashel) {
            //обновление обновлять надо лишь отдельные части
            geobase.pull_cur[index].shir = this.shir;
            geobase.pull_cur[index].dolg = this.dolg;
            this.update_loc_map();
            return false;
        } else {
            //добавление
            geobase.pull_cur.push(this);
            this.add_on_map();
            this.update_loc_map("fdsf");
            return true;
        }
    }
    //добавление заказа без изменения координат
    add_in_pull2() {

        let nashel = false;
        let index = 0;
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (geobase.pull_cur[x].id == this.id) {
                nashel = true;
                index = x;
                this.index2 = x;
                break;
            }
        }
        if (nashel) {
            //обновление обновлять надо лишь отдельные части
     
          
            return false;
        } else {
            //добавление
            geobase.pull_cur.push(this);
            this.add_on_map();
            this.update_loc_map("fdsf");
            return true;
        }
    }
    //удаляю курьера
    static del_byid(id) {
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (geobase.pull_cur[x].id == id) {
                geobase.pull_cur.splice(x, 1);
            }
        }
    }

    //работа с картой
    add_on_map() {
        var fe = this;
        myMap.geoObjects.add(this.placemark);
        this.placemark.events.add(['click'], function (e) {
            fe.on_click();
        });
        

    }
    dell_on_map() {

    }

    hide_on_map() {
        var tdsd = this;
        myMap.geoObjects.each(function (geoObject) {
            if (geoObject.properties._data.iconCaption == tdsd.id) {

                geoObject.options.set("visible", false);
            }
        });
    }
    show_on_map(value) {

        var tdsd = this;
        myMap.geoObjects.each(function (geoObject) {
            if (geoObject.properties._data.iconCaption == tdsd.id) {

                geoObject.options.set("visible", true);
            }
        });
    }

    update_loc_map() {
        var fe = this;
        myMap.geoObjects.each(function (geoObject) {
            if (geoObject.properties._data.iconCaption == fe.id) {

                geoObject.geometry.setCoordinates([fe.shir, fe.dolg]);
            }
        });
    }
    static get_by_name(name) {
        for (let x = 0; x < geobase.pull_cur.length; x++) {

            if (geobase.pull_cur[x].id == name) return geobase.pull_cur[x];
       
        }
               return null;
    }
    on_click() {
        alert("nagak");
    }
    on_right() {
        alert("PRAWO");
    }
    static  hide_all_zak() {
        for (var ob in geobase.pull_cur) {
            if (geobase.pull_cur[ob].zkaz_li == true) {
                var d = document.getElementById(geobase.pull_cur[ob].id);
                d.setAttribute("hidden", "hidden");
            }
        }
    }

    
    
}
//класс для работы с дочерними заказами
class zakazi extends geobase {
    pull_zakazow = new Array();


    constructor(id, shir, dolg, placemark) {
        super(id, shir, dolg, placemark);
        this.select = false;



    }
    add_doch(zakazec) {

        if (zakazec == null) return false;
       for (let x = 0; x < this.pull_zakazow.length; x++) {
            if (zakazec.id == this.pull_zakazow[x].id) return false;
        }
        // if (-1 != this.pull_zakazow.indexOf(zakazec)) return false;
       
        this.pull_zakazow.push(zakazec);


        this.placemark.properties._data.data[0].weight = this.mbt_count();
        this.placemark.properties._data.data[1].weight = this.kbt_count();

        this.placemark.options.set("iconPieChartCoreFillStyle", "#ffffff");
        this.placemark.options.set("iconPieChartRadius", this.placemark.options.get("iconPieChartRadius") / 2);
        this.placemark.options.set("iconPieChartRadius", this.placemark.options.get("iconPieChartRadius") * 2);

        return true;
        //возвращает истину если добавил

    }
    //вернёт число заказов оставшееся  
    del_doch(zakazec) {


        for (let x = 0; x < this.pull_zakazow.length; x++) {
            if (this.pull_zakazow[x].id == zakazec.id) {
                this.pull_zakazow.splice(x, 1);

                this.placemark.properties._data.data[0].weight = this.mbt_count();
                this.placemark.properties._data.data[1].weight = this.kbt_count();

                this.placemark.options.set("iconPieChartRadius", this.placemark.options.get("iconPieChartRadius") / 2);
                this.placemark.options.set("iconPieChartRadius", this.placemark.options.get("iconPieChartRadius") * 2);

                return this.pull_zakazow.length;
            }
        }

        return -1;



    }
    show_doch() {
        for (let x = 0; x < this.pull_zakazow.length; x++) {
            this.pull_zakazow[x].show_on_map();
        }
    }
    hide_doch() {
        for (let x = 0; x < this.pull_zakazow.length; x++) {
            this.pull_zakazow[x].hide_on_map();
        }
    }

    kbt_count() {
        var kbt = 0;

        for (let x = 0; x < this.pull_zakazow.length; x++) {
            if (this.pull_zakazow[x].kbt_li != "False") kbt++;
        }
        return kbt;
    }
    mbt_count() {
        var kbt = 0;

        for (let x = 0; x < this.pull_zakazow.length; x++) {
            if (this.pull_zakazow[x].kbt_li == "False") kbt++;
        }
        return kbt;
    }

      v_nalicii(dock) {
        for (let fei in this.pull_zakazow) {
            if (dock.id == fei.id) return true
        }
        return false;
    }
   
}

class kurier extends zakazi {

    static target;

    constructor(id, shir, dolg, data_last_update_coord) {


        var mark = new ymaps.Placemark([shir, dolg], {
            data: [
              
                     { weight: 1, color: '#9400d3' },
                { weight: 0, color: '#ff0000' }
            ],
            iconCaption: id, hui: "4234"
        }, {
            iconSize: 100,
            // Зададим произвольный макет метки.
            iconLayout: 'default#pieChart',
            // Радиус диаграммы в пикселях.
            iconPieChartRadius: 15,
            // Радиус центральной части макета.
            iconPieChartCoreRadius: 10,
            // Стиль заливки центральной части.
            iconPieChartCoreFillStyle: '#000000',
            // Cтиль линий-разделителей секторов и внешней обводки диаграммы.
            iconPieChartStrokeStyle: '#ffffff',
            // Ширина линий-разделителей секторов и внешней обводки диаграммы.
            iconPieChartStrokeWidth: 3,
            // Максимальная ширина подписи метки.
            iconPieChartCaptionMaxWidth: 200
        });
        super(id, shir, dolg, mark);
        this.kurierLI = true;
        this.data_last_update_coord = data_last_update_coord;

    }
    //если кликаю на иконку курьера
    on_click() {

        if ((kurier.target == this)) {
            this.placemark.options.set("iconPieChartRadius", 15);
            this.hide_doch();
            kurier.target = null;

        } else {
            if (kurier.target != null) {
                kurier.target.hide_doch();
                this.placemark.options.set("iconPieChartRadius", 15);
            }

            kurier.target = this;
           // this.show_doch();
            this.placemark.options.set("iconPieChartRadius", 20);
        }


    }
    del_doch(zakazec) {

        if (0 == super.del_doch(zakazec)) {
            this.placemark.properties._data.data[0].weight = 1;

            this.placemark.options.set("iconPieChartCoreFillStyle", "#000000");

            this.placemark.options.set("iconPieChartRadius", this.placemark.options.get("iconPieChartRadius") / 2);
            this.placemark.options.set("iconPieChartRadius", this.placemark.options.get("iconPieChartRadius") * 2);

        } else {
            this.placemark.options.set("iconPieChartCoreFillStyle", "#ffffff");

            this.placemark.options.set("iconPieChartRadius", this.placemark.options.get("iconPieChartRadius") / 2);
            this.placemark.options.set("iconPieChartRadius", this.placemark.options.get("iconPieChartRadius") * 2);

        }





    }

    add_in_pull() {
        if (!super.add_in_pull()) {

            geobase.pull_cur[this.index2].data_last_update_coord = this.data_last_update_coord;
            return geobase.pull_cur[this.index2];
        }
    }

    mag_pl() {

    }
 
    static dell_all_doch() {
        if (this.target == null) alert("не выбран курьер");

        //ищу магазины которым пренадлежат заказы
        var mag_array = new Array();
        let counter = kurier.target.pull_zakazow.length;
        //докидываю в эти магазины
        for (let zak = 0; zak < counter; zak++) {
            var nashel = false

            for (let x = 0; x < mag_array.length; x++) {
                if (mag_array[x] == kurier.target.pull_zakazow[zak].father) {
                    nashel = true;
                    break;
                }
            }


            if (!nashel)
                mag_array.push(kurier.target.pull_zakazow[zak].father);


        }

        //сворачиваю магазины
        for (let zak = 0; zak < counter; zak++) {
            //массив сдвигается по этому удаляю всегда по 0 индексу
            var zakazec = kurier.target.pull_zakazow[0];
            kurier.target.del_doch(zakazec);
            market.add_doch(zakazec);


        }
        for (let x = 0; x < mag_array.length; x++) {
            mag_array[x].on_click2();
        }

    }
    static v_nalicii(dock) {
        super.v_nalicii(dock);
    }
}
class zakaz extends geobase  {
    constructor(id, shir, dolg, father, kbt_li, status) {
        var color;
        if (kbt_li == "False") color = "#008000";
        else color = "#ff0000";

        var mark = new ymaps.Placemark([shir, dolg], {

            iconCaption: id, hui: "4234"
        }, {

            // Зададим произвольный макет метки.
          //  preset: 'islands#redCircleDotIcon', метка для заказа оплаченного
            preset:  'islands#blueCircleIcon',
            iconColor: color

        });
        super(id, shir, dolg, mark);
        this.father = father;
        this.kbt_li = kbt_li;
        this.status = status;
        this.zkaz_li = true;
        
    }


    add_in_pull() {
        if (super.add_in_pull2()) {
            //добавил
            super.hide_on_map();
            //устанавливаю в html значение
            if (this.status != null)
            document.getElementById(this.id + "\'status43243\'").value = "" + this.status.toString();

            return this;
        }
        else {
            //обновить статус

            // drive_foto(this.id);
            geobase.pull_cur[this.index2].status = this.status;

            if (this.status != null) {
                var ffl = document.getElementById(this.id + "\'status43243\'");
                if (ffl == null) return null;
                else ffl.value = "" + this.status.toString();

            }
            return geobase.pull_cur[this.index2];
        }
        
    }

    //добавляю пришедшие заказы курьерам только если заказы отличаются
   static dokidiway(id_cur,zakaz) {
        var cura = geobase.get_by_name(id_cur);
       if (cura.add_doch(zakaz)) {
            //если заказа не было у курьера
           zakaz.hide_on_map();
           if (0 == market.del_doch(zakaz)) market.show_mag(zakaz);
       }
      
    }
    on_click() {
        //скрываю все
        geobase.hide_all_zak();
        //отрисовываю в окне
        show_hide(this.id);
        //отдаю заказ
        if (kurier.target != null) {

            if (kurier.target.add_doch(this)) {
                //если заказа не было у курьера
                this.hide_on_map();
                if (0 == market.del_doch(this)) market.show_mag(this);
            } else {
                //закз был
                this.hide_on_map();
                kurier.target.del_doch(this);
                market.add_doch(this);
            }
        }
    }
     clear_all_poiuawleniuy() {
        for (var indexer = 0; indexer < geobase.pull_cur.length; indexer++) {

            if (geobase.pull_cur[indexer].kurierLI || geobase.pull_cur[indexer].magazin) {
                geobase.pull_cur[indexer].del_doch(this);
            }
        }
    }

    
    static clear_all_poiuawleniuy_id(id) {
       
        var zak = geobase.get_by_name(id);
        zak.clear_all_poiuawleniuy();
        geobase.del_byid(id);
        //удаляю с карты
        /*
        myMap.geoObjects.each(function (geoObject) {
            if (geoObject.properties._data.iconCaption == phrase) {
                myMap.geoObjects.remove(geoObject);
            }


        });
        */
    }
}
class market extends zakazi {
    static target = new Array();
        //проверяю все магазины выделленные и добавляю в них заказ на который нажал
    //проверяю является ли магазин отцовским для заказа
    static add_doch(zakazec) {

       
       
        for (let x = 0; x < geobase.pull_cur.length; x++) {

            if (geobase.pull_cur[x].id == zakazec.father.id) {

                

                geobase.pull_cur[x].add_doch(zakazec);
                geobase.pull_cur[x].show_on_map("2");
                zakazec.show_on_map();
                geobase.pull_cur[x].placemark.options.set("iconPieChartRadius", 20);
                //market.target[x].hide_doch();
                return geobase.pull_cur[x];
            }
            
        }
        return null;

    }
 

    static del_doch(zakazec) {
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (geobase.pull_cur[x].magazin == true)
            geobase.pull_cur[x].del_doch(zakazec);

        }
    }
    constructor(id, shir, dolg) {

        var mark = new ymaps.Placemark([shir, dolg], {
            data: [
                { weight: 0, color: '#008000' },
                { weight: 0, color: '#ff0000' }

            ],
            iconCaption: id, hui: "4234"
        }, {
            iconSize: 100,
            // Зададим произвольный макет метки.
            iconLayout: 'default#pieChart',
            // Радиус диаграммы в пикселях.
            iconPieChartRadius: 15,
            // Радиус центральной части макета.
            iconPieChartCoreRadius: 10,
            // Стиль заливки центральной части.
            iconPieChartCoreFillStyle: '#ffffff',
            // Cтиль линий-разделителей секторов и внешней обводки диаграммы.
            iconPieChartStrokeStyle: '#ffffff',
            // Ширина линий-разделителей секторов и внешней обводки диаграммы.
            iconPieChartStrokeWidth: 3,
            // Максимальная ширина подписи метки.
            iconPieChartCaptionMaxWidth: 200
        });
        super(id, shir, dolg, mark);
        this.magazin = true;
        this.show = true;
    //если заказов не осталось то скрываю магазин и показываю другие
    }

    del_doch(zakazec) {

        if (super.del_doch(zakazec) == 0) {
            market.show_mag(this);
            this.hide_on_map();

        }
    }
    on_click() {
        
        //если нет в массиве то добавляю  а если есть то удаляю
        if (-1 == market.target.indexOf(this)) {
            market.target.push(this);
            this.show_doch();
            this.placemark.options.set("iconPieChartRadius", 20);
            market.hide_mag(this);
            //скрываю все заказы
            geobase.hide_all_zak();
        }
        else {
            this.hide_doch();
            var dest = market.target.indexOf(this)
            market.target.splice(dest, 1);
            this.placemark.options.set("iconPieChartRadius", 15);
            market.show_mag(this);
            //скрываю все заказы
            geobase.hide_all_zak();

        }


    }
    on_click2() {
        this.hide_doch();
       
       
        this.placemark.options.set("iconPieChartRadius", 15);
        market.show_mag(this);
        //скрываю все заказы
        geobase.hide_all_zak();
    }
    //скрывает показывает все магазины кроме выбранного 
    static hide_mag(val) {
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (val.id != geobase.pull_cur[x].id) {
                if (geobase.pull_cur[x].magazin == true) geobase.pull_cur[x].hide_on_map();
            }
        }
      
        
    }
    static hide_mag_by_id(val) {
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (val != geobase.pull_cur[x].id) {
                if (geobase.pull_cur[x].magazin == true) geobase.pull_cur[x].hide_on_map();
            }
        }


    }
    static show_mag(val) {
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (val.id != geobase.pull_cur[x].id) {
                if ((geobase.pull_cur[x].magazin == true) && (geobase.pull_cur[x].pull_zakazow != 0)
                    &&geobase.pull_cur[x].show) geobase.pull_cur[x].show_on_map();
            }
        }


    }
    static show_mag_by_id(val) {
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (val != geobase.pull_cur[x].id) {
                if ((geobase.pull_cur[x].magazin == true) && (geobase.pull_cur[x].pull_zakazow != 0)) geobase.pull_cur[x].show_on_map();
            }
        }


    }
    static show_hide(val) {
        for (let x = 0; x < geobase.pull_cur.length; x++) {
            if (val == geobase.pull_cur[x].id) {
                if ((geobase.pull_cur[x].magazin == true) && (geobase.pull_cur[x].pull_zakazow != 0)) {
                    if (geobase.pull_cur[x].show) { geobase.pull_cur[x].hide_on_map(); geobase.pull_cur[x].show = false; }
                    else { geobase.pull_cur[x].show_on_map(); geobase.pull_cur[x].show = true; }


                }
            }
        } 
    }
}

//отрисовка меню курьера 

class draw_interf {

    static draw(inp) {
        var pp = document.getElementById(inp.id);
        if (pp != null) pp.remove();

        var block_main = document.createElement("div");
        block_main.id = inp.id;
        block_main.className = "wodili";
        document.getElementById("woditeli_wsee").appendChild(block_main);


      

        var idddi = document.createElement("div");
        idddi.id = "idddi32332g";
        idddi.className = "line";
        block_main.appendChild(idddi);
        //статус
        var stat = document.createElement("div");
        stat.id = "status32332g";
        stat.className = "line";
        block_main.appendChild(stat);
        //статус
        var stat_time = document.createElement("div");
        stat_time.id = "status32332gtime";
        stat_time.className = "line";
        block_main.appendChild(stat_time);
        //последнее обновление
        var last_pak = document.createElement("div");
        last_pak.className = "line";
        block_main.appendChild(last_pak);
        //имя
        var namess = document.createElement("div");
        namess.className = "line";
        block_main.appendChild(namess);
        //кнопка проверил логист
        var log_btm = document.createElement("div");
        log_btm.className = "line";
        block_main.appendChild(log_btm);
        //файлы
        var filee = document.createElement("div");
        filee.className = "line";
        block_main.appendChild(filee);
        for (let x = 0; x < inp.zakazi.length; x++) {

 

           

            var block = document.createElement("a");
            block.setAttribute('href', block.href = "/HISTORY/formated_history/" + inp.zakazi[x].id);
            block.innerHTML = inp.zakazi[x].id;
            block.className = "id_spisok_zak";
            idddi.appendChild(block);


            block = document.createElement("div");
            block.innerHTML = inp.zakazi[x].status[inp.zakazi[x].status.length - 1].status;
            stat.appendChild(block);


            block = document.createElement("div");
            //подкрашиваю в случае оппоздания
            //длительность операции!!!
            var how_long = inp.zakazi[x].status[inp.zakazi[x].status.length - 1].status_long;
            var shpit_dat2 = how_long.split(' ');
            shpit_dat2 = shpit_dat2[1];
            shpit_dat2 = shpit_dat2.split(':');;
            var how_long_dat = new Date();
            how_long_dat.setHours(shpit_dat2[0], shpit_dat2[1], shpit_dat2[2], 0);

            var current_time = inp.zakazi[x].status[inp.zakazi[x].status.length - 1].data_time;
            var shpit_dat = current_time.split(' ');

            block.innerHTML = " " + shpit_dat[1];


            var now = new Date();
            if (now > how_long_dat)
                block.style.backgroundColor = "red";
            if (inp.zakazi[x].status[inp.zakazi[x].status.length - 1].status == "логист проверил")
                block.style.backgroundColor = "green";

            if ((now > how_long_dat) && (inp.zakazi[x].status[inp.zakazi[x].status.length - 1].status == "логист проверил"))
                delete_zakaz(inp.zakazi[x].id);

            stat_time.appendChild(block);



            
         
            

            block = document.createElement("a");
            block.setAttribute('href', block.href = "/DRIVER_DATA_BASE/option_driver_database?data=" + inp.name);
            block.innerHTML = inp.name;
            block.className = "id_spisok_zak";
            namess.appendChild(block);

            /*
            //координаты
            block = document.createElement("div");
            block.innerHTML = inp.shir;
            block_main.appendChild(block);
            block.className = "line";

            block = document.createElement("div");
            block.innerHTML = inp.dolg;
            block_main.appendChild(block);
            block.className = "line";
             */
            //время обновления координат
            block = document.createElement("div");
            block.innerHTML = inp.data_last_update_coord;
            last_pak.appendChild(block);


            //файлы
            var block2 = document.createElement("div");
            for (let fotki = 0; fotki < inp.zakazi[x].foto.length; fotki++) {
                block = document.createElement("a");
                block.setAttribute('href', block.href = "/FILE/Foto_pokaz?path=" + inp.zakazi[x].foto[fotki]);
                block.innerHTML = "file" + fotki.toString() + "  ";


                block2.appendChild(block);

            }
            

            if (inp.zakazi[x].foto.length == 0) {
                block = document.createElement("div");
                block.innerHTML = "пусто";
                filee.appendChild(block);
            } else {
                filee.appendChild(block2);
            }
           //кнопки
               block = document.createElement("input");
            block.type = "button";
            block.className = "knopki_logist";
            block.value = "логист проверил";
            block.setAttribute("onclick", "logist_chek('" + inp.zakazi[x].id+ "')");
            log_btm.appendChild(block);
            
        }
    }
    static cratko_wodit(name, last_updt) {
        var pp = document.getElementById( "kutieri_upr34234");
      


        var namee = document.createElement("div");
        namee.innerHTML = name;
        pp.appendChild(namee);

        var last_updtt = document.createElement("div");
        last_updtt.innerHTML = last_updt;
        pp.appendChild(last_updtt);
    }
    static clear_kratko() {
        var pp = document.getElementById("kutieri_upr34234");
        if (pp != null) pp.textContent = '';
    }

}


 //поиск координат вывод  ошибки в случае не нахождения
// отрисовка иконок на карте 
/*
данные и частота запроса
1 запрос
какой заказ дочерний кому
2 множество запросов
коордиеаиы статус фото
*/