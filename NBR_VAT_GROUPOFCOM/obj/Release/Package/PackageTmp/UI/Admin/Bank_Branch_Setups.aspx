<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Bank_Branch_Setups.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.Bank_Branch_Setups" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>



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
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                        Bank Branch Setup
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Branch Name :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Bank :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlBank" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Upazila :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlUpazila" runat="server" CssClass="form-control select2" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlUpazila_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Union/Ward :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlUnionWard" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Phone1 :</label>
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
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Address :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtAddress" runat="server" Rows="3" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
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
                             <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Branch Code :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                           
                        </div>

                        <div class="row" style="text-align:right">
                             <div class="col-md-12">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" OnClick="btnSave_Click" Text="Save" />
                                <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" OnClick="btnRefresh_Click" Text="Refresh" />
                                <asp:Button ID="btnBranchList" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;float: right" OnClick="btnBranchList_Click" Text="Show Branch List" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-primary">
                    <div class="panel panel-body">
                        <asp:GridView ID="dgvBankBranch" CssClass="mydatagrid" runat="server" AutoGenerateColumns="False" DataKeyNames="branch_id" Width="100%" 
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="dgvBankBranch_PageIndexChanging"
                            OnSelectedIndexChanged="dgvBankBranch_SelectedIndexChanged"
                            OnRowDeleting="dgvBankBranch_RowDeleting">
                            <Columns>
                                  <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:BoundField DataField="branch_id" HeaderText="Branch ID" Visible="False" />
                                <asp:BoundField DataField="bank_name" HeaderText="Bank Name" />
                                <asp:BoundField DataField="branch_name" HeaderText="Branch Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="upazila_name" HeaderText="Upazila" />
                                <asp:BoundField DataField="union_ward_name" HeaderText="Union/Ward">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="branch_address" HeaderText="Address">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="phone_one" HeaderText="Phone1" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="phone_two" HeaderText="Phone2" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="branch_email" HeaderText="Email">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                              
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
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
      <%--      <uc2:MsgBox ID="msgBox" runat="server" />--%>
            <uc1:MsgBoxs runat="server" ID="msgBox" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

