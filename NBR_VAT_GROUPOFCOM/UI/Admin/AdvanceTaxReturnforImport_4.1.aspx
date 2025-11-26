<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="AdvanceTaxReturnforImport, App_Web_4urmxq31" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src= "~/UserControls/Item.ascx" tagname="ItemNav" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
        <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="container" style="margin-left:5%">
     <div class="panel panel-default">
            <div class="panel-body">
        <div class="row">
          <div class="form-group form-group-sm">
          <div class="col-sm-2"></div>
            <div class="col-sm-4">
                <asp:Label ID="lbApplicationName" runat="server" Text="Applicants Name:" class="control-label col-sm-12"></asp:Label>
            </div>
            <div class="control-label col-sm-4">
                <asp:TextBox ID="tbApplicationName" runat="server" CssClass="form-control" placeholder="Enter Application Name"></asp:TextBox>
            </div>
            <div class="col-sm-2"></div>
         </div>
        </div>
        <div class="row">
          <div class="form-group form-group-sm">
          <div class="col-sm-2"></div>
            <div class="col-sm-4">
                <asp:Label ID="lblBusinessPointingNumber" runat="server" Text="Pointing Number of Regular Business:" class="control-label col-sm-12"></asp:Label>
            </div>
            <div class="col-sm-4">
                <asp:DropDownList ID="drpDistrict" runat="server" Width="100%" ReadOnly="true" AutoPostBack="True" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
                            OnSelectedIndexChanged="drpBusinessPointingNumber_SelectedIndexChanged" >
                    </asp:DropDownList>
            </div>
            <div class="col-sm-2"></div>
          </div>
        </div>
        <div class="row">
          <div class="form-group form-group-sm">
          <div class="col-sm-2"></div>
            <div class="col-sm-4">
                <asp:Label ID="lblAddress" runat="server" Text="Address:" class="control-label col-sm-12"></asp:Label>
            </div>
            <div class="control-label col-sm-4">
                <asp:TextBox ID="tbAddress" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2"></div>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-4">
          <div class="form-group form-group-sm">
            <div class="col-sm-4">
                <asp:Label ID="lblBillEntryNo" runat="server" Text="Bill of Entry No:" class="control-label col-sm-12"></asp:Label>
            </div>
            <div class="control-label col-sm-8">
               <div class="col-sm-8">
                <asp:DropDownList ID="drpBillEntryNo" runat="server" Width="100%" ReadOnly="true" AutoPostBack="True" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
                            OnSelectedIndexChanged="drpBillofEntryNo_SelectedIndexChanged" >
                    </asp:DropDownList>
            </div>
            </div>
            </div>
            </div>
            <div class="col-sm-4">
            <div class="form-group form-group-sm">
            <div class="col-sm-4">
                <asp:Label ID="lblDate" runat="server" Text="Date:" class="control-label col-sm-12"></asp:Label>
            </div>
            <div class="control-label col-sm-8">
                <asp:TextBox ID="tbDate" runat="server" class="form-control"></asp:TextBox>
            </div>
            </div>
            </div>
            <div class="col-sm-4">
            <div class="form-group form-group-sm">
            <div class="col-sm-4">
                <asp:Label ID="lblCountryofOrigin" runat="server" Text="Country of Origin:" class="control-label col-sm-12"></asp:Label>
            </div>
            <div class="control-label col-sm-8">
                <asp:TextBox ID="tbCountryofOrigin" runat="server" class="form-control"></asp:TextBox>
            </div>
            </div>
            </div>

        </div>
        <div class="row">
           <div class="form-group form-group-sm">
            <div class="col-sm-2"></div>
            <div class="col-sm-4">
                <asp:Label ID="Label1" runat="server" Text="Item Description:" class="control-label col-sm-12"></asp:Label>
            </div>
            <div class="control-label col-sm-4">
                <asp:TextBox ID="TextBox1" runat="server" TextMode=MultiLine class="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2"></div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lblAdvanceVat" runat="server" Text="Advance Vat Amount:" class="control-label"></asp:Label>
                    </div>
                    <div class="control-label col-sm-8">
                        <asp:TextBox ID="tbAdvanceVat" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lblCustomPaidDate" runat="server" Text="Custom Duty Paid Date:" class="control-label"></asp:Label>
                    </div>
                    <div class="control-label col-sm-8">
                        <asp:TextBox ID="tbCustomPaidDate" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lblReleaseOrderNo" runat="server" Text="Release Order No:" class="control-label"></asp:Label>
                    </div>
                    <div class="control-label col-sm-8">
                        <asp:TextBox ID="tbReleaseOrderNo" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lblReleaseOrderDate" runat="server" Text="Date:" class="control-label"></asp:Label>
                    </div>
                    <div class="control-label col-sm-8">
                        <asp:TextBox ID="tbReleaseOrderDate" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lblUserName" runat="server" Text="User Name:" class="control-label"></asp:Label>
                    </div>
                    <div class="control-label col-sm-8">
                        <asp:TextBox ID="tbUserName" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lblDesignation" runat="server" Text="Designation:" class="control-label"></asp:Label>
                    </div>
                    <div class="control-label col-sm-8">
                        <asp:TextBox ID="tbDesignation" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
       </div>
     </div>
  </div>
 </asp:Content>

