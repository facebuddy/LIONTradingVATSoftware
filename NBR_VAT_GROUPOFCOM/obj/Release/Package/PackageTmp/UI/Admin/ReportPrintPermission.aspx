<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_ReportPrintPermission, App_Web_bxnrqbtx" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                         Report Print Permission Setup
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">

                                        <label class="col-sm-5 control-label text-right">Report Name:</label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList ID="drpParty" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">

                                            <label class="col-sm-5 control-label">No of Print:</label>
                                            <div class="col-sm-5">
                                                <asp:TextBox ID="DropDownList1" runat="server" CssClass="form-control select2">
                                                </asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                        </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Content>
