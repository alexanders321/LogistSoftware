ymaps.ready(init);
 
function init() {
  
 

    var pp = [[44.77751]];
    pp.pop();
 

    var fer0 = document.getElementsByClassName('dolg434');
    var fer1 = document.getElementsByClassName('shir232');

    //определяю зум
 
     
    if (fer0.length != 0) {
        myMap = new ymaps.Map("map2", {
            center: [parseFloat(fer1[0].innerHTML), parseFloat(fer0[0].innerHTML)],
            zoom: 10
        }, {
            searchControlProvider: 'yandex#search'
        });
    } else {
        myMap = new ymaps.Map("map2", {
            center: [55.76, 37.64],
            zoom: 10
        }, {
            searchControlProvider: 'yandex#search'
        });
    }



    for (let x = 0; x < fer0.length; x++) {
        pp.push([parseFloat(fer1[x].innerHTML), parseFloat(fer0[x].innerHTML)]);
    }
    var myPolyline = new ymaps.GeoObject({
        geometry: {
            type: "LineString",
            coordinates: pp
        }
    });

    // Добавляем линии на карту.
    myMap.geoObjects
        .add(myPolyline);


    begunok_setup();
}


var fer0

function begunok_setup() {
    fer0 = document.getElementsByClassName('data24214');
    var start = document.getElementById("start");

    var end = document.getElementById("end");
    start.innerHTML = fer0[0].innerHTML;

    end.innerHTML = fer0[fer0.length - 1].innerHTML;


    var begunok = document.getElementById("progressbr_21");
    begunok.setAttribute("max", fer0.length);
}
function on_change(fef) {
    
    var target = document.getElementById("target");
    target.innerHTML = fer0[fef.value].innerHTML;

    var geoObject_;
    myMap.geoObjects.each(function (geoObject) {
        if (geoObject.properties._data.iconCaption == "курьер") {
            geoObject_ = geoObject;
        }

       
    });



    var dolgota = document.getElementsByClassName('shir232');
    var shirota =  document.getElementsByClassName('dolg434');

    var data = [parseFloat(dolgota[fef.value].innerHTML), parseFloat(shirota[fef.value].innerHTML)];
    if (geoObject_ != null) {

        geoObject_.geometry.setCoordinates(data);
    } else {
      

        var mark = new ymaps.Placemark(data, {
            data: [

                { weight: 1, color: '#9400d3' },
                { weight: 0, color: '#ff0000' }
            ],
            iconCaption: "курьер"
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
        myMap.geoObjects.add(mark);
    }
}