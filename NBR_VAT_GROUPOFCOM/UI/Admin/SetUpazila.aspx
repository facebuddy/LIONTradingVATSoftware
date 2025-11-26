<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_irtltu31" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <link href="../../Styles/panel.css" rel="stylesheet" />
</asp:Content>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-group">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                        Set Upazila
                    </div>
                    <div class="panel-body">
                        <div class="row" style="margin-top:1%">
                   <%--  <div class="col-md-2"></div>--%>
                     <div class="col-md-4">
                         <div class="form-group form-group-sm">
                             <asp:Label ID="lblDistrictName0" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>Upazila Name :</asp:Label>
                             <div class="col-sm-7">
                                 <asp:TextBox ID="txtUpazilaName" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                         </div>
                     </div> 
                            <div class="col-md-4">
                            <div class="form-group form-group-sm">
                             <asp:Label ID="Label1" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>District Name :</asp:Label>
                             <div class="col-sm-7">
                                  <asp:DropDownList ID="drpDistrictName" runat="server" CssClass="form-control select2">
                                  </asp:DropDownList>
                             </div>
                                </div>
                         </div>
                            <div class="col-md-4">
                        <asp:Button ID="btnSave" runat="server"  Text="Save" Style="background-color:#4CAF50;margin-left:16.5%;" CssClass="btn-btn" onclick="btnSave_Click" />
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" style="background-color:#4CAF50;" CssClass="btn-btn" onclick="btnRefresh_Click" />
                        <asp:Button ID="btnShowUpazila" runat="server" Text="Show Upazila List" Style="background-color:#5CB85C;" CssClass="btn-btn" onclick="btnShowUpazila_Click"  />
                        
                     </div>
                     <%--<div class="col-md-4"></div>--%>
                  
                        <div class="row">
                     <div class="col-md-2"></div>
                    
                         
                     </div>
                     <div class="col-md-4"></div>
                  </div>
                        <div class="row" style="margin-top:0px;margin-bottom:5px">
                     <div class="col-md-3"></div>
                     
                     <div class="col-md-3"></div>
                   </div>
                    </div>
                </div>
                <div class="panel panel-primary">
                    <div class="panel panel-body">
                        <asp:GridView ID="dgvUpazila" runat="server" AutoGenerateColumns="False" 
                    CssClass="mydatagrid" DataKeyNames="upazila_id" Width="100%" 
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="dgvUpazila_PageIndexChanging"
                        onrowdatabound="dgvUpazila_RowDataBound" onrowdeleting="dgvUpazila_RowDeleting" 
                        onselectedindexchanged="dgvUpazila_SelectedIndexChanged" >
                    <Columns>
                         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                        <asp:BoundField DataField="upazila_name" HeaderText="Upazila Name" />
                        <asp:BoundField DataField="disName" HeaderText="District" />                       
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
                    <b><asp:Label ID="lblMessage" runat="server" Text="This entry already exists for the selected district in delete mode. Do you want to reload it?"></asp:Label></b>
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

