<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_Vat_Division_New, App_Web_znns2ib5" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../../UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function FormatIt(obj) {
            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;
                    height: 25px; padding-top: 0px">
                    VAT Division</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top:1%">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="label9" runat="server" Text="Commissonerate Name :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:DropDownList ID="drpCommName" runat="server" class="form-control select2" data-toggle="dropdown">
                               </asp:DropDownList>
                            </div>
                        </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="label10" runat="server" Text="Division Name :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:TextBox runat="server" type="text" class="form-control" ID="txtDivisionName" placeholder="Enter here"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                 <asp:Label ID="label16" runat="server" Text="Division Code :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:TextBox ID="txtDivisionCode" runat="server" class="form-control" placeholder="Enter here" MaxLength="25"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="label2" runat="server" Text="Upazilla Name :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:DropDownList ID="drpUpazillaName" AutoPostBack="True" runat="server" class="form-control select2"
                                            data-toggle="dropdown" onselectedindexchanged="drpUpazillaName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        </div>
                         <div class="col-md-4">
                             <div class="form-group form-group-sm">
                                 <asp:Label ID="label14" runat="server" Text="Union/Ward Name:" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpUnionWardName" runat="server" class="form-control select2" data-toggle="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        </div>
                         <div class="col-md-4">
                             <div class="form-group form-group-sm">
                                 <asp:Label ID="label17" runat="server" Text="Phone No :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:TextBox ID="txtDivisionPhone" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="label1" runat="server" Text="Address :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:TextBox runat="server" type="text" class="form-control" ID="txtDivisionAddress" 
                                            placeholder="Enter here" TextMode="MultiLine" Height="32px" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                        <div class="col-md-4">

                        </div>
                        <div class="col-md-4">
                             <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" Text="Save" OnClick="btnSave_Click" />
                             <asp:Button ID="btnShowDivisionList" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;float: right" Text="Show Division List" OnClick="btnShowDivisionList_Click" />
                             <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right"
                                            OnClick="btnRefresh_Click" Text="Refresh" />
                        </div>
                    </div>

                   
                     <div class="row">
                        <asp:GridView ID="dgvVatDivision" runat="server" AutoGenerateColumns="False"  Style="width: 97%; margin-left: 15px"
                    CssClass="sGrid" DataKeyNames="division_id"
                        onrowdeleting="dgvVatDivision_RowDeleting" 
                        onselectedindexchanged="dgvVatDivision_SelectedIndexChanged" CellPadding="3" 
                             BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <Columns>
                         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                        <asp:BoundField DataField="comm_id" HeaderText="Commissionerate ID" Visible = "false" />
                        <asp:BoundField DataField="comm_name" HeaderText="Commissionerate" />
                        <asp:BoundField DataField="division_id" HeaderText="Division ID" Visible = "false" />
                        <asp:BoundField DataField="division_name" HeaderText="Division Name" />
                        <asp:BoundField DataField="division_code" HeaderText="Division Code">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="address" HeaderText="Address">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="phone_no" HeaderText="Phone" ItemStyle-Wrap="false">
                        <ItemStyle HorizontalAlign="Left" Wrap="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="uName" HeaderText="Upazilla">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="uwName" HeaderText="Union/Ward">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                    </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" 
                                ForeColor="#000066" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>
