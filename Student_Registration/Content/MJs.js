$(document).ready(function () {
    $('select').selectize({
        sortField: 'text'
    });
});

function goBack() {
    window.location.replace("https://localhost:44398/Home/Index");
    // window.location.href = "../RegisterSubs/RegisterSubjects.cshtml";
}
function message() {
    alert("An excel file will be downloaded containing the Student's selected subjects.");
}

function Decline() {
    var st = $("#cancel").val();
    window.location.replace("https://localhost:44398/RegisterSubs/RegisterSubjects?stud=" + encodeURIComponent(st));
}

function searchST() {
    var input, filter, table, tr, td, i;
    input = document.getElementById("srch_box");
    filter = input.value.toUpperCase();
    table = document.getElementById("s_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        td3 = tr[i].getElementsByTagName("td")[2];
        var x = $("#srch_box").val();
        var regex = /^[a-zA-Z]+$/;
        if (!x.match(regex)) {
            td = tr[i].getElementsByTagName("td")[0];
        }
        if (td1 || td2 || td3) {
            if (td1.innerHTML.toUpperCase().indexOf(filter) > -1 || td2.innerHTML.toUpperCase().indexOf(filter) > -1 || td3.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

//For Required subjects
function searchSB_REQ() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_boxREQ");
    filter = input.value.toUpperCase();
    table = document.getElementById("req_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_boxREQ").val();
        var regex = /^[a-zA-Z]+$/;
        if (!x.match(regex)) {
            td = tr[i].getElementsByTagName("td")[0];
        }
        if (td1 || td2 || td3) {
            if (td1.innerHTML.toUpperCase().indexOf(filter) > -1 || td2.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function searchSB_TECH() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_boxTECH");
    filter = input.value.toUpperCase();
    table = document.getElementById("te_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_boxTECH").val();
        var regex = /^[a-zA-Z]+$/;
        if (!x.match(regex)) {
            td = tr[i].getElementsByTagName("td")[0];
        }
        if (td1 || td2 || td3) {
            if (td1.innerHTML.toUpperCase().indexOf(filter) > -1 || td2.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function searchSB_FREE() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_boxFREE");
    filter = input.value.toUpperCase();
    table = document.getElementById("fre_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_boxFREE").val();
        var regex = /^[a-zA-Z]+$/;
        if (!x.match(regex)) {
            td = tr[i].getElementsByTagName("td")[0];
        }
        if (td1 || td2 || td3) {
            if (td1.innerHTML.toUpperCase().indexOf(filter) > -1 || td2.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}