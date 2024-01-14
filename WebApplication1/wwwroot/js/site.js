// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
 

ymaps.ready(init);
var myMap
var count_zapr = 0;
var cheker;
function init() { 
    myMap = new ymaps.Map("map", {
        center: [55.76, 37.64],
        zoom: 10
    }, {
        searchControlProvider: 'yandex#search'
    });

    ustanavlivayu_koordinati();
    //pokaz_magazinow();
    cheker=setInterval(coordinati_polucheni_chek, 1000, "Привет");

}
//setInterval(sayHi, 1000, "Привет", "Джон"); // Привет, Джон
 
 //получаю координаты объектов
var fer
var fer0
var fer1
var fer2
function coordinati_polucheni_chek(kkr) {
    if (count_zapr == fer.length) {
        clearInterval(cheker);
        if (count_nedaidenih != 0) alert("не нашел " + count_nedaidenih + " адресов")
        setInterval(sayHi, 5000, "Привет");
    }
}
function ustanavlivayu_koordinati() {

    fer0 = document.getElementsByClassName('namem'); //имена магазинов
    fer = document.getElementsByClassName('adresa');
    fer1 = document.getElementsByClassName('MAG_D');
    fer2 = document.getElementsByClassName('MAG_H');
    if (fer1.length == 0) return;
    if (fer1[0].value != 0) return;

 get_loc_out_mark(fer, fer1, fer2);
   

}
let count_nedaidenih = 0;
function get_loc_out_mark(lokaciya, inp_massiv_d, inp_massiv_sh) {
 
    for (var s = 0; s < inp_massiv_d.length; s++) {

        var pr = lokaciya[s].value;
        ymaps.geocode(pr, {
            /**
             * Опции запроса
             * see https://api.yandex.ru/maps/doc/jsapi/2.1/ref/reference/geocode.xml
             */
            // Сортировка результатов от центра окна карты.
            // boundedBy: myMap.getBounds(),
            // strictBounds: true,
            // Вместе с опцией boundedBy будет искать строго внутри области, указанной в boundedBy.
            // Если нужен только один результат, экономим трафик пользователей.
            results: 1
        }).then(function (res,) {

            count_zapr++;
            for (var s = 0; s < fer.length; s++) {
                if (fer[s].value == res.metaData.geocoder.request) {
                    var firstGeoObject = res.geoObjects.get(0);
                    if (firstGeoObject == null) count_nedaidenih++;
                    var coords = firstGeoObject.geometry.getCoordinates();
                    fer1[s].value = coords[0];
                    fer2[s].value = coords[1];
                }

                
 

            }

        });
    }
 
}

//отрисовываю магазины
function pokaz_magazinow() {

       
        var fer122 = document.getElementsByClassName('MAG_D2');
        var fer222 = document.getElementsByClassName('MAG_H2');
        var mag_data_count_k = document.getElementsByClassName('mag_data_count_k');
        var mag_data_count_m = document.getElementsByClassName('mag_data_count_m');
       
    

    for (var s = 0; s < fer122.length; s++) {


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

      //  myMap.geoObjects.add(pr);
    }
}

//отрисовываю магазины и заказы
function pokaz_magaz_zakazow() {
    var fer122 = document.getElementsByClassName('MAG_D2');
    var fer222 = document.getElementsByClassName('MAG_H2');
    var mag_data_count_k = document.getElementsByClassName('mag_data_count_k');
    var mag_data_count_m = document.getElementsByClassName('mag_data_count_m');

    var magaz_inner_dat = document.getElementsByClassName('magaz_inner_dat');

    //отрисовываю магазины у которых открыто описание
    for (var s = 0; s < fer122.length; s++) {

        var atr = magaz_inner_dat[s].getAttribute("hidden");
        if (atr != "hidden") {
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
                var MAG_D2 = document.getElementsByClassName(dd);
                var MAG_H2 = document.getElementsByClassName(hh);
                myMap.geoObjects.add(new ymaps.Placemark([MAG_D2[0].value, MAG_H2[0].value], { iconCaption: zakazi[x]}));

            }

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

            myMap.geoObjects.add(pr);
        }
    }


   



}

//отрисовываю курьеров

function pokaz_kurierow() {
    var woditeli_wsee = document.getElementById("woditeli_wsee");
 
    var atr = woditeli_wsee.getAttribute("hidden");
    if (atr != "hidden") {
        var name = document.getElementsByClassName('name_kuriera_322');
        var dolgota = document.getElementsByClassName('dolg');
        var shirota = document.getElementsByClassName('shir');

        for (var s = 0; s < shirota.length; s++) {

            myMap.geoObjects.add(new ymaps.Placemark([shirota[s].innerHTML, dolgota[s].innerHTML], { iconCaption: name[s].innerHTML }));


        }
    }
}
//создаю кнопки с имянами  курьеров работает отлично
class pak {
     
    constructor(zakaz, curier,zabral) {
        this.zakaz = zakaz;
        this.curier = curier;
        this.zabral = zabral
      
    }

    toString() {
        var ret = `{"zakaz": "${this.zakaz}", "curier": "${this.curier}", "zabral": "${this.zabral}"}`;

        return ret;
    }
}
function add_botom_kureri(element) {
    //если есть кнопки курьеров то выхожу
    if (find_botom_kureri(element)) return;

    var zakaz = document.getElementById(element);
    //вставляю кнопки перед вторым элементом списка
    var first = zakaz.childNodes[2];
    var kurieri = document.getElementsByClassName("name_kuriera_322");


    for (var x = 0; x < kurieri.length; x++) {

        var new_kurier = document.createElement("button");
        new_kurier.innerHTML = kurieri[x].innerHTML;
        new_kurier.className = "wremenniy_kyrier";
        //слушатель на кнопке курьера
        new_kurier.addEventListener("click", send_and_dell.bind(null,element, new_kurier.innerHTML));
        zakaz.insertBefore(new_kurier, first);
    }

}

//проверяю имеются ли курьеры 
function find_botom_kureri(element) {
    
    var zakaz = document.getElementById(element);
    var zakaz_child = zakaz.childNodes;
    for (var x = 0; x < zakaz_child.length; x++) {
        if ("wremenniy_kyrier" == zakaz_child[x].className)
            return true;
    }
    return false;
}

//удаляю всех курьеров  //отправляю!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
function dell_all_botom_kureri(element, e) {

    while (true) {
        var powt = false;
        var zakaz = document.getElementById(element);
        var zakaz_child = zakaz.childNodes;
        for (var x = 0; x < zakaz_child.length; x++) {
            if ("wremenniy_kyrier" == zakaz_child[x].className) {
                zakaz_child[x].remove();
                powt = true;
                break;
            }

        }
        if (!powt) break;
    }
    let pa = new pak(element,"",true);
    sayHi(pa);
    document.getElementById(element +"zakazi_kur").remove();
}
//удаляю всех курьеров кроме выбранного
//elem отцовское окно name курьер которого не надо удалять
function dell_botom_kureri(element, name, e) {

    var zakaz = document.getElementById(element);
    var zakaz_child = zakaz.childNodes;
    for (var x = 0; x < zakaz_child.length; x++) {
        if ("wremenniy_kyrier" == zakaz_child[x].className)
            if (zakaz_child[x].innerHTML != name)
            zakaz_child[x].remove();

    }
}
//отправляю заказ и их курьеров!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
function send_zabranie_magaz(element) {

    //пакет
    var pk;
  
    var zakaz = document.getElementById(element);
    var zakaz_child = zakaz.childNodes;
    for (var x = 0; x < zakaz_child.length; x++) {
        if ("wremenniy_kyrier" == zakaz_child[x].className) {
             pk = new pak(element, zakaz_child[x].innerHTML,false);
            
        }
    }

    sayHi(pk.toString());
}

function send_and_dell(element, name) {
    dell_botom_kureri(element, name);
    send_zabranie_magaz(element);

}