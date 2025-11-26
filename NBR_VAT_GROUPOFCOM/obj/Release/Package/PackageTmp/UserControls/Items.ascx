
<%@ control language="C#" autoeventwireup="true"  CodeBehind="Items.ascx.cs" Inherits="NBR_VAT_GROUPOFCOM.UserControls.Items" %>
<link href="../Styles/Box_Border.css" rel="stylesheet" type="text/css" />

<%--<div class="page_nav" >
<ul>
<li><a href= "../Item/SetUnit.aspx">Set Unit</a></li>
<li><a href= "../Item/SetUintConversion.aspx">Set Unit Conversion</a></li>
<li><a href="../Item/SetItem.aspx">Set Item</a></li>
<li><a href="../Item/SetProperty.aspx">Set Item Property</a></li>
<li><a href="../Item/Item_Tax_Values.aspx">Item Tax</a></li>
<li><a href="../Item/Item_Price_Declarertion.aspx">Price Declaration</a></li>
</ul>

</div>--%>

<div id="div_close">
    <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Images/cross.png" 
            PostBackUrl="~/Item.aspx" ToolTip="Close" /></div>