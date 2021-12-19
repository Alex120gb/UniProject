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
function myFunctionR() {
    document.getElementById("myDropdown_R").classList.toggle("show");
}

function myFunctionT() {
    document.getElementById("myDropdown_T").classList.toggle("show");
}

function myFunctionF() {
    document.getElementById("myDropdown_F").classList.toggle("show");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function (event) {
    if (event.target.matches('#reqClose')) {
        document.getElementById("myDropdown_R").classList.toggle("show");
    }

    if (event.target.matches('#techClose')) {
        document.getElementById("myDropdown_T").classList.toggle("show");
    }

    if (event.target.matches('#freeClose')) {
        document.getElementById("myDropdown_F").classList.toggle("show");
    }
}


