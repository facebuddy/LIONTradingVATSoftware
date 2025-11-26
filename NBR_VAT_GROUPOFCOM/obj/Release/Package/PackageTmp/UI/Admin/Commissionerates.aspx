<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Commissionerates.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.Commissionerates" %>




<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


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
                    VAT Commissionerate
                </div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top:1%">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                     <asp:Label ID="label9" runat="server" Text="Commissonerate Name :" class="control-label col-sm-6 text-right" />
                                    <div class="col-sm-6">
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="txtCommName" placeholder="Enter here"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="label10" runat="server" Text="Commissionerate Code :" class="control-label col-sm-6 text-right" />
                                    <div class="col-sm-6">
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="txtCommCode" placeholder="Enter here"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="label16" runat="server" Text="Phone No :" class="control-label col-sm-6 text-right" />
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtComPhone" runat="server" class="form-control" placeholder="Enter here" MaxLength="20"></asp:TextBox>
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
                                            OnSelectedIndexChanged="drpUpazillaName_SelectedIndexChanged" data-toggle="dropdown">
                               </asp:DropDownList>
                            </div>
                        </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                  <asp:Label ID="label14" runat="server" Text="Union/Ward Name :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:DropDownList ID="drpUnionWardName" AutoPostBack="True" runat="server" class="form-control select2" OnSelectedIndexChanged="drpUnionWardName_SelectedIndexChanged" data-toggle="dropdown" >
                               </asp:DropDownList>
                            </div>
                        </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                 <asp:Label ID="label17" runat="server" Text="Address :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:TextBox ID="txtComAdd" runat="server" class="form-control" TextMode="MultiLine" Height="32px" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="row">
                       <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="label1" runat="server" Text="Police Station :" class="control-label col-sm-6 text-right" />
                            <div class="col-sm-6">
                               <asp:DropDownList ID="drpThana" AutoPostBack="True" runat="server" class="form-control"
                                             data-toggle="dropdown">
                               </asp:DropDownList>
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="row" style="text-align: right">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnShowCommissionerateList" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;float: right" Text="Show List" OnClick="btnShowCommissionerateList_Click" />
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50;float: right" OnClick="btnRefresh_Click" Text="Refresh" />
                    </div>
                    <div class="row">
                        <asp:GridView ID="dgvVatCommissonerate" runat="server" AutoGenerateColumns="False"
                            CssClass="sGrid" DataKeyNames="comm_id" Style="width: 97%; margin-left: 15px"
                            OnRowDeleting="dgvVatCommissonerate_RowDeleting" OnSelectedIndexChanged="dgvVatCommissonerate_SelectedIndexChanged"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3">
                            <Columns>
                                  <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:BoundField DataField="comm_id" HeaderText="Commissionerate ID" Visible="False" />
                                <asp:BoundField DataField="comm_name" HeaderText="Commissionerate Name" DataFormatString="{0:000}" />
                                <asp:BoundField DataField="comm_code" HeaderText="Commissionerate Code">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="address" HeaderText="Address" />
                                <asp:BoundField DataField="phone_no" HeaderText="Phone No">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="uName" HeaderText="Upazilla" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="uwName" HeaderText="Union/Ward">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ps_name" HeaderText="Police Station">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                             
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
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
    <%--<uc2:MsgBox ID="msgBox" runat="server" />--%>
 <%--   <uc2:MsgBox ID="msgBox" runat="server" />--%>
    <uc1:MsgBoxs runat="server" ID="msgBox" />
</asp:Content>
