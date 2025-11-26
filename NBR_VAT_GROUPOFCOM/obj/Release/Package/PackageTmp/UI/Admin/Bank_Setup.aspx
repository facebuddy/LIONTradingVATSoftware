<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Bank_Setup, App_Web_z1w3wddp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-group">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px;font-weight: bold;">
                        Bank Setup
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <%--<label class="col-sm-5 control-label text-right">Bank Name :</label>--%>
                                    <label class="control-label col-sm-5"><span class="required" style="color:red"> * </span>Bank Name :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Bank Code :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtBankCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Short Name :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtShortName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <%--<label class="col-sm-5 control-label text-right">Phone1 :</label>--%>
                                    <label class="control-label col-sm-5">Phone1 :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Phone2 :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtPhone2" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Email :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <%--<label class="col-sm-5 control-label text-right">Address :</label>--%>
                                    <label class="control-label col-sm-5"><span class="required" style="color:red"> * </span>Address :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtAddress" runat="server" Rows="3" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Web Address :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" OnClick="btnSave_Click" Text="Save" />
                                <asp:Button ID="btnRefresh" runat="server"  CssClass="btn-btn" Style="background-color:#4CAF50;float: right" OnClick="btnRefresh_Click" Text="Refresh" />
                                <asp:Button ID="btnShowBankList" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;float: right" OnClick="btnShowBankList_Click" Text="Show Bank List" />
                            </div>
                        </div>
                    </div>
                </div>

                <%--sabbir 18/5/20--%>
                 <div class="panel panel-primary">
                <div class="panel-body">
                   <div class="col-md-6">
                                    <div class="form-group form-group-sm">                                        
                                        <label class="col-sm-5 control-label text-right">Bank Name :</label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList ID="drpBank" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>
                                           
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" Style="background-color:#3B7CB5;" OnClick="btnSearch_Click" Text="Search" />
                                        </div>
                                    </div>
                                </div>
                    
                 </div>
            </div>
                <%--end sabbir 18/5/20--%>

                <div class="panel panel-primary">
                    <div class="panel panel-body">
                        <asp:GridView ID="dgvBank" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" DataKeyNames="bank_id" Width="100%"
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="dgvBank_PageIndexChanging"
                            OnSelectedIndexChanged="dgvBank_SelectedIndexChanged" OnRowDataBound="dgvBank_RowDataBound"
                            OnRowDeleting="dgvBank_RowDeleting">
                            <Columns>
                                 <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:BoundField DataField="bank_id" HeaderText="Bank ID" Visible="False" />
                                <asp:BoundField DataField="bank_name" HeaderText="Bank Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Bank_Code" HeaderText="Bank Code" DataFormatString="{0:000}" />
                                <asp:BoundField DataField="short_name" HeaderText="Short Name" />
                                <asp:BoundField DataField="bank_address" HeaderText="Address">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="phone_one" HeaderText="Phone1" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="phone_two" HeaderText="Phone2" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="bank_email" HeaderText="Email">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="web_address" HeaderText="Web" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                               
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
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
                    <b><asp:Label ID="lblMessage" runat="server" Text="This bank name entry already exists for the organization in delete mode. Do you want to reload it?"></asp:Label></b>
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

