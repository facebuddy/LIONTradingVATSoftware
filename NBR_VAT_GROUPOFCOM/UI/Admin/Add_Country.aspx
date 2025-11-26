<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Add_Country, App_Web_z1w3wddp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

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
                        Set Country
                    </div>
                    <div class="panel-body">
                        <div class="row">
                         <%--   <div class="col-md-2"></div>--%>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="lblDistrictName0" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>Country Name :</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label2" CssClass="col-sm-5 control-label text-right" runat="server" Text="">Country Code :</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtCountryCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label5" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>Abbreviation Name :</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtCountryAbbrName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                           <%-- <div class="col-md-4"></div>--%>
                        </div>
                      <%--  <div class="row">
                            <div class="col-md-2"></div>
                            
                            <div class="col-md-4"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-2"></div>
                           
                            <div class="col-md-4"></div>
                        </div>--%>
                        <div class="row" style="margin-top: 0px; margin-bottom: 5px">
                            <div class="col-md-6"></div>
                            <div class="col-md-6" style="text-align:right">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Style="background-color:#4CAF50;margin-left: 16.5%;" CssClass="btn-btn" OnClick="btnSave_Click" />
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" style="background-color:#4CAF50;" CssClass="btn-btn" OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnShowCountryList" runat="server" Text="Show Country List" Style="background-color:#5CB85C;" CssClass="btn-btn" OnClick="btnShowCountryList_Click" />

                            </div>
                          <%--  <div class="col-md-3"></div>--%>
                        </div>
                    </div>
                </div>
                 <div class="panel panel-primary">
                <div class="panel-body">
                   <div class="col-md-6">
                                    <div class="form-group form-group-sm">                                        
                                        <label class="col-sm-5 control-label text-right">Country Name :</label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>
                                           
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" Style="background-color:#3B7CB5;" OnClick="btnSearch_Click" Text="Search" />
                                        </div>
                                    </div>
                                </div>
                    
                 </div>
            </div>
                <div class="panel panel-primary">
                    <div class="panel panel-body">
                        <asp:GridView ID="dgvCountry" runat="server" AutoGenerateColumns="False"
                            CssClass="mydatagrid" DataKeyNames="country_id"
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="dgvCountry_PageIndexChanging"
                            OnRowDeleting="dgvCountry_RowDeleting"
                            OnSelectedIndexChanged="dgvCountry_SelectedIndexChanged" Width="100%"
                            OnRowDataBound="dgvCountry_RowDataBound">
                            <Columns>
                                  <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png"
                                    ShowSelectButton="True">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                                <asp:BoundField DataField="country_id" HeaderText="Country ID"
                                    Visible="False" />
                                <asp:BoundField DataField="country_name" HeaderText="Country Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="country_code" HeaderText="Code">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="abbr_name" HeaderText="Abbriviation Name"
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
                            <PagerStyle ForeColor="Black" />
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
                    <b><asp:Label ID="lblMessage" runat="server" Text="This country already exists. Do you want to reload it?"></asp:Label></b>
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
