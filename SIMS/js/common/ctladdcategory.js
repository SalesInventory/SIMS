var hdfCategoryID = 0;
$(document).ready(function () {
    $('.selectpicker').selectpicker('refresh');
    ValidationCategoryDetails();
});

function OpenCategoryModal(CategoryID) {
    GetCategoryDetails();
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

function GetCategoryDetails() {
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
                    DataFormationofCategory(response.d);
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

function DataFormationofCategory(result) {
    var jsnData = JSON.parse(result);
    $('#tbodyCategory').html('');

    for (i = 0; i < jsnData.length; i++) {

        var buttonlnk = '';

        buttonlnk = '<button id="btnedit" class="btn-action padding-15 btn-edit" type="button" onclick="EditCategoryDetails(this,' + jsnData[i].ProductCategoryID + ');return false;" rel="tooltip" title="" data-placement="bottom" data-original-title="Edit Category Details"></button>';

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

        $('#tbodyCategory').append(tr);
    }
    $("[rel=tooltip]").tooltipnoConflict();
}

function EditCategoryDetails(obj, CategoryID) {
    var dataFromTheRow = $(obj).closest('tr');
    $('#txtCategoryName').val(dataFromTheRow.find('td').eq(0).text());
}