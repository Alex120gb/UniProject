/* When the user clicks on the button,
    toggle between hiding and showing the dropdown content */


function filters(option) {

    //console.log(option.innerText);
    var choosen = option.innerText;
    filter = choosen.toUpperCase();

    
    var table, tr, i;
    table = document.getElementById("s_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td2 = tr[i].getElementsByTagName("td")[4];
        //td3 = tr[i].getElementsByTagName("td")[4];

        if (td2) {
            if (td2.innerHTML.toUpperCase().indexOf(filter) > -1) {
                $(tr[i]).show();
            } else {
                $(tr[i]).hide();
            }

            if (filter == "ALL") {
                $(tr[i]).show();
            }
        }
        
    }
}

