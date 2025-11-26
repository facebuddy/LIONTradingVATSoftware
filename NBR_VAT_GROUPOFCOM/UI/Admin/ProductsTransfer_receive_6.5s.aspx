<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="ProductsTransfer_receive_6.5s.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.ProductsTransfer_receive_6__5s" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 <%--   <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
      <link rel="stylesheet" href="/resources/demos/style.css">   
    <link href="../../Styles/panel.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>--%>
    <script type = "text/javascript">


        function PrintPanel() {
            var panel = document.getElementById("<%=ptPrint.ClientID %>");
      var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
      printWindow.document.write('<html><head><title>DIV Contents</title>');
      printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
      //printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
      printWindow.document.write('</head>');
      printWindow.document.write('<body style="margin: 50px;font-family: "Times New Roman", Times, serif; font-size:16px">');
      printWindow.document.write(panel.innerHTML);
      printWindow.document.write('</body>');
      printWindow.document.write('</html>');
      printWindow.document.close();
      setTimeout(function () {
          printWindow.print();
      }, 500);
      return false;
  }

        function SelectAllCheckboxesgvIngredience(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvAddtnProperty.ClientID%>");
                 var items = jsGvItem.getElementsByTagName('input');

                 //var rowCount = jsGvItem.rows.length;

                 for (var i = 0; i < items.length; i++) {
                     if (items[i].type == "checkbox") {
                         if (items[i].checked != IsChecked) {
                             items[i].click();
                         }
                     }
                 }

             }

    </script>
   
    <script type="text/javascript">
        function a(q) {
            gvItem.rows[0].cells[6].getElementsByTagName('input')[0].value = q;
        }

    </script>
    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right:0%; padding-left:0%">
      <div class="panel-group">
        <div class="panel panel-primary">
           <div class="panel-heading" style="text-align:center;font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">
             <%--  Receive/পণ্য স্থানান্তর চালানপত্র--%>
               Receive / কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র (মুসক-৬.৫)
           </div>
            <div class="panel-body" style="padding-top:0px; padding-bottom:2px;padding-right:2px">
                <div class="row hiddencol" style="background-color: #FFD9C3; ">
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Org. Name :</label>
                            <div class="col-sm-7 m">
                                <asp:Label ID="orgName" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Org. Address :</label>
                            <div class="col-sm-7 m">
                                <asp:Label ID="orgAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Org. BIN :</label>
                            <div class="col-sm-7 m">
                                <asp:Label ID="orgBIN" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>গ্রহীতা শাখার নাম :</label>
                            <div class="col-sm-7 m">
                                 <asp:DropDownList ID="drpReceipentBranch" runat="server" class="form-control" 
                                     AutoPostBack="True" OnSelectedIndexChanged="drpReceipentBranch_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">গ্রহীতা শাখার ঠিকানা :</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox ID="txtReceipentAddress" runat="server" 
                                    CssClass="form-control" placeholder="গ্রহীতা শাখার ঠিকানা লিখুন " ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">বিআইএন :</label>
                            <div class="col-sm-7 m">
                               <asp:TextBox ID="txtReceipentBIN" ReadOnly="true" runat="server" CssClass="form-control" placeholder="গ্রহীতা শাখার বিআইএন লিখুন "></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>প্রেরণকারী শাখার নাম :</label>
                            <div class="col-sm-7 m">
                                <asp:DropDownList ID="drpProviderBranch" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpProviderBranch_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">প্রেরণকারী শাখার ঠিকানা :</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox ID="txtProviderAddress" runat="server" CssClass="form-control"  ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">বিআইএন :</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox ID="txtProviderBIN" ReadOnly="true"  runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>ইস্যুকৃত চালান নম্বর :</label>
                            <div class="col-sm-7 m">
                                 <asp:DropDownList ID="drpChallanNo" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="drpChallanNo_SelectedIndexChanged"></asp:DropDownList>
                            <asp:HiddenField runat="server" ID="ItemType" />
                             <asp:HiddenField runat="server" ID="hdBookId" />
                             <asp:HiddenField runat="server" ID="hdPageNo" />
                             <asp:Label runat="server" ID="lblProperty11" Visible="false" />
                            <asp:Label runat="server" ID="lblProperty22" Visible="false" />
                            <asp:Label runat="server" ID="lblProperty33" Visible="false" />
                            <asp:Label runat="server" ID="lblProperty44" Visible="false" />
                            <asp:Label runat="server" ID="lblProperty55" Visible="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"> গ্রহণকারী ইস্যুর তারিখ ও সময়:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtChallanReceiveDate" Style="width: 50%; float: left" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanReceiveDate" />
                                            <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                                            <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Receive Scroll No :</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox ID="txtReceiveScrollNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                   <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Vehicle Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpVehicleType" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Vehicle No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtVehicleNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                    
                                     </div>



             
                     <div class="row hiddencol" style="margin-top:10px; margin-left:5px">
                        <div class="test-label">
                            <asp:Label ID="Label33" runat="server" Text="Role:"></asp:Label><br />
                            <asp:DropDownList ID="drpType" runat="server" CssClass="category select2" style="width: 150px;height:27px;text-align:left" AutoPostBack="True" OnSelectedIndexChanged="drpRole_SelectedIndexChanged" >
                                <asp:ListItem Value="">--Select--</asp:ListItem>
                                <asp:ListItem Value="C">Finished Product (Production)</asp:ListItem>
                                 <asp:ListItem Value="P">Finished Product</asp:ListItem>
                                  <asp:ListItem Value="R">Ingridients</asp:ListItem>
                                  <asp:ListItem Value="F">Goods</asp:ListItem>
                                <asp:ListItem Value="W">Real-estate Property</asp:ListItem>
                                <asp:ListItem Value="M">Medicine</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label22" runat="server" Text="Category:"></asp:Label><br />
                            <asp:DropDownList ID="drpCategory" runat="server" CssClass="category select2" style="width: 150px;height:27px;text-align:left" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" 
                            AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label23" runat="server" Text="Sub Cat:"></asp:Label><br />
                            <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                            CssClass="sub-category select2" style="width: 150px;height:27px;text-align:left"></asp:DropDownList>
                        </div>
                       <%-- <div class="test-label">
                           <asp:Label ID="Label40" runat="server" Text="Search Product:"/><br />
                           <asp:TextBox ID="productName" AutoPostBack="true" CssClass="search-product" placeholder="Search Product" runat="server" OnTextChanged="productName_TextChanged"/>
                           <div id="listPlacement" style="height:100px; overflow:scroll; width:200%" ></div>
                            <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName" ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement"
                                 MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetProductByProductName" >
                            </ajaxToolkit:AutoCompleteExtender>
                        </div>--%>
                        <div class="test-label">
                            <asp:Label ID="Label24" runat="server" Text="Item Name:" style="margin-left:0px;"/><br />
                            <asp:DropDownList ID="drpItem" CssClass="item select2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" Height="27px" style="width: 150px;"/>
                            <asp:Label runat="server" ID="lblProductType" Visible="false" />
                            <asp:Label runat="server" ID="lblItemType" Visible="false" />
                            <asp:Label runat="server" ID="lblProp1" Visible="false" />
                            <asp:Label runat="server" ID="lblProp2" Visible="false" />
                            <asp:Label runat="server" ID="lblProp3" Visible="false" />
                            <asp:Label runat="server" ID="lblProp4" Visible="false" />
                            <asp:Label runat="server" ID="lblProp5" Visible="false" />
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label25" runat="server" Text="HS Code:"/><br />
                             <asp:TextBox ID="lblHSCode" runat="server" CssClass="hs-code" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                             <asp:Label ID="Label26" runat="server" Text="Quantity:" style=""/><br />
                             <asp:TextBox ID="txtQuantity" style="width:90px" runat="server" CssClass="quantity" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                             <asp:Label runat="server" ID="Label6" style="color: #008000;font-weight:bold" Text="Avl. Stock:" /><asp:Label runat="server"   style="color: #008000;font-weight:bold" ID="lblAvailQuantity" />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9"
                                                                 runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="test-label">
                             <asp:Label ID="Label41" runat="server" Text="Unit:"  style="width: 150px;margin-left: 0px;"/><br />
                             <asp:TextBox ID="lblUnit" runat="server" style="width: 100px;" CssClass="unit"></asp:TextBox>
                             <asp:Label runat="server" ID="lblUnitID" Visible="false"/>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label37" runat="server" Text="Remarks:" style="margin-left:0px;"/><br />
                            <asp:TextBox ID="txtRemark" CssClass="remark" runat="server" AutoPostBack="True"></asp:TextBox><br />
                        </div>
                      
                    </div>
                    <div class="row" style="text-align:right">
                       <div class="col-md-12">
                        <asp:Button ID="btnAdd" style="background-color:#B681B7;margin-top:15px; margin-left: 4px; margin-right:0px" runat="server" class="btn-btn hiddencol" OnClick="btnAddItem_Click" Text="Add Item" />
                        <asp:Button ID="btnSave" style="background-color:#4CAF50;margin-top:15px;"  runat="server" class="btn-btn" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnClear" style="background-color: #4CAF50;margin-top:15px;"  runat="server" class="btn-btn" OnClick="btnClear_Click" Text="Refresh" />
                        <asp:Button ID="btnShowReport" style="background-color:#5CB85C;margin-top:15px;" runat="server" class="btn-btn" OnClick="btnShowReport_OnClick" Text="Show Report" />
                        <%--<asp:Button ID="btnShowReport" style="margin-top:15px; margin-left: 4px; margin-right:0px" runat="server" class="btn btn-default" OnClientClick="btnPrint_click('Print'); return false;" Text="Print" />--%>
                       </div>  
                         </div>
            </div>
        </div>
        <div class="panel panel-primary">
        <div class="panel-body">
             <div class="">
                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    DataKeyNames="row_no" Width="100%" OnRowDeleting="gvItem_RowDeleting" 
                    BackColor="#DEBA84" BorderColor="#DEBA84" 
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <%--<asp:BoundField HeaderText="Category" DataField="Category" />
                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategory" />--%>
                        <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <ItemTemplate>
                                            <asp:HiddenField ID="item_id" Value='<%# Eval("item_id") %>' runat="server" />
                                    </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <ItemTemplate>
                                            <asp:HiddenField ID="unit_id" Value='<%# Eval("unit_id") %>' runat="server" />
                                    </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <ItemTemplate>
                                            <asp:HiddenField ID="property_id1" Value='<%# Eval("property_id1") %>' runat="server" />
                                    </ItemTemplate>
                           </asp:TemplateField>
                           
                        <asp:BoundField HeaderText="Item Type" DataField="product_type" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                        <asp:BoundField HeaderText="Item" DataField="item_name" />                      
                        <asp:BoundField HeaderText="Issued Quantity" DataField="issued_quantity" />
                        <asp:BoundField HeaderText="Unit" DataField="Unit" />
                         <asp:TemplateField HeaderText="Received Quantity">
                             <ItemTemplate>
                               <asp:TextBox ID="received_quantity" runat="server" Text= '<%# Eval("received_quantity") %>' style="width:auto" ></asp:TextBox>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                                                      runat="server" Enabled="True" TargetControlID="received_quantity"
                                                                      ValidChars=".0123456789">
                                 </ajaxToolkit:FilteredTextBoxExtender>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <ItemTemplate>
                                            <asp:HiddenField ID="property_id2" Value='<%# Eval("property_id2") %>' runat="server" />
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <ItemTemplate>
                                            <asp:HiddenField ID="property_id3" Value='<%# Eval("property_id3") %>' runat="server" />
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <ItemTemplate>
                                            <asp:HiddenField ID="property_id4" Value='<%# Eval("property_id4") %>' runat="server" />
                                    </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <ItemTemplate>
                                            <asp:HiddenField ID="property_id5" Value='<%# Eval("property_id5") %>' runat="server" />
                                    </ItemTemplate>
                              </asp:TemplateField>
                        <asp:BoundField HeaderText="Property1" DataField="Property1_Text" />
                        <asp:BoundField HeaderText="Property2" DataField="Property2_Text" />
                        <asp:BoundField HeaderText="Property3" DataField="Property3_Text" />
                        <asp:BoundField HeaderText="Property4" DataField="Property4_Text" />
                        <asp:BoundField HeaderText="Property5" DataField="Property5_Text" />

                        <%--<asp:BoundField HeaderText="Received Quantity" DataField="received_quantity" />--%>
                        <asp:BoundField HeaderText="Remark" DataField="remarks" />
                        <asp:BoundField HeaderText="Purchase Type" DataField="purchase_type" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField HeaderText="Unit Price" DataField="unit_price" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField HeaderText="VATAmount" DataField="vat_amount" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField HeaderText="SDAmount" DataField="sd_amount" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField HeaderText="Brand" DataField="brand_name" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                         <asp:BoundField HeaderText="Receivable Quantity" DataField="received_quantity" />
                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" HeaderText="Action" />--%>
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

                   <br />
                  <div class="row" style="text-align:right" runat="server" visible="false" id ="divSearch">
                                 Search:
                                <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="Search" AutoPostBack="true"></asp:TextBox>
                            </div>
                 <div class="row">
                     <asp:Label ID="lblTotalRow" runat="server" Text=""></asp:Label>
                                   <asp:GridView ID="gvAddtnProperty"  runat="server" AutoGenerateColumns="false" CellPadding="4" Width="100%"
                                       DataKeyNames="item_id" OnRowDataBound="gvAddtnProperty_RowDataBound" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
                                     <Columns>

                                  <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="additionalInfoId" Value='<%# Eval("additionalInfoId") %>' runat="server" />
                                    </ItemTemplate>
                                  </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderTemplate >
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesgvIngredience(this)" ToolTip="Check to Select All Item" />
                                            </HeaderTemplate>
                                            <ItemTemplate >
                                                <asp:CheckBox ID="chkChallan" runat="server"  OnCheckedChanged="chkAdditionalProperty_CheckedChanged" AutoPostBack="true"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>  
                                 </Columns>  
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />  
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                                </asp:GridView>  
                            </div>

            </div>
        </div>
    </div>
   </div>
   <div class="container-fluid" id="ptPrint" runat="server" style="font-family:Nikosh" visible="false">
     <div class="row" style="font-size:16px">
       <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
       <p style="text-align:center">জাতীয় রাজস্ব বোর্ড</p>
       <p style="text-align:right;"><strong style="border:1px solid gray;font-size:16px">মূসক-৬.৫</strong></p>
      <%-- <p style="text-align:center">পণ্য স্থানান্তর চালানপত্র </p>--%>
         <p style="text-align:center;font-size:20px">কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র </p>
       <p style="text-align:center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (ঙ) দ্রষ্টব্য]</p>
     </div>
       <div style="font-size:12px">
     <div class="row">
      <p>নিবন্ধিত ব্যক্তির নামঃ  <asp:Label runat="server" ID="lblOrgName" /></p>
      <p>নিবন্ধিত ব্যক্তির বিআইএনঃ  <asp:Label runat="server" ID="lblOrgBIN" /></p>
 
          <p>প্রেরণকারী শাখা/পণ্যাগারের নাম ও ঠিকানাঃ  <asp:Label runat="server" ID="lblPNameAddress" /></p>
     </div>
         <div class="row" style="height:10px;"></div>
         <div class="row">
           <p>গ্রহীতা শাখা/পণ্যাগারের নাম ও ঠিকানাঃ  <asp:Label runat="server" ID="lblReceipentAddress" /></p>
        </div>
     <div class="row" style="width:100%; height:0px;">
       <div class="col-sm-6" style="width:50%; height:150px; float:left">
        <%-- <p>গ্রহীতার শাখার নামঃ  <asp:Label runat="server" ID="lblReceipentName" /></p>
          <p>গ্রহীতা শাখার ঠিকানাঃ  <asp:Label runat="server" ID="lblReceipentAddress" /></p>--%>
       </div>
       <div class="col-sm-6" style="width:49%; float:left">
          <p>চালানপত্রের নম্বরঃ  <asp:Label runat="server" ID="lblChallanNo" /></p>
          <p>ইস্যুর তারিখঃ  <asp:Label runat="server" ID="lblIssueDate" /></p>
          <p>ইস্যুর সময়ঃ  <asp:Label runat="server" ID="lblIssueTime" /></p>
            <p>যানবাহনের প্রকৃতি ও নম্বর:  <asp:Label runat="server" ID="txtTransport" /></p>
       </div>
     </div>
     <div>
       <table class="table table-bordered" style="background:none; border-collapse:collapse; width:100%">
         <tr>
          <td style="border:1px solid gray; width:5%; text-align: center;">ক্রমিক নং</td>
           <td style="border:1px solid gray; width:30%; text-align: center;">পণ্যের(প্রযোজ্য ক্ষেত্রে সুনির্দিষ্ট ব্র্যান্ড নামসহ) বর্ণনা
           </td>
           <td style="border:1px solid gray;width:15%; text-align: center;">পরিমাণ</td>
              <td style="border:1px solid gray;width:15%; text-align: center;">মূল্য</td>
             
           <td style="border:1px solid gray;width:20%; text-align: center;">মন্তব্য</td>
         </tr>
         <tr>
           <td style="border:1px solid gray; text-align: center;">(১)</td>
           <td style="border:1px solid gray; text-align: center;">(২)</td>
           <td style="border:1px solid gray; text-align: center;">(৩)</td>
           <td style="border:1px solid gray; text-align: center;">(৪)</td>
           <td style="border:1px solid gray; text-align: center;">(৫)</td>
           
         </tr>
         <tr>
           <asp:Label runat="server" ID="tblProductTransferChallan"></asp:Label>
         </tr>
       </table>
     </div>
     <div>
       <%--<p style="margin-top:55px">দায়িত্ব প্রাপ্ত কর্মকর্তার স্বাক্ষর</p>--%>
       <p style="margin-top:55px">প্রতিষ্ঠান কর্তৃপক্ষের দায়িত্বপ্রাপ্ত ব্যাক্তির নাম : <asp:Label runat="server" ID="lblDutyOfficer"/></p> 
       <p>পদবী :  <asp:Label runat="server" ID="lblDutyOfficerDesignationName"/></p>
       <p> স্বাক্ষর:  <asp:Label runat="server" ID="Label2"/></p>
       <p> সিল:  <asp:Label runat="server" ID="Label3"/></p>
        
     </div> 
           <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>

           </div>
       
   </div>
   <asp:Button runat="server" style="float:right;" CssClass="btn btn-info" Text="Print" ID="btnPrint" Visible= "false" OnClientClick="return PrintPanel()" />
<%--   <uc2:MsgBox ID="msgBox" runat="server"/>--%>
        <uc1:MsgBoxs runat="server" ID="msgBox" />
</div>
</asp:Content>

