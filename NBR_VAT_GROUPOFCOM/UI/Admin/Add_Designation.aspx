<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Add_Designation, App_Web_bxnrqbtx" %>

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
       <link href="../../Styles/panel.css" rel="stylesheet" />
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
                <div class="panel-heading" style="text-align: center;font-family:Tahoma; font-size:18px; font-weight: bold;height: 25px; padding-top: 0px">
                    Set Designation
                </div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top:1%">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right"><span class="required">*</span>Designation Name :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="txtDesignationName" placeholder="Enter here" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right"><span class="required">*</span>Designation Short Name :</label>
                                    <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtDesignationShortName" placeholder="Enter here" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right"><span class="required">*</span>Department :</label>
                                    <div class="col-sm-7">
                                    <asp:DropDownList runat="server" class="form-control select2" ID="ddlDepartment"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                    </div>
                    <div class="row" style="text-align: right">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" Text="Save" onclick="btnSave_Click" />
                        <asp:Button ID="btnShow" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;float: right" Text="Show List" onclick="btnShow_Click" />
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" Text="Refresh" onclick="btnRefresh_Click" />
                    </div>
                    <div class="row">
                        <asp:GridView ID="dgvDesignation" runat="server" AutoGenerateColumns="False"
                            CssClass="sGrid" DataKeyNames="designation_id" Style="width: 97%; margin-left: 15px"
                            CellPadding="3" 
                            AllowPaging="True" PageSize="15" 
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                            BorderWidth="1px" onpageindexchanging="dgvDesignation_PageIndexChanging" 
                            onrowdeleting="dgvDesignation_RowDeleting" 
                            onselectedindexchanged="dgvDesignation_SelectedIndexChanged">
                            <Columns>
                                 <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/edit.png"
                                    ShowSelectButton="True" />
                                <asp:BoundField DataField="designation_name" HeaderText="Designation Name" />
                                <asp:BoundField DataField="designation_short_name" 
                                    HeaderText="Designation Short Name" >
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                               
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                    ShowDeleteButton="True" Visible="False" />
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" 
                                ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                            <%--<EmptyDataTemplate>
                                No Items Found.
                            </EmptyDataTemplate>--%>
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
    <%--<EmptyDataTemplate>
                                No Items Found.
                            </EmptyDataTemplate>--%>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>