<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_ItemPriceDeclaration_1KHA, App_Web_jwpupl0k" %>
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
<script language="javascript" type="text/javascript" src="../../Scripts/scrollsaver.min.js"></script>

    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" 
        cellspacing="2" class="brd_tbl_input" border="0px" width="100%">
        <tr>
            <td class="page_title" colspan="7" align="center">
                উপকরণ/উৎপাদন সম্পর্ক বা সহগ মূল্যভিত্তি ঘোষনাপত্র<uc1:ItemNav ID="ItemNav" runat="server" />&nbsp; 
                (মূসক - ১খ)</td>
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
            <td valign="top" align="right" colspan="7" style="text-align: center">
                <asp:Panel ID="pnlTaxVAT" runat="server">
                
    <table align="center" class="brd_tbl_input" cellpadding="0" cellspacing="0">
        <tr>
            <td style="background-color: #FCEEDA">
                &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="Label59" runat="server" Text="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            </td>
            <td style="background-color: #FCEEDA">
                &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="Label60" runat="server" Text="ভ্যাট আরোপযোগ্য মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            </td>
            <td colspan="2" style="background-color: #FCEEDA">
                <asp:Label ID="Label61" runat="server" Text="শুল্ক ও করসহ বিক্রয়মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="background-color: #FCEEDA">
                <asp:Label ID="Label80" runat="server" Text="প্রস্তাবিত মূল্য"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="বর্তমান"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="প্রস্তাবিত"></asp:Label>
            </td>
            <td style="background-color: #FCEEDA">
                <asp:Label ID="Label2" runat="server" Text="সম্পূরক শুল্ক ="></asp:Label>
                <asp:TextBox ID="txtSDRate" runat="server" Width="23px"
                    CssClass="text_box" Enabled="False" ReadOnly="True">0</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label62" runat="server" Text="বর্তমান ="></asp:Label>
                <asp:TextBox ID="txtVATRate" runat="server" Width="23px"
                    CssClass="text_box" Enabled="False" ReadOnly="True">0</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label63" runat="server" Text="প্রস্তাবিত"></asp:Label>
            </td>
            <td style="background-color: #FCEEDA">
                <asp:Label ID="Label64" runat="server" Text="পাইকারী"></asp:Label>
            </td>
            <td class="style2" style="background-color: #FCEEDA">
                <asp:Label ID="Label65" runat="server" Text="খুচরা মূল্য (যদি থাকে)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtProposedPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txtCurrentSDPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txtProposedSDPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtSD" runat="server" Width="100px"
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txtCurrentVATPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txtProposedVATPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtWholeSalePrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtRetailPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
        </tr>
    </table>
    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="6"></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="7" align="right">
                <br />
                                            <asp:Button ID="btnSave" runat="server" CssClass="button" 
                        Text="Save Declaration" onclick="btnSave_Click" />
                                            <asp:Button ID="btnRefreshChallan1" runat="server" CssClass="button" 
                        Text="Refresh" onclick="btnRefreshChallan1_Click" />
                <br />
                    <asp:Label ID="Label77" runat="server" Text="মূল্য ঘোষণা নং :"></asp:Label>
                    <asp:DropDownList ID="ddlPriceDeclarationNo" runat="server" Width="130px">
                    </asp:DropDownList>
                <br />

            </td>
        </tr>
        <tr>
            <td colspan="7" align="right">
                <br />
            </td>
        </tr>
    </table>
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
    <br />
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                </asp:Panel>
<uc2:MsgBox ID="msgBox" runat="server" />
    <br />
</asp:Content>

