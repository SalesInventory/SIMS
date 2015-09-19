<%@ Page Title="" Language="C#" MasterPageFile="~/common/masters/mstcommon.Master" AutoEventWireup="true" CodeBehind="productdetails.aspx.cs" Inherits="SIMS.common.productdetails" %>

<%@ Register Src="~/common/controls/ctladdproduct.ascx" TagPrefix="uc1" TagName="ctladdproduct" %>




<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
      <style type="text/css">
        .state-error.form-control {
            background: none repeat scroll 0% 0% #FFF0F0 !important;
        }

        .desktop-record-columns li {
            border-left: 1px solid #eeeeee;
            border-right: 1px solid #f1f1f1;
            border-top: 1px solid #f1f1f1;
            margin-bottom: 0px;
            margin-left: 0px;
            padding: 11px;
        }

        .appraisaldetailtab ul li {
            min-width: 8% !important;
        }

        .dashboard-table tr.selectedRow:hover:first-child {
            background: none repeat scroll 0% 0% transparent !important;
            border: medium none !important;
        }

        .selectedRow {
            background: none repeat scroll 0% 0% #F2FAFD !important;
            border: 1px solid #9CD6F3 !important;
        }

            .selectedRow:hover {
                background: none repeat scroll 0% 0% #F2FAFD !important;
                border: 1px solid #9CD6F3 !important;
            }

        /*tr.selectedRow > td {
            border-top: 1px solid #9CD6F3 !important;
        }*/
        /*.table > thead > tr.selectedRow > th, .table > thead > tr.selectedRow > td, .table > tbody > tr.selectedRow > th, .table > tbody > tr.selectedRow > td, .table > tfoot > tr.selectedRow > th, .table > tfoot > tr.selectedRow > td {
            border-top: 1px solid #9CD6F3 !important;
        }*/

        [data-tip] {
            position: relative;
        }

            [data-tip]:before {
                content: '';
                display: none;
                content: '';
                display: none;
                border-left: 5px solid transparent;
                border-right: 5px solid transparent;
                border-bottom: 5px solid #1a1a1a;
                position: absolute;
                top: 30px;
                left: 35px;
                z-index: 8;
                font-size: 0;
                line-height: 0;
                width: 0;
                height: 0;
                position: absolute;
                top: 30px;
                left: 35px;
                z-index: 8;
                font-size: 0;
                line-height: 0;
                width: 0;
                height: 0;
            }

            [data-tip]:after {
                display: none;
                content: attr(data-tip);
                position: absolute;
                top: 35px;
                left: 0px;
                padding: 3px 8px;
                background: #1a1a1a;
                color: #fff;
                z-index: 9;
                font-size: 12px;
                font-weight: normal;
                line-height: 1.4;
                line-height: 18px;
                -webkit-border-radius: 3px;
                -moz-border-radius: 3px;
                border-radius: 3px;
                white-space: nowrap;
                word-wrap: normal;
            }

            [data-tip]:hover:before,
            [data-tip]:hover:after {
                display: block;
            }

        /*.appraisals {
            background-image: url(../img/appraisals.png);
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpContent" runat="server">
    <script type="text/javascript">
        //Do not remove this
        $("#dvMaster").removeClass("col-el-12");
        $("#dvMaster").addClass("col-el-8");
    </script>
    <div class="dashboard-search">
        <div class="col-lg-8 col-sm-6 step-1">
            <div class="pull-left">
                <a href="#">
                    <img src="../img/icons/btn-search.svg" alt="" height="" width=""></a>
            </div>
            <div class="col-md-12 col-xs-12">
                <input class="SearchAppraisal" placeholder="Search for any kind of details" id="txtSearchKeyWord" maxlength="100" type="text">
            </div>
        </div>
        <div class="col-lg-4 col-sm-6 step-2 col-xs-12 text-right">
            <ul class=" list-inline">
                <li>
                    <button type="submit" class="btn btn-default appraisal-btn" onclick="OpenProductModal(0);return false;">
                        <svg xmlns:xlink="http://www.w3.org/1999/xlink" xmlns="http://www.w3.org/2000/svg" version="1.1" viewBox="0 0 15 15" width="20px" height="26">
                            <g fill-rule="evenodd" stroke-width="1" stroke="none">
                                <g fill="#17A1E5" transform="translate(-1598.000000, -152.000000)">
                                    <g transform="translate(0.000000, 80.000000)">
                                        <g transform="translate(1589.000000, 62.000000)">
                                            <path id="icon:-plus" d="M16.012,17.01 L16.012,14.522 C16.012,14.234 16.23,14.001 16.5,14.001 C16.77,14.001 16.988,14.234 16.988,14.522 L16.988,17.01 L19.477,17.01 C19.765,17.01 19.998,17.229 19.998,17.498 C19.998,17.769 19.765,17.987 19.477,17.987 L16.988,17.987 L16.988,20.476 C16.988,20.764 16.77,20.997 16.5,20.997 C16.23,20.997 16.012,20.764 16.012,20.476 L16.012,17.987 L13.523,17.987 C13.235,17.987 13.002,17.769 13.002,17.498 C13.002,17.229 13.235,17.01 13.523,17.01 L16.012,17.01 Z M16.5,9.999 C12.358,9.999 9,13.356 9,17.498 C9,21.641 12.358,24.999 16.5,24.999 C20.642,24.999 24,21.641 24,17.498 C24,13.356 20.642,9.999 16.5,9.999 Z M16.5,10.999 C12.91,10.999 10,13.909 10,17.498 C10,21.089 12.91,23.999 16.5,23.999 C20.09,23.999 23,21.089 23,17.498 C23,13.909 20.09,10.999 16.5,10.999 Z" class="svgicn" />
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </svg>
                        <span>New Product</span></button></li>
                <li>
                    <button type="button" class="btn btn-default appraisal-btn" onclick="ClearProductSearchInputs();return false;">
                        <svg width="16px" height="16px" viewBox="0 0 17 16" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                <g transform="translate(-873.000000, -760.000000)" fill="#17A1E5">
                                    <g transform="translate(599.000000, 90.000000)">
                                        <g id="btn:-create" transform="translate(265.000000, 661.000000)">
                                            <path d="M17.4845473,18.7653727 L14.847,16.141 C14.653,15.948 14.34,15.948 14.147,16.141 C13.953,16.333 13.953,16.645 14.147,16.838 L17.0316433,19.7082297 C17.0543365,19.7510387 17.0837887,19.791162 17.12,19.827 C17.2302489,19.9361182 17.3785367,19.9835432 17.5216698,19.9692751 C17.6411709,19.9640643 17.7590274,19.9159726 17.85,19.825 C17.8821517,19.7930149 17.9089472,19.7576996 17.9303867,19.7201636 L24.848,12.838 C25.042,12.646 25.042,12.332 24.848,12.14 C24.653,11.946 24.339,11.946 24.145,12.14 L17.4845473,18.7653727 Z M24.8765325,15.6539709 C24.9504907,16.0912563 24.989,16.5406198 24.989,16.999 C24.989,21.417 21.41,24.998 16.994,24.998 C12.579,24.998 9,21.417 9,16.999 C9,12.58 12.579,8.999 16.994,8.999 C19.0206793,8.999 20.8710647,9.75325165 22.2801015,10.9966037 L21.561033,11.6957233 C20.3353665,10.6383497 18.7392468,9.999 16.994,9.999 C13.13,9.999 9.997,13.133 9.997,16.999 C9.997,20.865 13.13,23.999 16.994,23.999 C20.858,23.999 23.991,20.865 23.991,16.999 C23.991,16.8412829 23.9857857,16.684784 23.9755202,16.5296666 L24.8765325,15.6539709 L24.8765325,15.6539709 Z" id="icon:-check" class="svgicn"></path>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </svg>
                        <span>Reset Search</span></button>
                </li>

            </ul>
            &nbsp;    
        </div>
        <div class="clearfix"></div>
    </div>
   <div class="table-responsive table-drop" data-pattern="priority-columns" style="overflow-x: visible !important">
        <form>
            <table class="table dashboard-table" id="tblProductList">
                <thead>
                    <tr>
                        <th>
                            <div class="form-group">
                                <label for="dname">Product Name</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control" maxlength="100" id="txtNameForSearch" placeholder="Product Name" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">Descryption</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control" maxlength="100" id="txtDescryptionForSearch" placeholder="Descryption" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">ShortCode</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control" maxlength="100" id="txtShortCodeForSearch" placeholder="ShortCode" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">VendorName</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control" maxlength="100" id="txtVendorNameForSearch" placeholder="VendorName" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">Company</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control" maxlength="100" id="txtCompanyNameForSearch" placeholder="Company" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">For</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control" maxlength="100" id="txtProductForForSearch" placeholder="For" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">Color</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control " maxlength="100" id="txtProductColorForSearch" placeholder="Color" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">ProductCategory</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control " maxlength="100" id="txtProductCategoryForSearch" placeholder="ProductCategory" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">Size</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control " maxlength="100" id="txtProductSizeForSearch" placeholder="Size" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">Quantity</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control amount-only" maxlength="100" id="txtQuantityForSearch" placeholder="Quantity" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">TotalPrice</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control amount-only" maxlength="100" id="txtTotalPriceForSearch" placeholder="TotalPrice" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">PurchasePrice</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control amount-only" maxlength="100" id="txtPurchasePriceForSearch" placeholder="PurchasePrice" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">MRP</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control amount-only" maxlength="100" id="txtMRPForSearch" placeholder="MRP" />
                                </div>
                            </div>
                        </th>
                         <th>
                            <div class="form-group">
                                <label for="dname">Discount</label>
                                <div data-tip="Enter text to filter">
                                    <input type="text" class="SearchAppraisal form-control amount-only" maxlength="100" id="txtDiscountForSearch" placeholder="Discount" />
                                </div>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">Actions</label>
                            </div>
                        </th>
                    </tr>
                </thead>
                <tr class="text-center">
                    <th class="text-center">
                        <a id="lnkProductSortByName" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('Name');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByDescryption" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('Descryption');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByShortCode" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('ShortCode');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByVendorName" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('VendorName');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByCompanyName" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('CompanyName');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByProductFor" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('ProductFor');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByProductColor" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('ProductColor');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByProductCategory" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('ProductCategory');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByProductSize" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('ProductSize');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="text-center">
                        <a id="lnkProductSortByQuantity" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('Quantity');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                      <th class="text-center">
                        <a id="lnkProductSortByTotalPrice" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('TotalPrice');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                      <th class="text-center">
                        <a id="lnkProductSortByPurchasePrice" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('PurchasePrice');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                      <th class="text-center">
                        <a id="lnkProductSortByMRP" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('MRP');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                      <th class="text-center">
                        <a id="lnkProductSortByDiscount" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('Discount');">
                            <%--<img src="../img/icons/arrows.svg" class="svg-small" alt="">--%></a>
                    </th>
                    <th class="thAppraisalAction text-center">&nbsp;
                    </th>
                </tr>
                <tbody id="tbodyProduct">
                </tbody>
            </table>
        </form>
    </div>
    <div>&nbsp;</div>
    <input type="hidden" id="hdnCurrentPageProduct" value="1" />
    <input type="hidden" id="hdnSortDirectionProduct" value="asc" />
    <input type="hidden" id="hdnSortByProduct" value="Name" />
    <nav class="text-center indexing" id="dvPagerVendor">&nbsp;</nav>
    <script type="text/javascript">
        <%--var UserID = "<%= UserID %>";
        var UserType = "<%= UserType %>";
        var FirstName = "<%= FirstName%>";
        var LastName = "<%= LastName%>";
        var AccountTypeID = "<%= AccountTypeID%>";
        var UserStatus = "<%= UserStatus%>";
        var UserProfileImage = "<%= UserProfileImage %>";--%>

        $(".SearchAppraisal").keypress(function (event) {
            if (event.keyCode == 13) {
                ReloadData();
                return false;
            }
        });

        $(".amount-only").keydown(function (event) {
            if (event.keyCode != 13) {
                if (event.shiftKey == true) {
                    event.preventDefault();
                }
                // Allow Only: keyboard 0-9, numpad 0-9, backspace, tab, left arrow, right arrow, delete
                if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 46 || event.keyCode == 190 || event.keyCode == 110) {
                    // Allow normal operation
                } else {
                    // Prevent the rest
                    event.preventDefault();
                }
            }
        });

    </script>
     <script src="<%=ResolveUrl("~/js/underscore-min.js") %>"></script>
     <script src='<%=ResolveUrl("~/js/common/productdetails.js") %>'></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContentRight" runat="server">
    <uc1:ctladdproduct runat="server" id="ctladdproduct" />
</asp:Content>
