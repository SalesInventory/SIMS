<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctladdproduct.ascx.cs" Inherits="SIMS.common.controls.ctladdproduct" %>
<script src='<%=ResolveUrl("~/js/common/ctladdproduct.js") %>'></script>
<div class="appraisal-overlay notification-window">
    <div class="modal fade" id="mdlProductDetails" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="overlay-form">
                    <div class="modal-body clearfix">
                        <h3 class="text-uppercase text-center">Product Details<span class="pull-right close margin-right-10" data-dismiss="modal" onclick="HideCoveragePopup()" style="font-size: 16px;">x</span></h3>

                        <div id="divCoverageArea" class="">
                            <form id="frmProductDetails" class="signup-form-2" enctype="multipart/form-data" role="form">
                                <div class="divider col-6 clearfix">
                                    <div class="form-group">
                                        <label for="lblProductName">Product Name</label>
                                        <input class="form-control" id="txtName" name="txtName" placeholder="Product Name" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblDescryption">Descryption</label>
                                        <input class="form-control" id="txtDescryption" name="txtDescryption" placeholder="Descryption" type="text" />
                                    </div>
                                </div>
                                <div class="divider col-6 clearfix">
                                    <div class="form-group">
                                        <label for="lblShortCode">Product ShortCode</label>
                                        <input class="form-control" id="txtShortCode" name="txtShortCode" placeholder="Product ShortCode" type="text" />
                                    </div>
                                    <div class="form-group">
                                         <label for="lblVendor">Vendor</label>
                                        <input id="txtVendor" onkeyup="VendorAutoSugetion(1)" name="txtVendor" autocomplete="off" class="valid" type="text">
                                        <div id="vendorSugest" class="bg-color-lighten autoSugestBox" style="margin-top: 0px"></div>
                                    </div>
                                </div>
                                <div class="divider col-4 clearfix">
                                    <div class="form-group">
                                        <label for="lblCompanyName">Brand or Company</label>
                                        <select class="selectpicker form-control" id="selCompany">
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="lblCategory">Category</label>
                                        <select class="selectpicker form-control" id="selCategory" onchange="ShowProductSize();">
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="lblProductFor">Product For</label>
                                        <select class="selectpicker form-control" id="selProductFor">
                                        </select>
                                    </div>
                                </div>
                                <div class="divider col-6 clearfix">
                                    <div class="form-group">
                                        <label for="lblColor">Color</label>
                                        <select class="selectpicker form-control" id="selColor">
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="lblSize">Size</label>
                                        <select class="selectpicker form-control" id="selSize">
                                        </select>
                                    </div>
                                </div>
                                <div class="divider col-4 clearfix">
                                    <div class="form-group">
                                        <label for="lblTotalPrice">Total Price</label>
                                        <input class="form-control" id="txtTotalPrice" name="txtTotalPrice" placeholder="TotalPrice" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblMRP">MRP</label>
                                        <input class="form-control" id="txtMRP" name="txtMRP" placeholder="MRP" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblPurchasePrice">Purchase Price</label>
                                        <input class="form-control" id="txtPurchasePrice" name="txtPurchasePrice" placeholder="PurchasePrice" type="text" />
                                    </div>
                                </div>
                                <div class="divider col-6 clearfix">
                                    <div class="form-group">
                                        <label for="lblQuantity">Quantity</label>
                                        <input class="form-control" id="txtQuantity" name="txtQuantity" placeholder="0" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblDiscount">Discount %</label>
                                        <input class="form-control" id="txtDiscount" name="txtDiscount" placeholder="0" type="text" />
                                    </div>
                                </div>
                                <h4 class="text-uppercase text-left">ReOrder Details</h4>
                                <div class="divider col-4 clearfix">
                                    <div class="form-group">
                                        <label for="lblReOrderQuantity">ReOrder Quantity</label>
                                        <input class="form-control" id="txtReOrderQuantity" name="txtRQuantity" placeholder="0" type="text" />
                                    </div>
                                    <div class="form-group">
                                        <label for="lblRVendor">Vendor</label>
                                        <input id="txtRVendor" onkeyup="VendorAutoSugetion(0)" name="txtRVendor" autocomplete="off" class="valid" type="text">
                                        <div id="rVendorSugest" class="bg-color-lighten autoSugestBox" style="margin-top: 0px"></div>
                                    </div>
                                    <div class="form-group">
                                        <label for="lblLessthen">ReOrder when quantity less then</label>
                                        <input class="form-control" id="txtMinQuantity" name="txtMinQuantity" placeholder="0" type="text" />
                                    </div>
                                </div>
                                <div class="col-12 text-center padding-10">
                                    <button id="btnProductSteps3" type="submit" class="btn btn-default appraisal-btn">
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
                                        <span id="btnProductStepsText3">Submit</span></button>
                                    <button id="btnProductBackSteps2" type="button" onclick="HideVendorModal();return false;" class="btn btn-default appraisal-btn">
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
                                        <span id="btnProductBackStepsText2">Cancel</span></button>
                                </div>
                            </form>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</div>
</div>

