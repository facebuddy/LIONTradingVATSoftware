<%@ page language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_PricedecComparison, App_Web_ovuzd3bo" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="/resources/demos/style.css">
    <link href="../../Styles/panel.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>

    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=print.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            //printWindow.document.write('</head><body style="margin: 20px;">');
            printWindow.document.write('</head><body style="margin: 20px;font-size:smaller;">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }

    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%;">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Price declaration comparison 4.3
                </div>


                <div class="panel panel-primary" style="font-family: Nikosh">
                    <div class="panel panel-body">
                        <div class="col-md-12">
                            <div class="row">

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label"><span class="required">* </span>পণ্য :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpItem" runat="server" Width="100%" CssClass="select2" Height="25px" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label"><span class="required">* </span>মূল্য ঘোষণা নম্বর:</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpPriceDecNo" runat="server" Width="100%" CssClass="select2"
                                                Height="25px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn-btn" Style="background-color: #59BA68;" OnClick="btnReport_Click" />
                                    
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-btn" Style="background-color: #65C2DD;" OnClientClick="return PrintPanel();" Width="64px" />
                                </div>
                            </div>
                            <div class="row" runat="server" id="print" visible="false">
                                    <div class="row">
                                    <table border="1" style="width: 100%; border-collapse: collapse; background-color: white">
                                        <thead>



                                            <tr style="background-color: white; text-align: center; font-size: 12px;">
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #CBAA90; text-align: center">Item</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #CBAA90; text-align: center">Gross</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #CBAA90; text-align: center">Wastage%</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #CBAA90; text-align: center">Wastage</th>
                                                <th class="col_5_percent" style="font-weight: normal; background-color: #CBAA90; text-align: center">Net used</th>

                                                <th class="col_3_percent" style="font-weight: normal; background-color: #CBAA90; text-align: center">Price</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #A1C270; text-align: center">New Price</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #A1C270; text-align: center">Price Difference%</th>
                                                <%-- <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">মূল্য সংযোজনের খাত</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">মূল্য</th>--%>
                                            </tr>

                                        </thead>
                                        <tbody style="font-size: 11px;">

                                            <tr style=" text-align: center;">
                                                <td style="background-color: #CBAA90;">(১)</td>
                                                <td style="background-color: #CBAA90;">(২)</td>
                                                <td style="background-color: #CBAA90;">(৩)</td>
                                                <td style="background-color: #CBAA90;">(৪)</td>
                                                <td style="background-color: #CBAA90;">(৫)</td>
                                                <td style="background-color: #CBAA90;">(৬)</td>
                                                <td style="background-color: #A1C270;">(৭)</td>
                                                <td style="background-color: #A1C270;">(৮)</td>
                                                <%--  <td>(৯)</td>
                                                <td>(১০)</td>
                                                <td>(১১)</td>
                                                <td>(১২)</td>--%>
                                            </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblInfoShow" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>  
                                    <div class="row" style="width: 100%;display:inline-table;">
                                    <div id="valueAdditionItem" style="width: 50%;display:inline-table;">
                                        <asp:Panel ID="Panel1" runat="server" Height="100%" ScrollBars="Vertical">
                                            <table>
                                                <tr>
                                                    <td class="grid_row_style">
                                                        <asp:Label ID="Label2" runat="server"
                                                            Text="একক পণ্য উৎপাদনে প্রতিটি খাতের মূল্য সংযোজনের পরিমাণ (Value Addition)"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="style3">
                                                        <asp:GridView ID="gvValueAddition" runat="server" AutoGenerateColumns="False"
                                                            DataKeyNames="code_id_d" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("code_id_d") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID2" runat="server" Text='<%# Bind("code_id_d") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত পণ্য ছাড়া">
                                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                                    <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="item_value" HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                                    <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                                </asp:BoundField>

                                                                <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtValueAdditionItem" runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalValueAdditionItem" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtValueAdditionItem" runat="server" CssClass="text_box" OnTextChanged="txtValueAddition_TextChanged" AutoPostBack="true"
                                                                            Width="50px">0.00</asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                                    <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ পার্থক্য%(টাকা)">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtValueAddItemPct" runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtValueAddItemPct" runat="server" CssClass="text_box"
                                                                            Width="50px">0.00</asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                                    <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle Height="25px" />

                                                            <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                                            <EmptyDataTemplate>
                                                                No Data Found.
                                                            </EmptyDataTemplate>

                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </div>
                                    <div id="valueAdditionNonItem"  style="width: 50%;display:inline-table;">
                                        <asp:Panel ID="Panel5" runat="server" Height="100%" ScrollBars="Vertical">
                                            <table>
                                                <tr>
                                                    <td class="grid_row_style">
                                                        <asp:Label ID="Label6" runat="server"
                                                            Text="একক পণ্য উৎপাদনে প্রতিটি খাতের মূল্য সংযোজনের পরিমাণ (Other Principal Inputs)"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="style3">
                                                        <asp:GridView ID="gvValueAdditionNonItem" runat="server" AutoGenerateColumns="False"
                                                            DataKeyNames="code_id_d" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("code_id_d") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID2" runat="server" Text='<%# Bind("code_id_d") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত পণ্য ছাড়া">
                                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                                    <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="item_value" HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                                    <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                                </asp:BoundField>

                                                                <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtValueAdditionNonItem" runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalValueAdditionNonItem" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtValueAdditionNonItem" runat="server" CssClass="text_box" OnTextChanged="txtgvValueAdditionNonItem_TextChanged" AutoPostBack="true"
                                                                            Width="50px">0.00</asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                                    <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ পার্থক্য%(টাকা)">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtValueAddnonItemPct" runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtValueAddnonItemPct" runat="server" CssClass="text_box"
                                                                            Width="50px">0.00</asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                                    <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle Height="25px" />

                                                            <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                                            <EmptyDataTemplate>
                                                                No Data Found.
                                                            </EmptyDataTemplate>

                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </div>

                                    </div>                             
                                    <div class="row" style="text-align: right;margin-top:5px;">
                                   <div class="col-sm-3">
                                        <asp:Label ID="Label4" runat="server" Text="Total Raw Materials:" Style="text-align: right"></asp:Label>
                                        <asp:TextBox ID="txtTotRawmaterial" runat="server" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                            Font-Bold="True" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </div>
                                        
                                        <div class="col-sm-3">
                                        <asp:Label ID="Label10" runat="server" Text="Total Other Principal Inputs:" Style="text-align: right"></asp:Label>
                                        <asp:TextBox ID="nonItemTotalExpense" runat="server" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                            Font-Bold="True" ReadOnly="True" Width="100px">
                                        </asp:TextBox>
                                    </div>                                    
                                    <div class="col-sm-3">
                                        <asp:Label ID="Label11" runat="server" Text="Total Value Addition:" Style="text-align: right"></asp:Label>
                                        <asp:TextBox ID="txtTotalExpenses" runat="server" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                            Font-Bold="True" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="Label3" runat="server" Text="Total Difference(%):" Style="text-align: right"></asp:Label>
                                        <asp:TextBox ID="txtTotal" runat="server" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                            Font-Bold="True" ReadOnly="True" Width="100px">
                                        </asp:TextBox>
                                    </div>
                                </div>
  
                            </div>
                        </div>
                   </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
