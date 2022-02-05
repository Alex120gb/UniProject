$(document).ready(function () {
    //Required
    var rowReqCount = $('#req_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Req_Count").text(rowReqCount);
    }
    else {
        $("#Req_Count").text("");
    }
    

    var rowReqCount = $('#Failed_req_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Req_Failed_Count").text(rowReqCount);
    }
    else {
        $("#Req_Failed_Count").text("");
    }
    

    var rowReqCount = $('#req_Unregistered_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Req_Unregistered_Count").text(rowReqCount);
    }
    else {
        $("#Req_Unregistered_Count").text("");
    }
    


    //Technical
    var rowReqCount = $('#te_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Tech_Count").text(rowReqCount);
    }
    else {
        $("#Tech_Count").text("");
    }
    

    var rowReqCount = $('#te_Failed_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Tech_Failed_Count").text(rowReqCount);
    }
    else {
        $("#Tech_Failed_Count").text("");
    }
    

    var rowReqCount = $('#te_Unregistered_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Tech_Unregistered_Count").text(rowReqCount);
    }
    else {
        $("#Tech_Unregistered_Count").text("");
    }
    


    //Free
    var rowReqCount = $('#fre_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Free_Count").text(rowReqCount);
    }
    else {
        $("#Free_Count").text("");
    }
    

    var rowReqCount = $('#Free_Failed_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Free_Failed_Count").text(rowReqCount);
    }
    else {
        $("#Free_Failed_Count").text("");
    }
    

    var rowReqCount = $('#fre_Unregistered_tbl tr').length;
    if (rowReqCount > 0) {
        $("#Free_Unregistered_Count").text(rowReqCount);
    }
    else {
        $("#Free_Unregistered_Count").text("");
    }
    
});

function goBack() {
    window.location.replace("https://localhost:44398/Home/Index");
    // window.location.href = "../RegisterSubs/RegisterSubjects.cshtml";
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

function searchSB_Failed_REQ() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_boxFailed_REQ");
    filter = input.value.toUpperCase();
    table = document.getElementById("Failed_req_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_boxFailed_REQ").val();
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

function searchSB_Unregistered_REQ() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_box_Unregistered_REQ");
    filter = input.value.toUpperCase();
    table = document.getElementById("req_Unregistered_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_box_Unregistered_REQ").val();
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

//For Technical subjects
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

function searchSB__Failed_TECH() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_box_Failed_TECH");
    filter = input.value.toUpperCase();
    table = document.getElementById("te_Failed_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_box_Failed_TECH").val();
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

function searchSB_Unregistered_TECH() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_box_Unregistered_TECH");
    filter = input.value.toUpperCase();
    table = document.getElementById("te_Unregistered_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_box_Unregistered_TECH").val();
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

//For Free subjects
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

function searchSB_Failed_FREE() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_box_Failed_FREE");
    filter = input.value.toUpperCase();
    table = document.getElementById("Free_Failed_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_box_Failed_FREE").val();
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

function searchSB_Unregistered_FREE() {
    var input, filter, table, tr, i;
    input = document.getElementById("srch_box_Unregistered_FREE");
    filter = input.value.toUpperCase();
    table = document.getElementById("fre_Unregistered_tbl");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var x = $("#srch_box_Unregistered_FREE").val();
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