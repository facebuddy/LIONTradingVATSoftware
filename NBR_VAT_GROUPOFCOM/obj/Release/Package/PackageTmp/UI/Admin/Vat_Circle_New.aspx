<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_Vat_Circle_New, App_Web_znns2ib5" %>

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
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <style media="print">
        {
        }

        .noPrint {
            display: none;
        }

        @media print {
            table {
                width: 100%;
            }

            tr, td {
            }

            .full_width {
                width: 100%;
            }
        }

        .yesPrint {
            display: block !important;
        }

        input[type=text], select, textarea, .text_box {
            border: none;
        }
    </style>
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                            VAT Circle
                        </div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label ID="label9" runat="server" Text="Commissonerate Name:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpCommName" runat="server" class="form-input select2" data-toggle="dropdown"
                                                Height="33px" AutoPostBack="True"
                                                OnSelectedIndexChanged="drpCommName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div style="height: 2px">
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="label2" runat="server" Text="Circle Name:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtCircleName" runat="server" class="form-input"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div style="height: 8px">
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="label1" runat="server" Text="Address:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtCircleAddress"
                                                placeholder="Enter here" Width="650px" TextMode="MultiLine" Height="60px"
                                                MaxLength="199"></asp:TextBox>
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <asp:Label ID="label4" runat="server" Text="Jurisdiction:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtJurisdiction"
                                                placeholder="Enter here" Width="650px" TextMode="MultiLine" Height="60px"
                                                MaxLength="999"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label ID="label10" runat="server" Text="Division Name:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpDivisionName" runat="server" class="form-input  select2" data-toggle="dropdown"
                                                Height="33px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div style="height: 5px">
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="label14" runat="server" Text="Circle Code:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtCircleCode" runat="server" class="form-input"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label ID="label16" runat="server" Text="Upazilla Name:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpUpazillaName" AutoPostBack="True" runat="server" class="form-input select2" OnSelectedIndexChanged="drpUpazillaName_SelectedIndexChanged"
                                                data-toggle="dropdown" Height="33px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div style="height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="label17" runat="server" Text="Union/Ward Name:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpUnionWardName" runat="server" ReadOnly="true" class="form-input select2"
                                                data-toggle="dropdown" Height="33px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div style="height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="label3" runat="server" Text="Phone #:" class="control-label col-sm-5" />
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtCirclePhone" runat="server" class="form-input"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div style="height: 8px">
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-12">
                                        </div>
                                    </div>
                                </div>
                                </div>
                                <div class="row" style="text-align: right">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right"
                                        Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnShowCircleList" runat="server"  CssClass="btn-btn" Style="background-color:#5CB85C ;float: right" 
                                       Text="Show Circle List" OnClick="btnShowCircleList_Click" />
                                    <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50;float: right"
                                        OnClick="btnRefresh_Click" Text="Refresh" />
                                </div>
                                <div class="row">
                                    <asp:GridView ID="dgvVatCircle" runat="server" AutoGenerateColumns="False" Style="width: 97%; margin-left: 15px"
                                        CssClass="sGrid" DataKeyNames="circle_id" Width="600px"
                                        OnRowDeleting="dgvVatCircle_RowDeleting"
                                        OnSelectedIndexChanged="dgvVatCircle_SelectedIndexChanged" CellPadding="3"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                        <Columns>
                                             <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                              SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                            <asp:BoundField DataField="comm_name" HeaderText="Commissonerate Name" />
                                            <asp:BoundField DataField="division_Name" HeaderText="Division" />
                                            <asp:BoundField DataField="circle_id" HeaderText="Circle ID" Visible="False" />
                                            <asp:BoundField DataField="circle_name" HeaderText="Circle Name" />
                                            <asp:BoundField DataField="circle_code" HeaderText="Circle Code">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="comm_id" HeaderText="Commissonerate" Visible="false" />
                                            <asp:BoundField DataField="address" HeaderText="Address">

                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="jurisdiction" HeaderText="Jurisdiction" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
      
    <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 20.06.2021
            </div>    

</asp:Content>
