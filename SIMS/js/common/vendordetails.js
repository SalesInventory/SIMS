var hfsearchkeyword = '';
var hfName = '';
var hfBrandName = '';
var hfAddress = '';
var hfCityName = '';
var hfStateName = '';
var hfCountryName = '';
var hfZip = '';
var hfMobile = '';
var hfPhone = '';
var hfFax = '';
var hfEmail = '';

$(document).ready(function () {
    GetVendorDetails();
});

function GetVendorDetails() {
    var params = new Object();
    params.UserID = 1;
    params.sord = $("#hdnSortDirectionVendor").val();
    params.sidx = $("#hdnSortByVendor").val();
    params.rows = 20;
    params.page = $("#hdnCurrentPageVendor").val();


    hfsearchkeyword = $('#txtSearchKeyWord').val().trim();
    hfName = $('#txtNameForSearch').val().trim();
    hfBrandName = $('#txtBrandNameForSearch').val().trim();
    hfAddress = $('#txtAddressForSearch').val().trim();
    hfCityName = $('#txtCityNameForSearch').val().trim();
    hfStateName = $('#txtStateNameForSearch').val().trim();
    hfCountryName = $('#txtCountryNameForSearch').val().trim();
    hfZip = $('#txtZipForSearch').val().trim();
    hfMobile = $('#txtMobileForSearch').val().trim();
    hfPhone = $('#txtPhoneForSearch').val().trim();
    hfFax = $('#txtFaxForSearch').val().trim();
    hfEmail = $('#txtEmailForSearch').val().trim();

    params.searchkeyword = hfsearchkeyword;
    params.Name = hfName;
    params.BrandName = hfBrandName;
    params.Address = hfAddress;
    params.CityName = hfCityName;
    params.StateName = hfStateName;
    params.CountryName = hfCountryName;
    params.Zip = hfZip;
    params.Mobile = hfMobile;
    params.Phone = hfPhone;
    params.Fax = hfFax;
    params.Email = hfEmail;

    $.ajax({
        type: "POST",
        url: BaseURL + 'services/vendordetails.asmx/GetVendorDetailsByUserID',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('Fail') == -1) {
                if (response.d.length > 0) {
                    DataFormationofVendor(response.d);
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

function DataFormationofVendor(result) {
    var jsnData = JSON.parse(result);
    $('#tbodyVendor').html('');
    $("#dvPagerVendor").html("&nbsp;");

    for (i = 0; i < jsnData.rows.length; i++) {

        var buttonlnk = '';

        //buttonlnk = '<button type="button" onclick="AcceptDeclinePopUp(' + jsnData.rows[i].ID + ',' + jsnData.rows[i].StatusTrackingID + ',' + jsnData.rows[i].InstructionSettingIsActive + ',\'' + jsnData.rows[i].FileNum + '\',\'' + AppraisalListInspectionDate + '\',\'' + AppraisalListInspectionTime + '\',\'' + AppraisalListEstimatedDate + '\',3,\'' + jsnData.rows[i].AssignedToUserID + '\',\'' + jsnData.rows[i].DueDate + '\')" rel="tooltip" title="" data-placement="bottom" data-original-title="Accept For Me" class="btn-action padding-15 btn-accept" ></button>' +
        //                   '<button type="button" onclick="OpenOrderAssignmentModal(' + jsnData.rows[i].ID + ',\'' + jsnData.rows[i].AssignedToUserID + '\',' + jsnData.rows[i].ProcessStatusID + ')" rel="tooltip" title="" data-placement="bottom" data-original-title="Re-assign" class="btn-action padding-15 btn-reassign" ></button>' +
        //                   '<button type="button" onclick="AcceptDeclinePopUp(' + jsnData.rows[i].ID + ',' + jsnData.rows[i].StatusTrackingID + ',' + jsnData.rows[i].InstructionSettingIsActive + ',\'' + jsnData.rows[i].FileNum + '\',\'' + AppraisalListInspectionDate + '\',\'' + AppraisalListInspectionTime + '\',\'' + AppraisalListEstimatedDate + '\',5,\'' + jsnData.rows[i].AssignedToUserID + '\',\'' + jsnData.rows[i].DueDate + '\')" rel="tooltip" title="" data-placement="bottom" data-original-title="Accept With Conditions" class="btn-action padding-15 btn-accept-condition" ></button>' +
        //                   '<button type="button" onclick="AcceptDeclinePopUp(' + jsnData.rows[i].ID + ',' + jsnData.rows[i].StatusTrackingID + ',' + jsnData.rows[i].InstructionSettingIsActive + ',\'' + jsnData.rows[i].FileNum + '\',\'' + AppraisalListInspectionDate + '\',\'' + AppraisalListInspectionTime + '\',\'' + AppraisalListEstimatedDate + '\',6,\'' + jsnData.rows[i].AssignedToUserID + '\',\'' + jsnData.rows[i].DueDate + '\')" rel="tooltip" title="" data-placement="bottom" data-original-title="Decline" class="btn-action padding-15 btn-decline" ></button>';

        jsnData.rows[i].FileNum = '<a href="javascript:void(0);" id="alnk' + jsnData.rows[i].ID + '" class="nocloseslider btn btn-link btn-xs" onclick="OpenSlideBar(this,' + jsnData.rows[i].ID + ',\'' + jsnData.rows[i].FileNum + '\');">' + jsnData.rows[i].FileNum + '</a>';

        jsnData.rows[i].action = buttonlnk;

        var tr = $('<tr>');
        if (i == 0)
            tr = $('<tr class="selectedRow" style="background: none repeat scroll 0% 0% #F2FAFD !important;border: 1px solid #9CD6F3 !important;">');

        var tdName = $('<td>');
        tdName.append($('<strong>').append(jsnData.rows[i].Name));
        tr.append(tdName);

        var tdBrandName = $('<td>');
        tdBrandName.text(jsnData.rows[i].BrandName);
        tr.append(tdBrandName);

        var tdAddress = $('<td>');
        tdAddress.text(jsnData.rows[i].Address);
        tr.append(tdAddress);

        var tdCityName = $('<td>');
        tdCityName.text(jsnData.rows[i].CityName);
        tr.append(tdCityName);

        var tdStateName = $('<td>');
        tdStateName.text(jsnData.rows[i].StateName);
        tr.append(tdStateName);

        var tdCountryName = $('<td>');
        tdCountryName.text(jsnData.rows[i].CountryName);
        tr.append(tdCountryName);

        var tdZip = $('<td>');
        tdZip.text(jsnData.rows[i].Zip);
        tr.append(tdZip);

        var tdMobile = $('<td>');
        tdMobile.text(jsnData.rows[i].Mobile);
        tr.append(tdMobile);

        var tdPhone = $('<td>');
        tdPhone.text(jsnData.rows[i].Phone);
        tr.append(tdPhone);

        var tdFax = $('<td>');
        tdFax.text(jsnData.rows[i].Fax);
        tr.append(tdFax);

        var tdEmail = $('<td>');
        tdEmail.text(jsnData.rows[i].Email);
        tr.append(tdEmail);

        var tdActions = $('<td>');
        tdActions.append(jsnData.rows[i].action);
        tr.append(tdActions);

        $('#tbodyVendor').append(tr);
    }
    $("[rel=tooltip]").tooltipnoConflict();

    pager('Pager', {
        Grid: null,
        PagerContainer: $('#dvPagerVendor'),
        TotalRecords: jsnData.currrecords,
        CurrentPage: jsnData.currpage,
        TotalPages: jsnData.totalpages,
        OnCompleted: function () {
        },
        ReloadGrid: 'ReloadGridVendorList'
        //function (currentPage) { ReloadGridAppraisalList(currentPage) }
    });
   
    ////Do not change this width number(Main.css ref. Line Num : 5800)
    //if (window.innerWidth > 991 && window.innerWidth < 1900) {
    //    $("#dvSliderBarForAppraisalDetail").removeClass("hidden-md hidden-lg");
    //    //$("#btnsliderCloseAppraiserImg").removeClass("hidden-md hidden-lg");
    //    $("#btnsliderCloseAppraiser").removeClass("hidden-md hidden-lg");
    //}
}

function ReloadGridVendorList(currentPage) {
    $("#hdnCurrentPageVendor").val(currentPage);
    LoadGridForAppraisalList(0, false, false);
}

function ReloadData() {
    //Function Which will called from statuschange js
   
    if (!(hfsearchkeyword == $('#txtSearchKeyWord').val().trim() &&
        hfsearchkeyword == $('#txtSearchKeyWord').val().trim() &&
        hfName == $('#txtNameForSearch').val().trim() &&
        hfBrandName == $('#txtBrandNameForSearch').val().trim() &&
        hfAddress == $('#txtAddressForSearch').val().trim() &&
        hfCityName == $('#txtCityNameForSearch').val().trim() &&
        hfStateName == $('#txtStateNameForSearch').val().trim() &&
        hfCountryName == $('#txtCountryNameForSearch').val().trim() &&
        hfZip == $('#txtZipForSearch').val().trim() &&
        hfMobile == $('#txtMobileForSearch').val().trim() &&
        hfPhone == $('#txtPhoneForSearch').val().trim() &&
        hfFax == $('#txtFaxForSearch').val().trim() &&
        hfEmail == $('#txtEmailForSearch').val().trim())) {
        $("#hdnCurrentPageAppraisal").val(1);
    }
    GetVendorDetails();
}

function SortBy(sortby) {
    $('.gridarrowup').addClass('gridarrowupdown');
    $('.gridarrowdown').addClass('gridarrowupdown');
    $('.gridarrowupdown').removeClass('gridarrowdown gridarrowup');

    if (sortby == $("#hdnSortByVendor").val()) {
        if ($("#hdnSortDirectionVendor").val() == "asc") {
            $("#hdnSortDirectionVendor").val("desc");
            $('#lnkVendorSortBy' + sortby).removeClass("gridarrowupdown gridarrowup");
            $('#lnkVendorSortBy' + sortby).addClass("gridarrowdown");
        }
        else {
            $("#hdnSortDirectionVendor").val("asc")
            $('#lnkVendorSortBy' + sortby).removeClass("gridarrowupdown gridarrowdown");
            $('#lnkVendorSortBy' + sortby).addClass("gridarrowup");
        }
    }
    else {
        $("#hdnSortByVendor").val(sortby);
        $("#hdnSortDirectionVendor").val("asc");
        $('#lnkVendorSortBy' + sortby).removeClass("gridarrowupdown gridarrowdown");
        $('#lnkVendorSortBy' + sortby).addClass("gridarrowup");
    }
    GetVendorDetails();
}

function ClearVendorSearchInputs() {
    hfsearchkeyword = '';
    hfName = '';
    hfBrandName = '';
    hfAddress = '';
    hfCityName = '';
    hfStateName = '';
    hfCountryName = '';
    hfZip = '';
    hfMobile = '';
    hfPhone = '';
    hfFax = '';
    hfEmail = '';

    $('#txtSearchKeyWord').val('');
    $('#txtNameForSearch').val('');
    $('#txtBrandNameForSearch').val('');
    $('#txtAddressForSearch').val('');
    $('#txtCityNameForSearch').val('');
    $('#txtStateNameForSearch').val('');
    $('#txtCountryNameForSearch').val('');
    $('#txtZipForSearch').val('');
    $('#txtMobileForSearch').val('');
    $('#txtPhoneForSearch').val('');
    $('#txtFaxForSearch').val('');
    $('#txtEmailForSearch').val('');

    GetVendorDetails();
}

