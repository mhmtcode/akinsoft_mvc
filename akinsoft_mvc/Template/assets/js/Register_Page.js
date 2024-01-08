
$(document).ready(function () {

    var Id_val = $("#ID").val()
    if (Id_val != '') {

        Invoice_line_doldur();
        $("#sprinter").hide();
        $("#Invoice_line").show();

    }
    else {
        $("#sprinter").hide();
    }

});

function Invoice_line_doldur() {
    $("table > tbody> tr").remove();
    $.ajax({
        url: "/Admin/Invoice_Line_list/" + $("#INVOICE_NUMBER").val(),
        type: "GET",
        dataType: "json",
        crossDomain: true,
        success: function (data) {
            $.each(data, function (key, value) {

                var newRowContent = "<tr> <td>" + value.ID + "</td> <td>" + value.PRODUCT_NAME + "</td> <td>" + value.PRODUCT_MIKTAR + "</td> <td>  <a class='btn btn-danger rounded' onclick='Invoice_Line_delete(" + value.ID + ")'><i class='mdi mdi-delete'></i> Sil</a>   </td> </tr >";
                $("table > tbody").append(newRowContent);
            });
        }
    })

}
function Invoice_Line_save() {

    $.ajax({
        url: "/Admin/Invoice_line_Add",
        type: "POST",
        data: {

            INVOICE_NUMBER: $("#INVOICE_NUMBER").val(),
            PRODUCT_NAME: $("#product-name").val(),
            PRODUCT_MIKTAR: $("#product-miktar").val()
        },
        success: function () {
            alert("Kayit Yapildi");
            Invoice_line_doldur();
            $("#product-name").val(null);
            $("#product-miktar").val(null);
        },
        error: function () {
            alert("Error");
        }
    });
}
function Invoice_Line_delete(n) {


    if (confirm("Silmek Istediginize Eminmisiniz?") == true) {
        $.ajax({
            url: "/Admin/Invoice_line_Delete",
            type: "POST",
            data: {

                ID: n
            },
            success: function () {
                alert("Kayit Silindi");
                Invoice_line_doldur();
            },
            error: function () {
                alert("Error");
            }

        });
    } else {
        alert("Islem Iptal Edildi");
    }

}


