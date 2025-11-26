<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Division_Setup, App_Web_bxnrqbtx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <link href="../../Styles/panel.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px;font-weight: bold;">
                            Set Division
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">*</span>Division  Name :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtDivisionName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Division Code :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtDivisionCode" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">*</span>Country Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlCountryName" DataTextField="country_name" DataValueField="country_Id" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnSave" runat="server" Style="background-color:#4CAF50;" CssClass="btn-btn" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnRefresh" runat="server" style="background-color:#4CAF50;" CssClass="btn-btn" Text="Refresh" OnClick="btnRefresh_Click" />
                                    <asp:Button ID="btnShowDivisionList" runat="server" Style="background-color:#5CB85C;" CssClass="btn-btn" Text="Show Division List" OnClick="btnShowDivisionList_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel panel-body">
                            <asp:GridView ID="dgvDivision" runat="server" AutoGenerateColumns="False"
                                CssClass="mydatagrid" DataKeyNames="division_id" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            OnRowDeleting="dgvDivision_RowDeleting" OnRowDataBound="dgvDivision_RowDataBound"    OnSelectedIndexChanged="dgvDivision_SelectedIndexChanged" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="division_id" HeaderText="Division ID"
                                        Visible="False">
                                        <HeaderStyle CssClass="grid_item_header" />
                                        <ItemStyle CssClass="grid_item" />
                                    </asp:BoundField>
                                     <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True">
                                        <HeaderStyle CssClass="grid_item_header" />
                                        <ItemStyle CssClass="grid_item" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="division_name" HeaderText="Division Name">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle CssClass="grid_item_header" />
                                        <ItemStyle CssClass="grid_item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="division_code" HeaderText="Code">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle CssClass="grid_item_header" />
                                        <ItemStyle CssClass="grid_item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="country_name" HeaderText="Country Name"
                                        ItemStyle-Wrap="false">
                                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                        <HeaderStyle CssClass="grid_item_header" />
                                        <ItemStyle CssClass="grid_item" />
                                    </asp:BoundField>
                                  
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif"
                                        ShowDeleteButton="True">
                                        <HeaderStyle CssClass="grid_item_header" />
                                        <ItemStyle CssClass="grid_item" />
                                    </asp:CommandField>
                                </Columns>
                                <HeaderStyle Height="25px" />
                                <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                <EmptyDataTemplate>
                                    No Items Found.
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

<!-- Yes No Modal Panel Start-->                                 
     <asp:Panel ID="pnYesNoModal" runat="server" Width="700" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
    <%--<asp:Panel ID="pnYesNoModal" runat="server" CssClass="input-table col-md-5 center paddinglrb popupBlock" Visible="false">--%>
        <div class="panel panel-primary panel-primary-custom">
            <div class="panel-heading panel-heading-custom">
                <div class="col-md-6 col-sm-6 col-xs-12"><h4 style="float:left">Confirmation</h4></div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:Button ID="btnOK" runat="server" Text="Reload" Style="background-color: #4CAF50" class="btn-btn" OnClick="btnOkToReload" />
                    <asp:Button ID="btnNoCancel" runat="server" Text="Cancel" Style="background-color: #4CAF50" class="btn-btn" OnClick="btnCancelToSaveInvoice "/>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class='panel-body'>
                <div id="div_model_content">
                    <b><asp:Label ID="lblMessage" runat="server" Text="This entry already exists in delete mode. Do you want to reload it?"></asp:Label></b>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnHideButton" runat="server" Text="Close" CssClass="hide"  />
    
    <ajaxToolkit:ModalPopupExtender ID="mpeYesNoModal" runat="server" 
        PopupControlID="pnYesNoModal" TargetControlID="btnHideButton" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>

            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>

