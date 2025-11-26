<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_PriceDeclarartionByTrader, App_Web_jwpupl0k" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src= "~/UserControls/Item.ascx" tagname="ItemNav" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">

        .style2
        {
        }
        .style3
        {
            text-align: right;
        }
        .style4
        {
            border-left: 1px solid #336699;
            border-right: 1px solid #336699;
            border-top: 1px solid #336699;
            font-size: 18px;
            font-family: SolaimanLipi;
            font-weight: bold;
            color: #4CAF50;
            text-align: center;
            border-bottom: 2px solid #336699;
            padding-bottom: 6px;
            padding-top: 6px;
            border-top-right-radius: 4px;
            border-bottom-right-radius: 0px;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 0px;
            background: rgb(245,246,246);
/* Old browsers */background: -moz-linear-gradient(top, rgba(245,246,246,1) 0%, rgba(219,220,226,1) 21%, rgba(184,186,198,1) 49%, rgba(221,223,227,1) 80%, rgba(245,246,246,1) 100%); /* FF3.6+ */;
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(245,246,246,1)), color-stop(21%,rgba(219,220,226,1)), color-stop(49%,rgba(184,186,198,1)), color-stop(80%,rgba(221,223,227,1)), color-stop(100%,rgba(245,246,246,1))); /* Chrome,Safari4+ */;
            background: -webkit-linear-gradient(top, rgba(245,246,246,1) 0%,rgba(219,220,226,1) 21%,rgba(184,186,198,1) 49%,rgba(221,223,227,1) 80%,rgba(245,246,246,1) 100%); /* Chrome10+,Safari5.1+ */;
            background: -o-linear-gradient(top, rgba(245,246,246,1) 0%,rgba(219,220,226,1) 21%,rgba(184,186,198,1) 49%,rgba(221,223,227,1) 80%,rgba(245,246,246,1) 100%); /* Opera 11.10+ */;
            background: -ms-linear-gradient(top, rgba(245,246,246,1) 0%,rgba(219,220,226,1) 21%,rgba(184,186,198,1) 49%,rgba(221,223,227,1) 80%,rgba(245,246,246,1) 100%); /* IE10+ */;
            background: rgb(245,246,246); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f5f6f6', endColorstr='#f5f6f6',GradientType=0 );
            text-transform: capitalize;
        }
        .input_item
        {
            text-align: right;
        }
        .longTextBox
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script type="text/javascript">
    $(document).ready(function () {
       
    });
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
       
    });


    function showPrice(txtPriceId, txtVATId) {
       

        var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");
        var rowCountVat = jsGvVat.rows.length;
        var totalVAT = 0;
        for (var i = 1; i < rowCountVat; i++) {
          

            if (jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value);
                totalVAT = totalVAT + rowPrice;
            }
        }

        document.getElementById("<%=txtTotalExpenses.ClientID%>").value = parseFloat(totalVAT).toFixed(2);

        var purchasePrice = document.getElementById("<%=txtPurchasePrice.ClientID%>").value;
        if (purchasePrice > 0) {
            document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = (parseFloat(purchasePrice) + parseFloat(totalVAT)).toFixed(2);
        }
        else
        { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0.00; }


        var sdRate = document.getElementById("<%=txtSDRate.ClientID%>").value;
        var sdAmount = 0.00;

        if (sdRate > 0) {
            sdAmount = ((parseFloat(purchasePrice) + parseFloat(totalVAT)) * (sdRate / 100)).toFixed(2);
        }
        else { sdAmount = 0.00; }

        document.getElementById("<%=txtSD.ClientID%>").value = sdAmount;

        document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = (parseFloat(purchasePrice) + parseFloat(totalVAT) + parseFloat(sdAmount)).toFixed(2);

        var VATRate =  document.getElementById("<%=txtVATRate.ClientID%>").value;
        var vatAmount = 0.00;

        if (VATRate > 0) {
            vatAmount = (parseFloat(purchasePrice) + parseFloat(totalVAT) + parseFloat(sdAmount)) * (VATRate / 100);
        }
        else
            vatAmount = 0.00;


        document.getElementById("<%=txtVAT.ClientID%>").value = vatAmount.toFixed(2);

        document.getElementById("<%=txtWholeSalePrice.ClientID%>").value = (parseFloat(purchasePrice) + parseFloat(totalVAT) + parseFloat(sdAmount) + parseFloat(vatAmount)).toFixed(2);

        
    }

   

    function showNBRPrice(txtPriceId) {

        var jsGvNBRVat = document.getElementById("<%=gvNBRValueAddition.ClientID%>");
        var rowCountNBRVat = jsGvNBRVat.rows.length;
        var totalNBRVAT = 0;
        for (var i = 1; i < rowCountNBRVat; i++) {

            if (jsGvNBRVat.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                var rowNBRPrice = parseFloat(jsGvNBRVat.rows[i].cells[1].getElementsByTagName('input')[0].value);
                totalNBRVAT = totalNBRVAT + rowNBRPrice;
            }
        }

        var NBRActualPrice = document.getElementById("<%=txtNBRPrice.ClientID%>").value;
        var NBRSDRate = document.getElementById("<%= hfNBRSD.ClientID%>").value;

        //document.getElementById("<%=txtNBRPrice.ClientID%>").value = totalNBRVAT + Number(NBRActualPrice);
       
        document.getElementById("<%= txtNBRSDChargablePrice.ClientID%>").value = (parseFloat(totalNBRVAT) + parseFloat(NBRActualPrice)).toFixed(2);

        var NBRSDAmount = 0.00;

        if (NBRSDRate > 0)
            NBRSDAmount = (totalNBRVAT + parseFloat(NBRActualPrice)) * parseFloat(NBRSDRate) / 100;
        else
            NBRSDAmount = 0.00;

        document.getElementById("<%= txtNBRSD.ClientID%>").value = parseFloat(NBRSDAmount).toFixed(2);

        var NBRVATChargablePric = parseFloat((totalNBRVAT + Number(NBRActualPrice)) + Number(NBRSDAmount)).toFixed(2);
        document.getElementById("<%= txtNBRVATChargeablePrice.ClientID%>").value = NBRVATChargablePric;

        document.getElementById("<%= txtNBRWholeSalePrice.ClientID%>").value = parseFloat((Number(NBRVATChargablePric) + (Number(NBRVATChargablePric) * 15 / 100))).toFixed(2);
    }

</script>


    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" 
        cellspacing="2" class="brd_tbl_input" border="0px" width="100%">
        <tr>
            <td class="page_title" colspan="7" align="center">
                 &nbsp;ব্যবসায়ী বা
                 বাণিজ্যিক আমদানিকারক ্তৃক
                 মূল্যভিত্তি ঘোষনাপত্র<uc1:ItemNav ID="ItemNav" runat="server" /> </td>
        </tr>
        <tr>
            <td valign="top" align="right"></td>
            <td></td>
            <td align="right"</td>
            <td align="right" style="text-align: left"></td>
            <td align="right"></td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label29" runat="server" Text="প্রতিষ্ঠানঃ "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlOrganization" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="Label27" runat="server" Text="পণ্য ক্যাটাগরীঃ "></asp:Label>
            </td>
            <td align="right" style="text-align: left">
                <asp:DropDownList ID="ddlItemCategory" runat="server" Width="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlItemCategory_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="Label36" runat="server" Text="পন্যঃ"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlItem" runat="server" Width="150px" AutoPostBack="True" 
                    onselectedindexchanged="ddlItem_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblHSCode" runat="server"></asp:Label>
&nbsp;<asp:Label ID="lblUnit" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label30" runat="server" Text="মূল্য ঘোষনা নম্বরঃ"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPriceDeclaretionNo" runat="server" Width="150px" 
                    CssClass="text_box"></asp:TextBox>
            </td>
            <td align="right">
                <asp:Label ID="Label32" runat="server" Text="বৎসরঃ"></asp:Label>
            </td>
            <td align="right" style="text-align: left">
                <asp:DropDownList ID="ddlYear" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="Label33" runat="server" Text="কার্যকর তারিখঃ"></asp:Label>
            </td>
            <td colspan="2">
                <ww:jQueryDatePicker ID="dtpActiveDate" runat="server" Width="130px" 
                    DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" colspan="7" style="text-align: center">
    <table align="center" class="brd_tbl_input" 
    __designer:mapid="104" cellpadding="0" cellspacing="0">
        <tr __designer:mapid="105">
            <td __designer:mapid="106" style="background-color: #FCEEDA">
                &nbsp;</td>
            <td __designer:mapid="106" colspan="2">
                <asp:Label ID="Label59" runat="server" Text="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            </td>
            <td __designer:mapid="10a" style="background-color: #FCEEDA">
                <asp:Label ID="Label82" runat="server" Text="সম্পূরক শুল্কের পরিমাণ" 
                    CssClass="lebel_title"></asp:Label>
            </td>
            <td __designer:mapid="10c" colspan="2">
                <asp:Label ID="Label60" runat="server" Text="ভ্যাট আরোপযোগ্য মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            &nbsp;</td>
            <td __designer:mapid="10c" colspan="1">
                <asp:Label ID="Label4" runat="server" Text="মূল্য সংযজনের পরিমাণ " 
                    CssClass="lebel_title"></asp:Label>
            &nbsp;</td>
            <td __designer:mapid="110" colspan="2" style="background-color: #FCEEDA">
                <asp:Label ID="Label61" runat="server" Text="শুল্ক ও করসহ বিক্রয়মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="105">
            <td __designer:mapid="106" style="background-color: #FCEEDA">
                <asp:Label ID="Label80" runat="server" Text="পণ্যের ক্রয়মূল্য"></asp:Label>
            </td>
            <td __designer:mapid="106">
                <asp:Label ID="Label3" runat="server" Text="বর্তমান"></asp:Label>
            </td>
            <td __designer:mapid="108">
                <asp:Label ID="Label1" runat="server" Text="প্রস্তাবিত"></asp:Label>
            </td>
            <td __designer:mapid="10a" style="background-color: #FCEEDA">
                <asp:Label ID="Label2" runat="server" Text="শুল্ক হার ="></asp:Label>
                <asp:TextBox ID="txtSDRate" runat="server" Width="23px"
                    CssClass="text_box" Enabled="False" ReadOnly="True">0</asp:TextBox>
            </td>
            <td __designer:mapid="10c">
                <asp:Label ID="Label62" runat="server" Text="বর্তমান"></asp:Label>
            </td>
            <td __designer:mapid="10e">
                <asp:Label ID="Label63" runat="server" Text="প্রস্তাবিত"></asp:Label>
            </td>
             <td __designer:mapid="10e">
                <asp:Label ID="Label81" runat="server" Text="( হার = "></asp:Label>
                <asp:TextBox ID="txtVATRate" runat="server" Width="23px"
                    CssClass="text_box" Enabled="False" ReadOnly="True">0</asp:TextBox>
                <asp:Label ID="Label84" runat="server" Text=" )"></asp:Label>
                </td>
            <td __designer:mapid="110" style="background-color: #FCEEDA">
                <asp:Label ID="Label64" runat="server" Text="পাইকারী"></asp:Label>
            </td>
            <td class="style2" __designer:mapid="110" style="background-color: #FCEEDA">
                <asp:Label ID="Label65" runat="server" Text="খুচরা মূল্য (যদি থাকে)"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="112">
            <td align="center" __designer:mapid="113" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtPurchasePrice" runat="server" Width="100px"  onblur="showPrice(this)" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" __designer:mapid="113">
                <asp:TextBox ID="txtCurrentSDPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" __designer:mapid="115">
                <asp:TextBox ID="txtProposedSDPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" __designer:mapid="117" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtSD" runat="server" Width="60px"
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" __designer:mapid="119">
                <asp:TextBox ID="txtCurrentVATPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" __designer:mapid="11b">
                <asp:TextBox ID="txtProposedVATPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
             <td align="center" __designer:mapid="11b">
                <asp:TextBox ID="txtVAT" runat="server" Width="60px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" __designer:mapid="11d" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtWholeSalePrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" __designer:mapid="11d" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtRetailPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td colspan="7"
               style="vertical-align:top" align="right">
                                <asp:Panel ID="Panel4" runat="server" Height="250px" ScrollBars="Vertical">
                                    <table align="center" class="brd_tbl_input">
                                        <tr>
                                            <td class="grid_row_style">
                                                <asp:Label ID="Label76" runat="server" 
                                                    Text="একক পণ্য উৎপাদনে প্রতিটি খাতের মূল্য সংযোজনের পরিমাণ"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style3">
                                                <asp:GridView ID="gvValueAddition" runat="server" AutoGenerateColumns="False" 
                                                    CssClass="grid" DataKeyNames="code_id_d" Width="400px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" Visible="False">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("code_id_d") %>'> </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("code_id_d") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত">
                                                        <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                        <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblTotalValueAddition" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtValueAddition" runat="server" CssClass="text_box" 
                                                                    onblur="showPrice(this)" Width="50px">0.00</asp:TextBox>
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
                           
            </td>
           
        </tr>
       <tr> <td colspan="7" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:TextBox ID="txtTotalExpenses" 
    runat="server" BackColor="#B7E0E8" 
                                    BorderColor="#0099CC" BorderStyle="Solid" 
    BorderWidth="1px" Font-Bold="True" 
                                    ReadOnly="True" Width="70px"></asp:TextBox>
                                </td>
                                        </tr>
        <tr>
            <td colspan="7" align="right">
                
                <br />
                                            <asp:Button ID="btnSave" runat="server" CssClass="button" 
                        Text="Save Declaretion" onclick="btnSave_Click" />
                                            <asp:Button ID="btnRefreshChallan1" runat="server" CssClass="button" 
                        Text="Refresh" onclick="btnRefreshChallan1_Click" />
                <br />
                    <asp:Label ID="Label77" runat="server" Text="মূল্য ঘোষণা নং :"></asp:Label>
                    <asp:DropDownList ID="ddlPriceDeclarationNo" runat="server" Width="130px" 
                        onselectedindexchanged="ddlPriceDeclarationNo_SelectedIndexChanged">
                    </asp:DropDownList>
                                            <asp:Button ID="btnApprovePrice" runat="server" CssClass="button" 
                        Text="Approve NBR Price" onclick="btnApprovePrice_Click" />

            </td>
        </tr>
        <tr>
            <td colspan="7" align="right">
                <br />
                <asp:GridView ID="gvDeclaretion" runat="server" AutoGenerateColumns="False" 
                    CssClass="grid" DataKeyNames="price_id" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="price_id" HeaderText="Price ID" Visible="False" >
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="organization_name" HeaderText="Organization" >
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="item_name" HeaderText="Item">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hs_code" HeaderText="HS Code">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="price_declaration_no" 
                            HeaderText="Price Declaration No" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="price_declaration_year" HeaderText="Year">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="wholesale_prc_sd_vat" HeaderText="Wholesale Price" 
                            ItemStyle-Wrap="false">
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cgno" HeaderText="Computer Generated No">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Panel ID="pnlApprovePrice" CssClass="popupBlock" runat="server">
        <table class="brd_tbl_input"  
            style="border-color: #4CAF50; border-width: medium;">
            <tr>
                <td class="style4" align="center" height="32" colspan="6">
                    জাতীয় রাজস্ব বোর্ড&nbsp;&nbsp;&nbsp; ্তৃক অনুমোদিত মূল্য&nbsp;</td>
                <td align="center" class="style4" height="32">
                    <asp:Label ID="Label78" runat="server" 
                        Text="একক পণ্য উৎপাদনে প্রতিটি খাতের অনুমোদিত মূল্য সংযোজনের পরিমাণ"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="input_item">
                    <asp:Label ID="Label79" runat="server" Font-Bold="True" Text="মূল্য ঘোষণা নং :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPriceDeclarationNo" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:HiddenField ID="hfPriceId" runat="server" />
                </td>
                <td class="style3">
                    <asp:Label ID="lblDesc3" runat="server" Text="মূল্য ঘোষণার তারিখ :"></asp:Label>
                </td>
                <td colspan="2">
                    <ww:jQueryDatePicker ID="dtpNBRApproveDate" runat="server" 
                        DateFormat="dd/MM/yyyy" Width="130px"></ww:jQueryDatePicker>
                </td>
                <td rowspan="5" valign="top">
                    <asp:GridView ID="gvNBRValueAddition" runat="server" AutoGenerateColumns="False" 
                        CssClass="grid" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID0" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত">
                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                            <ItemStyle CssClass="grid_item" HorizontalAlign="Right" Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtValueAddition0" runat="server" CssClass="text_box" 
                                        onblur="showNBRPrice(this)" Width="50px" 
                                        Text='<%# Bind("cnfrmd_item_value") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="item_value" HeaderText="বর্তমান মূল্য" />
                        </Columns>
                        <HeaderStyle Height="25px" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                        <EmptyDataTemplate>
                            No Data Found.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right" class="input_item" colspan="3">
                    <table class="brd_tbl_input" style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblDesc7" runat="server" Font-Bold="True" Text="অনুমোদিত মূল্য"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDesc8" runat="server" Font-Bold="True" 
                                    Text="প্রস্তাবিত মূল্য"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesc0" runat="server" Text="ক্রয়মূল্য :"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txtNBRPrice" runat="server" CssClass="longTextBox" 
                                    Width="65px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblPrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                                <asp:HiddenField ID="hfNBRPrice" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSubCategory" runat="server" 
                                    Text="সম্পূরক শুল্ক আরোপযোগ্য মূল্য :"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:TextBox ID="txtNBRSDChargablePrice" runat="server" CssClass="longTextBox" 
                                    Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblNBRSDChargablePrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSubCategory0" runat="server" Text="সম্পূরক শুল্ক :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNBRSD" runat="server" CssClass="longTextBox" Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:HiddenField ID="hfNBRSD" runat="server" />
                                <asp:Label ID="lblNBRSD" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="input_item" align="right" colspan="3">
                    <table class="brd_tbl_input" style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblDesc4" runat="server" Font-Bold="True" Text="অনুমোদিত মূল্য"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDesc5" runat="server" Font-Bold="True" 
                                    Text="প্রস্তাবিত মূল্য"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesc" runat="server" Text="ভ্যাট আরোপযোগ্য মূল্য :"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txtNBRVATChargeablePrice" runat="server" 
                                    CssClass="longTextBox" Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblNBRVATChargeablePrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtNBRSDChargablePrice" 
                                    ErrorMessage="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" SetFocusOnError="True" 
                                    ToolTip="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" ValidationGroup="addSubCategory">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblDesc1" runat="server" Text="পাইকারী মূল্য :"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txtNBRWholeSalePrice" runat="server" CssClass="longTextBox" 
                                    Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblNBRWholeSalePrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesc2" runat="server" Text="খুচরা মূল্য :"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txtNBRRetailPrice" runat="server" CssClass="longTextBox" 
                                    Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblNBRRetailPrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" CssClass="label" Width="80px"></asp:Label>
                                <asp:Label ID="lblPriceId" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr>
                <td colspan="6" align="center" valign="middle" height="35px">
                    <asp:Button ID="btnApprove" runat="server" Text="Save"  CssClass="button"
                        ValidationGroup="addSubCategory" onclick="btnApprove_Click" />
                       &nbsp;
                    <asp:Button ID="btnSubClear"  CssClass="button" runat="server" Text="Close" 
                        onclick="btnSubClear_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                        ValidationGroup="addSubCategory" ForeColor="Red" />
                </td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

        <asp:Button ID="btnHiddenForApprovePrice" runat="server" style="display:none"/>
     <ajaxToolkit:ModalPopupExtender ID="modalPopupForApprovePrice" runat="server" 
        PopupControlID="pnlApprovePrice" 
        TargetControlID="btnHiddenForApprovePrice" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>


    <br />
    <br />
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                    <table align="left" class="brd_tbl_input">
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label58" runat="server" Text="Unit"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label53" runat="server" Text="Property 1"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label54" runat="server" Text="Property 2"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label55" runat="server" Text="Property 3"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label56" runat="server" Text="Property 4"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label57" runat="server" Text="Property 5"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:DropDownList ID="ddlUnit" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem6" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem7" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem8" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem9" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem10" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
<uc2:MsgBox ID="msgBox" runat="server" />
    <br />
</asp:Content>

