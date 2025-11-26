<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_bxnrqbtx" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="../../UserControls/admin.ascx" tagname="admin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .button
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input">
        <tr>
            <td class="page_title" colspan="4">
                VAT Circle<uc1:admin ID="admin" runat="server" /></td>
        </tr>
        <tr>
            <td valign="top" class="style1">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" class="style1">
                    <asp:Label ID="lblCommName" runat="server" Text="Commissonerate Name : "></asp:Label>
            </td>
            <td colspan="3">
                    <asp:DropDownList ID="drpCommName" runat="server" Width="250px" 
                        AutoPostBack="True" onselectedindexchanged="drpCommName_SelectedIndexChanged">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" class="style1" align="right">
                    <asp:Label ID="lblDivisionName" runat="server" Text="Division Name  : "></asp:Label>
            </td>
            <td colspan="3">
                    <asp:DropDownList ID="drpDivisionName" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td valign="top" class="style1" align="right">
                    <asp:Label ID="lblCircleName" runat="server" Text="Circle Name : "></asp:Label></td>
            <td>
                    <asp:TextBox ID="txtCircleName" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td align="right">
                    <asp:Label ID="lblCircleCode" runat="server" Text="Circle Code : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCircleCode" runat="server" Width="80px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1" valign="top" rowspan="3" align="right">
                    <asp:Label ID="lblCircleAddress" runat="server" Text="Address : "></asp:Label>
            </td>
            <td class="input_field" rowspan="3">
                    <asp:TextBox ID="txtCircleAddress" runat="server" TextMode="MultiLine" 
                    Height="70px" Width="250px"></asp:TextBox>
            </td>
            <td class="input_field" align="right">
                    <asp:Label ID="lblCirclePhone" runat="server" Text="Phone # : "></asp:Label>
            </td>
            <td class="input_field">
                    <asp:TextBox ID="txtCirclePhone" runat="server" Width="130px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="input_field" align="right">
                    <asp:Label ID="lblCircleUpazillaId" runat="server" Text="Upazilla Name : "></asp:Label>
            </td>
            <td class="input_field">
                    <asp:DropDownList ID="drpUpazillaName" runat="server" Width="130px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="drpUpazillaName_SelectedIndexChanged">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="input_field" align="right">
                    <asp:Label ID="lblCircleUnionWardId" runat="server" Text="Union/Ward Name : "></asp:Label>
            </td>
            <td class="input_field">
                    <asp:DropDownList ID="drpUnionWardName" runat="server" Width="130px" 
                        onselectedindexchanged="drpUnionWardName_SelectedIndexChanged">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1" align="center" colspan="4">
                <asp:Button ID="btnSave" runat="server" CssClass="button" 
                     Text="Save" onclick="btnSave_Click" />
                <asp:Button ID="btnRefresh" runat="server" CssClass="button" 
                     Text="Refresh" onclick="btnRefresh_Click" Height="26px" />
                <asp:Button ID="btnShowCircleList" runat="server" CssClass="button" 
                     Text="Show Circle List" onclick="btnShowCircleList_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
                <center>
                <asp:GridView ID="dgvVatCircle" runat="server" AutoGenerateColumns="False"
                    CssClass="sGrid" DataKeyNames="circle_id" Width="600px" 
                        onrowdeleting="dgvVatCircle_RowDeleting" 
                        onselectedindexchanged="dgvVatCircle_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="circle_id" HeaderText="Circle ID" Visible="False" />
                        <asp:BoundField DataField="circle_name" HeaderText="Circle Name" />
                        <asp:BoundField DataField="circle_code" HeaderText="Circle Code">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="division_Name" HeaderText="Division" />
                        <asp:BoundField DataField="address" HeaderText="Address">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="phone_no" HeaderText="Phone" ItemStyle-Wrap="false">
                        <ItemStyle HorizontalAlign="Left" Wrap="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="uName" HeaderText="Upazilla">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="uwName" HeaderText="Union/Ward">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
                </center>
            </td>
        </tr>
    </table>
    <br />
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

