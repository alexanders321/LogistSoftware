 
function show_hide(a) {
     
   // alert(a);
    var d = document.getElementById(a);
    var atr = d.getAttribute("hidden");

    if (atr == "hidden") {
        d.removeAttribute("hidden");
        //тут же отрисовываю точки на карте
    }
    else {
        d.setAttribute("hidden", "hidden");
        //удаляю точки на карте 
    }
    

}