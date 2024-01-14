



setInterval(sayHi, 1000, "Привет");
var last_packet;
function sayHi(phrase) {
    var xhr = new XMLHttpRequest();
    let f = window.location.protocol + "//" + window.location.host + "/WORK2/data_out?paket=" + phrase;
    // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
    xhr.open('GET', f, false);


    xhr.send();
    // chek();//нестоит

    if (xhr.status != 200) {

        alert("нет связи с сайтом " + xhr.status + ': ' + xhr.statusText); // 
    } else {
        var packet;
        if (packet == null) packet = new Array();
        const obj2 = JSON.parse(xhr.responseText);

        for (var mag in obj2) {

            packet.push(JSON.parse(obj2[mag]));
        }

        for (var mag in packet[0]) {

            var fe = packet[0][mag];
            let feht = 54;
        }
    }
}

//ищу если нахожу заменяю если не нахожу добавляю
function find() {

}