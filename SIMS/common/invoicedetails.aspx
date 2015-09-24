<%@ Page Title="" Language="C#" MasterPageFile="~/common/masters/mstcommon.Master" AutoEventWireup="true" CodeBehind="invoicedetails.aspx.cs" Inherits="SIMS.common.invoicedetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <script src='<%=ResolveUrl("~/js/common/invoicedetails.js")%>'></script>

    <style type="text/css">
        .table-responsive .form-group {
            width: 100%;
            padding: 0px !important;
            border: none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpContent" runat="server">
    <div class="page-wrapper col-md-10 col-md-offset-1 col-sm-10 col-xs-12">
        <%--<div class="col-xs-12">
            Bill Amount: 0.0
        </div>--%>
        <div class="wrapper-titles">
            <%--<h3 class="text-uppercase margin-top-5 text-center">Invoice Details</h3>--%>
        </div>
        <div class="clearfix"></div>
        <div>
            <form id="frmProfileDetail" class="signup-form-2" enctype="multipart/form-data" role="form" tabno="1">
                <div id="AppraiserStep1" style="">
                    <div class="divider">
                        <div class="divider-break"></div>
                    </div>
                    <h3 class="text-uppercase margin-top-5 text-center">Invoice Details</h3>
                    <%--<div class="divider col-12 clearfix no-padding" style="padding: 0px !important; border: none !important;">
                        <div class="form-group no-padding" style="padding: 5px 8px !important;">
                            <label for="lblFirstName">Product Barcode Number</label>
                            <input class="form-control" id="txtProductBarcodeNumber" name="txtProductBarcodeNumber" placeholder="Product Barcode Number" type="text" />
                        </div>
                    </div>--%>
                    <div class="divider col-3 clearfix">
                        <div class="form-group">
                            <label for="lblFirstName">Product Barcode Number</label>
                            <input class="form-control" id="txtProductBarcodeNumber" name="txtProductBarcodeNumber" placeholder="Product Barcode Number" type="text" />
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Date</label>
                            <input class="form-control datepicker" id="txtInvoiceDate" name="txtInvoiceDate" placeholder="Date" type="text" />
                        </div>
                        <div class="form-group no-padding" style="padding: 5px 8px !important;">
                            <label for="lblFirstName">Invoice Status</label>
                            <select class="selectpicker form-control" id="selInvoiceStatus" onchange="">
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Invoice Number</label>
                            <input class="form-control" id="txtInvoiceNumber" name="txtInvoiceNumber" placeholder="Invoice Number" type="text" />
                        </div>
                    </div>
                    <div class="table-responsive" data-pattern="priority-columns">
                        <table class="table dashboard-table" id="tblProductList">
                            <thead>
                                <tr>
                                    <th>
                                        <div class="form-group">
                                            <label for="dname">Barcode Number</label>
                                        </div>
                                    </th>
                                    <th>
                                        <div class="form-group">
                                            <label for="dname">MRP</label>
                                        </div>
                                    </th>
                                    <th>
                                        <div class="form-group">
                                            <label for="dname">Discount</label>
                                        </div>
                                    </th>
                                    <th>
                                        <div class="form-group">
                                            <label for="dname">Quantity</label>
                                        </div>
                                    </th>
                                    <th>
                                        <div class="form-group">
                                            <label for="dname">Action</label>
                                        </div>
                                    </th>
                                </tr>
                            </thead>
                            <%--<tr class="text-center">
                                <th class="text-center">
                                    <a id="lnkCoverageSortByStateCode" href="javascript:void(0);" class="svg-small gridarrowup" onclick="SortBy('StateCode');"></a>
                                </th>

                                <th class="text-center">
                                    <a id="lnkCoverageSortByLicense" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('License');"></a>
                                </th>
                                <th class="text-center">&nbsp;
                                </th>
                                <th class="text-center">
                                    <a id="lnkCoverageSortByFHAApproved" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('FHAApproved');"></a>
                                </th>
                                <th class="text-center">
                                    <a id="lnkCoverageSortByCommercial" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('Commercial');"></a>
                                </th>
                                <th class="text-center">
                                    <a id="lnkCoverageSortByLicenseExpirationDate" href="javascript:void(0);" class="svg-small gridarrowupdown" onclick="SortBy('LicenseExpirationDate');"></a>
                                </th>
                                <th class="text-center">&nbsp;
                                </th>
                                <th class="text-center">&nbsp;
                                </th>
                                <th class="text-center">&nbsp;
                                </th>
                            </tr>--%>
                            <tbody id="tbodyProduct">
                            </tbody>
                        </table>
                    </div>
                    <div class="divider">
                        <div class="divider-break"></div>
                    </div>
                    <h3 class="text-uppercase margin-top-5 text-center">Customer Details</h3>
                    <div class="divider col-3 clearfix">
                        <div class="form-group">
                            <label for="lblFirstName">First Name</label>
                            <input class="form-control" id="txtFirstName" name="txtFirstName" placeholder="First Name" type="text" />
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Last Name</label>
                            <input class="form-control" id="txtLastName" name="txtLastName" placeholder="Last Name" type="text" />
                        </div>
                        <div class="form-group no-padding" style="padding: 5px 8px !important;">
                            <label for="lblFirstName">Address</label>
                            <input class="form-control" id="txtAddress" name="txtAddress" placeholder="Address" type="text" />
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Mobile</label>
                            <input class="form-control" id="txtMobile" name="txtMobile" placeholder="Mobile" type="text" />
                        </div>
                    </div>
                    
                    <div class="divider col-3 clearfix">
                        <div class="form-group">
                            <label for="lblFirstName">Zip</label>
                            <input class="form-control" id="txtZip" name="txtZip" placeholder="Zip" type="text" />
                        </div>
                        <div class="form-group">
                            <label for="lblCompanyName">Country</label>
                            <select class="selectpicker form-control" id="selCountry" onchange="ShowState();">
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="lblCompanyName">State</label>
                            <select class="selectpicker form-control" id="selState" onchange="ShowCity();">
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="lblCompanyName">City</label>
                            <select class="selectpicker form-control" id="selCity" onchange="">
                            </select>
                        </div>

                        <div class="form-group">
                            <label for="lblFirstName">Phone</label>
                            <input class="form-control" id="txtPhone" name="txtPhone" placeholder="Phone" type="text" />
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Birth Date</label>
                            <input class="form-controlr datepicker" id="txtBirthDate" name="txtBirthDate" placeholder="Date" type="text" />
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Email</label>
                            <input class="form-control" id="txtEmail" name="txtEmail" placeholder="Email" type="text" />
                        </div>
                        <div class="form-group">
                        </div>
                    </div>
                    <%--<div class="divider col-12 clearfix no-padding" style="padding: 0px !important; border: none !important;">
                        <div class="form-group no-padding" style="padding: 5px 8px !important;">
                            <label for="lblFirstName">Email</label>
                            <input class="form-control" id="txtEmail" name="txtEmail" placeholder="Email" type="text" />
                        </div>
                    </div>--%>
                    <div class="divider">
                        <div class="divider-break"></div>
                    </div>
                    <h3 class="text-uppercase margin-top-5 text-center">Tax Details</h3>
                    <div class="divider col-12 no-padding">
                        <div class="form-group">
                            <div class="well-sm" id="dvTaxdetails">
                            </div>
                        </div>
                    </div>
                    <div class="divider">
                        <div class="divider-break"></div>
                    </div>
                    <h3 class="text-uppercase margin-top-5 text-center">Payment Details</h3>
                    <div class="divider col-3 clearfix">
                        <div class="form-group">
                            <label for="lblFirstName">Payment Mode</label>
                            <select class="selectpicker form-control" id="selPaymentMode" onchange="OnChangePaymentMode();return false;">
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Payment Date</label>
                            <input class="form-control datepicker" id="txtPaymentDate" name="txtPaymentDate" placeholder="Date" type="text" />
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Amount</label>
                            <input class="form-control" id="txtAmount" name="txtAmount" placeholder="Amount" type="text" />
                        </div>
                        <div class="form-group no-padding" style="padding: 5px 8px !important;">
                            <label for="lblFirstName">Discount</label>
                            <input class="form-control" id="txtDiscount" name="txtDiscount" placeholder="Discount" type="text" />
                        </div>
                        <%--<div class="form-group">
                            <label for="lblFirstName">Transcation Number</label>
                            <input class="form-control" id="txtTransactionNumber" name="txtTransactionNumber" placeholder="Transcation Number" type="text" />
                        </div>--%>
                    </div>
                    <div id="dvTransactionNumber" class="divider col-12 clearfix no-padding" style="display:none;padding: 0px !important; border: none !important;">
                        <div class="form-group no-padding" style="padding: 5px 8px !important;">
                            <label for="lblFirstName">Transcation Number</label>
                            <input class="form-control" id="txtTransactionNumber" name="txtTransactionNumber" placeholder="Transcation Number" type="text" />
                        </div>
                    </div>
                    <div class="divider">
                        <div class="divider-break"></div>
                    </div>
                    <h3 class="text-uppercase margin-top-5 text-center">Calculations</h3>
                    <div class="divider col-6 clearfix">
                        <div class="form-group">
                            <label for="lblFirstName">Amount Given</label>
                            <input class="form-control" id="txtAmountGiven" name="txtAmountGiven" placeholder="Amount Given" type="text" />
                        </div>
                        <div class="form-group">
                            <label for="lblFirstName">Return Amount</label>
                            <input class="form-control" id="txtReturnAmount" name="txtReturnAmount" placeholder="Return Amount" type="text" />
                        </div>
                    </div>
                </div>
                <div class="col-12 text-center">
                    <button id="btnAppraiserSteps" type="submit" class="btn btn-default appraisal-btn">
                        <svg width="16px" height="16px" viewBox="0 0 17 16" version="1.1" xmlns="http://www.w3.org/2000/svg">
                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                <g transform="translate(-873.000000, -760.000000)" fill="#17A1E5">
                                    <g transform="translate(599.000000, 90.000000)">
                                        <g transform="translate(265.000000, 661.000000)">
                                            <path d="M17.4845473,18.7653727 L14.847,16.141 C14.653,15.948 14.34,15.948 14.147,16.141 C13.953,16.333 13.953,16.645 14.147,16.838 L17.0316433,19.7082297 C17.0543365,19.7510387 17.0837887,19.791162 17.12,19.827 C17.2302489,19.9361182 17.3785367,19.9835432 17.5216698,19.9692751 C17.6411709,19.9640643 17.7590274,19.9159726 17.85,19.825 C17.8821517,19.7930149 17.9089472,19.7576996 17.9303867,19.7201636 L24.848,12.838 C25.042,12.646 25.042,12.332 24.848,12.14 C24.653,11.946 24.339,11.946 24.145,12.14 L17.4845473,18.7653727 Z M24.8765325,15.6539709 C24.9504907,16.0912563 24.989,16.5406198 24.989,16.999 C24.989,21.417 21.41,24.998 16.994,24.998 C12.579,24.998 9,21.417 9,16.999 C9,12.58 12.579,8.999 16.994,8.999 C19.0206793,8.999 20.8710647,9.75325165 22.2801015,10.9966037 L21.561033,11.6957233 C20.3353665,10.6383497 18.7392468,9.999 16.994,9.999 C13.13,9.999 9.997,13.133 9.997,16.999 C9.997,20.865 13.13,23.999 16.994,23.999 C20.858,23.999 23.991,20.865 23.991,16.999 C23.991,16.8412829 23.9857857,16.684784 23.9755202,16.5296666 L24.8765325,15.6539709 L24.8765325,15.6539709 Z" id="icon:-check" class="svgicn"></path>
                                        </g>
                                    </g>
                                </g>
                            </g>
                        </svg>
                        <span id="btnAppraiserStepsText">Submit</span></button>
                </div>
            </form>
        </div>

    </div>
    <script type="text/javascript">
        <%--var UserID = "<%= UserID %>";
        var UserType = "<%= UserType %>";
        var FirstName = "<%= FirstName%>";
        var LastName = "<%= LastName%>";
        var AccountTypeID = "<%= AccountTypeID%>";
        var UserStatus = "<%= UserStatus%>";
        var UserProfileImage = "<%= UserProfileImage %>";--%>

        $("#txtProductBarcodeNumber").keypress(function (event) {
            if (event.keyCode == 13) {
                GetProductByBarcodeNumber();
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContentRight" runat="server">
</asp:Content>
