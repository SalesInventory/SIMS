﻿<%@ Page Title="" Language="C#" MasterPageFile="~/common/masters/mstcommon.Master" AutoEventWireup="true" CodeBehind="taxdetails.aspx.cs" Inherits="SIMS.common.taxdetails" %>

<%@ Register Src="~/common/controls/ctladdtax.ascx" TagPrefix="uc1" TagName="ctladdtax" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpContent" runat="server">
    <div class="dashboard-search">
        <div class="col-lg-8 col-sm-6 step-1">
        </div>
        <div class="col-lg-4 col-sm-6 step-2 col-xs-12 text-right">
            <ul class=" list-inline">
                <li>
                    <button type="submit" class="btn btn-default appraisal-btn" onclick="OpenTaxModal(0);return false;">
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
                        <span>New Tax Detail</span></button>
                </li>
            </ul>
            &nbsp;      
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="table-responsive table-drop" data-pattern="priority-columns" style="overflow-x: visible !important">
        <form>
            <table class="table dashboard-table" id="tblTaxList">
                <thead>
                    <tr>
                        <th>
                            <div class="form-group">
                                <label for="dname">Name</label>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">Percentage</label>
                            </div>
                        </th>
                        <th>
                            <div class="form-group">
                                <label for="dname">Actions</label>
                            </div>
                        </th>
                    </tr>
                </thead>
                <tbody id="tbodyTax">
                </tbody>
            </table>
        </form>
    </div>
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
     <script src='<%=ResolveUrl("~/js/common/taxdetails.js") %>'></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContentRight" runat="server">
    <uc1:ctladdtax runat="server" ID="ctladdtax" />
</asp:Content>
