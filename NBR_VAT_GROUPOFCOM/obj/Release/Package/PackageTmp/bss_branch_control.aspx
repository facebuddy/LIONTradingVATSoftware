<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="bss_branch_control, App_Web_1kre2rwf" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <style>
         .hiddencol {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
       <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div id="mainDiv" class="container-fluid">
          <div class="container-fluid">
                <div class="panel panel-primary">
        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                        Business Unit / Branch Access Control
                    </div>        
                              <div class="row" style="margin-top:10px">
                                    <div class="col-md-5">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label1" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required" style="color:red"> * </span>User:</asp:Label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:DropDownList ID="drpUser" runat="server" class="form-control select2" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-5">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label34" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required" style="color:red"> * </span>Business Unit/Organization:</asp:Label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:DropDownList ID="drpOrg" runat="server" class="form-control select2" onselectedindexchanged="drpOrg_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                   </div>
                                    <div class="row">
                                            <div class="col-md-5">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label36" runat="server" Text="" class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>Org. Branch: </asp:Label>
                                                    <div class="col-sm-7 " style="padding:0px">
                                                        <asp:DropDownList ID="drpBranch" runat="server" class="form-control select2"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>                                       
                                               <div class="col-md-5">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label2" runat="server" Text="" class="col-sm-5 control-label text-right">Remarks: </asp:Label>
                                                    <div class="col-sm-7 " style="padding:0px">
                                                        <asp:TextBox ID="txtRemarks" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>                                         
                                        </div>
                    <div class="row">
                        
                       <div class="col-md-12" style="text-align:right;">
                           <asp:Button ID="btnBranchAdd" class="btn btn-primary btn-sm" Style="margin-right:10px" runat="server" Text="Add" OnClick="btnBranchAdd_Click"/>
                       <asp:Button ID="btnUpdate" Style="background-color:#f2b202" CssClass="btn-btn"
                                runat="server" Text="Update"  onclick="btnUpdate_Click" />
                       </div>
                    </div>
                    <div class="row">
                            <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="False"
                                    CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3"  
                onrowdeleting="gvBranch_RowDeleting" PageSize="15" 
                onrowdatabound="gvBranch_RowDataBound">
                                    <Columns>

                                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
                                         <asp:BoundField HeaderText="Employee Name" DataField="Employee_name" />
                                                <asp:BoundField HeaderText="Organization Name" DataField="Org_name" />
                                                <asp:BoundField HeaderText="Branch Name" DataField="Org_branch_name" />
                                         <asp:BoundField HeaderText="Remarks" DataField="Remarks" /> 
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                    <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                  </div>
                    <div class="row">
                              <div class="col-md-12" style="text-align:right">
                         <asp:Button ID="btnSave" Style="background-color:#4CAF50;margin-right:10px" CssClass="btn-btn"
                                runat="server" Text="Save"  onclick="btnSave_Click" />                            
                               
                    </div>
                  </div> 
                    
                      <div class="row">
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False"
                                    CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                             BorderStyle="None" BorderWidth="1px" CellPadding="3"                    
                onselectedindexchanged="gvShow_SelectedIndexChanged"   DataKeyNames="bss_brnch_cont_id"              
                onrowdeleting="gvShow_RowDeleting" PageSize="15" 
                onrowdatabound="gvShow_RowDataBound">
                                    <Columns>
                                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
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
                                    <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                  </div>                        
             </div>
          </div>
      </div>
               <div style="width:100%; height:auto">
                 <uc2:MsgBox ID="msgBox" runat="server" />
                 </div>

 </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
