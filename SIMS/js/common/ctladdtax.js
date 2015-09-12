var hdfTaxID = 0;
$(document).ready(function () {
    $('.selectpicker').selectpicker('refresh');
    ValidationTaxDetails();
});

function OpenTaxModal(TaxID) {
    $('#mdlTAxDetails').modal();
    $('#mdlTAxDetails').modal('show');
    hdfTaxID = TaxID;
}

function HideTaxModal() {
    $('#mdlTAxDetails').modal('hide');
    $('#mdlTAxDetails').val('');
    ClearTaxDetails();
}

function ClearTaxDetails() {
    hdfTaxID = 0;
    $("#txtName").val('');
    $("#txtPercentage").val('');
}

function ValidationTaxDetails() {

    validation = $("#frmVendorDetails").validate({
        //focusCleanup: true,
        rules: {
            txtName: {
                required: true,
                maxlength: 100
            },
            txtPercentage: {
                required: true,
                number: true,
                maxlength: 10
            },
        },
        messages: {
            txtName: {
                required: "required",
                maxlength: "Name should not more than 100 characters"
            },
            txtPercentage: {
                required: "required",
                number: "Please enter valid percentage",
                maxlength: "Percentage should not more than 10 characters"
            },

        },
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },

        submitHandler: function (form) {
            SaveTaxDetails();
            return false;

        }
    });
}

function SaveTaxDetails() {
    var Tax = { TaxID: hdfTaxID, Name: $("#txtName").val().trim(), Percentage: $("#txtPercentage").val().trim() };
    var param = JSON.stringify(Tax);
    $.ajax({
        type: "POST",
        url: BaseURL + "services/productdetails.asmx/SaveTaxDetails",
        data: JSON.stringify({ "Tax": param, "UserID": 1 }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('fail') == -1) {
                SmallNotification("Tax details saved successfully.", 1);
                HideTaxModal();
                ClearTaxDetails();
                if (typeof (GetTaxDetails) == 'function') {
                    GetTaxDetails();
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

