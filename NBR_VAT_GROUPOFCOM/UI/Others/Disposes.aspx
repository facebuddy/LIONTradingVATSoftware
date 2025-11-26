<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Disposes.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Others.Disposes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
             <div class="container-fluid">
    <div class="panel-group">
      <div class="panel panel-primary">
        <div class="panel-heading" style="text-align:center;font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ (মূসক-১৮.৭ & ১৮.৮)</div>
          <div class="panel-body">
              <div class="row">
                  <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-6 control-label">Organization Name :</label>
                      <div class="col-sm-6">
                          <asp:DropDownList ID="drpOrgName" CssClass="form-control" runat="server" AutoPostBack="True" onselectedindexchanged="drpOrgName_SelectedIndexChanged"/>
                      </div>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Address :</label>
                      <div class="col-sm-7">
                          <asp:TextBox runat="server" ID="lblAddress" CssClass="form-control" />
                      </div>
                  </div>
              </div>
               <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">BIN :</label>
                      <div class="col-sm-7">
                          <asp:TextBox runat="server" ID="lblBIN" CssClass="form-control" />
                      </div>
                  </div>
              </div>
                   </div>
              
              <div class="row">
                    <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-6 control-label">Org. Branch Name :</label>
                      <div class="col-sm-6">
                          <asp:DropDownList ID="drpBranchName" CssClass="form-control" runat="server" AutoPostBack="True" onselectedindexchanged="drpOrgName_SelectedIndexChanged"/>
                      </div>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Org. Branch Address :</label>
                      <div class="col-sm-7">
                          <asp:TextBox runat="server" ID="lblBranchAddress" CssClass="form-control" />
                      </div>
                  </div>
              </div>
                   <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Phone :</label>
                      <div class="col-sm-7">
                          <asp:TextBox runat="server" ID="lblPhone" CssClass="form-control" />
                      </div>
                  </div>
              </div>
              </div>
             
              <div class="row">
              <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-6 control-label"><span class="required" style="color:red"> * </span>Challan No :</label>
                      <div class="col-sm-6">
                          <asp:TextBox runat="server" ID="txtChallanNo" ReadOnly="true" CssClass="form-control" />
                      </div>
                       <asp:HiddenField ID="hdBookId" runat="server" />
                       <asp:HiddenField ID="hdPageNo" runat="server" />
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label"><span class="required" style="color:red"> * </span>Challan Date :</label>
                      <div class="col-sm-7">
                          <asp:TextBox runat="server" ID="dtpDate0" CssClass="form-control" style="font-size:11pt" />
                          <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDate0"/>
                      </div>
                  </div>
              </div>
                   <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Area Code :</label>
                      <div class="col-sm-7">
                          <asp:TextBox runat="server" ID="lblAreaCode" CssClass="form-control" />
                      </div>
                  </div>
              </div>
              </div>
                <div class="row">
                  <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-6 control-label">Business Activity :</label>
                      <div class="col-sm-6">
                          <asp:TextBox runat="server" ID="lblBusinessActivity" CssClass="form-control" />
                      </div>
                  </div>
              </div>
             
                </div>
          </div>
        </div>

        <div class="panel panel-primary">
          <div class="panel-body">
           <div class="row">
              <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label"><span class="required" style="color:red"> * </span>Purchase Challan No :</label>
                      <div class="col-sm-7">
                          <asp:DropDownList ID="drpPurchaseChlNo" CssClass="form-control" runat="server" AutoPostBack="True"  onselectedindexchanged="drpPurchaseChlNo_SelectedIndexChanged" />
                          <asp:Label runat="server" ID="lblPurchaseChallan" Visible ="false" />
                     </div>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label"><span class="required" style="color:red"> * </span>Item Name :</label>
                      <div class="col-sm-7">
                          <asp:DropDownList ID="drpItem" runat="server" CssClass="form-control" AutoPostBack="True"  onselectedindexchanged="drpItem_SelectedIndexChanged" />
                                <asp:HiddenField ID="hfVAT" runat="server" />
                                <asp:HiddenField ID="hfDetailId" runat="server" />
                                <asp:HiddenField ID="hfQty" runat="server" />
                                <asp:HiddenField ID="hfActualPrice" runat="server" />
                                <asp:HiddenField ID="hfLotNo" runat="server" />
                     </div>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Category :</label>
                      <div class="col-sm-7">
                          <asp:DropDownList ID="drpCategory" CssClass="form-control" runat="server" AutoPostBack="false" />
                     </div>
                  </div>
              </div>
           </div>
              <div class="row">
                  <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Stock :</label>
                      <div class="col-sm-7">
                          <asp:Label ID="lblStock" runat="server"></asp:Label>
                          <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                     </div>
                  </div>
              </div>
                  <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label"><span class="required" style="color:red"> * </span>Dispose Quantity :</label>
                      <div class="col-sm-7">
                          <asp:TextBox ID="txtDispose" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDispose_TextChanged"></asp:TextBox>
                          <asp:Label ID="lblUnitName0" runat="server" Visible="false"></asp:Label>
                          <asp:Label ID="vatRate" runat="server" Visible="false"></asp:Label>
                          <asp:Label ID="sdRate" runat="server" Visible="false"></asp:Label>
                          <asp:Label ID="lblVat" runat="server" Visible="false"></asp:Label>
                     </div>
                  </div>
              </div>
                  <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Sub Category :</label>
                      <div class="col-sm-7">
                          <asp:DropDownList ID="drpSubCat" runat="server" CssClass="form-control" AutoPostBack="True">
                            </asp:DropDownList>
                     </div>
                  </div>
              </div>
              </div>
              <div class="row">
                  <div class="col-md-4">
                  <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Previous Unit Price :</label>
                      <div class="col-sm-7">
                          <asp:TextBox ID="lblPrevUnitPrice" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                          <%--<asp:Label ID="lblPrevUnitPrice" runat="server"></asp:Label>--%>
                     </div>
                  </div>
                </div>
                   <div class="col-md-4">
                    <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Total Price :</label>
                      <div class="col-sm-7">
                          <asp:TextBox ID="lblActualPrice" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                          <%-- <asp:Label ID="lblActualPrice" runat="server"></asp:Label>--%>
                     </div>
                  </div>
                </div>
                  <div class="col-md-4">
                    <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label"><span class="required" style="color:red"> * </span>Proposed Unit Price :</label>
                      <div class="col-sm-7">
                           <asp:TextBox ID="txtPresentUnitPrice" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                  </div>
                </div>
              </div>
              <div class="row">
                  <div class="col-md-4">
                    <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Unit VAT :</label>
                      <div class="col-sm-7">
                          <asp:TextBox ID="lblUnitVAT" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                           <%--<asp:Label ID="lblUnitVAT" runat="server"></asp:Label>--%>
                     </div>
                  </div>
                </div>
                  <div class="col-md-4">
                    <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label">Total VAT Paid :</label>
                      <div class="col-sm-7">
                          <asp:TextBox ID="lblVATPaid" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                           <%--<asp:Label ID="lblVATPaid" runat="server"></asp:Label>--%>
                     </div>
                  </div>
                </div>
                  <div class="col-md-4">
                    <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label"><span class="required" style="color:red"> * </span>Disposal Reason :</label>
                      <div class="col-sm-7">
                           <asp:DropDownList ID="drpDisposalReason" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                     </div>
                  </div>
                </div>
              </div>
              <div class="row">
                  <div class="col-md-4">
                    <div class="form-group form-group-sm">
                      <label class="col-sm-5 control-label"><span class="required" style="color:red"> * </span>Remarks :</label>
                      <div class="col-sm-7">
                          <asp:TextBox ID="txtDisposeReason" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                     </div>
                  </div>
                </div>
                  <div class="col-md-4"></div>
                  <div class="col-md-4">
                      <div class="form-group form-group-sm">
                           <asp:HiddenField ID="hfUnitId" runat="server" />
                            <asp:Button ID="btnSaveItem" runat="server" class="btn-btn" style="background-color:#B681B7" Text="Add Item" onclick="btnSaveItem_Click" />
                           <%-- <asp:Button ID="btnRefreshItem" runat="server" CssClass="btn btn-primary" Text="Refresh" onclick="btnRefreshItem_Click" />--%>
                            <asp:Button ID="btnSaveChallan" runat="server" style="background-color:#4CAF50" class="btn-btn" Text="Dispose" onclick="btnSaveChallan_Click" />
                           <asp:Button ID="btnRefreshChallan" runat="server" style="background-color: #4CAF50" class="btn-btn" Text="Refresh" onclick="btnRefreshChallan_Click" />
                      </div>
                  </div>
              </div>
          </div>
        </div>
         <div class="panel panel-primary">
              <div class="panel-body">
                   <asp:GridView ID="dgvDispose" runat="server" AutoGenerateColumns="False" 
                    CssClass="sGrid" Width="100%" 
                    DataKeyNames="lotNo,detailId,itemId,unitId,vat,disposeReasonD,PurchaseChallanId,ActualPrice">
                    <Columns>
                        <asp:BoundField DataField="RowNo" HeaderText="Row No" />
                              <asp:BoundField HeaderText="Category" DataField="Category" />
                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategory" />
                        <asp:BoundField DataField="Item" HeaderText="Item" />
                        <asp:BoundField HeaderText="Property1" DataField="property1" Visible="False" />
                        <asp:BoundField HeaderText="Property2" DataField="property2" Visible="False" />
                        <asp:BoundField HeaderText="Property3" DataField="property3" Visible="False" />
                        <asp:BoundField HeaderText="Property4" DataField="property4" Visible="False" />
                        <asp:BoundField HeaderText="Property5" DataField="property5" Visible="False" />
                        <asp:BoundField HeaderText="Purchase Chl No" DataField="PurchaseChallanNo" />
                        <asp:BoundField HeaderText="Sale Chl No" DataField="SaleChallanNo" 
                            Visible="False" />
                        <asp:BoundField HeaderText="Current Stock" DataField="CurrentStock" />
                        <asp:BoundField HeaderText="Unit" DataField="Unit" Visible="False" />
                        <asp:BoundField HeaderText="Actual Total Price" DataField="ActualTotalPrice" />
                        <asp:BoundField HeaderText="Dispose Quantity" DataField="DisposeQuantity" />
                        <asp:BoundField HeaderText="Present Unit Price" DataField="PresentUnitPrice" />
                        <asp:BoundField HeaderText="Dispose Reason" DataField="DisposeReason" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
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

         <table align="center" class="brd_tbl_input">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label41" runat="server" Text="Property 1 :" Visible="False"></asp:Label>
                        </td>
                        <td align="left"  style="text-align: left">
                            <asp:DropDownList ID="drpProperty1" runat="server" Width="100px" 
                                Visible="False">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label42" runat="server" Text="Property 2 :" Visible="False"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                            <asp:DropDownList ID="drpProperty2" runat="server" Width="100px" 
                                Visible="False">
                            </asp:DropDownList>
                        </td>
                        <td align="right" class="style12">
                            <asp:Label ID="Label43" runat="server" Text="Property 3 :" Visible="False"></asp:Label>
                        </td>
                            <td align="left" class="style13">
                            <asp:DropDownList ID="drpProperty3" runat="server" Width="100px" Visible="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label44" runat="server" Text="Property 4 :" Visible="False"></asp:Label>
                        </td>
                        <td  align="left">
                            <asp:DropDownList ID="drpProperty4" runat="server" Width="100px" 
                                Visible="False">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label45" runat="server" Text="Property 5 :" Visible="False"></asp:Label>
                        </td>
                        <td  align="left">
                            <asp:DropDownList ID="drpProperty5" runat="server" Width="100px" 
                                Visible="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
      </div>
   </div>
 <%--   <uc2:MsgBox ID="msgBox" runat="server" />--%>
            <uc1:MsgBoxs runat="server" ID="msgBox" />
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>


