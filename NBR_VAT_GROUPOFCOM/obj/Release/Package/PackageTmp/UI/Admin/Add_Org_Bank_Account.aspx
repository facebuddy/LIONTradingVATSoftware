<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Add_Org_bank_Account, App_Web_z1w3wddp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <script>
        function bankAccount(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9\b]|[.]|\-/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function character(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /^[a-zA-Z]+$|[ ]/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-group">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                        Organization Bank account setup
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Organization Name :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlOrganization" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Bank Name :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged" CssClass="form-control select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Branch Code :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlBankBranch" runat="server" CssClass="form-control select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Account number :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtAccountNo" onkeypress="return bankAccount(event)" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Account name :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtAccountName" onkeypress="return character(event)" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" OnClick="btnSave_Click" Text="Save" />
                                <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" OnClick="btnRefresh_Click" Text="Refresh" />
                                <asp:Button ID="btnShowList" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;float: right" Text="Show Account List" OnClick="btnShowList_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-primary">
                    <div class="panel panel-body">
                        <asp:GridView ID="dgvOrgBankAccount" runat="server" AutoGenerateColumns="False"
                            CssClass="mydatagrid" DataKeyNames="account_id"
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="dgvOrgBankAccount_PageIndexChanging"
                            Width="100%" OnRowDataBound="dgvOrgBankAccount_RowDataBound"
                            OnRowDeleting="dgvOrgBankAccount_RowDeleting"
                            OnSelectedIndexChanged="dgvOrgBankAccount_SelectedIndexChanged">
                            <Columns>
                                 <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True">
                                </asp:CommandField>
                                <asp:BoundField DataField="account_id" HeaderText="Account ID" Visible="False" />
                                <asp:BoundField DataField="Organization_Name" HeaderText="Organization Name"/>
                                <asp:BoundField DataField="bank_name" HeaderText="Bank Name"/>
                                <asp:BoundField DataField="branch_name" HeaderText="Branch Name"/>
                                <asp:BoundField DataField="account_no" HeaderText="Account No" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="Account_Name" HeaderText="Account Name">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                               
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True">
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle Height="25px" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                            <EmptyDataTemplate>
                                No Bank Account Found.
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
                    <b><asp:Label ID="lblMessage" runat="server" Text="This entry already exists for the same account no, branch and organization in delete mode. Do you want to reload it?"></asp:Label></b>
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

