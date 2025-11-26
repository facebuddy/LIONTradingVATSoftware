<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_SetUnit, App_Web_jwpupl0k" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery.tablePagination.0.1.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.tablesorter.js"></script>
    <link href="../../Styles/str.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= gvUnit.ClientID %>").tablesorter();
        $('#<%= gvUnit.ClientID %>').tablePagination({
            firstArrow: (new Image()).src = "../Content/Images/first.gif",
            prevArrow: (new Image()).src = "../Content/Images/prev.gif",
            lastArrow: (new Image()).src = "../Content/Images/last.gif",
            nextArrow: (new Image()).src = "../Content/Images/next.gif"
        });
    }
);

    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        $("#<%= gvUnit.ClientID %>").tablesorter();
        $('#<%= gvUnit.ClientID %>').tablePagination({
            firstArrow: (new Image()).src = "../Content/Images/first.gif",
            prevArrow: (new Image()).src = "../Content/Images/prev.gif",
            lastArrow: (new Image()).src = "../Content/Images/last.gif",
            nextArrow: (new Image()).src = "../Content/Images/next.gif"
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                            Unit Setup
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Unit Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpUnitType" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Unit Name :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtUnitName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Unit Code :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtUnitCode" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn-btn" Style="background-color:#4CAF50;" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn-btn" Style="background-color:#4CAF50;" />
                                    <asp:Button ID="btnShowHideData" runat="server" Text="Show All Records" OnClick="btnShowHideData_Click" CssClass="btn-btn" Style="background-color:#5CB85C;width:130px" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel panel-body">
                            <div class="gridDiv" align="center">
                                <asp:GridView ID="gvUnit" runat="server" AllowSorting="True" 
                                    AutoGenerateColumns="False" DataKeyNames="unit_id"
                                    OnRowDeleting="gvUnit_RowDeleting"
                                    OnSelectedIndexChanged="gvUnit_SelectedIndexChanged" CssClass="sGrid"
                                    OnRowDataBound="gvUnit_RowDataBound" PageSize="3" width="100%">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                        <asp:BoundField DataField="unit_name" HeaderText="Unit Name" />
                                        <asp:BoundField DataField="unit_code" HeaderText="Unit Code" />
                                        <asp:BoundField DataField="unit_type" HeaderText="Unit Type" />
                                         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

