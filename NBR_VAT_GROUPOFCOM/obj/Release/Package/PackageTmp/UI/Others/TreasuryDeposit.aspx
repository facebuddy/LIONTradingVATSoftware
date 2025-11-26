

<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="TreasuryDeposit.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Others.TreasuryDeposit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>




<%--<%@ Register src= "~/UserControls/Others.ascx" tagname="others" tagprefix="uc1" %>
<%@ Register src="../../UserControls/admin.ascx" tagname="admin" tagprefix="uc1" %>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style>
        .hiddencol {
            display: none;
        }

  </style> 
    <script>
       
        function openModal() {
            $('#exampleModalLong').modal('show');
        };
      
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" Runat="Server">
    <center><h3>Treasury Deposit(টি.আর. ফর্ম নং-৬)</h3>
    <h5>TR Challan Insertion Form</h5></center>
    <asp:Button ID="basic" runat="server" CssClass="btn-btn" style="background-color:#4CAF50;" Text="Insert New TR Challan No" OnClick="basic_Click"/>
    <asp:Button ID="Advanced" runat="server"  CssClass="btn-btn" style="background-color:#4CAF50;"  Text="Edit Existing TR Challan" OnClick="Advanced_Click"/>
    
    <asp:GridView ID="gvForTRchallan" runat="server"  AutoGenerateColumns="False" CssClass="mGrid"  ShowHeader="true" OnRowCommand="gvForTRchallan_RowCommand">
        <HeaderStyle  CssClass="GridViewHeaderStyle" />
            <Columns>                             
                <asp:TemplateField HeaderText="">        
                    <HeaderTemplate>Update</HeaderTemplate>            
                    <ItemTemplate>
                        <asp:Button ID="addTRchallanBtn" runat="server"  CommandName="AddTRchallan" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"                               
                         CssClass="btn-btn" style="background-color:#4CAF50;"   Text="Update TR Challan" />
                    </ItemTemplate>         
                </asp:TemplateField>   
                     
                <asp:TemplateField HeaderText="">        
                    <HeaderTemplate>TR Challan NO</HeaderTemplate>            
                    <ItemTemplate><asp:TextBox ID="txtTRchallanNO" runat="server" CssClass="text_box" Text='<%# Eval("tr_challan_no") %>' ></asp:TextBox></ItemTemplate>         
                </asp:TemplateField>               
                <asp:BoundField  HeaderText="CG Number" DataField="challan_no"/>
                <asp:BoundField  HeaderText="Vat Amount" DataField="vat_amount_unit"/>
                <asp:BoundField  HeaderText="Challan for" DataField="code_name"/>   
                <asp:BoundField HeaderText="Sales Challan Number" DataField="challan_numbers"/>  
                 <asp:BoundField  HeaderText="" DataField="Challan_id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>                              
              <asp:TemplateField HeaderText="">        
                    <HeaderTemplate>Upload</HeaderTemplate>            
                    <ItemTemplate>
                       <asp:FileUpload id="FileUploadControl" AllowMultiple="true" Width="100%" style="border:groove;" runat="server" /> 
                         <asp:Image ID="Image1" runat="server" Height = "100" Width = "100" />
                       <%-- <asp:Label runat="server" ID="imgP"></asp:Label>
                        <asp:Button  runat="server" id="btnPrev" class="btn btn-primary"  Text="Preview" onclick="btnPrev_Click" OnClientClick="openModal()"/>--%>
                         <%--<button type="button" runat="server" id="btnPrev" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong" onclick="btnPrev_Click" >Preview</button>--%>
                    </ItemTemplate>         
                </asp:TemplateField>   
            
            </Columns>
    </asp:GridView>
<%--     <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-10">
                
                                                
                                                <!-- Modal -->
                                                <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" style="height:100%;width:100%">
                                                  <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                      <div class="modal-header">
                                                     
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                          <span aria-hidden="true">&times;</span>
                                                        </button>
                                                      </div>
                                                      <div class="modal-body">
                                                        <asp:Image ID="ImageP" runat="server" Height="700" Width="500" />
                                                      </div>
                                                      <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                     
                                                      </div>
                                                    </div>
                                                  </div>
                                                </div>
                        </div>
                      </div>--%>

     <div id="PopupContainer" runat="server"></div>                
    <asp:Button CssClass="btn-btn" style="background-color:#4CAF50; display: none" ID="btnHiddenForImport" runat="server"  />
  <%--  <uc2:MsgBox ID="msgBox" runat="server" />--%>

    <uc1:MsgBoxs runat="server" ID="msgBox" />
</asp:Content>

