<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_fxp4hfg1" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
     <link href="../../Styles/panel.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-group">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center;font-family:Tahoma; font-size:18px; font-weight: bold;">
                        Set District
                    </div>
                    <div class="panel-body">
                        <div class="row">
                           <%-- <div class="col-md-2"></div>--%>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="lblDistrictName0" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>District Name :</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtDistrictName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                              <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label1" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>Division :</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpDivision" runat="server" CssClass="form-control select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                                <div class="col-md-4">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Style="background-color:#4CAF50;" CssClass="btn-btn" OnClick="btnSave_Click" />
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" style="background-color:#4CAF50;" CssClass="btn-btn" OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnShowDistrict" runat="server" Text="Show District List" Style="background-color:#5CB85C;" CssClass="btn-btn" OnClick="btnShowDistrict_Click" />

                            </div>
                          <%--  <div class="col-md-4"></div>--%>
                        </div>
                        <div class="row">
                            <div class="col-md-2"></div>
                          
                            <div class="col-md-4"></div>
                        </div>
                        <div class="row" style="margin-top: 0px; margin-bottom: 5px">
                            <div class="col-md-3"></div>
                        
                            <div class="col-md-3"></div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-primary">
                    <div class="panel panel-body">
                        <asp:GridView ID="dgvDistrict" runat="server" AutoGenerateColumns="False"
                            CssClass="mydatagrid" DataKeyNames="district_id" Width="100%"
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="dgvDistrict_PageIndexChanging"
                            OnRowDataBound="dgvDistrict_RowDataBound"
                            OnRowDeleting="dgvDistrict_RowDeleting"
                            OnSelectedIndexChanged="dgvDistrict_SelectedIndexChanged">
                            <Columns> 
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:BoundField DataField="district_name" HeaderText="District Name" />
                                <asp:BoundField DataField="divName" HeaderText="Division" />                               
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif"
                                    ShowDeleteButton="True" />
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
                    <b><asp:Label ID="lblMessage" runat="server" Text="This entry already exists for the selected division in delete mode. Do you want to reload it?"></asp:Label></b>
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

