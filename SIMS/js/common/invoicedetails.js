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
    ValidationInvoiceDetails();
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
    var taxrow = '<div class="col-md-6 col-lg-6 col-sm-6 col-xs-12"><div id="" class="row well-sm line-height-48"><div class="col-md-6 col-lg-6 col-sm-6 col-xs-12"><label class="checkbox-inline margin-bottom-23"><input type="checkbox" class="checkbox style-0" id="{1}" data-percentage="{2}" onchange = "ChangeJobTypeAllSelect(this);return false;"/><span>{0}</span></label></div></div></div>';
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
                        strData += String.format(taxrow, jsnData[i].Name + ' - ' + jsnData[i].Percentage + '%', jsnData[i].TaxID, jsnData[i].Percentage);
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
                    if (data.length == 0) {
                        var product = { ProductBarCodeDetaiID: jsnData.ProductBarCodeDetaiID };
                        arrayProduct.push(product);

                        var buttonlnk = '<button id="btnedit" class="btn-action padding-15  btn-decline" type="button" onclick="DeleteProduct(this,' + jsnData.ProductBarCodeDetaiID + ');return false;" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete Product"></button>';

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
                        var finalmrp = jsnData.MRP - discount;
                        amount = amount + finalmrp;

                        OnChangeOfDicount();
                        //var extradiscount = $('#txtDiscount').val();
                        //var finalamount = amount;
                        //if (extradiscount != '') {
                        //    finalamount = amount - ((amount * extradiscount) / 100);
                        //}
                        //$('#txtAmount').val(finalamount);

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

function DeleteProduct(obj, barcodeid) {

    $.SmartMessageBox({
        title: "Invoice",
        content: 'Are you sure, you want to delete this product?',
        buttons: '[CANCEL][OK]'
    }, function (ButtonPressed) {
        if (ButtonPressed === "OK") {
            var product = { ProductBarCodeDetaiID: barcodeid };
            arrayProduct.pop(product);
            console.log(arrayProduct);
            var dataFromTheRow = $(obj).closest('tr');//jQuery('#userCoverageArea').jqGrid('getRowData', rowId);
            var deletedproductamount = dataFromTheRow.find('td').eq(1).text();
            var deletedproductdiscount = dataFromTheRow.find('td').eq(2).text();
            var deletedproductamount = parseFloat(deletedproductamount) - ((parseFloat(deletedproductamount) * parseFloat(deletedproductdiscount)) / 100);
            amount = amount - deletedproductamount;
            OnChangeOfDicount();
            //$('#txtAmount').val(amount);
            $(obj).closest('tr').remove();
        } else if (ButtonPressed === "CANCEL") {
            //SmallNotification('Abort', 0);
        }
    });
}

function ValidationInvoiceDetails() {

    validation = $("#frmProfileDetail").validate({
        //focusCleanup: true,
        rules: {
            txtInvoiceDate: {
                required: true,
            },
            txtInvoiceNumber: {
                required: true,
                number: true,
                maxlength: 20
            },
            txtFirstName: {
                required: true,
                maxlength: 50
            },
            txtLastName: {
                required: true,
                maxlength: 50
            },
            txtMobile: {
                //required: true,
                number: true,
                maxlength: 20
            },
            txtEmail: {
                maxlength: 100,
                email: true,
            },
            txtAmount: {
                required: true,
                number: true,
                maxlength: 7
            },
            txtTransactionNumber: {
                required: true,
                maxlength: 100
            },
            txtZip: {
                number: true,
                maxlength: 20
            },
            txtPhone: {
                number: true,
                maxlength: 20
            },
            txtDiscount: {
                number: true,
                maxlength: 2
            },
            //txtAmountGiven: {
            //    number: true,
            //},
            //txtReturnAmount: {
            //    number: true,
            //},
        },
        messages: {
            txtInvoiceDate: {
                required: "required",
            },
            txtInvoiceNumber: {
                required: "required",
                number: "Please enter valid Invoice Number",
                maxlength: "Percentage should not more than 20 characters"
            },
            txtFirstName: {
                required: "required",
                maxlength: "First Name should not more than 50 characters"
            },
            txtLastName: {
                required: "required",
                maxlength: "Last Name should not more than 50 characters"
            },
            txtMobile: {
                //required: "required",
                number: "Please enter valid Mobile Number",
                maxlength: "Mobile should not more than 20 characters"
            },
            txtEmail: {
                maxlength: "Name should not more than 100 characters",
                email: "Please enter valid Email",
            },
            txtAmount: {
                required: "required",
                number: "Please enter valid Amount",
                maxlength: "Amount should not more than 7 characters"
            },
            txtTransactionNumber: {
                required: "required",
                maxlength: "Transaction Number should not more than 100 characters"
            },
            txtZip: {
                number: "Please enter Zip",
                maxlength: "Zip should not more than 20 characters"
            },
            txtPhone: {
                number: "Please enter Phone",
                maxlength: "Phone should not more than 20 characters"
            },
            txtDiscount: {
                number: "Please enter Discount",
                maxlength: "Name should not more than 2 characters"
            },
        },
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },

        submitHandler: function (form) {

            return false;

        }
    });
}

function isNumber(event, obj) {
    if (event) {
        //console.log($(obj).val().indexOf('.'));
        var charCode = (event.which) ? event.which : event.keyCode;

        if (charCode == 110)
            return false;
        if (charCode != 190 && charCode > 31 &&
           (charCode < 48 || charCode > 57) &&
           (charCode < 96 || charCode > 105) &&
           (charCode < 37 || charCode > 40) && charCode != 110 && charCode != 8 && charCode != 46)
            return false;
        else if ((charCode == 190 || charCode == 110) && $(obj).val().indexOf('.') != -1)
            return false;
    }
    return true;
}

function OnChangeOfDicount() {
    var extradiscount = $('#txtDiscount').val();
    var finalamount = amount;
    if (extradiscount != '') {
        finalamount = amount - ((amount * extradiscount) / 100);
    }

    //var totaltax = 0.0;
    //$("#dvTaxdetails").find("input[type=checkbox]").each(function () {
    //    if (!$(this).is(':checked')) {
    //        totaltax = totaltax + parseFloat((this).attr("data-percentage"));
    //    }
    //});
    //console.log(totaltax);

    $('#txtAmount').val(finalamount);
}


