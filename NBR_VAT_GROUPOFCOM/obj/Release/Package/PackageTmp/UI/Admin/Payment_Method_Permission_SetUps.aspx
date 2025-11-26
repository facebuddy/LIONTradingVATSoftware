<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Payment_Method_Permission_SetUps.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.Payment_Method_Permission_SetUps" %>



<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc2" TagName="MsgBoxs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
  <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .full_body_readyform
        {
            font-size: medium;
            font-family: Vani;
            width: 98%;
            padding: 3PX;
            border: 1px solid black;
        }
        
        
        .full_width_upermission
        {
            width: 55%;
            border: 1px solid black;
            padding: 10px;
            text-align: left;
            margin: 5px 0px;
            float: left;
        }
        
        .full_width_uspermission2
        {
            width: 40%;
            border: 1px solid black;
            padding: 10px;
            text-align: left;
            margin: 5px 0px;
            float: left;
        }
        
        .clear_fix
        {
            clear: both;
        }
    
        .style1
        {
            width: 106px;
        }
    
    </style>


     <div class="container-fluid">
              <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;
                height: 30px; padding-top: 0px">
                            <b>Payment Method Permission</b>
                        </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-2" style="text-align:right">
                             Organization Name <span style='font-size:20px;'>:</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtOrgName" runat="server" class="form-input-Test"  style="margin-top:5px"
                                        placeholder="Enter Organization Name" Width="200px"></asp:TextBox>
                              
                            </div>
                              <div class="col-sm-2">
                                   <asp:LinkButton ID="btnSearch" runat="server" style="width:100px;background-color:#3B7CB5;" CssClass="btn btn-success btn-sm" ValidationGroup="validUser" OnClick="btnSearch_Click"><i class="fa fa-search"></i>  Search</asp:LinkButton>

                            </div>
                              </div>
                            </div>
                           

                        <div class="clearfix">
                        </div>
                    </div>
                </div>

        <div class="container-fluid">
        <div class="panel panel-primary">
    <div class="panel-heading" style="text-align: center; font-size: 25px; font-weight: bold;
                height: 30px; padding-top: 0px">
                            <b>  Set Payment Method Permission</b>
                        </div>
                <div class="full_body_readyform">
                    <div class="clear_fix">
                    </div>
                    <div class="full_width_upermission">
                        <asp:Panel ID="pnInput" CssClass="input-table tablefull center paddinglrb" runat="server">
                            <asp:GridView ID="gvOrg" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True"
                                CssClass="table" DataKeyNames="org_id,branch_id" AllowPaging="True" 
                                onpageindexchanging="gvOrg_PageIndexChanging" 
                                onselectedindexchanged="gvOrg_SelectedIndexChanged" BackColor="White" 
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <Columns>
                                    <asp:BoundField DataField="organization_name" HeaderText="Organization Name" />
                                    <asp:BoundField DataField="branch_unit_name" HeaderText="Branch Name" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </asp:Panel>
                        <div style="text-align:right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary"
                              style="width:100px;background-color:#4CAF50;" ValidationGroup="validDept" onclick="btnSubmit_Click" />
                        </div>
                         <div style = "width:auto; padding-left:3%";">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </div>
                                    
                    </div>
                    <div class="full_width_uspermission2">
                        <%--<asp:TreeView ID="tvwOrgPermission" runat="server" ShowCheckBoxes="All" ExpandDepth="0"
                            ShowLines="True" TabIndex="0">
                            <SelectedNodeStyle BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" />
                        </asp:TreeView>--%>
                        <asp:TreeView ID="tvwOrgPermission" runat="server" ShowCheckBoxes="Leaf" ExpandDepth="0"
                            ShowLines="True" TabIndex="0">
                            <SelectedNodeStyle BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" />
                        </asp:TreeView>
                    </div>
                    <div class="clear_fix">
                    </div>
                </div>
            </div>
         </div>
<%--    <uc2:MsgBox ID="msgBox" runat="server" />--%>
    <uc2:MsgBoxs runat="server" id="msgBox" />
</asp:Content>


