
 
function logist_chek(phrase) {
    var xhr = new XMLHttpRequest();
    let f = window.location.protocol + "//" + window.location.host + "/dr_contr/site_status_update?paket=" + phrase;
    // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
    xhr.open('GET', f, true);
    dellite_s_karti = true;

    xhr.send();
   update_or_not(phrase, "block_status", "логист проверил", null);
    xhr.onreadystatechange = function () {
        // chek();//нестоит
        if (xhr.readyState != 4) return;
        if (xhr.status != 200) {
            console.log("ОЩИБКА3!!!");
            alert("нет связи с сайтом2 " + xhr.status + ': ' + xhr.statusText); // 
        } else {
            delete_zakaz(phrase);
        }
    }
}

function delete_zakaz(phrase) {
    //logist_chek("закрыт");

    var xhr = new XMLHttpRequest();
    let f = window.location.protocol + "//" + window.location.host + "/dr_contr/delete_zakaz?id=" + phrase;
    // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
    xhr.open('GET', f, true);
   

    xhr.send();
    xhr.onreadystatechange = function () {
        // chek();//нестоит
        if (xhr.readyState != 4) return;
        if (xhr.status != 200) {
            console.log("ОЩИБКА2!!!");
            alert("нет связи с сайтом2 " + xhr.status + ': ' + xhr.statusText); // 
        } else {
          //  zakaz.clear_all_poiuawleniuy_id(phrase);
            
        }
    }
}
//ищу если нахожу заменяю если не нахожу добавляю
 