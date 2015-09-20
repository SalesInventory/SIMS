<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctladdvendor.ascx.cs" Inherits="SIMS.common.controls.ctladdvendor" %>
<script src='<%=ResolveUrl("~/js/common/ctladdvendor.js") %>'></script>
<div class="appraisal-overlay notification-window">
    <div class="modal fade" id="mdlVendorDetails" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="overlay-form">
                    <div class="modal-body clearfix">
                        <h3 class="text-uppercase text-center">Vendor Details<span class="pull-right close margin-right-10" data-dismiss="modal" onclick="HideCoveragePopup()" style="font-size: 16px;">x</span></h3>

                        <div id="divVendorDetails" class="">
                            <form id="frmVendorDetails" class="signup-form-2" enctype="multipart/form-data" role="form">
                                <div class="divider col-6 clearfix">
                                    <div class="form-group">
                                        <label for="lblFirstName">Vendor Name</label>
                                        <input class="form-control" id="txtName" name="txtName" placeholder="Vendor Name" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblFirstName">Brand Name</label>
                                        <input class="form-control" id="txtBrandName" name="txtBrandName" placeholder="Brand Name" type="text" />
                                    </div>
                                </div>
                                <div class="divider col-12 clearfix no-padding" style="padding:0px !important;border:none !important;">
                                    <div class="form-group no-padding" style="padding: 5px 8px !important;">
                                        <label for="lblFirstName">Address</label>
                                        <input class="form-control" id="txtAddress" name="txtAddress" placeholder="Address" type="text" />
                                    </div>
                                </div>
                                <div class="divider col-6 clearfix">
                                    <div class="form-group">
                                        <label for="lblFirstName">Zip</label>
                                        <input class="form-control" id="txtZip" name="txtZip" placeholder="Zip" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblCompanyName">Country</label>
                                        <select class="selectpicker form-control" id="selCountry" onchange="ShowState();">
                                            <%--<option value="1">India</option>--%>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="lblCompanyName">State</label>
                                        <select class="selectpicker form-control" id="selState" onchange="ShowCity();">
                                            <%--<option value="1">Gujarat</option>--%>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="lblCompanyName">City</label>
                                        <select class="selectpicker form-control" id="selCity" onchange="">
                                            <%--<option value="1">Ahmedabad</option>--%>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="lblFirstName">Mobile</label>
                                        <input class="form-control" id="txtMobile" name="txtMobile" placeholder="Mobile" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblFirstName">Phone</label>
                                        <input class="form-control" id="txtPhone" name="txtPhone" placeholder="Phone" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblFirstName">Fax</label>
                                        <input class="form-control" id="txtFax" name="txtFax" placeholder="Fax" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblFirstName">Email</label>
                                        <input class="form-control" id="txtEmail" name="txtEmail" placeholder="Email" type="text" />
                                    </div>
                                </div>
                                <div class="col-12 text-center padding-10">
                                    <button id="btnAppraiserSteps3" type="submit" class="btn btn-default appraisal-btn">
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
                                        <span id="btnAppraiserStepsText3">Submit</span></button>
                                    <button id="btnAppraiserBackSteps2" type="button" onclick="HideVendorModal();return false;" class="btn btn-default appraisal-btn">
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
                                        <span id="btnAppraiserBackStepsText2">Cancel</span></button>
                                </div>
                            </form>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>
