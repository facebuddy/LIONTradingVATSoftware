<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Row_Material_Consumtion, App_Web_pn05akvb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="../../UserControls/admin.ascx" tagname="admin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style3
        {
        }
        .style4
        {
            border: 1px solid #CCCCCC;
            background-color: #F0F0F0;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
            width: 549px;
            height: 266px;
        }
        .style5
        {
            height: 21px;
            width: 91px;
        }
        .style10
        {
            width: 90px;
        }
        .style13
        {
        }
        .style14
        {
            border-left: 1px solid #336699;
            border-right: 1px solid #336699;
            border-top: 1px solid #336699;
            font-size: 18px;
            font-family: Arial, Helvetica, sans-serif;
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
            height: 34px;
        }
        .style15
        {
            height: 21px;
        }
        .style16
        {
            height: 32px;
            }
        .style17
        {
            height: 21px;
            width: 90px;
        }
        .style18
        {
            height: 22px;
            }
        .style19
        {
            height: 26px;
            width: 90px;
        }
        .style20
        {
            height: 27px;
            width: 90px;
        }
        .style21
        {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div><table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" 
        cellspacing="3" class="style4">
        <tr>
            <td class="style14" colspan="9">
                Raw Material Consumption</td>
        </tr>
        <tr>
            <td class="style15" valign="top">
                   &nbsp;</td>
            <td class="style15" valign="top" colspan="3">
                   &nbsp;</td>
            <td class="style5" valign="top">
                   &nbsp;</td>
            <td class="style15" valign="top" colspan="4">
                   &nbsp;</td>
        </tr>
        <tr>
            <td class="style15" valign="top" colspan="2" align="right">
                <asp:Label ID="Label1" runat="server" Text="Organization :"></asp:Label>
                   </td>
            <td class="style15" valign="top" align="right">
                <asp:DropDownList ID="drpOrganizationName" runat="server" 
                    Width="170px">
                </asp:DropDownList>
                   </td>
            <td class="style15" valign="top" colspan="2" align="left">
                &nbsp;</td>
            <td class="style15" valign="top" colspan="4">
                   &nbsp;</td>
        </tr>
        <tr>
            <td class="style16" valign="top" align="right" colspan="2">
                <asp:Label ID="lblChallanNo" runat="server" Text="Challan/Batch  :"></asp:Label>
                </td>
            <td class="input_field" colspan="2">
                <asp:TextBox ID="txtChallanBatchNo" runat="server" Width="170px"></asp:TextBox>
            </td>
            <td class="style13" align="right" colspan="2">
                <asp:Label ID="Label8" runat="server" Text="Production Date :"></asp:Label>
            </td>
            <td class="input_field" colspan="3">
                <ww:jQueryDatePicker ID="dtpUnloadRealDate2" runat="server" Width="120px"></ww:jQueryDatePicker></td>
        </tr>
        <tr>
            <td class="style17" valign="top">
                &nbsp;</td>
            <td class="style17" valign="top">
               </td>
            <td class="input_field" colspan="2">
                </td>
            <td class="style13">
                &nbsp;</td>
            <td class="input_field" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style18" valign="top" align="right" colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Category :"></asp:Label>
               </td>
            <td class="input_field" colspan="2">
                <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="category_name" 
                    DataValueField="category_id" Height="20px" Width="136px" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                </td>
            <td class="style13" align="right">
                <asp:Label ID="Label3" runat="server" Text="Item :"></asp:Label>
                </td>
            <td class="style13" colspan="3">
                <asp:DropDownList ID="ddlItemName" DataTextField="item_name" 
                    DataValueField="item_id" runat="server" 
                    onselectedindexchanged="ddlItemName_SelectedIndexChanged" Width="136px" 
                    AutoPostBack="True">
                </asp:DropDownList>
                </td>
            <td class="style13">
                <asp:Label ID="lblUnit" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style15" valign="top" align="center">
                &nbsp;</td>
            <td class="style15" valign="top" align="center" colspan="8">
                <asp:HiddenField ID="HFUnitId" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style20" valign="top" align="center">
                <asp:Label ID="Label6" runat="server" Text="Quantity"></asp:Label>
               </td>
            <td class="style20" valign="top" align="center">
                <asp:TextBox ID="txtQuantity" runat="server" Width="75px" style="text-align:center;"
                    AutoPostBack="True" ontextchanged="txtQuantity_TextChanged">0</asp:TextBox>
               </td>
            <td class="input_field" align="right" colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Unit Price"></asp:Label>
                </td>
            <td class="style3" align="left">
                <asp:TextBox ID="txtUnitPrice" runat="server" Width="75px" AutoPostBack="True" style="text-align:center;"
                    ontextchanged="txtUnitPrice_TextChanged">0</asp:TextBox>
            </td>
            <td class="style3" align="right" colspan="2">
                <asp:Label ID="lblTotal" runat="server" Text="Total Price"></asp:Label>
            </td>
            <td class="style3" align="left" colspan="2">
                <asp:Label ID="lblTotlaPrice"  runat="server">0</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style20" valign="top" align="center">
                &nbsp;</td>
            <td class="style20" valign="top" align="center">
                &nbsp;</td>
            <td class="style21" align="center" colspan="2">
                &nbsp;</td>
            <td class="style21" colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style19" valign="top">
                &nbsp;</td>
            <td class="style19" valign="top">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td align="center" colspan="6" >
                <asp:Button ID="btnAddItem" runat="server" Text="Add item" 
                    onclick="btnSave_Click" />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" />
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click1" />
                </td>
        </tr>
        </table>
       
      <table align="center" bgcolor="WhiteSmoke" border="2" cellpadding="1" cellspacing="3" class="brd_tbl_input">
        <tr>
            <td class="style1" valign="top" align="center">
                   Item Details</td>
        </tr>
        <tr>
            <td class="style1" valign="top" align="right">
               <asp:GridView ID="gvShowItemDetails" runat="server" AutoGenerateColumns="False" 
                                                CssClass="sGrid"   DataKeyNames="item_id,unit_id"
                                              
                                                
                   Width="100%" 
                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                    BorderWidth="1px" >
                    <Columns>
                        <%--<asp:BoundField DataField="item_id" HeaderText="Item ID" />--%>
                        <asp:BoundField DataField="item_name" HeaderText="Item Name" />
                        <%--<asp:BoundField DataField="unit_id" HeaderText="Unit ID" />--%>
                        <asp:BoundField DataField="unit_name" HeaderText="Unit" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="quantity" HeaderText="Qty" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="unit_price" HeaderText="Unit Price" />
                        <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Ok.gif" 
                            ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                    <EmptyDataTemplate>
                                                    No Items Found.
                                                </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
        </tr>
        </table>
       
        </div>
    <uc2:MsgBox ID="msgBox" runat="server" />

</asp:Content>

