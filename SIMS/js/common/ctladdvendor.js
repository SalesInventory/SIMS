var hdfVendorID = 0;
$(document).ready(function () {
    $('.selectpicker').selectpicker('refresh');
    ValidationVendorDetails();
    ShowCountry();
});

function ShowCountry() {
    var params = new Object();
    $.ajax({
        type: "POST",
        async: false,
        url: BaseURL + 'services/common.asmx/GetCountryMaster',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d != null) {
                var jsnData = JSON.parse(response.d);
                for (i = 0; i < jsnData.length; i++) {
                    $('#selCountry').append('<option value="' + jsnData[i].CountryID + '">' + jsnData[i].Name + '</option>');
                }
                $('#selCountry').selectpicker('refresh');
                ShowState();
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

function ShowState() {
    $('#selState').html('');
    var params = new Object();
    params.CountryID = $('#selCountry').val();
    $.ajax({
        type: "POST",
        async: false,
        url: BaseURL + 'services/common.asmx/GetStateMasterByCountry',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d != null) {
                var jsnData = JSON.parse(response.d);
                for (i = 0; i < jsnData.length; i++) {
                    $('#selState').append('<option value="' + jsnData[i].StateID + '">' + jsnData[i].Name + '</option>');
                }
                $('#selState').selectpicker('refresh');
                ShowCity();
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

function ShowCity() {
    $('#selCity').html('');
    var params = new Object();
    params.StateID = $('#selState').val();
    $.ajax({
        type: "POST",
        async: false,
        url: BaseURL + 'services/common.asmx/GetCityMasterByState',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d != null) {
                var jsnData = JSON.parse(response.d);
                for (i = 0; i < jsnData.length; i++) {
                    $('#selCity').append('<option value="' + jsnData[i].CityID + '">' + jsnData[i].Name + '</option>');
                }
                $('#selCity').selectpicker('refresh');
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

function OpenVendorModal(VendorID) {
    //$('#divCoverageArea').slideDown('slow');
    $('#mdlVendorDetails').modal();
    $('#mdlVendorDetails').modal('show');
    hdfVendorID = VendorID;
}

function HideVendorModal() {
    //$('#divCoverageArea').slideUp('slow');
    $('#mdlVendorDetails').modal('hide');
    $('#mdlVendorDetails').val('');
    ClearVendorDetails();
    //$('#adNewStateModal').modal('hide');
}

function ClearVendorDetails() {
    hdfVendorID = 0;
    $("#txtName").val('');
    $("#txtBrandName").val('');
    $("#txtAddress").val('');
    $("#txtZip").val('');
    $("#selCountry").val(-1);
    $("#selState").val(-1);
    $("#selCity").val(-1);
    $("#txtMobile").val('');
    $("#txtPhone").val('');
    $("#txtFax").val('');
    $("#txtEmail").val('');
    $('.selectpicker').selectpicker('refresh');
}

function ValidationVendorDetails() {

    validation = $("#frmVendorDetails").validate({
        //focusCleanup: true,
        rules: {
            txtName: {
                required: true,
                maxlength: 100
            },
            txtBrandName: {
                required: true,
                maxlength: 100
            },
            txtAddress: {
                required: true,
                maxlength: 300
            },
            txtZip: {
                required: true,
                maxlength: 20
            },
            txtMobile: {
                required: true,
                number: true,
                maxlength: 15
            },
            txtPhone: {
                //required: true,
                number: true,
                maxlength: 15,
            },
            txtFax: {
                //required: true,
                number: true,
                maxlength: 15
            },
            txtEmail: {
                required: true,
                email: true,
                maxlength: 100
            },

        },
        messages: {
            txtName: {
                required: "required",
                maxlength: "Name should not more than 100 characters"
            },
            txtBrandName: {
                required: "required",
                maxlength: "Brand Name should not more than 100 characters"
            },
            txtAddress: {
                required: "required",
                maxlength: "Address should not more than 300 characters"
            },
            txtZip: {
                required: "required",
                maxlength: "Zip should not more than 20 characters"
            },
            txtMobile: {
                required: "required",
                number: "Please enter Mobile in number",
                maxlength: "Mobile should not more than 15 characters"
            },
            txtPhone: {
                //required: "required",
                number: "Please enter Phone in number",
                maxlength: "Phone should not more than 15 characters"
            },
            txtFax: {
                //required: "required",
                number: "Please enter Fax in number",
                maxlength: "Fax should not more than 15 characters"
            },
            txtEmail: {
                required: "required",
                Email: "Please enter valid email",
                maxlength: "Email should not more than 200 characters"
            },
        },
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },

        submitHandler: function (form) {
            if ($('#selCountry').val() == -1) {
                SmallNotification('Please select country.', -1);
            } else if ($('#selState').val() == -1) {
                SmallNotification('Please select state.', -1);
            } else if ($('#selCity').val() == -1) {
                SmallNotification('Please select city.', -1);
            } else {
                SaveVendorDetails();
            }
            return false;
            
        }
    });
}

function SaveVendorDetails() {
    var vendor = { VendorID: hdfVendorID, Name: $("#txtName").val().trim(), BrandName: $("#txtBrandName").val().trim(), Address: $("#txtAddress").val().trim(), Zip: $("#txtZip").val().trim(), CountryID: $("#selCountry").val().trim(), StateID: $("#selState").val().trim(), CityID: $("#selCity").val().trim(), Mobile: $("#txtMobile").val().trim(), Phone: $("#txtPhone").val().trim(), Fax: $("#txtFax").val().trim(), Email: $("#txtEmail").val().trim() };
    var param = JSON.stringify(vendor);
    $.ajax({
        type: "POST",
        url: BaseURL + "services/vendordetails.asmx/SaveVendorDetails",
        data: JSON.stringify({ "vendor": param,"UserID":1 }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('fail') == -1) {
                SmallNotification("Vendor details saved successfully.", 1);
                HideVendorModal();
                ClearVendorDetails();
                if (typeof (ReloadData) == 'function') {
                    ReloadData();
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

