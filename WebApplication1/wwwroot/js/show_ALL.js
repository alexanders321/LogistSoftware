 
function show_ALL() {
     
    // alert(a);
    var d = document.getElementsByClassName("zakazi2435235");
    for (let x = 0; x < d.length; x++) { 
      
            d[x].removeAttribute("hidden");
            //тут же отрисовываю точки на карте
         
        
    }
    var d3 = document.getElementsByClassName("uproshayu333");
    for (let x = 0; x < d3.length; x++) {

        d3[x].removeAttribute("hidden");
        //тут же отрисовываю точки на карте


    }

    var d2 = document.getElementsByClassName("uproshayu332");
    for (let x = 0; x < d2.length; x++) {


        d2[x].setAttribute("hidden", "hidden");
        //удаляю точки на карте 

    }
 
}
function hide_ALL() {

    // alert(a);
    var d = document.getElementsByClassName("zakazi2435235");
    for (let x = 0; x < d.length; x++) { 
         

        d[x].setAttribute("hidden", "hidden");
        //удаляю точки на карте 

    }
    var d2 = document.getElementsByClassName("uproshayu332");
    for (let x = 0; x < d2.length; x++) {

        d2[x].removeAttribute("hidden");
        //тут же отрисовываю точки на карте


    }

    var d3 = document.getElementsByClassName("uproshayu333");
    for (let x = 0; x < d3.length; x++) {

        d3[x].setAttribute("hidden", "hidden");
        //тут же отрисовываю точки на карте


    }



   
    
}