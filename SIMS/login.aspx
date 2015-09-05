<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/mstsims.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SIMS._login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/select2.css" rel="stylesheet" />
    <link href="css/select2-bootstrap.css" rel="stylesheet" />
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="js/plugins/masking/jquery.maskedinput.min.js"></script>
    <script src="js/plugins/select2/select2.min.js"></script>
    <script src="js/login.js"></script>
    <style type="text/css">
        .allselect input[type=checkbox].checkbox + span:before {
            /*content: "\f00c";*/
            color: #2E7BCC;
        }

        #listOfStateCity {
            margin-left: 15px;
        }

            #listOfStateCity label.zipcode {
                display: none;
            }

            #listOfStateCity .allselect ~ label.btnzip {
                visibility: visible;
            }

            #listOfStateCity label.btnzip {
                visibility: hidden;
                color: #2E7BCC;
                font-weight: 700;
                cursor: pointer;
            }

        .countydisplay {
            z-index: 500;
            position: absolute;
            background-color: #f5f5f5;
            /*left:68%;*/
            right: 10%;
            border: 1px solid #e3e3e3;
            padding: 10px;
            max-width: 40%;
            max-height: 200px;
            overflow-y: auto;
        }

        .signup-form-1 h3 {
            padding-top: 0px !important;
            clear: both;
        }

        .forinvitaiontab {
            width: 50% !important;
        }

        #tblCoverageList thead tr th {
            text-transform: uppercase;
            color: #999999;
            font-size: 11px;
            font-weight: normal;
        }


        #divlimitedliability .bootstrap-select > .btn {
            border: 1px solid grey !important;
        }

        .category{
            font-size:16px !important;
            color:black !important;
        }
    </style>
</asp:Content>
<%-- col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1 col-xs-12 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpContent" runat="server">
    <div class="signin col-md-11 col-md-offset-1 col-sm-11 col-sm-offset-0 col-xs-12">
        <div class="page-wrapper" style="width: 90%">
            <h3 id="h3Welcome" class="text-uppercase"><b>Welcome</b></h3>
            <div id="registrationprocess">
                <%--<div class="wrapper-titles" id="signuplinks">
                    <ul class="list-unstyled col-md-12 steps">
                        <li class="active" onclick="LoadTab(1);" id="liSignIn" tabno="1"><a id="lnkSignIn" href="#" class="category">Sign In</a></li>
                        <li onclick="LoadTab(2);" id="liClientSignUp" tabno="2"><a href="#" class="category">Client Sign Up</a></li>
                        <li onclick="LoadTab(3);" id="liAppraisalSignUp" tabno="3"><a id="lnkAppraisalSignUp" href="#" class="category">Appraiser Sign Up</a></li>
                    </ul>
                </div>--%>
                <div class="clearfix"></div>
                <div id="dvAccountDetails">
                    <%--<h3 class="text-uppercase">Account Details</h3>--%>
                    <form id="frmLogin" class="signin-form" enctype="multipart/form-data" role="form" tabno="1" runat="server">
                        <asp:ScriptManager ID="smfrmlogin" runat="server"></asp:ScriptManager>
                        <asp:LinkButton ID="btnValueLogin" OnClick="btnValueLogin_Click" runat="server" />
                        <asp:UpdatePanel ID="UPfrmLogin" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-group">
                                    <label for="lblUserName">Username</label>
                                    <input type="text" class="form-control" id="txtUserName" name="txtUserName" placeholder="Username" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="signin_password">Password&nbsp;</label>
                                    <input type="password" class="form-control" id="txtPassword" name="txtPassword" placeholder="Password" runat="server" />
                                </div>
                                <div class="clearfix">&nbsp;</div>
                                <div class="col-lg-5 col-sm-5 footer-txt padding-left-10">
                                    Don't have a SIMS account? <strong class="clearfix"><a href="javascript:void(0);" onclick="LoadTab(3);">SIGN UP TODAY</a></strong>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnValueLogin" EventName="Click" />
                                <%--<asp:AsyncPostBackTrigger ControlID="btnLoginByUserID" EventName="Click" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="clearfix visible-xs">&nbsp;</div>
                        <div class="col-lg-2 col-sm-2 footer-btn">
                            <button type="submit" class="btn btn-default signin-btn">
                                <svg width="16px" height="16px" viewBox="0 0 17 16" version="1.1" xmlns="http://www.w3.org/2000/svg">
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
                                <span>Sign In</span></button>
                        </div>
                        <div class="clearfix visible-xs">&nbsp;</div>
                        <div class="col-lg-5 col-sm-5 text-right footer-txt">
                            Problems with your Account Details? <strong class="clearfix"><a href="javascript:void(0);" onclick="LoadForgotPassword();">REMIND ME ON MY EMAIL</a></strong>
                        </div>

                    </form>
                </div>
                <div id="dvForgotPassword" style="display: none;">
                    <h3 class="text-uppercase">Get Back Your Account Details</h3>
                    <form id="frmForgotPassword" class="signin-form" enctype="multipart/form-data" role="form">
                        <%--<div class="form-group">
                    <label for="forget_password">Name</label>
                    <input type="text" class="form-control" id="txtForgotName" placeholder="Name" />
                </div>--%>
                        <div class="divider col-12 ">
                            <%--<div class="form-group">
                                <label for="forget_email">User Name</label>
                                <input type="text" class="form-control" id="txtForgotUserName" name="txtForgotUserName" placeholder="Your User Name" />
                            </div>--%>
                            <div class="form-group">
                                <label for="forget_email">Email</label>
                                <input type="text" class="form-control" id="txtForgotEmail" name="txtForgotEmail" placeholder="Your Email Address" />
                            </div>
                        </div>
                        <div class="clearfix">&nbsp;</div>
                        <div class="col-lg-12 text-center">
                            <button type="submit" class="btn btn-default signin-btn">
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
                                <span>Submit</span></button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var BaseURL = "<%= SIMS.ConfigUtility.BaseURL %>";

        $(".amount-only").keydown(function (event) {
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
        });

        //InitializeMasking();

    </script>
</asp:Content>
