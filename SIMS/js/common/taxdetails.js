$(document).ready(function () {
    GetTaxDetails();
});

function GetTaxDetails() {
    var params = new Object();
    params.UserID = 1;
    $.ajax({
        type: "POST",
        url: BaseURL + 'services/productdetails.asmx/GetTaxDetails',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('Fail') == -1) {
                if (response.d.length > 0) {
                    DataFormationofTax(response.d);
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

function DataFormationofTax(result) {
    var jsnData = JSON.parse(result);
    $('#tbodyTax').html('');

    for (i = 0; i < jsnData.length; i++) {

        var buttonlnk = '';

        buttonlnk = '<button id="btnedit" class="btn-action padding-15 btn-edit" type="button" onclick="EditTaxDetails(this,' + jsnData[i].TaxID + ');return false;" rel="tooltip" title="" data-placement="bottom" data-original-title="Edit Vendor Details"></button>';
        
        jsnData[i].action = buttonlnk;

        var tr = $('<tr>');
        if (i == 0)
            tr = $('<tr class="selectedRow" style="background: none repeat scroll 0% 0% #F2FAFD !important;border: 1px solid #9CD6F3 !important;">');

        var tdName = $('<td>');
        tdName.append($('<strong>').append(jsnData[i].Name));
        tr.append(tdName);

        var tdPercentage = $('<td>');
        tdPercentage.text(jsnData[i].Percentage+'%');
        tr.append(tdPercentage);

        var tdActions = $('<td>');
        tdActions.append(jsnData[i].action);
        tr.append(tdActions);

        $('#tbodyTax').append(tr);
    }
    $("[rel=tooltip]").tooltipnoConflict();
}

function EditTaxDetails(obj, TaxID) {
    var dataFromTheRow = $(obj).closest('tr');
    $('#txtName').val(dataFromTheRow.find('td').eq(0).text());
    $('#txtPercentage').val(dataFromTheRow.find('td').eq(1).text().replace('%',''));
    OpenTaxModal(TaxID);
}