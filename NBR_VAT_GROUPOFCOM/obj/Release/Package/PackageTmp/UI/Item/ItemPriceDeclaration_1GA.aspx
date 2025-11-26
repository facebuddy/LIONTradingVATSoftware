<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_ItemPriceDeclaration_1GA, App_Web_jwpupl0k" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src= "~/UserControls/Item.ascx" tagname="ItemNav" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">

        .input_item
        {
            text-align: left;
        }
        .longTextBox
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        SetScroolBar();
    });
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        SetScroolBar();
    });
    function keepScrollPosition() {
        var s = document.getElementById("detailDivArea").scrollTop;
        var l = document.getElementById("detailDivArea").scrollLeft;
        document.getElementById("<%= scrollPos.ClientID %>").value = s;
        document.getElementById("<%= scrollPosLeft.ClientID %>").value = l;
    }
    function SetScroolBar() {
        document.getElementById("detailDivArea").scrollTop = document.getElementById("<%= scrollPos.ClientID %>").value;
        document.getElementById("detailDivArea").scrollLeft = document.getElementById("<%= scrollPosLeft.ClientID %>").value;
    }
    function Onscrollfnction() {
        var div = document.getElementById('detailDivArea');
        var div2 = document.getElementById('HeaderDiv');
        //****** Scrolling HeaderDiv along with DataDiv ******
        div2.scrollLeft = div.scrollLeft;
        keepScrollPosition();
        return false;
    }

    function showPrice(txtPriceId, txtVATId) {
        var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
        var rowCount = jsGvItem.rows.length;
        var totalPrice = 0;
        for (var i = 0; i < rowCount - 1; i++) {
            if (jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value);
                totalPrice = totalPrice + rowPrice;
            }
        }
        document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(Number(totalPrice)).toFixed(2);
    }

    function showTotalQuantity(txtPriceId, txtVATId) {
        var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
        var rowCount = jsGvItem.rows.length;

        var totalQuantity = 0;
        for (var i = 0; i < rowCount - 1; i++) {
            if (jsGvItem.rows[i].cells[3].getElementsByTagName('input')[0].value != "") {
                var rowQuantity = parseFloat(jsGvItem.rows[i].cells[3].getElementsByTagName('input')[0].value);
                totalQuantity = totalQuantity + rowQuantity;
            }
        }
        document.getElementById("<%=txtTotalQuantity.ClientID%>").value = parseFloat(Number(totalQuantity)).toFixed(2);
    }

    function showTotalWastage(txtPriceId, txtVATId) {
        var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
        var rowCount = jsGvItem.rows.length;

        var totalWastage = 0;
        for (var i = 0; i < rowCount - 1; i++) {
            if (jsGvItem.rows[i].cells[6].getElementsByTagName('input')[0].value != "") {
                var rowWastage = parseFloat(jsGvItem.rows[i].cells[6].getElementsByTagName('input')[0].value);
                totalWastage = totalWastage + rowWastage;
            }
        }
        document.getElementById("<%=txtTotalWastage.ClientID%>").value = parseFloat(Number(totalWastage)).toFixed(2);
    }

</script>


    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" 
        cellspacing="2" class="brd_tbl_input" border="0px" width="100%">
        <tr>
            <td class="page_title" colspan="7" align="center">
                উপকরণ/উৎপাদন সম্পর্ক বা সহগ মূল্যভিত্তি ঘোষনাপত্র<uc1:ItemNav ID="ItemNav" runat="server" />&nbsp; 
                (মূসক -১গ)</td>
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
                <asp:Label ID="Label36" runat="server" Text="পণ্যঃ"></asp:Label>
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
                <asp:Label ID="Label30" runat="server" Text="মূল্য ঘোষণা নম্বরঃ"></asp:Label>
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
            <td colspan="6"></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="7" align="right">
                <asp:Panel ID="Panel2" runat="server" Width="100%">
                
                    <table align="center" style="width:100%;margin:0px;padding:0px">
                        <tr>
                            <td valign="top">
                            <asp:Panel ID="pnDetails" runat="server" Width="">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <fieldset>
                                <legend>একক পণ্য উৎপাদনে ব্যবহার্য কাঁচামাল ও প্যাকিং সামগ্রীর পরিমাণ (অপচয়সহ)</legend>
                                <table class="fixed_header_table" border="0px">
                                    <tr class="fixed_grid_head">
                                        <td style="width:24px"></td>
                                        <td style="width:172px">পণ্য ক্যাটাগরী</td>
                                        <td style="width:174px">পণ্য</td>
                                        <td style="width:63px">পরিমান</td>
                                        <td style="width:63px">একক</td>
                                        <td style="width:73px">মূল্য</td>
                                        <td style="width:80px">
                                            অপচয়</td>
                                    </tr>
                                </table>
                                <div id="detailDivArea"  
                                    style="overflow: auto; border: 0px solid olive; width: 100%; height: 320px;" 
                                    onscroll="Onscrollfnction();">
                                <asp:GridView ID="gvItems" ShowFooter="True" runat="server" 
                                        AutoGenerateColumns="False" Width="680px"
                                        CssClass="mGrid" ShowHeader="False" onprerender="gvItems_PreRender" 
                                        onrowdatabound="gvItems_RowDataBound" onrowdeleting="gvItems_RowDeleting" >
                                <HeaderStyle  CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                                         <asp:TemplateField HeaderText="পণ্য ক্যাটাগরী">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="drpCategory" runat="server" CssClass="stdSizeDropdownList" DataSourceID="odsItemCategory"   DataTextField="category_name" DataValueField="category_id" AutoPostBack="true"  OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblDrpCategory" runat="server" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                             <ItemStyle Width="175px" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="পণ্য">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="drpItemName" runat="server" 
                                                    CssClass="stdSizeDropdownList" AutoPostBack="True" 
                                                    onselectedindexchanged="drpItemName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblItemUnitId" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblItemUnit" runat="server"></asp:Label>
                                            </ItemTemplate>
                                             <ItemStyle Width="175px" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="পরিমান">
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtItemQuantity" runat="server"  Width="65px" onblur="showTotalQuantity(this)">0.00</asp:TextBox>
                                             </ItemTemplate>
                                             <FooterStyle HorizontalAlign="Right" />
                                             <FooterTemplate>
                                                 <asp:TextBox ID="txtAddRowNo" runat="server" Width="50px"></asp:TextBox>
                                             </FooterTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="একক">
                                             <FooterTemplate>
                                                 <asp:Button ID="btnNewRow" runat="server" CssClass="button" 
                                                     onclick="ButtonAdd_Click" Text="New Row" />
                                             </FooterTemplate>
                                             <ItemTemplate>
                                                 <asp:DropDownList ID="ddlUnit" runat="server" Width="50px">
                                                 </asp:DropDownList>
                                             </ItemTemplate>
                                             <ItemStyle Width="65px" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="মূল্য">
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtPrice" runat="server" CssClass="stdTextBox" Text="0.00" onblur="showPrice(this)"
                                                     Width="65px"></asp:TextBox>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="txtPrice_FilteredTextBoxExtender" 
                                                     runat="server" Enabled="True" TargetControlID="txtPrice" 
                                                     ValidChars=".0123456789">
                                                 </ajaxToolkit:FilteredTextBoxExtender>
                                             </ItemTemplate>
                                             <ItemStyle Width="65px" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="অপচয়">
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtPrice" runat="server" CssClass="stdTextBox" 
                                                     onblur="showPrice(this)" Text="0.00" Width="75px"></asp:TextBox>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="txtPrice_FilteredTextBoxExtender" 
                                                     runat="server" Enabled="True" TargetControlID="txtPrice" 
                                                     ValidChars=".0123456789">
                                                 </ajaxToolkit:FilteredTextBoxExtender>
                                             </ItemTemplate>
                                             <FooterStyle HorizontalAlign="Right" />
                                             <ItemTemplate>
                                                 <asp:TextBox ID="txtWastage" runat="server" CssClass="stdTextBox" Text="0.00" 
                                                     Width="75px" onblur="showTotalWastage(this)"></asp:TextBox>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="txtDepriciation_FilteredTextBoxExtender" 
                                                     runat="server" Enabled="True" TargetControlID="txtWastage" 
                                                     ValidChars=".0123456789">
                                                 </ajaxToolkit:FilteredTextBoxExtender>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Button ID="ButtonAdd" runat="server" CssClass="add_new_row_button" 
                                                     OnClick="ButtonAdd_Click" Text="New Row" Visible="False" />
                                             </FooterTemplate>
                                             <ItemStyle Width="65px" />
                                         </asp:TemplateField>
                                    </Columns>
                                
                                    <HeaderStyle CssClass="header"/>
                                </asp:GridView>
                                <input id="scrollPos" runat="server" type="hidden" value="0" />
                                <input id="scrollPosLeft" runat="server" type="hidden" value="0" />
                                <asp:ObjectDataSource ID="odsItemCategory" runat="server" SelectMethod="getAllItemCategoryWithBlankRow" TypeName="SetItemBLL">
                                </asp:ObjectDataSource>
                            </div>
                            </fieldset>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                                
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table border="0px">
                                    <tr>
                                        <td style="width:24px">
                                        </td>
                                        <td style="width:172px">
                                            &nbsp;</td>
                                        <td style="width:174px">
                                            <asp:Label ID="Label81" runat="server" Text="মোট ="></asp:Label>
                                        </td>
                                        <td style="width:63px">
                                            <asp:TextBox ID="txtTotalQuantity" runat="server" Width="65px" 
                                                BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" 
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td style="width:63px">
                                            &nbsp;</td>
                                        <td style="width:73px">
                                            <asp:TextBox ID="txtTotalPrice" runat="server" Width="65px" BackColor="Transparent" 
                                                BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" 
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td style="width:80px">
                                            <asp:TextBox ID="txtTotalWastage" runat="server" Width="65px" 
                                                BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" 
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                                            <asp:Button ID="btnSave" runat="server" CssClass="button" 
                        Text="Save Declaration" onclick="btnSave_Click" />
                                            <asp:Button ID="btnRefreshChallan1" runat="server" CssClass="button" 
                        Text="Refresh" onclick="btnRefreshChallan1_Click" />
                <br />
                    <asp:Label ID="Label77" runat="server" Text="মূল্য ঘোষণা নং :"></asp:Label>
                    <asp:DropDownList ID="ddlPriceDeclarationNo" runat="server" Width="130px">
                    </asp:DropDownList>

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
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                </asp:Panel>
<uc2:MsgBox ID="msgBox" runat="server" />
    <br />
</asp:Content>

