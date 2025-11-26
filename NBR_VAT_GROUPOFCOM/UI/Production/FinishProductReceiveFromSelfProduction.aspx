<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Production_FinishProductReceiveFromSelfProduction, App_Web_zewpzv5m" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
            <link rel="stylesheet" href="/resources/demos/style.css">
            <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
            <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
            <link href="../../Styles/Main.css" rel="stylesheet" />
            <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1 {
            text-align: right;
        }

        .input_field {
            text-align: right;
        }
        
        .FixedHeader {
            position: fixed;
            font-weight: bold;
            text-align:center
        }   

        .grid_header {
            background-image: none;
            color:#000 !important;         
            border: 1px solid #c9c9c9;
            font-family: arial,Helvetica,sans-serif;
            font-size: 15px;
            font-weight:700;
            height: 20px;
            text-align: center;
        }
        .label {
            color:#000;
            font-size:13px !important;
            font-family: arial,Helvetica,sans-serif;
        }


    </style>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=cpPrint.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            //            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head>');
            printWindow.document.write('<body style="margin: 50px; font-family: "Times New Roman", Times, serif; font-size:18px">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="panel-group">
        <div class="panel panel-primary">
           <div class="panel-heading" style="text-align:center; font-size:21px; font-weight:bold; height:30px; padding-top:0px">Finished Product Received</div>
                <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
                  <div class="row" style="background-color:#E0EBF5">
                    <div class="col-sm-4">
                        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                         <asp:Literal ID="lt_companyName" runat="server"></asp:Literal>
                    </div>
                    <div class="col-sm-6">
                         <asp:Label class="col-sm-2" ID="Label2" runat="server" Text="Address:"></asp:Label>
                         <asp:Literal ID="It_companyAddress" runat="server"></asp:Literal>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="Label8" runat="server" Text="BIN:"></asp:Label>
                        <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-3 col-xs-3 col-lg-2">
                        <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                        <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                        <asp:Label ID="lblOrgAddress" runat="server" Visible="False"></asp:Label>
                    </div>
                    </div>
                <div class="row" style="margin-top: 5px; background-color: #E0EBF5">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label26" CssClass="present-address-lbl" Style="margin-left: 22%" runat="server"
                                    Text="Branch Name:">
                                </asp:Label></div>
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:DropDownList ID="drpBranchName" runat="server" Style="margin-left: 11px; height: 27px;text-align: left" OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged" AutoPostBack = "true"
                                     CssClass="present-address-tb">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label28" runat="server" Style="margin-left: 9%" CssClass="present-address-lbl"
                                    Text="Branch Address:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px; margin-left: 36px">
                                <asp:Label ID="Label10" Style="margin-left: 42%; margin-top: 4px" CssClass="present-address-lbl"
                                    runat="server" Text="BIN:"></asp:Label></div>
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top:1%">
                       <div class="col-sm-4" style="padding: 0px" id="challan" runat="server">
                            <asp:Label ID="Label30" CssClass="present-address-lbl" Style="margin-left: 5px; margin-top: 2px;"
                                runat="server" Text="Production Challan No:"></asp:Label>
                            <asp:TextBox ID="txtChallanNo" CssClass="present-address-tb" Style="float: left; width: 52%; height: 27px" runat="server"
                                 AutoPostBack = "true" Enabled="true" OnTextChanged = "challanNo_textChanged"></asp:TextBox>
                             <asp:HiddenField ID="hdBookId" runat="server" />
                             <asp:HiddenField ID="hdPageNo" runat="server" />
                            <%--<asp:CheckBox ID="chkDiscard" Style="float: left; margin-left: 3px; margin-top: 4px;"
                                runat="server" AutoPostBack="True" OnCheckedChanged="chkDiscard_CheckedChanged"
                                Text="Discard" Visible="false" />
                            <asp:DropDownList ID="drpDiscardReason1" CssClass="present-address-tb" runat="server"
                                    Style="width: 125px; height: 27px; margin-left: 0px; margin-top:3px" Visible="false"/>--%>
                        </div>
                         <div class="col-sm-2" style="padding: 0px" runat="server" id="discard" visible="false">
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:Label ID="lblDiscardReason" CssClass="present-address-lbl" Style="margin-left: 5px;
                                    margin-top: 4px;" runat="server" Text="Discard Reason:" Visible="true"></asp:Label></div>
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:DropDownList ID="drpDiscardReason" CssClass="present-address-tb" runat="server"
                                    Style="width: 94%; height: 27px; margin-left: 0px" Visible="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                    <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="Label32" CssClass="present-address-lbl" runat="server" Style="margin-left: 9px;
                                float: left; margin-top: 2px;" Text="Challan Date:"></asp:Label>
                            <asp:TextBox ID="txtChallanDate" CssClass="present-address-tb" runat="server" Style="width: 43%;
                                margin-left: 14px; float: left; height: 27px" DateFormat="dd/MM/yyyy" ReadOnly="true"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanDate"/>
                        </div>
                     <div class="col-sm-1" style="padding:0px"></div>
                    <div class="col-sm-3" style="padding:0px">
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:Label ID="Label111" runat="server" Text="Receive Scroll No:" Visible="true" Style=" margin-left: 33px;"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                        <asp:TextBox ID="txtScroll" runat="server" class="present-address-tb" Style="width: 91%; margin-left: -5px; height: 27px" ></asp:TextBox>
                        </div>
                    </div>
                    </div>
                 <div class="row" style="margin:10px;padding:0px">
                    <div class="test-label">
                            <asp:Label ID="Label6" runat="server" Text="Role:"></asp:Label><br />
                            <asp:DropDownList ID="drpRole" runat="server" style="width:100px;text-align:left" CssClass="detail-role" OnSelectedIndexChanged="drpRole_SelectedIndexChanged"
                                AutoPostBack="True" TabIndex="1">
                                <asp:ListItem>Finish Product(Production)</asp:ListItem>
                                <asp:ListItem>Finish Product</asp:ListItem>
                                <asp:ListItem>Ingredient</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    <div class="test-label">
                            <asp:Label ID="Label7" runat="server" Text="Category :"></asp:Label><br />
                            <asp:DropDownList ID="drpCategory" runat="server" style="text-align:left" CssClass="category" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                Enabled="true" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    <div class="test-label">
                            <asp:Label ID="Label15" runat="server" Text="Sub Cat:"></asp:Label><br />
                            <asp:DropDownList ID="drpSubCategory" style="text-align:left" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                              Enabled="true"  CssClass="sub-category">
                            </asp:DropDownList>
                            
                        </div>
                    <div class="test-label">
                            <asp:Label ID="Label40" runat="server" Text="Search Product:" /><br />
                            <asp:TextBox style="text-align: left" ID="productName" CssClass="search-product" AutoPostBack="true" placeholder="Search Product"
                                runat="server" OnTextChanged="productName_TextChanged" />
                            <div id="listPlacement" style="height: 100px; overflow: scroll;">
                            </div>
                            <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName"
                                ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement" MinimumPrefixLength="1"
                                EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetProductByProductName">
                            </ajaxToolkit:AutoCompleteExtender>
                            <%--<ajaxToolkit:AutoCompleteExtender runat="server" ID="accProductName" TargetControlID="productName"
                             ServiceMethod="GetProductByProductName" ServicePath="~/WebService.asmx" MinimumPrefixLength="1"
                             CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement"
                             CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                             DelimiterCharacters=";, :" ShowOnlyCurrentWordInCompletionListItem="true">
                        </ajaxToolkit:AutoCompleteExtender>--%>
                        </div>
                    <div class="test-label">
                            <asp:Label ID="Label16" runat="server" Text="Item Name:" Style="margin-left: 0px;" /><br />
                            <asp:DropDownList ID="drpItem" CssClass="item" style="text-align:left" runat="server" AutoPostBack="True"
                               Enabled="true" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" />
                            <asp:Label runat="server" ID="lblProductType" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp1" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp2" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp3" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp4" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp5" Visible="false"></asp:Label>
                        </div>
                    <div class="test-label">
                            <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                            <asp:TextBox ID="lblHSCode" CssClass="hs-code" runat="server" Style="width: 80px"
                                Enabled="false"></asp:TextBox>
                        </div>
                    <div class="test-label">
                            <asp:Label ID="Label18" runat="server" Text="Quantity:" Style="margin-left: 0px;" /><br />
                            <asp:TextBox ID="txtQuantity" CssClass="quantity" Style="width: 75px" runat="server"
                                AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                            <asp:Label runat="server" ID="aa" Text="avl qnt: " style="margin-left: -35px;" Visible="false"/><asp:Label runat="server" ID="lblAvailableQuantity" Visible="false"/>

                        </div>
                    <div class="test-label">
                            <asp:Label ID="Label41" runat="server" Text="Unit:" /><br />
                            <asp:TextBox ID="lblUnit" CssClass="unit" runat="server" Style="width: 35px"></asp:TextBox>
                            <asp:Label runat="server" ID="lblUnitId" Visible="false" />
                        </div>
                    <div class="test-label">
                                <asp:Label ID="Label13" runat="server" Text="Unit Price(S):" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtSaleUnitPrice" CssClass="category" runat="server" AutoPostBack="True" OnTextChanged="txtSaleUnitPrice_TextChanged" Style="background-color: #D4FCFF" />
                                <asp:Label ID="lblSaleUnitPrice" runat="server" Text="" Style="margin-left: 0px;" Visible="false" />
                                <asp:HiddenField runat="server" ID="hdPriceID" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label34" runat="server" Text="Vatable(P):" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtSaleVatablePrice" CssClass="category" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtVatablePrice_TextChanged" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label42" runat="server" Text="VAT:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtSaleVat" CssClass="quantity" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True"></asp:TextBox>
                                <asp:Label ID="lblSaleVat" runat="server" Text="" /><asp:Label ID="Label9" runat="server" Text="%"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label43" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtSaleSD" CssClass="quantity" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True"></asp:TextBox>
                                <asp:Label ID="lblSaleSD" runat="server" Text="" /><asp:Label ID="Label11" runat="server" Text="%"></asp:Label>
                            </div>
                </div>
                <div class="row" style="padding-left: 25px;padding-right: 18px;">
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp1" runat="server" />
                                <asp:Label ID="lblProperty1" runat="server" Text="Color:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty1" runat="server" AutoPostBack="True" CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp2" runat="server" />
                                <asp:Label ID="lblProperty2" runat="server" Text="Company:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty2" runat="server" AutoPostBack="True" Visible="false" CssClass="category" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp3" runat="server" />
                                <asp:Label ID="lblProperty3" runat="server" Text="Grade:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty3" runat="server" AutoPostBack="True" CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp4" runat="server" />
                                <asp:Label ID="lblProperty4" runat="server" Text="Size:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty4" runat="server" AutoPostBack="True" CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp5" runat="server" />
                                <asp:Label ID="lblProperty5" runat="server" Text="Specification:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty5" runat="server" AutoPostBack="True" CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label" style="margin-left:10px">
                            <asp:Label ID="Label5" runat="server" Text="Remarks:" /><br />
                            <asp:TextBox ID="txtRemark" CssClass="remark" runat="server" Style="width: 150px"></asp:TextBox>
                            <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label>
                    </div>
                    <div class="test-btn">
                            <asp:Button ID="printBTN" runat="server" class="test-btn-primary" OnClick="btnPrint_Click" Text="Show Report" Style="margin-top: 17px;width:100%" />
                        </div>
                    <div class="test-btn">
                        <asp:Button ID="btnAdd" runat="server" class="test-btn-primary" OnClick="btnAddItem_Click" Text="Add Item" style="margin-top: 17px;"/>
                     </div>
                    <div class="test-btn">
                        <asp:Button ID="btnSave" runat="server" class="test-btn-primary" Text="Save" OnClick="btnSave_Click" style="margin-top: 17px;"/>
                    </div>
                    <div class="test-btn">
                         <asp:Button ID="btnClear" runat="server" class="test-btn-primary" OnClick="btnClear_Click" Text="Clear" style="margin-top: 17px;"/>
                    </div>
                  </div>
       <div class="row" style="margin:10px">
        <div class="panel panel-primary">
        <div class="panel-body">
             <div class="">
                <asp:GridView ID="gvMainItem" runat="server" AutoGenerateColumns="False" 
                     CssClass="sGrid" DataKeyNames="RowNo" Width="100%" BackColor="#DEBA84" BorderColor="#DEBA84" 
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                        <asp:BoundField HeaderText="Item" DataField="ItemName" />
                        <asp:BoundField HeaderText="Property1" DataField="PropertyID1" Visible="False" />
                        <asp:BoundField HeaderText="Property2" DataField="PropertyID2" Visible="False" />
                        <asp:BoundField HeaderText="Property3" DataField="PropertyID3" Visible="False" />
                        <asp:BoundField HeaderText="Property4" DataField="PropertyID4" Visible="False" />
                        <asp:BoundField HeaderText="Property5" DataField="PropertyID5" Visible="False" />
                        <asp:BoundField HeaderText="Used Quantity" DataField="Quantity" />
                        <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                        <asp:BoundField HeaderText="Unit Price" DataField="SaleUnitPrice" />
                        <asp:BoundField HeaderText="Vat" DataField="SaleVat" />
                        <asp:BoundField HeaderText="SD" DataField="SaleSD" />
                        <asp:BoundField HeaderText="Vatable Price" DataField="SaleVatablePrice" />
                        <asp:BoundField HeaderText="Remark" DataField="Remark" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" 
                        ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
              </div>
           </div>
        </div>
       </div>
       <div class="row" style="margin:10px">
         <div class="panel panel-primary">
        <div class="panel-body">
             <div class="">
                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False"  CssClass="sGrid" DataKeyNames="RowNo" Width="100%" 
                OnSelectedIndexChanged="gvItem_SelectedIndexChanged" OnRowDeleting="gvItem_RowDeleting" BackColor="#DEBA84" BorderColor="#DEBA84" 
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />
                       <%-- <asp:BoundField HeaderText="Category" DataField="CategoryName" />--%>
                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                        <asp:BoundField HeaderText="Item" DataField="ItemName" />
                        <asp:BoundField HeaderText="Property1" DataField="Property_id1" Visible="False" />
                        <asp:BoundField HeaderText="Property2" DataField="Property_id2" Visible="False" />
                        <asp:BoundField HeaderText="Property3" DataField="Property_id3" Visible="False" />
                        <asp:BoundField HeaderText="Property4" DataField="Property_id4" Visible="False" />
                        <asp:BoundField HeaderText="Property5" DataField="Property_id5" Visible="False" />
                        <asp:BoundField HeaderText="Used Quantity" DataField="Quantity" />
                        <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                        <asp:BoundField HeaderText="Remark" DataField="Remark" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" 
                        ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
              </div>
           </div>
        </div>
       </div>
      <uc2:MsgBox ID="msgBox" runat="server"/>
      </div>
     </div>
    </div>
    <div id="cpPrint" class="container-fluid" style="margin-top: 2%;" runat="server" visible="false">
            <div class="row">
                <p style="text-align: center;font-weight:bold">
                    উৎপাদিত পণ্য চালানপত্র</p>
            </div>
            <div class="row" style="margin-top: 4%">
                <p style="margin-left: 35%">
                    নিবন্ধিত ব্যক্তির নামঃ <asp:Label runat="server" ID="lblOrgName"/></p>
                <p style="margin-left: 35%">
                    নিবন্ধিত ব্যক্তির বিআইএনঃ  <asp:Label runat="server" ID="lblOrgBinNo"/></p>
                <p style="margin-left: 35%">
                    চালান ইস্যুর ঠিকানাঃ <asp:Label runat="server" ID="lblChallanAddress"/>
                </p>
            </div>
            <div class="row">
                <div class="col-sm-6" style="width:50%;float:left">
                    <p>
                        পণ্য গ্রহীতার নামঃ  <asp:Label runat="server" ID="lblReceipentName"/></p>
                    <p>
                        গ্রহীতার বিআইএনঃ  <asp:Label runat="server" ID="lblReceipentBIN"/>
                    </p>
                    <p>
                        গন্তব্যস্থলঃ  <asp:Label runat="server" ID="lblTransport"/></p>
                </div>
                <div class="col-sm-6" style="width:49%;float:left">
                    <p>
                        চালানপত্র নম্বরঃ  <asp:Label runat="server" ID="lblChallanNo"/></p>
                    <p>
                        ইস্যুর তারিখঃ  <asp:Label runat="server" ID="lblChallanIssueDate"/>
                    </p>
                    <p>
                        ইস্যুর সময়ঃ  <asp:Label runat="server" ID="lblChallanIssueTime"/>
                    </p>
                </div>
            </div>
            <div class="row" style="margin-top: 3%">
                <table class="table table-bordered" style="width: 100%; text-align: center;background:none;border-collapse:collapse" >
                    <tr>
                        <td style="border:1px solid gray">
                            ক্রমিক নং
                        </td>
                        <td style="border:1px solid gray">
                            প্রকৃতি (উপকরণ বা উৎপাদিত পণ্য )
                        </td>
                        <td style="border:1px solid gray">
                            পণ্যের বিবরণ
                        </td>
                        <td style="border:1px solid gray">
                            পরিমাণ
                        </td>
                        <td style="border:1px solid gray">
                            মন্তব্য
                        </td>
                    </tr>
                    <tr>
                        <td style="border:1px solid gray">
                            (১)
                        </td>
                        <td style="border:1px solid gray">
                            (২)
                        </td>
                        <td style="border:1px solid gray">
                            (৩)
                        </td>
                        <td style="border:1px solid gray">
                            (৪)
                        </td>
                        <td style="border:1px solid gray">
                            (৫)
                        </td>
                    </tr>
                    <tr>
                        <asp:Label runat="server" ID="HaiMan"></asp:Label></tr>
                </table>
            </div>
            <div class="row" style="margin-top: 10px">
                <p>
                    দায়িত্ব প্রাপ্ত কর্মকর্তার স্বাক্ষর</p>
                <p>
                    নামঃ  <asp:Label runat="server" ID="lblDutyOfficer" /></p>
            </div>
        </div>
         <asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" style="float:right"
                            Text="Print" onclientclick="return PrintPanel();" Visible="false"/>
  </div>
</asp:Content>
