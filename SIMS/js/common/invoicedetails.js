var arrayProduct = [];
var amount = 0;
$(document).ready(function () {
    var d = new Date();
    $('#txtInvoiceDate').val((d.getMonth() + 1) + '/' + d.getDate() + '/' + d.getFullYear());
    $('#txtInvoiceDate').datepickernoConflict('setDate', (d.getMonth() + 1) + '/' + d.getDate() + '/' + d.getFullYear());
    $('#txtPaymentDate').val((d.getMonth() + 1) + '/' + d.getDate() + '/' + d.getFullYear());
    $('#txtPaymentDate').datepickernoConflict('setDate', (d.getMonth() + 1) + '/' + d.getDate() + '/' + d.getFullYear());

    $('#txtProductBarcodeNumber').focus();
    $('.selectpicker').selectpicker('refresh');
    $('.datepicker').datepicker();
    //ValidationVendorDetails();
    ShowCountry();
    ShowInvoiceDetails();
    ShowPaymentModeDetails();
    GetTaxDetails();
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

function ShowInvoiceDetails() {
    $('#selInvoiceStatus').html('');
    var params = new Object();
    params.UserID = 1;
    $.ajax({
        type: "POST",
        async: false,
        url: BaseURL + 'services/productdetails.asmx/GetInvoiceStatusDetails',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d != null) {
                var jsnData = JSON.parse(response.d);
                for (i = 0; i < jsnData.length; i++) {
                    $('#selInvoiceStatus').append('<option value="' + jsnData[i].InoiceStatusID + '">' + jsnData[i].Name + '</option>');
                }
                $('#selInvoiceStatus').selectpicker('refresh');
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

function ShowPaymentModeDetails() {
    $('#selPaymentMode').html('');
    var params = new Object();
    params.UserID = 1;
    $.ajax({
        type: "POST",
        async: false,
        url: BaseURL + 'services/productdetails.asmx/GetPaymentModeDetails',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d != null) {
                var jsnData = JSON.parse(response.d);
                for (i = 0; i < jsnData.length; i++) {
                    $('#selPaymentMode').append('<option value="' + jsnData[i].PaymentModeID + '">' + jsnData[i].Name + '</option>');
                }
                $('#selPaymentMode').selectpicker('refresh');
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

function GetTaxDetails() {

    //var select = '<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12"><div id="" class="row well-sm line-height-48"><div class="col-md-12 col-lg-12 col-sm-12 col-xs-12"><label class="checkbox-inline margin-bottom-23"><input id="chkAllJobTypes" type="checkbox" class="checkbox style-0" id="-1"  onchange="CoverAllJobTypes(this)"/><span>Select All</span></label></div></div></div>';
    var taxrow = '<div class="col-md-6 col-lg-6 col-sm-6 col-xs-12"><div id="" class="row well-sm line-height-48"><div class="col-md-6 col-lg-6 col-sm-6 col-xs-12"><label class="checkbox-inline margin-bottom-23"><input type="checkbox" class="checkbox style-0" id="{1}" onchange = "ChangeJobTypeAllSelect(this);return false;"/><span>{0}</span></label></div></div></div>';
    var params = new Object();
    params.UserID = 1;
    $.ajax({
        type: "POST",
        //async: false,
        url: BaseURL + 'services/productdetails.asmx/GetTaxDetails',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('fail') == -1) {
                if (response.d.length > 0) {
                    var jsnData = JSON.parse(response.d);
                    var strData = "";
                    for (i = 0; i < jsnData.length; i++) {
                        strData += String.format(taxrow, jsnData[i].Name + ' - ' + jsnData[i].Percentage + '%', jsnData[i].TaxID);
                    }
                    $("#dvTaxdetails").html(strData);
                    //$("#dvTaxdetails").html(select + strData);
                } else {
                    SmallNotification('Unable to proceed, please try later.', -1);
                }
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
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

function OnChangePaymentMode() {

    if ($('#selPaymentMode').val() == 2) {
        $('#dvTransactionNumber').show();
    } else {
        $('#dvTransactionNumber').hide();
    }

}

function GetProductByBarcodeNumber() {
    var params = new Object();
    params.UserID = 1;
    params.BarcodeNumber = $("#txtProductBarcodeNumber").val();
    $("#txtProductBarcodeNumber").val('');
    $.ajax({
        type: "POST",
        url: BaseURL + 'services/productdetails.asmx/GetAllRecordsByUserAndBarcodeNumber',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('Fail') == -1) {
                if (response.d.length > 0 && response.d != 'null') {

                    var jsnData = JSON.parse(response.d);
                    var data = $.grep(arrayProduct, function (obj) { return obj.ProductBarCodeDetaiID == jsnData.ProductBarCodeDetaiID; });
                    //console.log(data);
                    //console.log(data.length);
                    if (data.length == 0) {
                        var product = { ProductBarCodeDetaiID: jsnData.ProductBarCodeDetaiID };
                        arrayProduct.push(product);
                        //console.log(arrayProduct);

                        var buttonlnk = '<button id="btnedit" class="btn-action padding-15  btn-decline" type="button" onclick="EditVendorDetails(this,' + jsnData.ProductBarCodeDetaiID + ');return false;" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete Product"></button>';
                        //'<button type="button" onclick="AcceptDeclinePopUp(' + jsnData.rows[i].ID + ',' + jsnData.rows[i].StatusTrackingID + ',' + jsnData.rows[i].InstructionSettingIsActive + ',\'' + jsnData.rows[i].FileNum + '\',\'' + AppraisalListInspectionDate + '\',\'' + AppraisalListInspectionTime + '\',\'' + AppraisalListEstimatedDate + '\',3,\'' + jsnData.rows[i].AssignedToUserID + '\',\'' + jsnData.rows[i].DueDate + '\')" rel="tooltip" title="" data-placement="bottom" data-original-title="Accept For Me" class="btn-action padding-15 btn-accept" ></button>' +
                        //                   '<button type="button" onclick="OpenOrderAssignmentModal(' + jsnData.rows[i].ID + ',\'' + jsnData.rows[i].AssignedToUserID + '\',' + jsnData.rows[i].ProcessStatusID + ')" rel="tooltip" title="" data-placement="bottom" data-original-title="Re-assign" class="btn-action padding-15 btn-reassign" ></button>' +
                        //                   '<button type="button" onclick="AcceptDeclinePopUp(' + jsnData.rows[i].ID + ',' + jsnData.rows[i].StatusTrackingID + ',' + jsnData.rows[i].InstructionSettingIsActive + ',\'' + jsnData.rows[i].FileNum + '\',\'' + AppraisalListInspectionDate + '\',\'' + AppraisalListInspectionTime + '\',\'' + AppraisalListEstimatedDate + '\',5,\'' + jsnData.rows[i].AssignedToUserID + '\',\'' + jsnData.rows[i].DueDate + '\')" rel="tooltip" title="" data-placement="bottom" data-original-title="Accept With Conditions" class="btn-action padding-15 btn-accept-condition" ></button>' +
                        //                   '<button type="button" onclick="AcceptDeclinePopUp(' + jsnData.rows[i].ID + ',' + jsnData.rows[i].StatusTrackingID + ',' + jsnData.rows[i].InstructionSettingIsActive + ',\'' + jsnData.rows[i].FileNum + '\',\'' + AppraisalListInspectionDate + '\',\'' + AppraisalListInspectionTime + '\',\'' + AppraisalListEstimatedDate + '\',6,\'' + jsnData.rows[i].AssignedToUserID + '\',\'' + jsnData.rows[i].DueDate + '\')" rel="tooltip" title="" data-placement="bottom" data-original-title="Decline" class="btn-action padding-15 btn-decline" ></button>';

                        jsnData.action = buttonlnk;

                        var tr = $('<tr>');
                        if (i == 0)
                            tr = $('<tr class="selectedRow" style="background: none repeat scroll 0% 0% #F2FAFD !important;border: 1px solid #9CD6F3 !important;">');

                        var tdBarCodeNumber = $('<td>');
                        tdBarCodeNumber.append($('<strong>').append(jsnData.BarCodeNumber));
                        tr.append(tdBarCodeNumber);

                        var tdMRP = $('<td>');
                        tdMRP.text(jsnData.MRP);
                        tr.append(tdMRP);

                        var tdDiscount = $('<td>');
                        tdDiscount.text(jsnData.Discount);
                        tr.append(tdDiscount);

                        var tdQuantiry = $('<td>');
                        tdQuantiry.text(1);
                        tr.append(tdQuantiry);

                        var tdActions = $('<td>');
                        tdActions.append(jsnData.action);
                        tr.append(tdActions);

                        $('#tbodyProduct').append(tr);

                        var discount = (jsnData.MRP * jsnData.Discount) / 100;
                        console.log(discount);
                        var finalmrp = jsnData.MRP - discount;
                        console.log(finalmrp);
                        amount = amount + finalmrp;
                        
                        $('#txtAmount').val(amount);
                        
                        console.log($('#txtAmount').val());

                    } else {
                        SmallNotification('Product is already added.', 2);
                    }
                } else {
                    SmallNotification('No data found.', 2);
                }
            } else {
                SmallNotification('Unable to proceed, please try later.', -1);
            }
        },
        failure: function (xhr, status, error) {
            SmallNotification('Unable to proceed, please try later.', -1);
        },
        error: function (xhr, status, error) {
            SmallNotification('Unable to proceed, please try later.', -1);
        }
    });
}

function DeleteProduct() {
    var dataFromTheRow = $(obj).closest('tr');//jQuery('#userCoverageArea').jqGrid('getRowData', rowId);

    $('#txtCoverageID').val(rowId);
    $('#selState').val(dataFromTheRow.find('td').eq(0).text());
}

