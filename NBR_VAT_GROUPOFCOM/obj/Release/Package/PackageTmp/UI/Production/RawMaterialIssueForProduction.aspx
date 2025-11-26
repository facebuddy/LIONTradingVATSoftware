<%@ page title="কাঁচামালের চাহিদা পত্র" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Production_RawMaterialIssueForProduction, App_Web_zewpzv5m" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        
        .input_field
        {
            text-align: right;
        }
        
        .FixedHeader
        {
            position: fixed;
            font-weight: bold;
            text-align: center;
        }
        
        .grid_header
        {
            background-image: none;
            color: #000 !important;
            border: 1px solid #c9c9c9;
            font-family: arial,Helvetica,sans-serif;
            font-size: 15px;
            font-weight: 700;
            height: 20px;
            text-align: center;
        }
        .label
        {
            color: #000;
            font-size: 13px !important;
            font-family: arial,Helvetica,sans-serif;
        }
    </style>
    <script type="text/javascript">
        function ToggleDiv(flag) {
            if (flag == "first") {
                var id = document.getElementById("cpPrint");
                if (id.style.display == 'none') {
                    document.getElementById("cpPrint").style.display = 'block';
                } else {
                    document.getElementById("cpPrint").style.display = 'none';
                }
            }
        }
    </script>
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
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
</script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                 <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px"> Raw Material Requisition (কাঁচামালের চাহিদা পত্র) </div>
                  <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row" style="background-color: #E0EBF5">
                        <div class="col-sm-4">
                            <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                            <asp:Literal ID="org_name" runat="server"></asp:Literal>
                        </div>
                        <div class="col-sm-6">
                            <asp:Label class="col-sm-2" ID="Label2" runat="server" Text="Address:"></asp:Label>
                            <asp:Literal ID="org_address" runat="server"></asp:Literal>
                        </div>
                        <div class="col-sm-2">
                            <asp:Label ID="Label8" runat="server" Text="BIN:"></asp:Label>
                            <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-3 col-xs-3 col-lg-2">
                            <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px">
                            </asp:DropDownList>
                            <asp:Label ID="lblOrgAddress" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                      <div class="col-md-4" style="margin-top:7px">
                          <div class="form-group form-group-sm">
                              <label class="col-sm-5 control-label">Branch Name :</label>
                              <div class="col-sm-7">
                                  <asp:DropDownList ID="drpBranchName" runat="server" CssClass="form-control" Style=" height: 27px; text-align:left" AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                                </asp:DropDownList>
                              </div>
                          </div>
                      </div>
                      <div class="col-md-4" style="margin-top:7px">
                          <div class="form-group form-group-sm">
                              <label class="col-sm-5 control-label">Requisition No :</label>
                              <div class="col-sm-7">
                                 <asp:TextBox ID="txtRequisitionNo" CssClass="form-control" Style=" height: 27px" runat="server"  ></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="col-md-4" style="margin-top:7px">
                          <div class="form-group form-group-sm">
                              <label class="col-sm-5 control-label">Requisition Date :</label>
                              <div class="col-sm-7">
                                 <asp:TextBox ID="txtRequisitionDate" CssClass="form-control" Style=" height: 27px;font-size:11pt" runat="server" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10" ></asp:TextBox>
                                  <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtRequisitionDate"/>
                              </div>
                          </div>
                      </div>
                      <div class="col-md-4">
                          <div class="form-group form-group-sm">
                              <label class="col-sm-5 control-label">Quantity :</label>
                              <div class="col-sm-7">
                                 <asp:TextBox ID="txtFQuantity" CssClass="form-control" Style=" height: 27px" runat="server"  ></asp:TextBox>
                              </div>
                          </div>
                      </div>
                      <div class="col-md-4">
                          <div class="form-group form-group-sm">
                              <label class="col-sm-5 control-label">Finish Product :</label>
                              <div class="col-sm-7">
                                 <asp:DropDownList ID="drpFinishProduct" CssClass="form-control" runat="server" Style="height: 29px;text-align:left" Visible="True" OnSelectedIndexChanged="drpFP_SelectedIndexChanged" AutoPostBack="true" >
                                </asp:DropDownList>
                              </div>
                          </div>
                      </div>
                      <div class="col-md-4">
                          <div class="form-group form-group-sm">
                              <label class="col-sm-5 control-label">Price Declaration No :</label>
                              <div class="col-sm-7">
                                 <asp:DropDownList ID="drpPriceDeclarationNo" CssClass="form-control" runat="server" Style="height: 29px;text-align:left" OnSelectedIndexChanged="drpPriceDeclarationNo_SelectedIndexChanged" AutoPostBack="true" >
                                </asp:DropDownList>
                              </div>
                          </div>
                      </div>
                    <div class="row" style="margin-top: 15px; padding:5px">
                        <div class="test-label">
                            <asp:Label ID="Label6" runat="server" Text="Role:"></asp:Label><br />
                            <asp:DropDownList ID="drpRole" runat="server" CssClass="detail-role" OnSelectedIndexChanged="drpRole_SelectedIndexChanged"
                                AutoPostBack="True" TabIndex="1">
                                <asp:ListItem>Ingredient</asp:ListItem>
                                <asp:ListItem>Finish Product</asp:ListItem>
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
                            <asp:Label runat="server" ID="Label9" Text="avl qnt: " style="margin-left: -35px;"/><asp:Label runat="server" ID="avlQuantity"/>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label41" runat="server" Text="Unit:" /><br />
                            <asp:TextBox ID="lblUnit" CssClass="unit" runat="server" Style="width: 35px"></asp:TextBox>
                            <asp:Label runat="server" ID="lblUnitId" Visible="false" />
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label5" runat="server" Text="Requisitor Name:" /><br />
                            <asp:TextBox ID="txtRequisitorName" CssClass="remark" runat="server" Style="width: 150px"></asp:TextBox>
                            <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label>
                        </div>
                        <div class="test-btn">
                            <asp:Button ID="printBTN" runat="server" class="test-btn-primary" OnClick="btnPrint_Click"
                                Text="Show Report" Style="margin-top: 15px;width:92px" />
                        </div>
                        <div class="test-btn">
                            <asp:Button ID="btnAdd" runat="server" class="test-btn-primary" OnClick="btnAddItem_Click" Enabled="true"
                                Text="Add Item" Style="margin-top: 15px" />
                        </div>
                        <div class="test-btn">
                            <asp:Button ID="btnSave" runat="server" class="test-btn-primary" Text="Save" OnClick="btnSave_Click"
                                Style="margin-top: 15px" />
                        </div>
                        <div class="test-btn">
                            <asp:Button ID="btnClear" runat="server" class="test-btn-primary" OnClick="btnClear_Click"
                                Text="Clear" Style="margin-top: 15px" />
                        </div>
                    </div>
                    <div class="row" style="margin: 10px">
                        <div class="panel panel-primary">
                            <div class="panel-body">
                                <div class="">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                        DataKeyNames="RowNo" Width="100%" OnRowDeleting="gvItem_RowDeleting" 
                                        BackColor="#DEBA84" BorderColor="#DEBA84" 
                                        BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                        <Columns>
                                            <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                                                ShowSelectButton="True" />--%>
                                            <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                                            <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                                            <asp:BoundField HeaderText="Item" DataField="ItemName" />
                                            <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                                            <asp:BoundField HeaderText="Property1" DataField="PropertyID1" Visible="False" />
                                            <asp:BoundField HeaderText="Property2" DataField="PropertyID2" Visible="False" />
                                            <asp:BoundField HeaderText="Property3" DataField="PropertyID3" Visible="False" />
                                            <asp:BoundField HeaderText="Property4" DataField="PropertyID4" Visible="False" />
                                            <asp:BoundField HeaderText="Property5" DataField="PropertyID5" Visible="False" />
                                            <asp:TemplateField HeaderText="Quantity" >
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="gvTxtQuantity" Value='<%# Eval("Quantity") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Per Unit Quantity" DataField="PreQuantity" />
                                            <%--<asp:BoundField HeaderText="Requisitor Name" DataField="Remark" />--%>
                                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                        </Columns>
                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                        <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" ForeColor="#8C4510" />
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
                </div>
            </div>
        </div>
        <div id="cpPrint" class="container-fluid" style="margin-top: 2%;" runat="server" visible="false">
            <div class="row">
                <p style="text-align: center;font-weight:bold">Raw Material Requisition (কাঁচামালের চাহিদা পত্র)</p>
            </div>
            <div class="row" style="margin-top: 4%">
                <p style="margin-left: 35%">নিবন্ধিত ব্যক্তির নামঃ <asp:Label runat="server" ID="lblOrgName"/></p>
                <p style="margin-left: 35%">নিবন্ধিত ব্যক্তির বিআইএনঃ <asp:Label runat="server" ID="lblOrgBinNo"/></p>
                <p style="margin-left: 35%">চালান ইস্যুর ঠিকানাঃ <asp:Label runat="server" ID="lblChallanAddress"/></p>
            </div>
            <div class="row">
                <div class="col-sm-6" style="width:50%;float:left">
                    <p>পণ্য গ্রহীতার নামঃ <asp:Label runat="server" ID="lblReceipentName"/></p>
                    <p>গ্রহীতার বিআইএনঃ <asp:Label runat="server" ID="lblReceipentBIN"/></p>
                    <p>গন্তব্যস্থলঃ <asp:Label runat="server" ID="lblTransport"/></p>
                </div>
                <div class="col-sm-6" style="width:49%;float:left">
                    <p>চালানপত্র নম্বরঃ <asp:Label runat="server" ID="lblChallanNo"/></p>
                    <p>ইস্যুর তারিখঃ <asp:Label runat="server" ID="lblChallanIssueDate"/></p>
                    <p>ইস্যুর সময়ঃ <asp:Label runat="server" ID="lblChallanIssueTime"/></p>
                </div>
            </div>
            <div class="row" style="margin-top: 3%">
                <table class="table table-bordered" style="width: 100%; text-align: center; background:none; border-collapse:collapse">
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
         <asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" style="float:right" Text="Print" onclientclick="return PrintPanel();" Visible="false"/>
        <uc2:MsgBox ID="msgBox" runat="server"/>
            </ContentTemplate>
        </asp:UpdatePanel>
       
    </div>
    
</asp:Content>
