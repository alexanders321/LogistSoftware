
document.onload(inicjj());
function sss(iii) {
    var dd = document.getElementsByClassName("data");
    //получаю все заказы с указаной датой
    for (let x = 0; x < dd.length; x++) {

        var all = document.getElementsByClassName(iii+" "+dd[x].id );
        //сортирую по разделу
        var count = 0;
        for (let z = 0; z < all.length; z++) {

            count = count + Number(all[z].innerHTML);
        }

        var met = document.getElementsByClassName(iii+"_d" + " " + dd[x].id);

        met[0].innerHTML = count;

    }
}
function sss2(iii) {
    var dd = document.getElementsByClassName("data");
    //получаю все заказы с указаной датой
    for (let x = 0; x < dd.length; x++) {

        //получаю все магазины с заданной датой 
        var all2 = document.getElementsByClassName("market_master" + " " + dd[x].id);
        for (let f = 0; f < all2.length; f++) {


            var all = document.getElementsByClassName(iii + " " + dd[x].id + " " + all2[f].innerHTML);
            //сортирую по разделу
            var count = 0;
            for (let z = 0; z < all.length; z++) {

                count = count + Number(all[z].innerHTML);
            }

            var met = document.getElementsByClassName(iii + "_m" + " " + dd[x].id + " " + all2[f].innerHTML);

            met[0].innerHTML = count;
        }

    }
}


function inicjj() {
   
    sss("dostaw");
    sss("nalogka");
    sss("nedozwon");
    sss("ne_widal");
    sss("obshee_count");
    sss("oplachen");
    sss("org");
    sss("otkaz");
    sss("roznica");
    sss("wne_zoni");
    sss("kbt");
    sss("mbt");
    
    sss2("dostaw");
    sss2("nalogka");
    sss2("nedozwon");
    sss2("ne_widal");
    sss2("obshee_count");
    sss2("oplachen");
    sss2("org");
    sss2("otkaz");
    sss2("roznica");
    sss2("wne_zoni");
    sss2("kbt");
    sss2("mbt");

}

function ttest() {
    alert("fdf");
}


function show_hide_MA(a,data) {

    // alert(a);
    var d = document.getElementsByClassName(a + " " + data);
    for (let x = 0; x < d.length; x++) {
        var atr = d[x].getAttribute("hidden");

        if (atr == "hidden") {
            d[x].removeAttribute("hidden");
            //тут же отрисовываю точки на карте
        }
        else {
            d[x].setAttribute("hidden", "hidden");
            //удаляю точки на карте 
        }
    }
    _hide_MA2("z", a);
}

function show_hide_MA2(a, data,mag) {

    // alert(a);
    var d = document.getElementsByClassName(a + " " + data + " " + mag);
    for (let x = 0; x < d.length; x++) {
        var atr = d[x].getAttribute("hidden");

        if (atr == "hidden") {
            d[x].removeAttribute("hidden");
            //тут же отрисовываю точки на карте
        }
        else {
            d[x].setAttribute("hidden", "hidden");
            //удаляю точки на карте 
        }
    }

}

function _hide_MA2(a, data) {

    // alert(a);
    var d = document.getElementsByClassName(a + " " + data );
    for (let x = 0; x < d.length; x++) {
        

          
            d[x].setAttribute("hidden", "hidden");
            //удаляю точки на карте 
        
    }

}