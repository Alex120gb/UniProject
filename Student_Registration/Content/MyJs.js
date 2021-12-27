//Remove unwanted rows from selected_sub table
function removeRow() {
    var val = parseInt($("#tot_ects").html());
    $("#selected_sub").on("click", "#rm_row", function () {

        var str_name = $(this).closest("tr").find("#strct_name").val();

        if (str_name == "Required") {
            var id = $(this).closest("tr").find("#gback").val();
            $("#req_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                    console.log(id);
                }
            });
        }

        if (str_name == "Technical Electives") {
            var id = $(this).closest("tr").find("#gback").val();
            $("#te_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });
        }

        if (str_name == "Free Electives") {
            var id = $(this).closest("tr").find("#gback").val();
            $("#fre_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });
        }

        val -= parseInt($(this).closest("tr").find(".ects_cnt").html());
        $(this).closest("tr").remove();
        $("#tot_ects").text(val);

        if (val <= 30) {
            $("#msg").text("");
            $("#sbj_selct").prop('disabled', false);
        }

        if (val <= 0) {
            $("#msg").text("");
            $("#sbj_selct").prop('disabled', true);
        }
    });
}

//Block "sbj_selct" button if table empty
document.addEventListener('DOMContentLoaded', function (event) {
    //the event occurred

    if ($("#selected_sub").children().length <= 0) {
        $("#sbj_selct").prop('disabled', true);
    }
});

function rmSe() {
    var btnValue = $('form#form0').data("unobtrusiveAjaxClick")[0].value;
    $("#" + btnValue).closest("tr").find("#selct-" + btnValue).prop('disabled', true);
}

//Appends the selected_sub table
function jsfunction(ajaxContext) {

    //ajaxContext contains the responseText
    $("#selected_sub").append(ajaxContext);


    var count = 0;
    $('#selected_sub .ects_cnt').each(function () {
        count += parseInt($(this).html());
    });

    $("#tot_ects").text(count);

    if (count > 30) {
        $("#msg").text("ECTS limit reached. Please remove one or more subjects.")
        $("#sbj_selct").prop('disabled', true);
    }

    if (count <= 30) {
        $("#msg").text("");
        $("#sbj_selct").prop('disabled', false);
    }
}


/* When the user clicks on the button,
    toggle between hiding and showing the dropdown content */
function myFunctionR(btn) {
    document.getElementById("myDropdown_R").classList.toggle("show");
    var property = document.getElementById(btn);
    var vl = parseInt(property.value);
    
    if (vl == 0) {
        document.querySelector("#ImgReq").style.transform = "rotate(0deg)";
        property.style.backgroundColor = "#6c757d";
        property.style.borderColor = "#6c757d";
        property.value = "1";
    }

    if (vl == 1) {
        document.querySelector("#ImgReq").style.transform = "rotate(180deg)";
        property.style.backgroundColor = "#0d6efd";
        property.style.borderColor = "#0d6efd";
        property.value = "0";
    }
}

function myFunctionT(btn) {
    document.getElementById("myDropdown_T").classList.toggle("show");

    var property = document.getElementById(btn);
    var vl = property.value;

    if (vl == 0) {
        document.querySelector("#ImgTech").style.transform = "rotate(0deg)";
        property.style.backgroundColor = "#6c757d";
        property.style.borderColor = "#6c757d";
        property.value = 1;
    }

    if (vl == 1) {
        document.querySelector("#ImgTech").style.transform = "rotate(180deg)";
        property.style.backgroundColor = "#0d6efd";
        property.style.borderColor = "#0d6efd";
        property.value = 0;
    }
}

function myFunctionF(btn) {
    document.getElementById("myDropdown_F").classList.toggle("show");

    var property = document.getElementById(btn);
    var vl = property.value;

    if (vl == 0) {
        document.querySelector("#ImgFree").style.transform = "rotate(0deg)";
        property.style.backgroundColor = "#6c757d";
        property.style.borderColor = "#6c757d";
        property.value = 1;
    }

    if (vl == 1) {
        document.querySelector("#ImgFree").style.transform = "rotate(180deg)";
        property.style.backgroundColor = "#0d6efd";
        property.style.borderColor = "#0d6efd";
        property.value = 0;
    }
}

// Close the dropdown if the user clicks outside of it
window.onclick = function (event) {
    if (event.target.matches('#reqClose')) {
        document.getElementById("myDropdown_R").classList.toggle("show");
        var btn = document.getElementById("dropdownMenuButton1");
        var value = btn.value;
        if (value == 0) {
            document.querySelector("#ImgReq").style.transform = "rotate(0deg)";
            btn.style.backgroundColor = "#6c757d";
            btn.style.borderColor = "#6c757d";
            btn.value = 1;
        }
        if (value == 1) {
            document.querySelector("#ImgReq").style.transform = "rotate(180deg)";
            btn.style.backgroundColor = "#0d6efd";
            btn.style.borderColor = "#0d6efd";
            btn.value = 0;
        }
    }

    if (event.target.matches('#techClose')) {
        document.getElementById("myDropdown_T").classList.toggle("show");

        var btn = document.getElementById("dropdownMenuButton2");
        var value = btn.value;
        if (value == 0) {
            document.querySelector("#ImgTech").style.transform = "rotate(0deg)";
            btn.style.backgroundColor = "#6c757d";
            btn.style.borderColor = "#6c757d";
            btn.value = 1;
        }
        if (value == 1) {
            document.querySelector("#ImgTech").style.transform = "rotate(180deg)";
            btn.style.backgroundColor = "#0d6efd";
            btn.style.borderColor = "#0d6efd";
            btn.value = 0;
        }
    }

    if (event.target.matches('#freeClose')) {
        document.getElementById("myDropdown_F").classList.toggle("show");

        var btn = document.getElementById("dropdownMenuButton3");
        var value = parseInt(btn.value);
        if (value == 0) {
            document.querySelector("#ImgFree").style.transform = "rotate(0deg)";
            btn.style.backgroundColor = "#6c757d";
            btn.style.borderColor = "#6c757d";
            btn.value = "1";
        }
        if (value == 1) {
            document.querySelector("#ImgFree").style.transform = "rotate(180deg)";
            btn.style.backgroundColor = "#0d6efd";
            btn.style.borderColor = "#0d6efd";
            btn.value = "0";
        }
    }
}


