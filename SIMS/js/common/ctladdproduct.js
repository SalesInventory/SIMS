
var hdfProductID = 0;
var hdfReOrderID = 0;

$(document).ready(function () {
    $('.selectpicker').selectpicker('refresh');
    ShowCompany();
    ShowCategoryDetails();
    ShowProductFor();
    ShowProductClor()
    ValidationProductDetails();
    //ShowCountry();
});

function ValidationProductDetails() {
    $.validator.addMethod("NotMorethen", function (value, element) {
        if ($(element).val() != "") {
            if (parseInt($("#txtQuantity").val()) <= parseInt(value))
                return false;
            else
                return true;
        }
        else
            return true;
        return this.optional(element) || (parseFloat(value) > 0);
    }, "Less then Quantity not more then total Quantity");
    validation = $("#frmProductDetails").validate({
        //focusCleanup: true,
        rules: {
            txtName: {
                required: true,
                maxlength: 50
            },
            txtShortCode: {
                required: true,
                maxlength: 6
            },
            txtVendor: {
                required: true,
            },
            txtTotalPrice: {
                required: true,
                number: true,
                min: 0
            },
            txtMRP: {
                required: true,
                number: true,
                min: 0
            },
            txtPurchasePrice: {
                required: true,
                number: true,
                min: 0
            },
            txtQuantity: {
                required: true,
                digits: true,
                min: 0
            },
            txtDiscount: {
                digits: true,
                range: [0, 100],
                min: 0
            },
            txtRQuantity: {
                digits: true,
                min: 0,
            },
            txtMinQuantity: {
                digits: true,
                min: 0,
                NotMorethen: true
            }

        },
        messages: {
            txtName: {
                required: "required",
                maxlength: "Product Name should not more than 50 characters"
            },
            txtShortCode: {
                required: "required",
                maxlength: "ShortCode should not more than 6 characters"
            },
            txtVendor: {
                required: "required",
            },
            txtTotalPrice: {
                required: "required",
                number: "TotalPrice should only number"
            },
            txtMRP: {
                required: "required",
                number: "MRP should only number"
            },
            txtPurchasePrice: {
                required: "required",
                number: "PurchasePrice should only number"
            },
            txtQuantity: {
                required: "required",
                digits: "Quantity should only number"
            },
            txtDiscount: {
                digits: "Discount should only number",
                range: "Please enter a value between 0 and 100"
            },
            txtRQuantity: {
                digits: "ReOrder Quantity should only number"
            },
        },
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },

        submitHandler: function (form) {
            console.log($("#selCompany").val());
            console.log($("#selCategory").val());
            console.log($("#selProductFor").val());
            console.log($("#selColor").val());
            console.log($("#selSize").val());
            console.log($("#txtVendor").attr("data-vender-id"));
            console.log(typeof ($("#txtVendor").attr("data-vender-id")));
            if (true) {
                if (typeof ($("#txtVendor").attr("data-vender-id")) != "undefined") {
                    SaveProductDetails();
                    return false;
                } else {
                    SmallNotification('Select or enter vender', -1);
                    return false;
                }
            } else {
                SmallNotification('Select', -1);
                return false;
            }
            //return false;
        }
    });
}

function SaveProductDetails() {
    var product = {
        ProductID: hdfProductID,
        VendorID: $("#txtVendor").attr("data-vender-id"),
        ProductCompanyID: $("#selCompany").val(),
        ProductSizeID: $("#selSize").val(),
        ProductColorID: $("#selColor").val(),
        ProductCategoryID: $("#selCategory").val(),
        ProductForID: $("#selProductFor").val(),
        Name: $("#txtName").val().trim(),
        Descryption: $("#txtDescryption").val().trim(),
        ShortCode: $("#txtShortCode").val().trim(),
        Quantity: $("#txtQuantity").val().trim(),
        TotalPrice: $("#txtTotalPrice").val().trim(),
        PurchasePrice: $("#txtPurchasePrice").val().trim(),
        MRP: $("#txtMRP").val().trim(),
        Discount: typeof ($("#txtDiscount").val()) != "undefined" && $("#txtDiscount").val() != "" ? $("#txtDiscount").val().trim():0
    }
    var reOderDetails = {
        ReOrderID:hdfReOrderID,
        ProductID:hdfProductID,
        VendorID: typeof ($("#txtRVendor").attr("data-vender-id")) != "undefined" ? $("#txtRVendor").attr("data-vender-id") : 0,
        Quantity: typeof ($("#txtReOrderQuantity").val()) != "undefined" && $("#txtReOrderQuantity").val() != "" ? $("#txtReOrderQuantity").val() : 0,
        MinimumQuntity: typeof ($("#txtMinQuantity").val()) != "undefined" && $("#txtMinQuantity").val() != "" ? $("#txtMinQuantity").val() : 0
    }
    console.log(product);
    console.log(reOderDetails);
   // var param = JSON.stringify(vendor);
    $.ajax({
        type: "POST",
        url: BaseURL + "services/productdetails.asmx/SaveProductDetails",
        data: JSON.stringify({ "product": JSON.stringify(product), "UserID": 1, "reOderDetails":  JSON.stringify(reOderDetails) }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('fail') == -1) {
                SmallNotification("Product details saved successfully.", 1);
                HideProductModal();
                ClearProductDetails();
                //if (typeof (ReloadData) == 'function') {
                //    ReloadData();
                //}
            }
            else {
                SmallNotification("Unable to proceed, please try later.", -1);
            }
        },
        failure: function (xhr, status, error) {
            AjaxErrorHandling(status);
        },
        error: function (xhr, status, error) {
            AjaxErrorHandling(status);
        }
    });


}

function OpenProductModal(ProductID) {
    $('#mdlProductDetails').modal();
    $('#mdlProductDetails').modal('show');
    hdfProductID = ProductID;
}

function HideProductModal() {
    $('#mdlProductDetails').modal('hide');
    $('#mdlProductDetails').val('');
    ClearProductDetails();
}

function ClearProductDetails() {
    hdfVendorID = 0;
    hdfReOrderID = 0;
    $("#txtName,#txtDescryption,#txtShortCode,#txtVendor,#txtTotalPrice,#txtMRP,#txtPurchasePrice,#txtQuantity,#txtDiscount,#txtReOrderQuantity,#txtRVendor,#txtMinQuantity").val('');
    //$("#selCompany,#selCategory,#selProductFor,#selColor,#selSize").val(-1);
    $('.selectpicker').selectpicker('refresh');
}

function ShowCompany() {
    var params = {
        UserID: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: BaseURL + 'services/productdetails.asmx/GetProductCompany',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d != null) {
                var jsnData = JSON.parse(response.d);
                var companyOption = _.template('<option value="<%=CompanyID%>"> <%=Name%> </option>');
                var companyOptions = "";
                for (i = 0; i < jsnData.length; i++)
                    companyOptions += companyOption(jsnData[i]);
                $("#selCompany").html(companyOptions);
                $('#selCompany').selectpicker('refresh');
            }
        },
        failure: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        }
    });

}

function ShowCategoryDetails() {
    var params = new Object();
    params.UserID = 1;
    $.ajax({
        type: "POST",
        url: BaseURL + 'services/productdetails.asmx/GetCategoryDetails',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('Fail') == -1) {
                if (response.d.length > 0) {
                    var jsnData = JSON.parse(response.d);
                    var categoryOption = _.template('<option value="<%=ProductCategoryID%>"> <%=Name%> </option>');
                    var categoryOptions = "";
                    for (i = 0; i < jsnData.length; i++)
                        categoryOptions += categoryOption(jsnData[i]);
                    $("#selCategory").html(categoryOptions);
                    $('#selCategory').selectpicker('refresh');
                    ShowProductSize();
                } else {
                    SmallNotification('No data found.', 2);
                }
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
            }
            HideLoadingOverlay();
        },
        failure: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        }
    });
}

function ShowProductFor() {
    var params = new Object();
    $.ajax({
        type: "POST",
        url: BaseURL + 'services/productdetails.asmx/GetProductFor',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('Fail') == -1) {
                if (response.d.length > 0) {
                    var jsnData = JSON.parse(response.d);
                    var productForOption = _.template('<option value="<%=ProductForID%>"> <%=Name%> </option>');
                    var productForOptions = "";
                    for (i = 0; i < jsnData.length; i++)
                        productForOptions += productForOption(jsnData[i]);
                    $("#selProductFor").html(productForOptions);
                    $('#selProductFor').selectpicker('refresh');
                } else {
                    SmallNotification('No data found.', 2);
                }
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
            }
            HideLoadingOverlay();
        },
        failure: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        }
    });
}


function ShowProductClor() {
    var params = new Object();
    $.ajax({
        type: "POST",
        url: BaseURL + 'services/productdetails.asmx/GetProductColor',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('Fail') == -1) {
                if (response.d.length > 0) {
                    var jsnData = JSON.parse(response.d);
                     var productColorOption = _.template('<option  value="<%=ColorID%>" data-content="<span class=\'label\' style=\'background-color:<%=ColorCode%>;color:<%=Color%>;\' ><%=Name%></span>"><%=Name%></option>');
                     var productColorOptions = "";
                     for (i = 0; i < jsnData.length; i++) {
                         if (jsnData[i].ColorCode == "#000000")
                             jsnData[i].Color = "#FFFFFF";
                         else
                             jsnData[i].Color = "#000000";
                         productColorOptions += productColorOption(jsnData[i]);
                     }
                     $("#selColor").html(productColorOptions);
                     $('#selColor').selectpicker('refresh');
                } else {
                    SmallNotification('No data found.', 2);
                }
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
            }
            HideLoadingOverlay();
        },
        failure: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        }
    });
}

function ShowProductSize() {
    $('#selSize').html('');
    var params = new Object();
    params.ProductCategoryID = $('#selCategory').val();
    $.ajax({
        type: "POST",
        async: false,
        url: BaseURL + 'services/productdetails.asmx/GetProductSizeByCategory',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d != null) {
                var jsnData = JSON.parse(response.d);
                var productSizeOption = _.template('<option value="<%=ProductSizeID%>"> <%=Name%> </option>');
                var productSizeOptions = "";
                for (i = 0; i < jsnData.length; i++)
                    productSizeOptions += productSizeOption(jsnData[i]);
                $("#selSize").html(productSizeOptions);
                $('#selSize').selectpicker('refresh');
            }
        },
        failure: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            AjaxErrorHandling(status);
            //SmallNotification('Unable to proceed, please try later.', -1);
        }
    });

}