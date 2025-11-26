<%@ page language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_GoodsRequisitionToVendor, App_Web_jwpupl0k" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlPrint.ClientID %>");
            var windowHeight = window.innerHeight;
            var windowWidth = window.innerWidth;
            var printWindow = window.open('', '', 'letf=0,top=0,height=' + windowHeight + ',width=' + windowWidth + ',toolbar=0,scrollbars=1,status=0');
            printWindow.document.write('<html><head><title>Goods Receipt Note</title>');
            printWindow.document.write('<link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet">');
            printWindow.document.write('</head><body style="padding:5%">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            // printWindow.close();
        }

        function calculation(selectedgrid)
        {
            var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
            var rowCount = jsGvItem.rows.length;
            var rows = selectedgrid.parentNode.parentNode;
            var quantity = parseFloat(rows.cells[2].getElementsByTagName('input')[0].value);
           
            var rate = parseFloat(rows.cells[3].getElementsByTagName('input')[0].value);
            
            var discount = parseFloat(rows.cells[4].getElementsByTagName('input')[0].value);
            var tax = parseFloat(rows.cells[5].getElementsByTagName('input')[0].value);
            
            var x = quantity * rate;
            var y = parseFloat(x) + parseFloat(tax);
            var total = parseFloat(y) - parseFloat(discount);
            rows.cells[6].getElementsByTagName('input')[0].value = total;
            //rows.cells[6].getElementsByTagName('input')[0].value = x;
        }
    </script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel panel-heading text-center" style="font-family:Tahoma; font-size:18px;"><b>Goods Requisition Form for Vendor</b></div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Organization : </label>
                                        <asp:Label runat="server" ID="lblOrganization" CssClass="col-sm-8 text-left" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Address : </label>
                                        <asp:Label runat="server" ID="lblOrgAddress" CssClass="col-sm-8 text-left" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">BIN : </label>
                                        <asp:Label runat="server" ID="lblOrgBIN" CssClass="col-sm-7 text-left" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Branch Name : </label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="ddlOrgBranch" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgBranch_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Address : </label>
                                        <asp:Label runat="server" ID="lblOrgBranchAddress" CssClass="col-sm-8 text-left" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">BIN : </label>
                                        <asp:Label runat="server" ID="lblOrgBranchBIN" CssClass="col-sm-7 text-left" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">GRN : </label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtGRNNo" CssClass="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Vendor : </label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="ddlVendor" CssClass="form-control" />
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Reg. No : </label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtRegNo" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Purchase Order : </label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtPurchaseOrder" CssClass="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Receiving Store : </label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtReceivingStore" CssClass="form-control" />
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Date : </label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtRequisitionDate" CssClass="form-control" style="font-size:11pt" />
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtRequisitionDate"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Voucher No : </label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtVoucherNo" CssClass="form-control" />
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label text-right">Template No : </label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="ddlTemplateNo" CssClass="form-control"></asp:DropDownList>
                                        </div>

                                    </div>
                                </div>

                                <div class="col-md-4">
                               <%--<asp:Button runat="server" ID="btnShow" OnClick="btnShow_Click" Text="Show" CssClass="btn btn-primary btn-sm" />
                                    <asp:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="Add" CssClass="btn btn-primary btn-sm" />
                                    <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-primary btn-sm" />
                                    <asp:Button runat="server" ID="btnClear" OnClick="btnClear_Click" Text="Clear" CssClass="btn btn-primary btn-sm" />--%>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 10px; padding: 5px">
                                <div class="test-label">
                                    <asp:Label ID="Label40" runat="server" Text="Search Product:" /><br />
                                    <asp:TextBox Style="text-align: left" ID="productName" CssClass="search-product" AutoPostBack="true" placeholder="Search Product"
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
                                    <asp:DropDownList ID="drpItem" CssClass="item" Style="text-align: left" runat="server" AutoPostBack="True" Enabled="true" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" />
                                   
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                    <asp:TextBox ID="lblHSCode" CssClass="hs-code" runat="server" Style="width: 80px"
                                        Enabled="false"></asp:TextBox>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label18" runat="server" Text="Quantity:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtQuantity" CssClass="quantity" Style="width: 75px" runat="server" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                                   <%-- <asp:Label runat="server" ID="Label9" Text="avl qnt: " Style="margin-left: -35px;" /><asp:Label runat="server" ID="avlQuantity" />--%>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label41" runat="server" Text="Unit:" /><br />
                                    <asp:DropDownList ID="ddlUnit" CssClass="unit" runat="server" Style="width: 100px"></asp:DropDownList>
                                    <asp:Label runat="server" ID="lblUnitId" Visible="false" />
                                </div>
                               
                                <div class="test-label">
                                    <asp:Label ID="Label1" runat="server" Text="Rate:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtRate" CssClass="quantity" Style="width: 75px" runat="server" AutoPostBack="True" OnTextChanged="txtRate_TextChanged"></asp:TextBox>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label2" runat="server" Text="Discount:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtDiscount" CssClass="quantity" Style="width: 75px" runat="server" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label3" runat="server" Text="Tax:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtTax" CssClass="quantity" Style="width: 75px" runat="server" AutoPostBack="True" OnTextChanged="txtTax_TextChanged"></asp:TextBox>
                                </div>
                                 <div class="test-label">
                                    <asp:Label ID="Label4" runat="server" Text="Total:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtTotal" CssClass="quantity" Style="width: 115px" runat="server"/>
                                </div>
                                 <div class="test-label">
                                    <asp:Label ID="Label5" runat="server" Text="Remarks:" /><br />
                                    <asp:TextBox ID="txtRemark" CssClass="remark" runat="server" Style="width: 150px"></asp:TextBox>
                                    <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label>
                                </div>                               
                            </div>
                            <div class="row" style="text-align:right">
                                 <div class="test-btn">
                                    <asp:Button runat="server" ID="btnShow" OnClick="btnShow_Click" Text="Show" class="btn-btn" style="background-color:#5CB85C;" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="Add" class="btn-btn" style="background-color:#05f1f6;color:black;" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" class="btn-btn" style="background-color:#4CAF50;" />
                                </div>
                                <div class="test-btn">
                                   <asp:Button runat="server" ID="btnClear" OnClick="btnClear_Click" Text="Clear" class="btn-btn" style="background-color:#4CAF50;"  />
                                </div>
                                 <div class="test-btn">
                                   <asp:Button runat="server" ID="btnPrint" OnClientClick="PrintPanel()" Text="Print" class="btn-btn" style="background-color:#4CAF50;"  />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel panel-body">
                            <asp:GridView runat="server" DataKeyNames="ItemID" ID="gvItems" AutoGenerateColumns="False" 
                                OnRowDataBound="gvItems_RowDataBound" OnRowDeleting="gvItems_RowDeleting"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width=100%>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                                <asp:HiddenField ID="ItemID" Value='<%# Eval("ItemID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText ="Item">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblItem" Text='<%# Eval("ItemName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="Item" DataField="ItemName" />--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                                <asp:HiddenField ID="UnitID" Value='<%# Eval("UnitID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUnit" Text='<%# Eval("UnitName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="Unit" DataField="UnitName" />--%>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="gvTxtQuantity" onkeyup="calculation(this)" Text= '<%# Eval("Quantity") %>' CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="gvTxtRate" onkeyup="calculation(this)" Text= '<%# Eval("UnitPrice") %>' CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="gvTxtDiscount" onkeyup="calculation(this)" Text= '<%# Eval("Discount") %>' CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="gvTxtTax" onkeyup="calculation(this)" Text= '<%# Eval("Tax") %>' CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="gvTxtAmount" Text= '<%# Eval("Total") %>' CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="true" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle Height="40" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="panel panel-primary" runat="server" id="pnlPrint">
                        <div class="panel panel-body">
                            <div class="row">
                                <asp:Label runat="server" ID="lblOrganizationName" CssClass="text-left" style="font-weight:bold" /><br />
                                <asp:Label runat="server" ID="lblOrganizationAddress" CssClass="text-left" style="font-weight:bold" /><br />
                                <asp:Label runat="server" ID="lblOrganizationDistrict" CssClass="text-left" style="font-weight:bold" />
                            </div>
                            <div class="row">
                                <center><label style="font-weight:bold;font-size:14pt">Goods Receipt Note</label></center>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbl1" Text="GRN#" />
                                    <asp:Label runat="server" ID="lblGRNNo" Style="margin-left:15.5%" /><br />
                                    <asp:Label runat="server" ID="Label7" Text="Voucher No" />
                                    <asp:Label runat="server" ID="lblVoucherNo" Style="margin-left:10%" /><br />
                                    <asp:Label runat="server" ID="Label9" Text="Date" />
                                    <asp:Label runat="server" ID="lblDate" Style="margin-left:17.2%" /><br />
                                    <asp:Label runat="server" ID="Label12" Text="Receiving Store" />
                                    <asp:Label runat="server" ID="lblReceivingStore" Style="margin-left:5.8%" /><br />
                                     <asp:Label runat="server" ID="Label13" Text="Purchase Order" />
                                    <asp:Label runat="server" ID="lblPurchaseOrder" Style="margin-left:6%" /><br />
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="Label6" Text="Vendor" />
                                    <asp:Label runat="server" ID="lblVendor" Style="margin-left:10%" /><br />
                                    <asp:Label runat="server" ID="Label8" Text="Reg. No." />
                                    <asp:Label runat="server" ID="lblRegNo" Style="margin-left:8.5%" /><br />
                                    <asp:Label runat="server" ID="Label10" Text="Print Date" />
                                    <asp:Label runat="server" ID="lblPrintDate" Style="margin-left:7.5%" /><br />
                                    <asp:Label runat="server" ID="Label11" Text="Print By" />
                                    <asp:Label runat="server" ID="lblPrintBy" Style="margin-left:10%" /><br />
                                </div>
                                
                            </div>
                            <div class="row">
                                <table border="1" class="table" style="width:100%;border-collapse:collapse">
                                    <thead>
                                        <tr>
                                            <th style="text-align:center">Item Name</th>
                                             <th style="text-align:center">Quantity</th>
                                             <th style="text-align:center">Unit</th>
                                             <th style="text-align:center">Rate</th>
                                             <th style="text-align:center">Dis. Amount</th>
                                             <th style="text-align:center">Tax</th>
                                             <th style="text-align:center">Amount</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <asp:Label runat="server" ID="lblTableBody" />
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <uc2:MsgBox ID="msgBox" runat="server" style="background:#0094ff"/>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
