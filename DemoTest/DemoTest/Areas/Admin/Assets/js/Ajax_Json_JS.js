$(document).ready(function () {
    LoadMenuAdmin();
    LoadMainAdmin();
    try {
        LoadTableMenuAdmin();
    }
    catch (err) {
        alert(err.err);
    }
    finally {
        LoadTableMenuAdmin();
    }
    
});

function LoadMenuAdmin() {
    $.getJSON("/HomeAdmin/GetAllSidebar", {}, function (data) {
        if (data != null)
        {
            var htmlMenu = "<ul class='nav menu'>";
            $.each(data, function (key, value) {
                htmlMenu += "<li>";
                htmlMenu += "<div id='" + value.Name + "' onclick='clickItem(this)' style='padding-left:15px;'>";
                htmlMenu += "<img src='" + value.Img + "' width='17' height='17' style='margin-right:5px;'/>";
                htmlMenu += value.Name + "</div>"; 
                htmlMenu += "</li>";
                
            })
            htmlMenu += "<li><a href='/Admin/LoginAdmin'><em class='fa fa-power-off'>&nbsp;</em>Log Out</a></li>";
            htmlMenu += "</ul>";
            $("#menu_admin").html(htmlMenu);
        }
    })
}

function LoadTableMenuAdmin() {
    debugger;
    $.getJSON("/HomeAdmin/GetAllSidebar", {}, function (data) {
        if (data != null) {
            var htmlTableMenu = "<div style='font-size:30px;text-align:center;height:30px;padding:5px;margin:20px;'><strong>Menu List</strong></div>";
            htmlTableMenu += "<div class='btn btn-md btn-info' id='create_Menu' onclick='CreateBtn(this)'><span>Create</span></div>";
            htmlTableMenu += "<table class='table'>";
            htmlTableMenu += "<tr><th>Id</th><th>Name</th><th>Image</th><th>#</th></tr>";
            $.each(data, function (key, value) {
                debugger;
                htmlTableMenu += "<tr>";
                for (var x in value) {
                    if (x == 'Img') htmlTableMenu += "<td><img src='" + value[x] + "' width='50' height='50'/></td>";
                    else htmlTableMenu += "<td>" + value[x] + "</td>";
                }
                htmlTableMenu += "<td>";
                htmlTableMenu += "<div class='btn btn-md btn-info' id='edit_Menu' onclick='EditBtn(this)'><span>Edit</span></div> | ";
                htmlTableMenu += "<div class='btn btn-md btn-info' id='details_Menu' onclick='DetailsBtn(this)'><span>Details</span></div>";
                htmlTableMenu += "<div class='btn btn-md btn-info' id='delete_Menu' onclick='DeleteBtn(this)'><span>Delete</span></div>";
                htmlTableMenu += "</td>";
                htmlTableMenu += "</tr>";
            })
            htmlTableMenu += "</table>";
            $("#main_admin").find("#_Menu").html(htmlTableMenu);
        }
    })
    
}

function LoadMainAdmin() {
    $.getJSON("/HomeAdmin/GetAllSidebar", {}, function (data) {
        if (data != null) {
            var htmlBodyMenu = "";
            $.each(data, function (key, value) {
                debugger;
                if (value.Name == "Menu") htmlBodyMenu += "<div id='_" + value.Name + "' style='display:block;'>" + value.Name + "Admin</div>";
                else htmlBodyMenu += "<div id='_" + value.Name + "' style='display:none;'>" + value.Name + "Admin</div>";
                htmlBodyMenu += "<div id='create_" + value.Name + "_1' style='display:none;'>" + value.Name + "Admin Create</div>";
                htmlBodyMenu += "<div id='details_" + value.Name + "_1' style='display:none;'>" + value.Name + "Admin Details</div>";
            })
            $("#main_admin").html(htmlBodyMenu);
        }
    })   
}

function ShowFormCreate() {
    var html = "";
    html += "<form action='#' method='post' class='form-horizontal'>";

}








function CreateBtn(e) {
    var str = e.id;
    var res = str.slice(6);
    document.getElementById(res).style.display = "none";
    document.getElementById(str + "_1").style.display = "block";
}

function EditBtn(e) {
    var str = e.id;
    var res = str.slice(4);
    document.getElementById(res).style.display = "none";
    document.getElementById(str + "_1").style.display = "block";
}

function DetailsBtn(e) {
    var str = e.id;
    var res = str.slice(7);
    document.getElementById(res).style.display = "none";
    document.getElementById(str + "_1").style.display = "block";
}

var q = "_Menu";
var s = "_Menu";
function clickItem(e) {
    var et = "_" + e.id;
    var m = "create" + q + "_1";
    var n = "details" + q + "_1";
    document.getElementById(s).style.display = "none";
    document.getElementById(m).style.display = "none";
    document.getElementById(n).style.display = "none";
    document.getElementById(et).style.display = "block";
    q = s = et;
}