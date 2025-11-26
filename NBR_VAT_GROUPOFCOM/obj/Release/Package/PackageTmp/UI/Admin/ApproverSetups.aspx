<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="ApproverSetups.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.ApproverSetups" %>




<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
        <div id="mainDiv" class="container-fluid">
          <div class="container-fluid">
                <div class="panel panel-primary">
        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">Approver Stage Setting</div>        
                              <div class="row" style="margin-top:10px">
                                      <%--<div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label2" runat="server" Text="" class="col-sm-5 control-label text-right">No. of Stage </asp:Label>
                                                    <div class="col-sm-7 ">
                                                        <asp:TextBox ID="txtNoStage" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                     </div>--%>
                                   <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                               <asp:Label ID="label34" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required" style="color:red"> * </span>Approver:</asp:Label>
                                             <div class="col-sm-7">
                                                <asp:DropDownList ID="drpApprove" runat="server" class="form-control select2" >

                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">1st Stage</asp:ListItem>
                                                            <asp:ListItem Value="2">2nd Stage</asp:ListItem>
                                                            <asp:ListItem Value="3">3rd Stage</asp:ListItem>
                                                            <asp:ListItem Value="4">Final Stage</asp:ListItem>
                                               </asp:DropDownList>
                                            </div>
                                        </div>
                                  </div>
                                    <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label1" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required" style="color:red"> * </span>User:</asp:Label>
                                                    <div class="col-sm-7">
                                                        <asp:DropDownList ID="drpUser" runat="server" class="form-control select2" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                    <div class="col-md-4" style="text-align:right;">
                                           <asp:Button ID="btnBranchAdd" class="btn-btn" style="background-color:#B681B7" runat="server" Text="Add" OnClick="btnAdd_Click"/>
                                            <asp:Button ID="btnSave" Style="background-color:#4CAF50;margin-right:10px" CssClass="btn-btn" runat="server" Text="Save" OnClick="btnSave_Click"/>    
                       <%--<asp:Button ID="btnUpdate" Style="background-color:#f2b202" CssClass="btn-btn"
                                runat="server" Text="Update"  onclick="btnUpdate_Click" />--%>
                                    </div>  
                                   </div>
                                  
                    <div class="row">
                        
                     
                    </div>
                    <div class="row">
                            <asp:GridView ID="gvApprover" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px"  BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" PageSize="15" onrowdatabound="gvApprover_RowDataBound">
                                    <Columns>

                                         <asp:BoundField HeaderText="Employee Name" DataField="Employee_name" />
                                         <asp:BoundField HeaderText="Organization Name" DataField="Org_name" />
                                         <%--<asp:BoundField HeaderText="Branch Name" DataField="Org_branch_name" />--%>
                                         <asp:BoundField HeaderText="Approver Stage" DataField="ApproverStage" /> 
                                        
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                  </div>
                  
                    
                    <%--  <div class="row">
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False"
                                    CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                             BorderStyle="None" BorderWidth="1px" CellPadding="3"                    
                onselectedindexchanged="gvShow_SelectedIndexChanged"   DataKeyNames="bss_brnch_cont_id"              
                onrowdeleting="gvShow_RowDeleting" PageSize="15" 
                onrowdatabound="gvShow_RowDataBound">
                                    <Columns>
                     
                                         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/edit.png"
                                ShowSelectButton="True" />
                                         <asp:BoundField HeaderText="Employee Name" DataField="Employee_name" />
                                          <asp:BoundField HeaderText="Organization Name" DataField="Org_name" />                                         
                                          <asp:BoundField HeaderText="Branch Name" DataField="Org_branch_name" />
                                         <asp:BoundField HeaderText="Remarks" DataField="Remarks" /> 
                                         <asp:BoundField HeaderText="" DataField="Org_branch_reg_id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                                        <asp:BoundField HeaderText="" DataField="bss_brnch_cont_id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                  </div>  --%>                      
             </div>
          </div>
      </div>
               <div style="width:100%; height:auto">
               <%--  <uc2:MsgBox ID="msgBox" runat="server" />--%>
                   <uc1:MsgBoxs runat="server" ID="msgBox" />
                 </div>

        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>