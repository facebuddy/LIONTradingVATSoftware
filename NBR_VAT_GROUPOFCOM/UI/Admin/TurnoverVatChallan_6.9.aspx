<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="TurnoverVatChallan_6_9, App_Web_fxp4hfg1" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src= "~/UserControls/Item.ascx" tagname="ItemNav" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
        <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
        <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <div class="container-fluid">
 <div class="panel-group">
   <div class="panel panel-primary">
     <div class="panel-heading" style="text-align:center; font-size:21px; font-weight:bold; height:30px; padding-top:0px">টার্নওভার কর চালানপত্র (মূসক-৬.৯)</div>
       <div class="panel-body" style="padding-top:0px; padding-bottom:5px">
         <div class="row" style="background-color:#E0EBF5">
           <div class="col-sm-4" style="padding:0px;">
             <asp:Label ID="Label1" runat="server" Text="তালিকাভূক্ত ব্যক্তির নাম:" CssClass="present-address-lbl" ></asp:Label>
             <div class="col-sm-7" style="padding:0px;">
             <asp:Label ID="lblOrgName" runat="server" style="width:100%"></asp:Label>
             </div>
            </div>
            <div class="col-sm-4" style="padding:0px;">
              <asp:Label ID="Label2" runat="server" Text="চালান ইস্যুর ঠিকানা:" CssClass="present-address-lbl"></asp:Label>
              <div class="col-sm-7" style="padding:0px;">
              <asp:Label ID="lblOrgAddress" runat="server" style="width:100%;"></asp:Label>
              </div>
             </div>
             <div class="col-sm-4" style="padding:0px;">
               <asp:Label ID="Label8" runat="server" Text="তালিকাভূক্ত ব্যক্তির বিআইএন:" CssClass="present-address-lbl"></asp:Label>
               <div class="col-sm-7" style="padding:0px;">
               <asp:Label ID="lblOrgBin" runat="server" style="width:100%;"></asp:Label>
               </div>
            </div>
         </div>
         <div class="row" style="margin-top:1%">
           <div class="col-sm-4" style="padding:0px;">
               <div class="col-sm-2" style="padding:0px"><asp:Label ID="Label16" runat="server" Text="চালান নম্বর:" CssClass="present-address-lbl" style="margin-left: 3px;margin-top:4px"></asp:Label></div>
              <div class="col-sm-10" style="padding:0px;">
             <asp:DropDownList ID="drpMainChallanNo" OnSelectedIndexChanged="drpChallanNo_selectedIndexChanged" runat="server" CssClass="present-address-tb" style="width:59%; height:27px" AutoPostBack="true"></asp:DropDownList>
            </div>
            </div>
             <div class="col-sm-4" style="padding:0px;">
               <asp:Label ID="Label11" runat="server" Text="চালান ইস্যুর তারিখ:" CssClass="present-address-lbl" style="margin-left: 4px;margin-top:4px"></asp:Label>
               <div class="col-sm-7" style="padding:0px;">
               <asp:TextBox ID="txtDate" runat="server" CssClass="present-address-tb" style="width:100%;height:27px"></asp:TextBox>
               </div>
              </div>
         </div>
         <div class="row" style="margin-top:1%">
           <%--<div class="col-sm-4" style="padding:0px;">
              <asp:Label ID="Label4" runat="server" Text="ক্রেতার নাম:" CssClass="present-address-lbl" style="margin-left: 8%;"></asp:Label>
              <div class="col-sm-7" style="padding:0px;">
              <asp:DropDownList ID="drpParty" runat="server" CssClass="present-address-tb" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                        </asp:DropDownList>
              <asp:Button ID="btnAddParty" runat="server" CssClass="button_sub noPrint" OnClick="btnAddParty_Click" Text="New" Width="50px" />
                                <br />
              <asp:TextBox ID="txtPartyName" runat="server" Visible="False" Width="200px" class="form-control"></asp:TextBox>
            </div>
            </div>--%>
            <div class="col-sm-4" style="padding:0px">
              <div class="col-sm-2" style="padding:0px"><asp:Label ID="Label9" CssClass="present-address-lbl" runat="server" Text="ক্রেতার নাম:" style="margin-top:4px"></asp:Label></div>
              <div class="col-sm-4" style="padding:0px">   
                <asp:DropDownList ID="drpParty" runat="server" CssClass="present-address-tb" style="width:150px; height:27px;text-align:left" AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                </asp:DropDownList>
              </div>
              <div class="col-sm-2" style="padding:0px"> 
                <asp:Button ID="Button1" runat="server"  OnClick="btnAddParty_Click" Text="New" style="width:60px; height:28px; margin-left:12px"/>
              </div>
              <div class="col-sm-4" style="padding:0px"><asp:TextBox ID="txtCompanyName" runat="server" Visible="False" CssClass="present-address-tb" style="width:150px;" placeholder="enter company name"></asp:TextBox></div> 
                
            </div>
            <div class="col-sm-4" style="padding:0px;">
              <asp:Label ID="Label5" runat="server" Text="ক্রেতার ঠিকানা:" CssClass="present-address-lbl" style="margin-left: 28px;margin-top:4px"></asp:Label>
              <div class="col-sm-7" style="padding:0px;">
              <asp:TextBox ID="txtPartyAddress" runat="server" CssClass="present-address-tb" style="width:100%;height:27px"></asp:TextBox>
              </div>
             </div>
             <div class="col-sm-4" style="padding:0px;">
               <asp:Label ID="Label6" runat="server" Text="ক্রেতার বিআইএন:" CssClass="present-address-lbl" style="margin-left: 62px;margin-top:4px"></asp:Label>
               <div class="col-sm-7" style="padding:0px;">
               <asp:TextBox ID="txtPartyBIN" runat="server" CssClass="present-address-tb" style="width:100%; height:27px"></asp:TextBox>
               </div>
              </div>
         </div>
          <div class="row" style="margin-top:10px">
             <div class="test-label">
                <asp:Label ID="Label33" runat="server" Text="Type:"></asp:Label><br />
                <asp:DropDownList ID="drpTrnsType" runat="server" CssClass="category" OnSelectedIndexChanged="drpVatType_SelectedIndexChanged" AutoPostBack="True">
                   <asp:ListItem>Goods</asp:ListItem>
                   <asp:ListItem>Service</asp:ListItem>
                 </asp:DropDownList>
             </div>
              <div class="test-label">
                 <asp:Label ID="Label22" runat="server" Text="Category :"></asp:Label><br />
                 <asp:DropDownList ID="drpCategory" runat="server" CssClass="category" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" AutoPostBack="True" style="text-align:left"></asp:DropDownList>
               </div>
               <div class="test-label">
                  <asp:Label ID="Label23" runat="server" Text="Sub Cat:"></asp:Label><br />
                  <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                   CssClass="sub-category" style="text-align:left"></asp:DropDownList>
                </div>
                <div class="test-label">
                           <asp:Label ID="Label40" runat="server" Text="Search Product:"/><br />
                           <asp:TextBox ID="productName" CssClass="search-product" AutoPostBack="true" placeholder="Search Product" runat="server" OnTextChanged="productName_TextChanged"/>
                           <div id="listPlacement" style="height:100px; overflow:scroll;" ></div>
                            <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName" ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement"
                                 MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetProductByProductName" >
                            </ajaxToolkit:AutoCompleteExtender>
                 </div>
                 <div class="test-label">
                     <asp:Label ID="Label24" runat="server" Text="Item Name:" style="margin-left:0px;"/><br />
                     <asp:DropDownList ID="drpItem" CssClass="item"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged"/>
                     <asp:Label runat="server" ID="lblProp1" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp2" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp3" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp4" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp5" Visible="false"></asp:Label>
                  </div>
                  <div class="test-label">
                     <asp:Label ID="Label25" runat="server" Text="HS Code:"/><br />
                     <asp:TextBox ID="lblHSCode" CssClass="hs-code" runat="server" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="test-label">
                     <asp:Label ID="Label26" runat="server" Text="Quantity:" style="margin-left: 0px;"/><br />
                     <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantity" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                     <asp:Label runat="server" ID="Label4" Text="avl qnt:" style="margin-left:-42px" /><asp:Label runat="server" ID="lblAvailQuantity" />
                   </div>
                        <div class="test-label">
                             <asp:Label ID="Label41" runat="server" Text="Unit:" style="margin-left: 0px;"/><br />
                             <asp:TextBox ID="txtUnitCode" CssClass="unit" runat="server"></asp:TextBox>
                             <asp:Label runat="server" ID="lblUnitId" Visible="false"></asp:Label>
                             <asp:Label runat="server" ID="lblProductType" Visible="false"></asp:Label>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label31" runat="server" Text="একক মূল্য" style="margin-left:0px;"/><br />
                            <asp:TextBox ID="txtUnitPrice" CssClass="category" runat="server" placeholder="টাকায়"></asp:TextBox><br />
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label32" runat="server" Text="মোট মূল্য" style="margin-left:0px;"/><br />
                            <asp:TextBox ID="txtAmount" CssClass="category" runat="server" placeholder="টাকায়"></asp:TextBox><br />
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label37" runat="server" Text="টার্নওভার কর" style="margin-left:-7px;"/><br />
                            <asp:TextBox ID="txtTurnoverTax" CssClass="category" runat="server" AutoPostBack="True"></asp:TextBox><br />
                        </div>
                         <div class="test-label">
                         <asp:Label ID="Label3" runat="server" Text="" style="margin-left:0px;"/><br />
                            <asp:Button ID="TextBox3" class="btn btn-success" style="margin-left: 2px;margin-top: -4px;" runat="server" AutoPostBack="True" Text="Add" OnClick="btnAdd_Click"> </asp:Button>
                        </div>
                         <div class="test-label">
                         <asp:Label ID="Label7" runat="server" Text="" style="margin-left:0px;"/><br />
                            <asp:Button ID="TextBox5" class="btn btn-success" style="margin-left: 2px;margin-top: -4px;" runat="server" AutoPostBack="True" Text="Save" OnClick="btnSave_Click" ></asp:Button>
                        </div>
            </div>
       </div>
     </div>
      <div class="panel panel-primary">
        <div class="panel-body">
             <div class="">
                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
                     CssClass="sGrid" DataKeyNames="RowId" Width="100%" ShowHeaderWhenEmpty="True" 
                OnSelectedIndexChanged="gvItem_SelectedIndexChanged" 
                     OnPreRender="gvItem_PreRender" OnRowDataBound="gvItem_RowDataBound" 
                     OnRowDeleting="gvItem_RowDeleting" BackColor="White" BorderColor="#CCCCCC" 
                     BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />
                        <asp:BoundField HeaderText="Trns Type" DataField="TrnsType" />
                        <asp:BoundField HeaderText="Category" DataField="Category" />
                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategory" />
                        <asp:BoundField HeaderText="Item" DataField="Item" />
                        <asp:BoundField HeaderText="Property1" DataField="Prop1" Visible="False" />
                        <asp:BoundField HeaderText="Property2" DataField="Prop2" Visible="False" />
                        <asp:BoundField HeaderText="Property3" DataField="Prop3" Visible="False" />
                        <asp:BoundField HeaderText="Property4" DataField="Prop4" Visible="False" />
                        <asp:BoundField HeaderText="Property5" DataField="Prop5" Visible="False" />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                        <asp:BoundField HeaderText="Unit" DataField="Unit" />
                        <asp:BoundField HeaderText="একক মূল্য" DataField="UnitPrice" />
                        <asp:BoundField HeaderText="মোট মূল্য" DataField="TotalPrice" />
                        <asp:BoundField HeaderText="টার্নওভার কর" DataField="TurnoverTax" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>
            <asp:Button ID="btnPrint" runat="server" style="float:right; margin:5px" AutoPostBack="True" Text="Print" OnClick="btnPrint_Click" ></asp:Button>
        </div>
    </div>
   </div>
 </div>
</asp:Content>
