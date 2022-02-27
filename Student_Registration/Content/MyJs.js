//Remove all content in selected_sub table
$(document).ready(function () {
});
function RmAll() {
   
    $('#selected_sub #gback').each(function () {

        var str_name = $(this).closest("tr").find("#strct_name").val();

        if (str_name == "Required") {
            var id = $(this).closest("tr").find("#gback").val();
            $("#req_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });

            $("#Failed_req_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });

            $("#req_Unregistered_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
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

            $("#te_Failed_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });

            $("#te_Unregistered_tbl").find('tr').each(function (i, el) {
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

            $("#Free_Failed_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });

            $("#fre_Unregistered_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });
        }
    });

    $("#selected_sub").empty();
    $("#tot_ects").text(0);
    $("#msg").text("");
    $("#seper").text("");

    if ($("#selected_sub").children().length <= 0) {
        $("#sbj_selct").prop('disabled', true);
    }
}

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
                }
            });

            $("#Failed_req_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });

            $("#req_Unregistered_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
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

            $("#te_Failed_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });

            $("#te_Unregistered_tbl").find('tr').each(function (i, el) {
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

            $("#Free_Failed_tbl").find('tr').each(function (i, el) {
                var $tds = $(this).find('td');
                if ($tds.eq(4).find("#selct-" + id)) {
                    $($tds.eq(4).find("#selct-" + id)).prop('disabled', false);
                }
            });

            $("#fre_Unregistered_tbl").find('tr').each(function (i, el) {
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
            $("#seper").text("");
            $("#sbj_selct").prop('disabled', false);
        }

        if (val <= 0) {
            $("#msg").text("");
            $("#seper").text("");
            $("#sbj_selct").prop('disabled', true);
        }
    });
}

//Block "sbj_selct" button if table empty on page load & GPA message warning.
document.addEventListener('DOMContentLoaded', function (event) {
    //the event occurred
    
    if ($("#lastGpa").text() <= 6 && $("#lastGpa").text() >= 5) {
        $("#sbj_selct").prop('disabled', true);
        $("#GPAWarning").text("Warning: Last semester GPA is less than 6! Recommended ECTS for current semester is 25!");
    }

    if ($("#lastGpa").text() < 5) {
        $("#sbj_selct").prop('disabled', true);
        $("#GPAWarning").text("Warning: Last semester GPA is less than 5! Recommended ECTS for current semester is 20!");
    }

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

    $("#sbj_selct").prop('disabled', false);

    var count = 0;
    $('#selected_sub .ects_cnt').each(function () {
        count += parseInt($(this).html());
    });

    $("#tot_ects").text(count);

    if (count > 30) {
        $("#seper").text(" - ");
        $("#msg").text("Warning: Exceeded 30 ECTS!");
    }

    if (count <= 30) {
        $("#seper").text("");
        $("#msg").text("");
    }

    if ($("#lastGpa").text() <= 7.5 && $("#lastGpa").text() >= 5 && count >= 25) {
        $("#seper").text(" - ");
        $("#msg").text("Warning: Exceeded 25 ECTS!");
    }

    if ($("#lastGpa").text() < 5 && count >= 20) {
        $("#seper").text(" - ");
        $("#msg").text("Warning: Exceeded 20 ECTS!");
    }
}

