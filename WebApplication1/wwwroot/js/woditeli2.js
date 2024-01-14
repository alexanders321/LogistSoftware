// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let audio = new Audio('https://zvukipro.com/uploads/files/2020-07/1594182502_6a9eda36651d8d7.mp3');
var once = true;
var once2 = false;
var once3 = true;
var last;
var last2;
var dellite_s_karti = false;
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
            console.log("ОЩИБКА1!!!");
          //  alert("нет связи с сайтом1 " + xhr.status + ': ' + xhr.statusText); // 
        } else {
            console.log("отрисовка магазинов");
           


            manager_packet.zakaz();
            const obj2 = JSON.parse(xhr.responseText);
            maket(obj2);
            napoln(obj2);
        
            stilizaciya(obj2);
            for (let ffeg = 0; ffeg < obj2.length; ffeg++) {
                if (obj2.length != 0) {
                    console.log("отрисовка курьеров");
                    // var kur = new kurier(obj2[0].id, "" + (55.56), obj2[0].dolg);
                    kur = new kurier(obj2[ffeg].name, obj2[ffeg].shir, obj2[ffeg].dolg, obj2[ffeg].data_last_update_coord);
                    kur = kur.add_in_pull();//вернёт ссылку если объект уже существовал


                    if (once) {

                        for (let x = 0; x < obj2[ffeg].zakazi.length; x++) {
                            var zak = new zakaz(obj2[ffeg].zakazi[x].id, 0, 0, 0, 0, obj2[ffeg].zakazi[x].status[obj2[ffeg].zakazi[x].status.length - 1].status);
                            console.log("отрисовка заказов у кур");
                            zak = zak.add_in_pull();
                            if (zak != null) {
                                zak.clear_all_poiuawleniuy();
                                kur.add_doch(zak);
                            }
                        }
                    }
                }
            }


            once = false;

        }
    
        
    }

}

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
        for (let x = 0; x < kurier.pull_cur.length; x++) {
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
            geobase.pull_cur[index].shir = this.shir;
            geobase.pull_cur[index].dolg = this.dolg;
            this.update_loc_map();
            return false;
        } else {
            //добавление
            geobase.pull_cur.push(this);

            this.index2 = geobase.pull_cur.length-1;

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
    static hide_all_zak() {
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
        if (this.pull_zakazow.length == 0) return 0;
        else
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

        if (0== super.del_doch(zakazec)) {
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
        super.add_in_pull()
         

            geobase.pull_cur[this.index2].data_last_update_coord = this.data_last_update_coord;
            return geobase.pull_cur[this.index2];
        
    }

    mag_pl() {

    }

    static dell_all_doch() {
        if (this.target == null) {
            alert("не выбран курьер");
            return;
        }
        dellite_s_karti = false;

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
class zakaz extends geobase {
    constructor(id, shir, dolg, father, kbt_li, status) {
        var color;
        if (kbt_li == "False") color = "#008000";
        else color = "#ff0000";

        var mark = new ymaps.Placemark([shir, dolg], {

            iconCaption: id, hui: "4234"
        }, {

            // Зададим произвольный макет метки.
            //  preset: 'islands#redCircleDotIcon', метка для заказа оплаченного
            preset: 'islands#blueCircleIcon',
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
    static dokidiway(id_cur, zakaz) {
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
                    && geobase.pull_cur[x].show) geobase.pull_cur[x].show_on_map();
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
 //поиск координат вывод  ошибки в случае не нахождения
// отрисовка иконок на карте 
/*
данные и частота запроса
1 запрос
какой заказ дочерний кому
2 множество запросов
коордиеаиы статус фото
*/
//удаляю марки с карты
function chek_remuve(id) {
    var vse_zakazi = document.getElementsByClassName("wse_zakazi_u_kur");
    if (vse_zakazi != null) {
        
        var new_pull = new Array();
        new_pull.push(id);
         


            //ищет номер  лишнего элемента и удаляет его потом
            for (let x = 0; x < vse_zakazi.length; x++) {
                var nashel = false;
                for (let xx = 0; xx < new_pull.length; xx++) {
               
                    if (vse_zakazi[x].innerHTML == new_pull[xx]) nashel= true;
                   
                }
                if (!nashel) {
                    zakaz.clear_all_poiuawleniuy_id(vse_zakazi[x].innerHTML);
                    remuve_or_not(vse_zakazi[x].innerHTML);
                }
            }

        
    }
}
//удаляю из списка
function chek_remuve_spis(obj2) {
    var vse_zakazi = document.getElementsByClassName("wse_zakazi_u_kur");
    if (vse_zakazi != null) {

        var new_pull = new Array();
        for (let ffeg = 0; ffeg < obj2.length; ffeg++) {



            for (let x = 0; x < obj2[ffeg].zakazi.length; x++) {

                new_pull.push(obj2[ffeg].zakazi[x].id);

            }
        }
        if (vse_zakazi.length > new_pull.length) {

            //ищет номер  лишнего элемента и удаляет его потом
            for (let x = 0; x < vse_zakazi.length; x++) {
                var nashel = false;
                for (let xx = 0; xx < new_pull.length; xx++) {

                    if (vse_zakazi[x].innerHTML == new_pull[xx]) {
                        nashel = true;
                        break;
                    }
                }
                if (!nashel) {
                    if(dellite_s_karti)
                    zakaz.clear_all_poiuawleniuy_id(vse_zakazi[x].innerHTML);
                    remuve_or_not(vse_zakazi[x].innerHTML);
                   
                }
            }

        }
    }
}
//удаляет или нет
function remuve_or_not(id) {

    var elem = Array();
    elem.push(document.getElementById(id + "id"));
    elem.push(document.getElementById(id + "name_dr"));
    elem.push(document.getElementById(id + "button"));
    elem.push(document.getElementById(id + "block_status"));
    elem.push(document.getElementById(id + "block_status"));
    elem.push(document.getElementById(id + "block_end_stat"));
    elem.push(document.getElementById(id + "block_last_update"));
    elem.push(document.getElementById(id + "FILE_pull"));
    elem.push(document.getElementById(id + "button_pull"));

    for (let x = 0; x < elem.length; x++) {
        if (elem[x] != null) {

            elem[x].remove();
        }
    }
   
}
//создаёт блок или не делает ни чего
function create_or_not_button(id, block_name,  apper_block) {

    var elem = document.getElementById(id + block_name);
    if (elem == null) {
       var  block = document.createElement("input");
        block.type = "button";
        block.className = "knopki_logist";
        
       

         
        block.setAttribute("hidden", "hidden");
        block.id = id + block_name;
        block.value = "логист проверил";
        block.setAttribute("onclick", "logist_chek('" + id + "')");
        apper_block.appendChild(block);
    }
}
function create_or_not(id, block_name, text,apper_block) {

    var elem = document.getElementById(id + block_name);
    if (elem == null) {
        var block_main = document.createElement("a");
       
     
        block_main.id = id + block_name;
        if (block_name == "id") {
            block_main.className = "wse_zakazi_u_kur";
            block_main.setAttribute('href', block_main.href = "/HISTORY/formated_history/" + text);
            block_main.setAttribute('target', block_main.target = "_blank" );
        }
        if (block_name == "name_dr") {
            block_main.setAttribute('target', block_main.target = "_blank");
            block_main.setAttribute('href', block_main.href = "/DRIVER_DATA_BASE/option_driver_database?data=" + text);
        }
        if (block_name != "id") block_main.className = "wse_zakazi_u_kur2313";

        if (block_name == "block_end_stat") block_main.setAttribute("hidden", "hidden");;

        block_main.innerHTML = text;
        apper_block.appendChild(block_main);
    }
}

function create_or_not_file(id, block_name, text, apper_block) {

    var elem = document.getElementById(id + block_name);
    if (elem == null) {

     


        var  block = document.createElement("a");
        block.setAttribute('href', block.href = "/FILE/Foto_pokaz?path=" + text);
        block.innerHTML = block_name + "  ";
        block.setAttribute('target', block.target = "_blank");
        block.id = id + block_name;
        block.className = "line" ;

        apper_block.appendChild(block);
    }
}
//обновляет блок
function update_or_not(id, block_name, text, apper_block) {

    var elem = document.getElementById(id + block_name);
    //обновляю если нашел и создаю если ненашел
    if (elem != null) {

        elem.innerHTML = text;

    } else {
        if (apper_block != null)
        create_or_not(id, block_name, text, apper_block);
    }
}

 

//класс создаёт таблицу из н блоков 
function maket(obj2) {
    //проверка на необходимость удаление объекта!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 chek_remuve_spis(obj2);


    //блок с водителями
   
    var block_id = document.getElementById("block_id");
    var block_but = document.getElementById("block_but");
    var block_file = document.getElementById("block_file");
   
    for (let ffeg = 0; ffeg < obj2.length; ffeg++) {

        

        for (let x = 0; x < obj2[ffeg].zakazi.length; x++) {
          
           //блок id
            create_or_not(obj2[ffeg].zakazi[x].id, "id", obj2[ffeg].zakazi[x].id, block_id);
            //блок имя
         






            var elem2 = document.getElementById(obj2[ffeg].zakazi[x].id + "button_pull");
            if (elem2 == null) {

                var block_main = document.createElement("div");
                block_main.id = obj2[ffeg].zakazi[x].id + "button_pull";
                block_main.className = "fileeee";
                block_but.appendChild(block_main);
                create_or_not_button(obj2[ffeg].zakazi[x].id, "button", block_main);
            } else {
                create_or_not_button(obj2[ffeg].zakazi[x].id, "button", elem2);
            }
            
            //ОТРИСОВЫВАЮ ФАЙЛЫ







            var elem = document.getElementById(obj2[ffeg].zakazi[x].id + "FILE_pull");
            if (elem == null) {

                var block_main = document.createElement("div");
                block_main.id = obj2[ffeg].zakazi[x].id + "FILE_pull";
                block_main.className = "fileeee";
                block_file.appendChild(block_main);
            } else {
                for (let fotki = 0; fotki < obj2[ffeg].zakazi[x].foto.length; fotki++) {

                    create_or_not_file(obj2[ffeg].zakazi[x].id, "file" + fotki, obj2[ffeg].zakazi[x].foto[fotki], elem);


                }
            }

          
           
        }
    }

}
function napoln(obj2) {
    //блок с водителями
    var block_status = document.getElementById("block_status");
    var block_end_stat = document.getElementById("block_end_stat");
    var block_last_update = document.getElementById("block_last_update");
    var block_name = document.getElementById("block_name");
    for (let ffeg = 0; ffeg < obj2.length; ffeg++) {



        for (let x = 0; x < obj2[ffeg].zakazi.length; x++) {

            update_or_not(obj2[ffeg].zakazi[x].id, "name_dr", obj2[ffeg].name, block_name);
            update_or_not(obj2[ffeg].zakazi[x].id, "block_status", obj2[ffeg].zakazi[x].status[obj2[ffeg].zakazi[x].status.length - 1].status, block_status);
            update_or_not(obj2[ffeg].zakazi[x].id, "block_end_stat", obj2[ffeg].zakazi[x].status[obj2[ffeg].zakazi[x].status.length - 1].status_long, block_end_stat);
            update_or_not(obj2[ffeg].zakazi[x].id, "block_last_update", obj2[ffeg].data_last_update_coord, block_last_update);
            //create_or_not(obj2[ffeg].zakazi[x].id, "block_file", obj2[ffeg]., block_file);
        }
    }
}
function stilizaciya(obj2) {

    for (let ffeg = 0; ffeg < obj2.length; ffeg++) {

        for (let x = 0; x < obj2[ffeg].zakazi.length; x++) {

            //удаляю если логист проверил
            var block_status = document.getElementById(obj2[ffeg].zakazi[x].id + "block_status");
       //     if (block_status.innerHTML == "логист проверил") delete_zakaz(obj2[ffeg].zakazi[x].id);
             
            var block_but = document.getElementById(obj2[ffeg].zakazi[x].id + "button");
            pokaz_knopki(block_status.innerHTML, block_but);


            //подкраска если выбивается из интервала
            var how_long = obj2[ffeg].zakazi[x].status[obj2[ffeg].zakazi[x].status.length - 1].status_long;
            var shpit_dat2 = how_long.split(' ');
            shpit_dat2 = shpit_dat2[1];
            shpit_dat2 = shpit_dat2.split(':');;
            var how_long_dat = new Date();
            how_long_dat.setHours(shpit_dat2[0], shpit_dat2[1], shpit_dat2[2], 0);

            var current_time = obj2[ffeg].zakazi[x].status[obj2[ffeg].zakazi[x].status.length - 1].data_time;
            var shpit_dat = current_time.split(' ');

            var now = new Date();
            if (now > how_long_dat) {
                if ((block_status.innerHTML == "в магазине") ||
                    (block_status.innerHTML == "курьер забрал заказ")||
                    (block_status.innerHTML == "доставил")
                )
                block_status.style.backgroundColor = "red";

            }
            else block_status.style.backgroundColor = "cornflowerblue";
          //  if (obj2[ffeg].zakazi[x].status[obj2[ffeg].zakazi[x].status.length - 1].status == "логист проверил")
               // block_status.style.backgroundColor = "green";
        }
    }
    //
   
}

function chek_status(status) {
    switch (status) {
        case "не выдал магазин": return true;
        case "доставил": return true;
        case "недоставлен недозвон": return true;
        case "недоставлен отказ клиента": return true;
        case "недоставлен вне зоны": return true;
        case "недоставлен перенос клиентом": return true;
        case "недоставлен другая причина": return true;
        case "недоставлен курьер не успел": return true;
        default: return false;
    }
}
function pokaz_knopki(status, block_but) {

    var atr = block_but.getAttribute("hidden");
    if (chek_status(status)) {


        if (atr == "hidden") {

            block_but.removeAttribute("hidden");

        } 
    }
}








function log_dell_zakaz(obj2) {

    var pull_zak = new Array();
    for (let ffeg = 0; ffeg < obj2.length; ffeg++) {



        for (let x = 0; x < obj2[ffeg].zakazi.length; x++) {

            pull_zak.push(obj2[ffeg].zakazi[x]);

        }
    }

    myMap.geoObjects.each(function (geoObject) {
        var nashel;

        for (let x = 0; x < pull_zak.length; x++) {

            if (geoObject.properties._data.iconCaption == pull_zak[x].id) {
                nashel = pull_zak[x]; break;
            }
        }

        if (nashel != null) zakaz.clear_all_poiuawleniuy_id(nashel.id);
    });
        
   }



/*

//макет 
пробегаю по всем заказам и формирую неизменяемые данные
id
имя
проверил логист
//наполнение
заполняю изменяемые поля
статус
окончание статуса
последнее обновление
файлы
//форматирование
изменяю стиль в зависимости от нужды
подкрашевание красным
сокрытие кнопки логист проверил
*/