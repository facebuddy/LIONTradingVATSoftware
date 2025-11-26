<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="MasterDataSetup.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.MasterDataSetup" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/panel.css" rel="stylesheet" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
           <%-- <div class="container">--%>
           <%--<div class="panel panel-group">--%>
            <div class="panel panel-primary">
                <div class="panel-heading text-center" style="font-family:Tahoma; font-size:18px;"><b>Set Master Base Data</b></div>
                <div class="panel-body">
                    <div class="row" style="margin-top: 0.5%">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="control-label col-sm-5 text-right"><span class="required"> *</span>Data Name :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" type="text" class="form-input" onkeypress="return isAlfa(event)"
                                        ID="txtCodeName" placeholder="Enter here" MaxLength="49" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="control-label col-sm-5 text-right">Code Description :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" CssClass="form-control" onkeypress="return isAlfa(event)"
                                        ID="txtCodeDescription" placeholder="Enter here" MaxLength="25"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="control-label col-sm-5 text-right"><span class="required"> *</span>Code Type : </label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" Width="50px"
                                        onkeypress="return isNumberKey(event)" MaxLength="1" ID="txtOrder" placeholder="">1</asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5"> </div>
                        <div class="col-md-7" style="text-align:right">
                             <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnShowCommissionerateList" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;float: right" Text="Show List" OnClick="btnShowCommissionerateList_Click" />
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" Text="Refresh" OnClick="btnRefresh_Click" />
                        </div>
                       <%-- <div class="col-md-4"> </div>--%>
                       
                    </div>
                   
                </div>
            </div>
        <%--</div>--%>
    <%--</div>--%>
             <div class="row" style="margin-top:1%">
                    <asp:GridView ID="dgvMasterData" runat="server" AutoGenerateColumns="False"
                        CssClass="mydatagrid" DataKeyNames="code_id_m" Style="width: 97%; margin-left: 15px"
                        CellPadding="3"
                        AllowPaging="True"
                        PageSize="15"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                        BorderWidth="1px" OnPageIndexChanging="dgvMasterData_PageIndexChanging"
                        OnSelectedIndexChanged="dgvMasterData_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/edit.png"
                                ShowSelectButton="True" />
                            <asp:BoundField DataField="code_name_m" HeaderText="Data Name" />
                            <asp:BoundField DataField="code_description"
                                HeaderText="Data Description">
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
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
      <%--      <uc2:MsgBox ID="msgBox" runat="server" />--%>
            <uc1:MsgBoxs runat="server" ID="msgBox" />
        </ContentTemplate>
    </asp:UpdatePanel>
    
    
</asp:Content>
