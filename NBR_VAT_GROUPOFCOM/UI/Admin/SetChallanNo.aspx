<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_SetChallanNo, App_Web_bxnrqbtx" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="../../UserControls/admin.ascx" tagname="admin" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
     <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .sGrid
        {}
        .table-bordered
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px;font-weight: bold; height: 30px; padding-top: 0px">Challan Book Setup</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                  <div class="row" style="margin-top:1%">
                     
                     <div class="col-md-4">
                         <div class="form-group form-group-sm">
                             <asp:Label ID="lblDistrictName0" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required"> * </span>Challan Type :</asp:Label>
                             <div class="col-sm-7">
                                 <asp:DropDownList ID="drpChallanType" CssClass="form-control select2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpChallanType_selectedIndexChanged"></asp:DropDownList>
                             </div>
                         </div>
                     </div>
                      <div class="col-md-4">
                         <div class="form-group form-group-sm">
                             <asp:Label ID="lblDistrictName" CssClass="control-label col-sm-5 text-right" runat="server" Text=""><span class="required"> * </span>Challan Book No :</asp:Label>
                            <div class="col-sm-7">
                               <asp:TextBox ID="txtBookNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                           <ajaxToolkit:FilteredTextBoxExtender ID="txtInsuranceAmount_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="txtBookNo"
                                                        ValidChars="0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                     </div>
                       <div class="col-md-4">
                         <div class="form-group form-group-sm">
                             <asp:Label ID="Label4" CssClass="control-label col-sm-5 text-right" runat="server" Text=""><span class="required"> * </span>Organization Branch :</asp:Label>
                            <div class="col-sm-7">
                                <asp:DropDownList ID="drpBranch" CssClass="form-control select2" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                     </div>
                    
                  </div>
                  
                  <div class="row">
                     
                       <div class="col-md-4">
                           <div class="form-group form-group-sm">
                               <asp:Label ID="lblDivision" CssClass="control-label col-sm-5 text-right" runat="server" Text=""><span class="required"> * </span>Page From :</asp:Label>
                            <div class="col-sm-7">
                               <asp:TextBox ID="txtPageFrom" CssClass="form-control"  runat="server" ></asp:TextBox>
                            </div>
                        </div>
                       </div>
                       <div class="col-md-4">
                           <div class="form-group form-group-sm">
                               <asp:Label ID="lblDivision0" CssClass="control-label col-sm-5 text-right" runat="server" Text=""><span class="required"> * </span>Page To :</asp:Label>
                            <div class="col-sm-7">
                               <asp:TextBox ID="txtPageTo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                       </div>
                     <div class="col-md-4">
                           <div class="form-group form-group-sm">
                               <asp:Label ID="Label3" CssClass="control-label col-sm-5 text-right" runat="server" Text="Prefix :"></asp:Label>
                            <div class="col-sm-7">
                               <asp:TextBox ID="txtPrefix" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                       </div>
                       
                  </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="lblDistrictName1" CssClass="control-label col-sm-5 text-right" runat="server" Text="Challan Year :"></asp:Label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpChallanYear" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <%--<asp:CheckBox ID="chkIsAppAllBranch" ForeColor="green" runat="server" Text="Is Applicable for All Branch?" />--%>
                                
                                <div class="col-sm-7">
                                  
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                              
                                <div class="col-sm-7">
                                  
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--sabbir 30/3/20--%>
                    <div class="row">

                        <%--<div class="col-md-4" style="padding-right: 0%; padding-left: 10%;"></div>--%>

                        <div class="col-md-5" style="padding-right: 0%; padding-left: 10%;">
                            <div class="form-group form-group-sm">
                                <asp:CheckBox ID="chkIsAppAllBranch" ForeColor="green" runat="server" Text="Is Applicable for All Branch?" />
                                <br />
                                <asp:CheckBox ID="digitCheck" ForeColor="green" runat="server" Text="Do you want to set specific number of digits in challan number?" OnCheckedChanged="digitCheckChanged" AutoPostBack="true" />
                                <div class="col-sm-7">
                                  
                                </div>
                            </div>
                        </div>

                        <div class="col-md-2" style="padding-right: 0%; padding-left: 6.5%;">
                            <div class="form-group form-group-sm">
                                <br />
                                <asp:TextBox ID="digitNumber" placeholder="Maximum 10" CssClass="form-control" Visible="false" runat="server" ></asp:TextBox>
                                <div class="col-sm-7">
                                  
                                </div>
                            </div>
                        </div>

                    </div>
                     <%-- end sabbir 30/3/20--%>

                  <div class="row">
                      <div class="col-md-4">
                           <div class="form-group form-group-sm">
                              <%-- <asp:Label ID="lblDistrictName1" CssClass="control-label col-sm-5 text-right" runat="server" Text="Challan Year :"></asp:Label>--%>
                            <div class="col-sm-7">
                       <%--        <asp:DropDownList ID="drpChallanYear" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                            </div>
                        </div>
                       </div>
                    <div class="col-md-8" style="text-align:right">
                        <asp:Button ID="btnSave" runat="server"  Text="Save" style="background-color:#4CAF50;margin-left:16.5%;" CssClass="btn-btn" onclick="btnSave_Click" />
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh"  CssClass="btn-btn" style="background-color:#4CAF50;" onclick="btnRefresh_Click" />
                        <%--<asp:Button ID="btnChallanBookDetails" runat="server" style="background-color:#5CB85C;" CssClass="btn-btn" onclick="btnShowChallanBookDetails_Click" ><i class="fa fa-search"></i>Search Challan Book</asp:Button>--%>

                        <asp:Button ID="btnChallanBookDetails" runat="server" Text="Search Challan Book" style="background-color:#3B7CB5;" CssClass="btn-btn" onclick="btnShowChallanBookDetails_Click"  />
                        <button type="button" class="btn-btn" style="background-color:#B681B7;" data-toggle="modal" data-target="#myModal">Add Fiscal Year</button>
                     </div>
                  </div>
                   <div class="row" style="margin-top:5px;margin-bottom:5px">
                     <div class="col-md-3"></div>
                     
                     <div class="col-md-3"></div>
                   </div>
                </div>

            </div>

         </div>
       </div>

  
    <%--<table align="center" id="tblSetDistrict"  bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input" runat="server">
            <tr>
                <td colspan="4" height="30" class="page_title">
                    Challan Book Setup<uc1:admin ID="admin" runat="server" /></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblDistrictName0" runat="server" Text="Challan Type :"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="drpChallanType" runat="server" Width="215px" AutoPostBack="True" OnSelectedIndexChanged="drpChallanType_selectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="lblDistrictName" runat="server" Text="Challan Book No :"></asp:Label>
                </td>
                <td style="text-align: left" colspan="3">
        <asp:TextBox ID="txtBookNo" runat="server" Width="212px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <asp:Label ID="lblDivision" runat="server" Text="Page From :"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtPageFrom" runat="server" Width="60px"></asp:TextBox>
                </td>
                    <td align="right">
                    <asp:Label ID="lblDivision0" runat="server" Text="Page To :"></asp:Label>
                </td>
                    <td>
        <asp:TextBox ID="txtPageTo" runat="server" Width="60px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <asp:Label ID="lblDistrictName1" runat="server" Text="Challan Year :"></asp:Label>
                </td>
            <td colspan="3">
                    <asp:DropDownList ID="drpChallanYear" runat="server" Width="62px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="btnSave" runat="server"  Text="Save" 
                        height="30px" CssClass="button" onclick="btnSave_Click" />
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                         Height="30px" CssClass="button" onclick="btnRefresh_Click" />
                    <asp:Button ID="btnChallanBookDetails" runat="server" Text="Search Challan Book" 
                         height="30px" CssClass="button" onclick="btnShowChallanBookDetails_Click"  />
                   <button type="button" class="btn btn-default" data-toggle="modal" data-target="#myModal">Add Fiscal Year</button>
                </td>
            </tr>
            
            <tr>
                <td colspan="4" style="text-align: center">
                    &nbsp;</td>
            </tr>
            
            </table>--%>

               <%--<table align="center" id="Table1"  bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" runat="server">
               <tr>
               <td>
               --%>
              
              <%-- 
               </td>

               </tr>
                 <tr>
               <td style="margin-top:1%">
               --%>
         <div class="row">
                    <asp:GridView ID="dgvChallanNo" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="challan_book_id"  CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    AutoGenerateSelectButton="True" 
                        onselectedindexchanged="dgvDistrict_SelectedIndexChanged" >
                    <Columns>
                        <asp:BoundField HeaderText="Chalan Type" DataField="challan_type"></asp:BoundField>
                        <asp:BoundField HeaderText="Book No" DataField="challan_book_no" />
                        <asp:BoundField HeaderText="Page From" DataField="page_from" />
                        <asp:BoundField DataField="page_to" HeaderText="Page To" />
                        <asp:BoundField DataField="USED_PAGE_COUNT" HeaderText="Used Pages" />
                        <asp:BoundField DataField="challan_year" HeaderText="Challan Year" />
                        <asp:BoundField DataField="branch_name" HeaderText="Office" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                                                    SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                                                    ShowDeleteButton="True" Visible="False" />
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
    <br />
                   <div class="row">
                         <asp:GridView ID="gvBookDetail" runat="server" AutoGenerateColumns="False" 
                   DataKeyNames="challan_book_id,page_no"  CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    AutoGenerateSelectButton="True" 
                        onrowdatabound="dgvDistrict_RowDataBound" 
                        onrowdeleting="dgvDistrict_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="Page No" DataField="page_no" />
                        <asp:BoundField HeaderText="Challan No" DataField="challan_no" />
                        <asp:BoundField DataField="page_status" HeaderText="Page Status" />
                        <asp:BoundField HeaderText="Remarks" DataField="remarks"></asp:BoundField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" Visible="False" />
                             <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/cross.png" 
                            ShowDeleteButton="True" Visible="False"  />
                    </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle Height="25px" BackColor="#29a531" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" 
                            ForeColor="#8C4510" />
                   <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                       </div>
            <%--   
               </td>

               </tr>
               <tr>
               <td style="margin-top:1%">--%>
                  <div class="row">
                       <asp:GridView ID="gvChallanBook" runat="server" AutoGenerateColumns="False" 
                     CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                     >
                    <Columns>
                        <asp:BoundField HeaderText="Chalan Type" DataField="challan_type"></asp:BoundField>
                        <asp:BoundField HeaderText="Book No" DataField="challan_book_no" />
                        <asp:BoundField HeaderText="Page From" DataField="page_from" />
                        <asp:BoundField DataField="page_to" HeaderText="Page To" />
                        <asp:BoundField DataField="USED_PAGE_COUNT" HeaderText="Used Pages" />
                        <asp:BoundField DataField="challan_year" HeaderText="Challan Year" />
                        <asp:BoundField DataField="branch_name" HeaderText="Branch" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                                                    SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                                                    ShowDeleteButton="True" Visible="False" />
                    </Columns>
                      <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle Height="25px" BackColor="#29a531" Font-Bold="True" 
                          ForeColor="White" />
                      <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#8C4510" 
                          BackColor="#FFF7E7" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                      <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#FFF1D4" />
                      <SortedAscendingHeaderStyle BackColor="#B95C30" />
                      <SortedDescendingCellStyle BackColor="#F1E5CE" />
                      <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                      </div>
              <%-- </td>
               </tr>
               </table>--%>

               <uc2:MsgBox ID="msgBox" runat="server" />

   <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm" style="width:355px">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Fiscal Year Add...</h4>
        </div>
        <div class="modal-body">
         <div class="row">
           <div class="col-sm-6">
              <asp:Label ID="Label1" runat="server" Text="From Date:"></asp:Label>
              <asp:TextBox runat="server" CssClass="present-address-tb" ID="txtFromDate" ReadOnly="true" ></asp:TextBox>
           </div>
           <div class="col-sm-6">
              <asp:Label ID="Label2" runat="server" Text="To Date:"></asp:Label>
              <asp:TextBox runat="server" CssClass="present-address-tb" ID="txtToDate" ReadOnly="true"></asp:TextBox>
           </div>
         </div>
        
        </div>
        <div class="modal-footer">
        <asp:Label runat="server" ID="lblFiscalYear" Visible=false/>
         <asp:Button ID="btnFiscalYearSave" runat="server" class="btn btn-primary" Text="Save" onclick="btnFiscalYear_Click"  />
          <button type="button" class="btn btn-default" data-dismiss="modal" >Close</button>
        </div>
      </div>
    </div>
  </div>
       <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 12.05.2021
            </div>    

</asp:Content>

