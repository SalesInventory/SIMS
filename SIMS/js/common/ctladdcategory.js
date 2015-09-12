var hdfCategoryID = 0;
$(document).ready(function () {
    $('.selectpicker').selectpicker('refresh');
    ValidationCategoryDetails();
});

function OpenCategoryModal(CategoryID) {
    $('#mdlCategoryDetails').modal();
    $('#mdlCategoryDetails').modal('show');
    hdfCategoryID = CategoryID;
}

function HideCategoryModal() {
    $('#mdlCategoryDetails').modal('hide');
    $('#mdlCategoryDetails').val('');
    ClearCategoryDetails();
}

function ClearCategoryDetails() {
    hdfCategoryID = 0;
    $("#txtCategoryName").val('');
}

function ValidationCategoryDetails() {

    validation = $("#frmCategoryDetails").validate({
        //focusCleanup: true,
        rules: {
            txtCategoryName: {
                required: true,
                maxlength: 100
            },
        },
        messages: {
            txtCategoryName: {
                required: "required",
                maxlength: "Name should not more than 100 characters"
            },
        },
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },

        submitHandler: function (form) {
            SaveCategoryDetails();
            return false;

        }
    });
}

function SaveCategoryDetails() {
    var Category = { ProductCategoryID: hdfCategoryID, Name: $("#txtCategoryName").val().trim() };
    var param = JSON.stringify(Category);
    $.ajax({
        type: "POST",
        url: BaseURL + "services/productdetails.asmx/SaveCategoryDetails",
        data: JSON.stringify({ "Category": param, "UserID": 1 }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('fail') == -1) {
                SmallNotification("Category details saved successfully.", 1);
                HideCategoryModal();
                ClearCategoryDetails();
                if (typeof (GetCategoryDetails) == 'function') {
                    GetCategoryDetails();
                }
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