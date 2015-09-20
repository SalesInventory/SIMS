var hdfCategorytypeID = 0;
$(document).ready(function () {
    $('.selectpicker').selectpicker('refresh');
    ValidationCategorytypeDetails();
    GetCategoryDetailsForDropdown();
});

function GetCategoryDetailsForDropdown() {
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
                var jsnData = JSON.parse(response.d);
                for (i = 0; i < jsnData.length; i++) {
                    $('#selCategory').append('<option value="' + jsnData[i].ProductCategoryID + '">' + jsnData[i].Name + '</option>');
                }
                $('#selCategory').selectpicker('refresh');
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
            }
            HideLoadingOverlay();
        },
        failure: function (xhr, status, error) {
            HideLoadingOverlay();
            SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            HideLoadingOverlay();
            SmallNotification('Unable to proceed, please try later.', -1);
        }
    });
}

function OpenCategorytypeModal(CategorytypeID) {
    GetCategorytypeDetails();
    $('#mdlCategorytypeDetails').modal();
    $('#mdlCategorytypeDetails').modal('show');
    hdfCategorytypeID = CategorytypeID;
}

function HideCategorytypeModal() {
    $('#mdlCategorytypeDetails').modal('hide');
    $('#mdlCategorytypeDetails').val('');
    ClearCategorytypeDetails();
}

function ClearCategorytypeDetails() {
    hdfCategorytypeID = 0;
    $("#txtCategorytypeName").val('');
}

function ValidationCategorytypeDetails() {

    validation = $("#frmCategorytypeDetails").validate({
        //focusCleanup: true,
        rules: {
            txtCategorytypeName: {
                required: true,
                maxlength: 100
            },
        },
        messages: {
            txtCategorytypeName: {
                required: "required",
                maxlength: "Name should not more than 100 characters"
            },
        },
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },

        submitHandler: function (form) {
            SaveCategorytypeDetails();
            return false;

        }
    });
}

function SaveCategorytypeDetails() {
    var Categorytype = { ProductCategorytypeID: hdfCategorytypeID, Name: $("#txtCategorytypeName").val().trim() };
    var param = JSON.stringify(Categorytype);
    $.ajax({
        type: "POST",
        url: BaseURL + "services/productdetails.asmx/SaveCategorytypeDetails",
        data: JSON.stringify({ "Categorytype": param, "UserID": 1 }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('fail') == -1) {
                SmallNotification("Category type details saved successfully.", 1);
                //HideCategoryModal();
                ClearCategorytypesDetails();
                if (typeof (GetCategorytypeDetails) == 'function') {
                    GetCategorytypeDetails();
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

function GetCategorytypeDetails() {
    var params = new Object();
    params.UserID = 1;
    $.ajax({
        type: "POST",
        url: BaseURL + 'services/productdetails.asmx/GetCategorytypeDetails',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('Fail') == -1) {
                if (response.d.length > 0) {
                    DataFormationofCategorytype(response.d);
                } else {
                    SmallNotification('No data found.', 2);
                }
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
            }
            HideLoadingOverlay();
        },
        failure: function (xhr, status, error) {
            HideLoadingOverlay();
            SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            HideLoadingOverlay();
            SmallNotification('Unable to proceed, please try later.', -1);
        }
    });
}

function DataFormationofCategorytype(result) {
    var jsnData = JSON.parse(result);
    $('#tbodyCategorytype').html('');

    for (i = 0; i < jsnData.length; i++) {

        var buttonlnk = '';

        buttonlnk = '<button id="btnedit" class="btn-action padding-15 btn-edit" type="button" onclick="EditCategoryDetails(this,' + jsnData[i].ProductCategoryID + ');return false;" rel="tooltip" title="" data-placement="bottom" data-original-title="Edit Category type Details"></button>';

        jsnData[i].action = buttonlnk;

        var tr = $('<tr>');
        if (i == 0)
            tr = $('<tr class="selectedRow" style="background: none repeat scroll 0% 0% #F2FAFD !important;border: 1px solid #9CD6F3 !important;">');

        var tdName = $('<td>');
        tdName.append($('<strong>').append(jsnData[i].Name));
        tr.append(tdName);

        var tdActions = $('<td>');
        tdActions.append(jsnData[i].action);
        tr.append(tdActions);

        $('#tbodyCategorytype').append(tr);
    }
    $("[rel=tooltip]").tooltipnoConflict();
}

function EditCategorytypeDetails(obj, CategorytypeID) {
    var dataFromTheRow = $(obj).closest('tr');
    $('#txtCategorytypeName').val(dataFromTheRow.find('td').eq(0).text());
    hdfCategorytypeID = CategorytypeID;
    $('#txtCategorytypeName').focus();
}