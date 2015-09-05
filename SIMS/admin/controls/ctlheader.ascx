<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlheader.ascx.cs" Inherits="ValuePad.admin.controls.ctlheader" %>
<div id="page-header">
    <div id="header-logo" class="width-210">
        <ul class="list-unstyled">
            <li class="hidden-sm hidden-md hidden-lg hidden-el">
                <asp:HyperLink ID="hlnkLogo" runat="server" NavigateUrl="~/admin/userlastactivity.aspx"><img src="../img/icon-3.png" /></asp:HyperLink>
            </li>
            <li class="hidden-xs">
                <asp:HyperLink ID="hlnkHome" runat="server" NavigateUrl="~/admin/userlastactivity.aspx">
                    <img src="../img/logo-4.png" style="width:158px !important;margin-right:17px;margin-left:12px;"/>
                </asp:HyperLink>
            </li>
            <%--<li class="header-note-icon def-pad no-margin">
                <div class="notification" style="cursor: pointer;" onclick="OpenNotificationLog();return false;">
                    <img src="../img/notification.png" width="22" height="22" alt="" />
                </div>
                <div class="countofunread text-center">0</div>
            </li>
            <li class="header-note-icon def-pad no-margin">
                <div class="notification" style="cursor: pointer;" onclick="GetCommentDetailNoti(null);ShowCommentPopup();return false;">
                    <img src="../img/icon-chat.png" width="22" height="22" alt="" />
                </div>
                <div class="unreadmsg text-center">0</div>
            </li>--%>
        </ul>
    </div>

    <div id="header-right">
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="navigation">
            <div class="navbar-left navbar-collapse collapse" id="app-navbar" aria-expanded="true" role="navigation">
                <ul class="nav navbar-nav headermenubar" role="tablist">
                    <li role="presentation" class="active" id="liUserActivity">
                        <asp:HyperLink ID="hlnkUserActivity" runat="server" NavigateUrl="~/admin/userlastactivity.aspx">
                            <span class="fa fa-pie-chart"></span>User Activity</asp:HyperLink>
                    </li>
                </ul>
            </div>
        </div>
        <ul class="nav  navbar-right ">
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">
                    <div class="img">
                        <div class="img-responsive" id="dvUserProfile" style="height: 50px; width: 50px; background-size: 50px 50px; border-radius: 100px; background-size: cover;"></div>
                    </div>
                    <div class="pull-left uname margin-top-12">
                        <label id="lblHeaderFirstName"></label>
                        <br />
                    </div>
                    <div class="pull-left r-caret">

                        <img src="../img/icons/arrows-header.svg" width="19" height="19" class="arrow" alt="" />
                    </div>
                </a>
                <ul class="dropdown-menu" role="menu">
                    <li>
                        <asp:HyperLink ID="hlnkLogout" runat="server" NavigateUrl="~/signout.aspx" Text="Logout" /></li>
                </ul>
            </li>
            <li class="visible-xs visible-sm visible-md bar"><a href="#" data-toggle="collapse" data-target="#app-navbar" aria-expanded="true"><i class="fa fa-bars"></i></a></li>
        </ul>
    </div>
</div>
