
<%@ control language="C#" autoeventwireup="true" CodeBehind="Others.ascx.cs" Inherits="NBR_VAT_GROUPOFCOM.UserControls.Others" %>
<link href="../Styles/Box_Border.css" rel="stylesheet" type="text/css" />

<%--<div class="page_nav" >
<ul>
<li><a href="../Others/Treasury_Deposit.aspx">Treasury Deposit</a></li>
<li><a href="../Others/Add_Trans_Party.aspx">Party</a></li>
<li><a href="../Others/Dispose.aspx">Dispose</a></li>
</ul>

</div>--%>

<div id="div_close">
    <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Images/cross.png" 
            PostBackUrl="~/Others.aspx" ToolTip="Close" /></div>