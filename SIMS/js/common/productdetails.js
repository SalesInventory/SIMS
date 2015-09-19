var hfsearchkeyword = '';
var hfName = '';
var hfDescryption = '';
var hfShortCode = '';
var hfVendorName = '';
var hfCompanyName = '';
var hfProductFor = '';
var hfProductColor = '';
var hfProductCategory = '';
var hfProductSize = '';
var hfQuantity = '';
var hfTotalPrice = '';
var hfPurchasePrice = '';
var hfMRP = '';
var hfDiscount = '';

$(document).ready(function () {
    GetProductDetails();
});

function VendorAutoSugetion(datafor) {
    console.log(datafor);
    var hfsearchkeyword = "";
    var isForReoder = false;
    if (datafor == 1)
        hfsearchkeyword = $('#txtVendor').val().trim();
    else {
        hfsearchkeyword = $('#txtRVendor').val().trim();
        isForReoder = true;
    }

    var params = {UserID: 1,sord :"asc",sidx :"Name",rows :-1,page: 1,searchkeyword :"",Name: hfsearchkeyword,BrandName :"",
        Address: "", CityName: "", StateName: "", CountryName: "", Zip: "", Mobile: "", Phone: "", Fax: "", Email: ""
    };

    $.ajax({
        type: "POST",
        url: BaseURL + 'services/vendordetails.asmx/GetVendorDetailsByUserID',
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.indexOf('Fail') == -1) {
                if (response.d.length > 0) {
                    console.log((JSON.parse(response.d)).rows);
                  if (response.d.length > 0 ) {
                     var jsnData = (JSON.parse(response.d)).rows;
                     var sugestOption = _.template('<div class="licensedata cursor-pointer no-padding no-margin" onclick="SetVendorFromAutoSugetion(\'<%=Name%>\',\'<%=VendorID%>\',<%=IsForReoder%>)"><%=Name%></div><hr class="no-margin"/>');
                     var sugestOptions = "";
                     
                     if (jsnData.length == 0) 
                         sugestOptions +='<div class="licensedata cursor-pointer no-padding no-margin text-center"> No Data Found</div>';
                     else {
                       for (i = 0; i < jsnData.length; i++) {
                           jsnData[i].IsForReoder = isForReoder;
                           sugestOptions += sugestOption(jsnData[i]);
                       }
                     }
                     console.log(sugestOptions);
                     if (isForReoder) {
                         if ($('#txtRVendor').val().trim() != '') 
                             $('#rVendorSugest').html(sugestOptions);
                     }
                     else
                     {
                         if ($('#txtVendor').val().trim() != '')
                             $('#vendorSugest').html(sugestOptions);
                     }
                  }
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
function SetVendorFromAutoSugetion(Name, VendorID, IsForReoder) {
    if (IsForReoder) {
        $('#txtRVendor').val(Name);
        $('#txtRVendor').attr("data-vender-id", VendorID);
        $('#rVendorSugest').html('');
    }
    else {
        $('#txtVendor').val(Name);
        $('#txtVendor').attr("data-vender-id", VendorID);
        $('#vendorSugest').html('');
    }
  
}



function GetProductDetails() {

    var params = new Object();
    params.UserID = 1;
    params.sord = $("#hdnSortDirectionProduct").val();
    params.sidx = $("#hdnSortByProduct").val();
    params.rows = 20;
    params.page = $("#hdnCurrentPageProduct").val();


    hfsearchkeyword = $('#txtSearchKeyWord').val().trim();
    hfName = $('#txtNameForSearch').val().trim();
    hfDescryption = $('#txtDescryptionForSearch').val().trim();
    hfShortCode = $('#txtShortCodeForSearch').val().trim();
    hfVendorName = $('#txtVendorNameForSearch').val().trim();
    hfCompanyName = $('#txtCompanyNameForSearch').val().trim();
    hfProductFor = $('#txtProductForForSearch').val().trim();
    hfProductColor = $('#txtProductColorForSearch').val().trim();
    hfProductCategory = $('#txtProductCategoryForSearch').val().trim();
    hfProductSize = $('#txtProductSizeForSearch').val().trim();
    hfQuantity = $('#txtQuantityForSearch').val().trim();
    hfTotalPrice = $('#txtTotalPriceForSearch').val().trim();
    hfPurchasePrice = $('#txtPurchasePriceForSearch').val().trim();
    hfMRP = $('#txtMRPForSearch').val().trim();
    hfDiscount = $('#txtDiscountForSearch').val().trim();

    params.searchkeyword = hfsearchkeyword;
    params.Descryption = hfDescryption;
    params.Name = hfName;
    params.ShortCode = hfShortCode;
    params.VendorName = hfVendorName;
    params.CompanyName = hfCompanyName;
    params.ProductFor = hfProductFor;
    params.ProductColor = hfProductColor;
    params.ProductCategory = hfProductCategory;
    params.ProductSize = hfProductSize;
    params.Quantity = hfQuantity;
    params.TotalPrice = hfTotalPrice;
    params.PurchasePrice = hfPurchasePrice;
    params.MRP = hfMRP;
    params.Discount = hfDiscount;

    //console.log(params);
   $.ajax({
       type: "POST",
       url: BaseURL + 'services/productdetails.asmx/GetProductByUserID',
       data: JSON.stringify(params),
       contentType: "application/json; charset=utf-8",
       dataType: "json",
       success: function (response) {
           if (response.d.indexOf('Fail') == -1) {
               if (response.d.length > 0) {
                   //console.log(JSON.parse(response.d));
                   DataFormationofProduct(response.d);
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

function DataFormationofProduct(result) {
    var jsnData = JSON.parse(result);
    $('#tbodyProduct').html('');
    $("#dvPagerProduct").html("&nbsp;");
    if (jsnData.rows.length > 0) {
        var htmlTdName = _.template('<td><strong><%=Name%></strong></td>');
        var htmlTdDescryption = _.template('<td><%=Descryption%></td>');
        var htmlTdShortCode = _.template('<td><%=ShortCode%></td>');
        var htmlTdVendorName = _.template('<td><%=VendorName%></td>');
        var htmlTdProductCompanyName = _.template('<td><%=ProductCompanyName%></td>');
        var htmlTdProductFor = _.template('<td><%=ProductFor%></td>');
        var htmlTdProductColor = _.template('<td><%=ProductColor%></td>');
        var htmlTdProductCategory = _.template('<td><%=ProductCategory%></td>');
        var htmlTdProductSize = _.template('<td><%=ProductSize%></td>');
        var htmlTdQuantity = _.template('<td><%=Quantity%></td>');
        var htmlTdTotalPrice = _.template('<td><%=TotalPrice%></td>');
        var htmlTdPurchasePrice = _.template('<td><%=PurchasePrice%></td>');
        var htmlTdMRP = _.template('<td><%=MRP%></td>');
        var htmlTdDiscount = _.template('<td><%=Discount%></td>');

    for (i = 0; i < jsnData.rows.length; i++) {

         var buttonlnk = '';
        buttonlnk = '<button id="btnedit" class="btn-action padding-15 btn-edit" type="button" onclick="EditProductDetails(this,' + jsnData.rows[i].VendorID + ');return false;" rel="tooltip" title="" data-placement="bottom" data-original-title="Edit Product Details"></button>';
        jsnData.rows[i].action = buttonlnk;

        var tr = $('<tr>');
        if (i == 0)
            tr = $('<tr class="selectedRow" style="background: none repeat scroll 0% 0% #F2FAFD !important;border: 1px solid #9CD6F3 !important;">');

        $(tr).attr("data-product-id", jsnData.rows[i].ProductID);
        var alltds = htmlTdName(jsnData.rows[i]) + htmlTdDescryption(jsnData.rows[i]) + htmlTdShortCode(jsnData.rows[i]) + htmlTdVendorName(jsnData.rows[i]) +
            htmlTdProductCompanyName(jsnData.rows[i]) + htmlTdProductFor(jsnData.rows[i]) + htmlTdProductColor(jsnData.rows[i]) + htmlTdProductCategory(jsnData.rows[i]) +
            htmlTdProductSize(jsnData.rows[i]) + htmlTdQuantity(jsnData.rows[i]) + htmlTdTotalPrice(jsnData.rows[i]) + htmlTdPurchasePrice(jsnData.rows[i]) +
            htmlTdMRP(jsnData.rows[i]) + htmlTdDiscount(jsnData.rows[i]);
        tr.append(alltds);
        //ColorCode: "#00FFFF"
        var tdActions = $('<td>');
        //tdActions.append(jsnData.rows[i].action);
        tr.append(tdActions);
        $('#tbodyProduct').append(tr);
    }
    }
    $("[rel=tooltip]").tooltipnoConflict();

    pager('Pager', {
        Grid: null,
        PagerContainer: $('#dvPagerProduct'),
        TotalRecords: jsnData.currrecords,
        CurrentPage: jsnData.currpage,
        TotalPages: jsnData.totalpages,
        OnCompleted: function () {
        },
        ReloadGrid: 'ReloadGridProductList'
        //function (currentPage) { ReloadGridAppraisalList(currentPage) }
    });

    ////Do not change this width number(Main.css ref. Line Num : 5800)
    //if (window.innerWidth > 991 && window.innerWidth < 1900) {
    //    $("#dvSliderBarForAppraisalDetail").removeClass("hidden-md hidden-lg");
    //    //$("#btnsliderCloseAppraiserImg").removeClass("hidden-md hidden-lg");
    //    $("#btnsliderCloseAppraiser").removeClass("hidden-md hidden-lg");
    //}
}

function ReloadGridProductList(currentPage) {
    $("#hdnCurrentPageProduct").val(currentPage);
    LoadGridForAppraisalList(0, false, false);
}

function ReloadData() {
    //Function Which will called from statuschange js

    if (!(hfsearchkeyword == $('#txtSearchKeyWord').val().trim() &&
        hfName == $('#txtNameForSearch').val().trim() &&
        hfDescryption == $('#txtDescryptionForSearch').val().trim() &&
        hfShortCode == $('#txtShortCodeForSearch').val().trim() &&
        hfVendorName == $('#txtVendorNameForSearch').val().trim() &&
        hfCompanyName == $('#txtCompanyNameForSearch').val().trim() &&
        hfProductFor == $('#txtProductForForSearch').val().trim() &&
        hfProductColor == $('#txtProductColorForSearch').val().trim() &&
        hfProductCategory == $('#txtProductCategoryForSearch').val().trim() &&
        hfProductSize == $('#txtProductSizeForSearch').val().trim() &&
        hfQuantity == $('#txtQuantityForSearch').val().trim() &&
        hfTotalPrice == $('#txtTotalPriceForSearch').val().trim() &&
        hfPurchasePrice == $('#txtPurchasePriceForSearch').val().trim() &&
        hfMRP == $('#txtMRPForSearch').val().trim() &&
        hfDiscount == $('#txtDiscountForSearch').val().trim())) {
        $("#hdnCurrentPageAppraisal").val(1);
    }
    GetProductDetails();
}

function SortBy(sortby) {
    $('.gridarrowup').addClass('gridarrowupdown');
    $('.gridarrowdown').addClass('gridarrowupdown');
    $('.gridarrowupdown').removeClass('gridarrowdown gridarrowup');

    if (sortby == $("#hdnSortByProduct").val()) {
        if ($("#hdnSortDirectionProduct").val() == "asc") {
            $("#hdnSortDirectionProduct").val("desc");
            $('#lnkProductSortBy' + sortby).removeClass("gridarrowupdown gridarrowup");
            $('#lnkProductSortBy' + sortby).addClass("gridarrowdown");
        }
        else {
            $("#hdnSortDirectionProduct").val("asc")
            $('#lnkProductSortBy' + sortby).removeClass("gridarrowupdown gridarrowdown");
            $('#lnkProductSortBy' + sortby).addClass("gridarrowup");
        }
    }
    else {
        $("#hdnSortByProduct").val(sortby);
        $("#hdnSortDirectionProduct").val("asc");
        $('#lnkProductSortBy' + sortby).removeClass("gridarrowupdown gridarrowdown");
        $('#lnkProductSortBy' + sortby).addClass("gridarrowup");
    }
    GetProductDetails();

}

function ClearProductSearchInputs() {
    hfsearchkeyword = '';
    hfName = '';
    hfDescryption = '';
    hfShortCode = '';
    hfVendorName = '';
    hfCompanyName = '';
    hfProductFor = '';
    hfProductColor = '';
    hfProductCategory ='';
    hfProductSize = '';
    hfQuantity = '';
    hfTotalPrice = '';
    hfPurchasePrice = '';
    hfMRP = '';
    hfDiscount = '';

    $('#txtSearchKeyWord,#txtNameForSearch,#txtDescryptionForSearch,#txtShortCodeForSearch,#txtVendorNameForSearch,#txtProductForForSearch').val('');
    $('#txtProductColorForSearch,#txtProductCategoryForSearch,#txtProductSizeForSearch,#txtQuantityForSearch,#txtTotalPriceForSearch').val('');
    $('#txtPurchasePriceForSearch,#txtMRPForSearch,#txtDiscountForSearch').val('');
  
    GetProductDetails();
}