/* When the user clicks on the button,
    toggle between hiding and showing the dropdown content */
function filters(option) {
    console.log(option.innerText)
    options = $('#select_structure')[0].selectize.options;
    console.log(options)
    var cnt = 0;
    for (k in options) {
        cnt++;
        console.log(k);
    }
   
    /*if (option.innerText == "Computer Science ssss") {
        select = document.getElementById("select_structure").options.length;
        //structOptions = select.getElementsByTagName("option");
        console.log($('#select_structure option').size());
        for (var i = 0; i < structOptions.length; i++) {
            optionVal = structOptions[i].getElementById;
            if (optionVal == option.innerText) {
                structOptions[i].style.display = "";
            }

            else {
                structOptions[i].style.display = "none";
            }
        }
    }

    else if (option.innerText == "Computer Engineering") {
        select = document.getElementById("select_structure");
        structOptions = select.getElementsByTagName("option");

        for (var i = 0; i < structOptions.length; i++) {
            optionVal = structOptions[i].getElementById;
            if (optionVal == option.innerText) {
                structOptions[i].style.display = "";
            }

            else {
                structOptions[i].style.display = "none";
            }
        }
    }

    else if (option.innerText == "All" || option.innerText == "") {
        select = document.getElementById("select_structure");
        structOptions = select.getElementsByTagName("option");

        for (var i = 0; i < structOptions.length; i++) {
            optionVal = structOptions[i].getElementById;
            structOptions[i].style.display = "";
        }
    }*/
}

