

$(document).ready(function () {
    Category_list()
});

// Generate a password string
function randString(id) {
    var dataSet = $(id).attr('data-character-set').split(',');
    var possible = '';
    if ($.inArray('a-z', dataSet) >= 0) {
        possible += 'abcdefghijklmnopqrstuvwxyz';
    }
    if ($.inArray('A-Z', dataSet) >= 0) {
        possible += 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    }
    if ($.inArray('0-9', dataSet) >= 0) {
        possible += '0123456789';
    }
    if ($.inArray('#', dataSet) >= 0) {
        possible += '![]{}()%&*$#^<>~@|';
    }
    var text = '';
    for (var i = 0; i < $(id).attr('data-size'); i++) {
        text += possible.charAt(Math.floor(Math.random() * possible.length));
    }
    return text;
}

// Create a new password
$(".getNewPass").click(function () {
    var field = $("#pass_1,#pass_2");
    field.val(randString(field));
});

//Category List
function Category_list() {

    var category_id = $("#category_id").val();
     $.ajax({
        url: "/Admin/Get_Category",
        type: "GET",
        dataType: "json",
        crossDomain: true,
        success: function (data) {

            $.each(data, function (key, value) {

                    $("#select_1").append("<option value=" + value.ID + ">" + value.Catagory_Name + "</option>");
               
            });
            $("#select_1").val(category_id);
        }
    })
}