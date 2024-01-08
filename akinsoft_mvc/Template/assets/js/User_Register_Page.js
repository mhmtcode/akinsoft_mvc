$(document).ready(function () {

    var Id_val = $("#register_number").val()
    if (Id_val != '') {

        $("#register_1").hide();
        $("#register_info").hide();
        $("#register_2").show();
        invoice_line_list();
    }

    $("#register").submit(function (e) {
        //---------------^---------------
        e.preventDefault();
        $("#btn_save_post").html('Waiting...');
        
            $.ajax({
                url: "/en/Invoice_line_update",
                type: "POST",
                data: {

                    ID: $("#invoice_id_number").val(),
                    USER_REGISTER_NAME: $("#USER_REGISTER_NAME").val(),
                    USER_REGISTER_LASTNAME: $("#USER_REGISTER_LASTNAME").val(),
                    EMAIL: $("#EMAIL").val()

                },
                success: function (data) {
                    $("#btn_save_post").html('Loading...');
                    $("#register_guide").text(data);
                    $("#register_3").hide(500);
                    $("#register_4").show(500);
                    scroll("thanks");
                },
                error: function () {
                    alert("Error");
                }
            });
          
        return false;

    });

});

function one_step() {
  
    $("#register_2").hide(500);
    $("#register_3").show(500);
  
}
//function two_step() {

//    if ($('#chk_box').is(":checked")) {
//        invoice_line_update();
//        $("#error_tag").remove();
//        $("#register_3").hide(500);
//        $("#register_4").show(500);
//        scroll("thanks");
//    }
//    else
//    {
//        $("#error_tag").remove();
//        $("#main1").prepend("<p id='error_tag' class='note form-error'>You did not approve the form</p> ");
//    }
//}
function scroll(n) {
    $('html, body').animate({
        scrollTop: $("#" + n).offset().top
    }, 800);
}

function invoice_line_list() {
    var i = 1;
    $.ajax({
        url: "/en/Invoice_Line_List/" + $("#register_number").val(),
        type: "GET",
        dataType: "json",
        crossDomain: true,
        success: function (data) {
            
            $.each(data, function (key, value) {
                var newRowContent = "<tr> <td class='text-left'>" + i + "</td> <td class='text-left'>" + value.PRODUCT_NAME + "</td> <td class='text-left'>" + value.PRODUCT_MIKTAR + "</td>  </tr>";
                $("#invoice_line_ > tbody").append(newRowContent);
                i++;
            });
        }
    })
}

//function invoice_line_update() {
//    $.ajax({
//        url: "/en/Invoice_line_update",
//        type: "POST",
//        data: {

//            ID: $("#invoice_id_number").val(),
//            USER_REGISTER_NAME:$("#USER_REGISTER_NAME").val(),
//            USER_REGISTER_LASTNAME:$("#USER_REGISTER_LASTNAME").val(),
//            EMAIL: $("#EMAIL").val()
           
//        },
//        success: function (data) {
//           $("#register_guide").text(data);
//        },
//        error: function () {
//            alert("Error");
//        }
//    });
//}