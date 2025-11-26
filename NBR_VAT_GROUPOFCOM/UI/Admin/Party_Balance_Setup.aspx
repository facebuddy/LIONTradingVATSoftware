<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Party_Balance_Setup, App_Web_znns2ib5" %>

<%@ Register Src="../../UserControls/admin.ascx" TagName="admin" TagPrefix="uc1" %>
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
    <style media="print">
        {
          
        }
        .noPrint
        {
            display: none;
        }
        @media print
        {
            table
            {
                width: 100%;
            }
            tr, td
            {
            }
            .full_width
            {
                width: 100%;
            }
        }
        .yesPrint
        {
            display: block !important;
        }
        input[type=text], select, textarea, .text_box
        {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }



        function isAlfa(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }
    </script>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;height: 25px; padding-top: 0px">
                    Party Balance Setup
                </div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top:1%">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right"><span class="required" style="color:red"> * </span>Balance Type :</label>
                                    <div class="col-sm-7">
                                        <%--<asp:TextBox runat="server" type="text" class="form-control" ID="txtVatClosingBalanceAmt"></asp:TextBox>--%>
                                         <asp:DropDownList ID="drpType" CssClass="form-control select2" runat="server">
                                               <asp:ListItem Value="Sl">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="P">Payable Balance</asp:ListItem>
                                                <asp:ListItem Value="R">Receivable Balance</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right"><span class="required" style="color:red"> * </span>Opening Balance :</label>
                                    <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtOpeningBalance" Text="0"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                                             runat="server" Enabled="True" TargetControlID="txtOpeningBalance"
                                                                             ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right"><span class="required" style="color:red"> * </span>Opening Date :</label>
                                    <%--<div class="col-sm-7">
                                     <asp:TextBox ID="txtOpeningDate" CssClass="form-control" Style="float: left" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                     <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtOpeningDate"/>
                                    </div>--%>
                                    <div class="col-sm-7">
                                           <asp:TextBox ID="txtOpeningDate" CssClass="form-control" Style="width: 50%; float: left" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                           <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtOpeningDate"/>
                                            <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server" ></asp:DropDownList>
                                            <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server" ></asp:DropDownList>
                                        </div>

                                </div>
                            </div>
                    </div>
                      <div class="row" style="margin-top:1%">
                          
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right">Party Name :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpPartyName" CssClass="form-control select2"  runat="server" >

                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right">Remarks :</label>
                                    <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtRemarks"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                           
                    </div>
                    <div class="row" style="text-align: right">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" Text="Save" onclick="btnSave_Click" />
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" Text="Refresh" onclick="btnRefresh_Click" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    <%--<EmptyDataTemplate>
                                No Items Found.
                            </EmptyDataTemplate>--%>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>
