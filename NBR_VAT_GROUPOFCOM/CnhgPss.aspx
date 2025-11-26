<%@ page title="" language="C#" masterpagefile="~/LoginMasterPage.master" autoeventwireup="true" inherits="CnhgPss, App_Web_1kre2rwf" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="container">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <%-- <div class="col-md-4 col-md-offset-4 text-center">--%>
                    <div class="col-md-4 col-md-offset-4 text-left">

                        <div>
                            <%--<h3 class="page-title" style="color: #0090d9; font-size: 14px;">Change Password</h3>--%>
                            <div class="row" style="height: 15px;">
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <label class="caption" style="color: #112383"><sup title="this field is required" style="color: red;">*</sup>Current Password</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox type="password" ID="txtCurrentPassword" runat="server" CssClass="form-control" placeholder="Current Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear"></div>
                            <div class="row">
                                <div class="col-md-5">
                                    <label class="caption" style="color: #112383"><sup title="this field is required" style="color: red;">*</sup>New Password</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox type="password" ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="New Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <label class="caption" style="color: #112383"><sup title="this field is required" style="color: red;">*</sup>Confirm Password</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox type="password" ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnSave" runat="server" Style="float: right" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click" Text="Change Password" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <uc2:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

