<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="WasteManagements.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.WasteManagements" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<%--    <link rel="stylesheet" href="/resources/demos/style.css">
    <link href="../../Styles/panel.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    .
     <link href="../../Styles/panel.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>--%>
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
            text-align: center;
        }

        .grid_header {
            background-image: none;
            color: #000 !important;
            border: 1px solid #c9c9c9;
            font-family: arial,Helvetica,sans-serif;
            font-size: 15px;
            font-weight: 700;
            height: 20px;
            text-align: center;
        }

        .label {
            color: #000;
            font-size: 13px !important;
            font-family: arial,Helvetica,sans-serif;
        }
        .hiddencol {
            display: none;
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
    <script type="text/javascript">
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
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">
                            Waste Management
                        </div>
                        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                            <div class="row" style="background-color: #FFD9C3;">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Name :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="org_name" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Address :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="org_address" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. BIN :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpBranchName" runat="server" OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged" AutoPostBack="true"
                                                CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label id="label21" class="control-label col-sm-5"><span class="required">* </span>Factory Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpParty" runat="server" CssClass="form-control"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Factory Address :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox class="form-control" ID="txtAddress" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label id="label211" class="control-label col-sm-5"><span class="required">* </span>Challan No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtChallanNo" CssClass="form-control" Style="height: 27px" runat="server" Enabled="true" />
                                            <asp:HiddenField ID="hdBookId" runat="server" />
                                            <asp:HiddenField ID="hdPageNo" runat="server" />
                                            <asp:CheckBox ID="chkDiscard" Style="float: left; margin-left: 3px; margin-top: 4px;" runat="server" AutoPostBack="True" OnCheckedChanged="chkDiscard_CheckedChanged"
                                                Text="Discard" Visible="false" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label"><span class="required">* </span>Challan Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtChallanDate" Style="width: 50%; float: left" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanDate" />
                                            <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                                            <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label">Transaction Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpTransactionType" runat="server" CssClass="detail-role select2" AutoPostBack="True" TabIndex="1">
                                                <asp:ListItem Value="1">Production Purpose</asp:ListItem>
                                                <asp:ListItem Value="2">Damage Purpose</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label id="label11" class="control-label col-sm-5"><span class="required">* </span>Finish Product(Pr) :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpFinishProduct" CssClass="form-control" runat="server" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpFinishProduct_Click" AutoPostBack="true" ToolTip="If choose finish product, Product Quantity & Price Decl. No are mandatory">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label id="lblBatchNo" runat="server" class="control-label col-sm-5" text="">Batch No.:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtBatchNo" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtBatchNo_TextChanged" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    
                                    <asp:Label runat="server" ID="lblProductType" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp1" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp2" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp3" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp4" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp5" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblUnitPrice" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblVatRate" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblSdRate" Visible="false"></asp:Label>
                                </div>
                                <div class="test-label hide">
                                    <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                    <asp:TextBox ID="lblHSCode" CssClass="hs-code" runat="server" Style="width: 80px"
                                        Enabled="false"></asp:TextBox>
                                    <asp:DropDownList ID="drpItem" CssClass="item select2" Style="text-align: left" runat="server" AutoPostBack="True" Enabled="true" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" />
                                </div>
                                <div class="test-label hide">
                                    <asp:Label ID="Label18" runat="server" Text="Quantity:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtQuantity" CssClass="quantity" Style="width: 75px" runat="server"
                                        AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                        runat="server" Enabled="True" TargetControlID="txtQuantity"
                                        ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:Label runat="server" ID="Label9" Text="avl qnt: " Style="margin-left: -35px;" /><asp:Label runat="server" ID="avlQuantity" />
                                </div>
                                <div class="test-label hide">
                                    <asp:Label ID="Label41" runat="server" Text="Unit:" /><br />
                                    <asp:TextBox ID="lblUnit" CssClass="unit" runat="server" Style="width: 75px"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblUnitId" Visible="false" />
                                </div>
                                <div class="test-label hide">
                                    <asp:Label ID="Label5" runat="server" Text="Remarks:" /><br />
                                    <asp:TextBox ID="txtRemark" CssClass="remark" runat="server" Style="width: 150px"></asp:TextBox>
                                    <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label>
                                </div>

                            </div>

                            <div class="row" style="text-align: right">
                                <div class="test-btn">
                                    <asp:Button ID="printBTN" runat="server" class="btn-btn" Style="background-color: #5CB85C; margin-top: 15px;" OnClick="btnPrint_Click"
                                        Text="Show Report" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnAdd" runat="server" class="btn-btn hiddencol" Style="background-color: #B681B7; margin-top: 15px" OnClick="btnAddItem_Click" Enabled="true"
                                        Text="Add Item" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnSave" runat="server" Style="background-color: #4CAF50; margin-top: 15px" class="btn-btn" Text="Save" OnClick="btnSave_Click" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnClear" runat="server" Style="background-color: #908F8D; margin-top: 15px" class="btn-btn" OnClick="btnClear_Click"
                                        Text="Clear" />
                                </div>
                            </div>
                            <div class="row" style="margin: 1px">
                                <div class="panel panel-primary">
                                    <div class="panel-body">
                                        <div class="" style="overflow: auto;">
                                            <asp:GridView ID="gvIngredience" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                                 Width="100%" OnRowDeleting="gvIngredience_RowDeleting"
                                                BackColor="#DEBA84" BorderColor="#DEBA84" 
                                                BorderStyle="None" BorderWidth="1px">
                                                <Columns>
                                                    <%--<asp:BoundField HeaderText="Category" DataField="CategoryName" />
                                                    <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />--%>
                                                     <asp:TemplateField  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="ItemId" Width="90px" runat="server" Text='<%# Eval("Item_id") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Ingredients Name">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="ItemName" Width="90px" runat="server" Text='<%# Eval("ItemName") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Used qty. (Per)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="PreQuantity" Width="90px" runat="server" Text='<%# Eval("PreQuantity") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="UsedqUnit" Width="90px" runat="server" Text='<%# Eval("UsedqUnit") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Unit">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="UnitName" Width="90px" runat="server" Text='<%# Eval("UnitName") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                    <asp:TemplateField HeaderText="Used for 100 Pcs.">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="used_quantity" Width="90px" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="Unit" Width="90px" runat="server" Text='<%# Eval("Unit") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Unit for 100 Pcs">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TotUnitName" Width="90px" runat="server" Text='<%# Eval("TotUnitName") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Finished Product qty.(Issued)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="finished_prod_issued_qty" Width="90px" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Received Quantity">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="received_quantity" Width="90px" runat="server" Text='<%# Eval("ReceivedQuantiy") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Waste/Damaged Quantity (Batch No. Wise)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="wastage_quantity_batchwise" Width="100px" runat="server" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                  
                                                    <asp:TemplateField HeaderText="Price">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="PriceValue" Width="100px" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="remarks" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reason">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="reason" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Challan Ref. No.">
                                                        <ItemTemplate>
                                                         <asp:DropDownList runat="server" ID="drpChallan" Width="90px" OnSelectedIndexChanged="drpChallan_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Challan Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="challanDate" Width="90px" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Purchase Qty.">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="purchase_quantity" Width="90px" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Challan Price">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="challanPrice" Width="90px" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="VAT">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="vat" Width="90px" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Expire Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="expireDate" Width="90px" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                                 <%--   <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="item_id" Value='<%# Eval("Item_id") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="unit_id" Value='<%# Eval("Unit_id") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="property_id1" Value='<%# Eval("Property_id1") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="property_id2" Value='<%# Eval("Property_id2") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="property_id3" Value='<%# Eval("Property_id3") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="property_id4" Value='<%# Eval("Property_id4") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="property_id5" Value='<%# Eval("Property_id5") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

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
                       <%--     <uc2:MsgBox ID="msgBox" runat="server" />--%>
                    <uc1:MsgBoxs runat="server" ID="msgBox" />

                        </div>
                    </div>
                </div>
                <div id="cpPrint" class="container-fluid" style="margin-top: 2%;" runat="server" visible="false">
                    <div class="row">
                        <p>
                            <center>
                                <b style="margin-left: 9%;">উৎপাদনের চালানপত্র </b>
                    </center>
                        </p>
                        <p style="text-align: center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (ঘ) দ্রষ্টব্য]</p>
                    </div>
                    <div class="row" style="margin-top: 4%">
                        <p style="margin-left: 35%">নিবন্ধিত ব্যাক্তির নাম :<asp:Label runat="server" ID="OrgName" /></p>
                        <p style="margin-left: 35%">নিবন্ধিত ব্যাক্তির বিআইএন :<asp:Label runat="server" ID="Label1" /></p>
                        <p style="margin-left: 35%">চালান ইস্যুর ঠিকানা :<asp:Label runat="server" ID="OrgAddress" /></p>
                    </div>
                    <div class="row">
                        <div class="col-sm-6" style="width: 50%; float: left">
                            <p>
                                পণ্য গ্রহিতার নাম :
                                <asp:Label runat="server" ID="PartyName" />
                            </p>

                            <p>
                                গ্রহীতার বিআইএন :
                                <asp:Label runat="server" ID="PartyBIN" />
                            </p>

                            <p>
                                গন্তব্যস্থল :
                                <asp:Label runat="server" ID="PartyAddress" />
                            </p>
                            <p style="display: none;">
                                যানবাহনের প্রকৃতি ও নম্বর :
                                <asp:Label runat="server" ID="vehicleType" />
                            </p>
                        </div>
                        <div class="col-sm-6" style="width: 49%; float: left">
                            <p>
                                চালানপত্র নম্বর :
                                <asp:Label runat="server" ID="ChallanNo" />
                            </p>
                            <p>
                                ইস্যুর তারিখ :
                                <asp:Label runat="server" ID="ChallanIssueDate" />
                            </p>
                            <p>
                                ইস্যুর সময় :
                                <asp:Label runat="server" ID="ChallanIssueTime" />
                            </p>
                            <p style="display: none;">
                                উপকরণ অপসারণের প্রকৃত তারিখ ও সময় :
                                <asp:Label runat="server" ID="ChallanDeliverDate" />
                            </p>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 3%">
                        <table class="table table-bordered" style="width: 100%; text-align: center; background: none; border-collapse: collapse">
                            <tr>
                                <td style="border: 1px solid gray">ক্রমিক নং
                                </td>
                                </td>--%>
                                <td style="border: 1px solid gray">প্রকৃতি (উপকরণ বা উৎপাদিত পণ্য)
                                </td>
                                <td style="border: 1px solid gray">পণ্যের বিবরণ
                                </td>
                                <td style="border: 1px solid gray">পরিমাণ
                                </td>
                                <td style="border: 1px solid gray">মন্তব্য
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid gray">(১)
                                </td>
                                <td style="border: 1px solid gray">(২)
                                </td>
                                <td style="border: 1px solid gray">(৩)
                                </td>
                                <td style="border: 1px solid gray">(৪)
                                </td>
                                <td style="border: 1px solid gray">(৫)
                                </td>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="HaiMan"></asp:Label>
                            </tr>
                        </table>
                    </div>
                    <div class="row" style="margin-top: 10px">
                        <p>
                            দায়িত্বপ্রাপ্ত কর্মকর্তার স্বাক্ষর
                        </p>
                        <p>
                            নাম : 
                            <asp:Label runat="server" ID="lblDutyOfficer" />
                        </p>
                        <p>
                            পদবী : 
                            <asp:Label runat="server" ID="Label11" />
                        </p>
                    </div>
                </div>
                <asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" Style="float: right"
                    Text="Print" OnClientClick="return PrintPanel();" Visible="false" />
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
