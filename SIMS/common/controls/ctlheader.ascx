<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlheader.ascx.cs" Inherits="ValuePad.common.controls.ctlheader" %>
<style type="text/css">
    #header-logo {
        width: 312px;
    }

    input[type=checkbox] {
        outline: 0 !important;
        -webkit-appearance: checkbox !important;
    }

    .seeallnotificationdecoration:hover {
        text-decoration: none;
    }

    /*.navbar-nav > li #liHelp a:focus {
        background: none repeat scroll 0% 0% #5A6970;
    }*/

    .help-center-ticket li a {
        display: block !important;
        font-weight: normal !important;
        line-height: 1.42857 !important;
        color: #333 !important;
        white-space: nowrap !important;
        text-align: left !important;
        border-top: none !important;
    }

        .help-center-ticket li a:hover {
            border-top: none !important;
            cursor: pointer;
        }

    .navbar-nav > li > .dropdown-menu li a:after {
        display: none;
    }

    .headermenubar li ul li a {
        color: #333 !important;
    }

    .headermenubar li a {
        color: #fff !important;
    }

    #SaveCommentModal .desktop-record-columns li {
        margin-left: 0px !important;
    }

    /*.dropdown-menu > .disabled > a:hover, .dropdown-menu > .disabled > a:focus {
            text-decoration: none;
            background-color: transparent;
            background-image: none;
            filter: progid:DXImageTransform.Microsoft.gradient(enabled = false);
            cursor: not-allowed;
        }*/

    /*.nav > li.dropdown, .nav > li.dropdown:focus {
        background-color: #5F7077 !important;
    }*/

    /*#header-right .navbar-nav li:last-child a {
        border-top: medium none !important;
        color: black;
    }*/
    /*.navbar-nav > li > .dropdown-menu*/
    /*#hlnkReportIssue,hlnkRequestFeature {
        border-top: medium none !important;
    }*/
    /*#liHelp ul.dropdown-menu li a*/
    /*#header-right .navbar-nav #liHelp ul.dropdown-menu li.active a, #header-right .navbar-nav #liHelp ul.dropdown-menu li a:hover, #header-right .navbar-nav #liHelp ul.dropdown-menu li a:focus, #header-right .navbar-nav #liHelp ul.dropdown-menu li a:active {
    background: none repeat scroll 0% 0% #48555B;
    border-top: 0px solid #17A1E5 !important ;
    color: #FFF;
}*/
</style>

<div id="page-header">
    <div id="header-logo">
        <ul class="list-unstyled">
            <li class="hidden-sm hidden-md hidden-lg hidden-el">
                <asp:HyperLink ID="hlnkLogo" runat="server" NavigateUrl="~/common/appraisal.aspx"><img src="../img/icon-3.png" /></asp:HyperLink>
            </li>
            <li class="hidden-xs">
                <asp:HyperLink ID="hlnkHome" runat="server" NavigateUrl="~/common/appraisal.aspx">
                    <img src="../img/logo-4.png" style="width:158px !important;margin-right:17px;margin-left:12px;"/>
                </asp:HyperLink>
            </li>
            <li class="header-note-icon def-pad no-margin">
                <div class="notification" style="cursor: pointer;" onclick="OpenNotificationLog();return false;">
                    <img src="../img/notification.png" width="22" height="22" alt="" />
                </div>
                <div class="countofunread text-center">0</div>
                <div id="divArrowSeeAllNotification" class="seeallnotificationarrow" style="display: none;"></div>
            </li>
            <li class="header-note-icon def-pad no-margin">
                <div class="notification" style="cursor: pointer;" onclick="GetCommentDetailNoti(null);ShowCommentPopup();return false;">
                    <img src="../img/icon-chat.png" width="22" height="22" alt="" />
                </div>
                <div class="unreadmsg text-center">0</div>
            </li>
        </ul>
    </div>

    <div id="header-right">
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="navigation">
            <div class="navbar-left navbar-collapse collapse" id="app-navbar" aria-expanded="true" role="navigation">
                <ul class="nav navbar-nav headermenubar" role="tablist">
                    <%-- <li role="presentation" class="active" id="liDashboard">
                        <asp:HyperLink ID="hlnkDashboard" runat="server" NavigateUrl="~/appraiser/dashboard.aspx">
                            <span class="dashboard"></span>Dashboard </asp:HyperLink>
                    </li>--%>
                    <li role="presentation" id="liAppraisal">
                        <asp:HyperLink ID="hlnkAppraisal" runat="server" NavigateUrl="~/common/appraisal.aspx">
                            <span class="appraisals"></span>Orders</asp:HyperLink>
                    </li>
                    <li role="presentation" id="liScheduler">
                        <asp:HyperLink ID="hlnkScheduler" runat="server" NavigateUrl="~/common/scheduler.aspx">
                        <span class="scheduler"></span>Schedule</asp:HyperLink>
                    </li>
                    <li role="presentation" id="liProfile">
                        <asp:HyperLink ID="hlnkProfile" runat="server" NavigateUrl="~/appraiser/profile.aspx">
                        <span class="profile"></span>Profile</asp:HyperLink>
                    </li>

                    <li role="presentation" id="liJobType">
                        <asp:HyperLink ID="hlnkJobType" runat="server" NavigateUrl="~/appraiser/jobtypes.aspx">
                            <span class="jobtype"></span>Job Type</asp:HyperLink>
                    </li>

                    <li role="presentation" id="liCoverage">
                        <asp:HyperLink ID="hlnkCoverage" runat="server" NavigateUrl="~/appraiser/coverage.aspx">
                            <span class="coverage"></span>Coverage</asp:HyperLink>
                    </li>
                    <li role="presentation" id="liAccounting">
                        <asp:HyperLink ID="hlnkAccounting" runat="server" NavigateUrl="~/appraiser/accounting.aspx">
                            <span class="accounting"></span>Accounting</asp:HyperLink>
                    </li>
                    <li role="presentation" id="liInvitation">
                        <asp:HyperLink ID="hlnkMyInvitation" runat="server" NavigateUrl="~/appraiser/myinvitations.aspx">
                            <span class="invitation"></span>Invitations</asp:HyperLink>
                    </li>
                    <%--<li role="presentation" id="liTeam" style="display: none">
                        <asp:HyperLink ID="hlnkMyTeam" runat="server" NavigateUrl="~/company/myteam.aspx">
                            <span class="myteam"></span>My Team</asp:HyperLink>
                    </li>--%>
                    <li role="presentation" id="liMSMQLog" style="display: none">
                        <asp:HyperLink ID="hlMSMQLog" runat="server" NavigateUrl="~/company/apiusermsmqlog.aspx">
                            <span class="fa fa-pie-chart"></span>Log Details</asp:HyperLink>
                    </li>
                    <li role="presentation" id="liAdditionalStatusHeader" style="display: none">
                        <asp:HyperLink ID="hlAdditionalStatus" runat="server" NavigateUrl="~/company/additionalstatus.aspx">
                            <span class="fa fa-tasks"></span>Additional Status</asp:HyperLink>
                    </li>
                    <li role="presentation" id="liSettings">
                        <asp:HyperLink ID="hlnkSettings" runat="server" NavigateUrl="~/appraiser/settings.aspx">
                            <span class="settings"></span>Settings</asp:HyperLink>
                    </li>
                    <%--onclick="ShowSupportPage();" #liHelp ul.dropdown-menu li a --%>
                    <li class="dropdown" id="liHelp">
                        <a href="#" class="dropdown-toggle header-help-center" data-toggle="dropdown" role="button" aria-expanded="false">
                            <span class="help-center"></span>
                            <div class="div-header-help-center">Help Center</div>
                            <div class="pull-right r-caret">
                                <img src="../img/icons/arrows-header.svg" width="19" height="19" class="arrow" alt="" />
                            </div>
                        </a>
                        <ul class="dropdown-menu help-center-ticket" role="menu">
                            <li>
                                <asp:HyperLink ID="hlnkReportIssue" runat="server" onclick="openPopUpHelpCenter(1);" Text="Report an Issue" /></li>
                            <li>
                                <asp:HyperLink ID="hlnkRequestFeature" runat="server" onclick="openPopUpHelpCenter(2);" Text="Request a New Feature" /></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
        <ul class="nav  navbar-right ">
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">
                    <div class="img">
                        <div class="img-responsive" id="dvUserProfile" style="height: 50px; width: 50px; background-size: 50px 50px; border-radius: 100px; background-size: cover;"></div>
                        <%--<img src="../img/pic-icon.png" class="img-responsive" alt="" id="imgUserProfile"/>--%>
                    </div>
                    <div class="pull-left uname margin-top-12">
                        <label id="lblHeaderFirstName"></label>
                        <br />
                        <%--<span class="pull-right">(<label id="lblHeaderUserStatus"></label>)</span>--%>
                    </div>
                    <div class="pull-left r-caret">

                        <img src="../img/icons/arrows-header.svg" width="19" height="19" class="arrow" alt="" />
                    </div>
                </a>
                <ul class="dropdown-menu" role="menu">
                    <%--<li>
                        <asp:HyperLink ID="hlnkAddOrderForAppraiser" runat="server" NavigateUrl="~/common/addorder.aspx" Text="Add order" /></li>--%>
                    <li>
                        <asp:HyperLink ID="hlnkLogout" runat="server" NavigateUrl="~/signout.aspx" Text="Logout" /></li>
                </ul>
            </li>
            <li class="visible-xs visible-sm visible-md bar show-for-large-custom"><a href="#" data-toggle="collapse" data-target="#app-navbar" aria-expanded="true"><i class="fa fa-bars"></i></a></li>
        </ul>
    </div>
</div>

<script type="text/javascript">
    $(document).ready(function () {
    });

</script>
