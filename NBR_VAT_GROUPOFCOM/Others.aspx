<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Others, App_Web_qr4mw4bg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
<link href="Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div id="page_description">Others Administrative Task <br /> <span class="description">Here are all types of user</span> <br />
<div id="report_list"><span class="report_title">Other</span>
<ul>
<%--<li><a href="Price_Declaration.aspx">Party</a> </li>--%>
<li><a href="UI/Others/Dispose.aspx">Dispose</a> </li>
<%--<li><a href="Price_Declaration.aspx">DADO</a> </li>--%>
</ul>
</div>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</div>



<div>
<p class="page_title">Others Setup</p>
<div id="divBoarder" style="text-align:center; height:300px">
<!-- Start BODY section -->
<ul id="box_icon" class="topmenu">
	<li class="topmenu"><a href="UI/Others/Treasury_Deposit.aspx"> <img src="Images/Treasury_Deposit.png" class="menu_thumb" title="Treasury Deposit" style="padding-top:3px;" /><br />Treasury Deposit</a></li>
    <li class="topmenu"><a href="UI/Others/Add_Trans_Party.aspx"><img src="Images/party.png" class="menu_thumb" style="padding-top:3px;" title="Party/Customer"/><br />Party</a></li>
    <li class="topmenu"><a href="UI/Others/Dispose.aspx"><img src="Images/dispose.png" class="menu_thumb" style="padding-top:3px;" title="Item Dispose"/><br />Dispose</a></li>
    <li class="topmenu"><a href="UI/Others/DADO.aspx"><img src="Images/dispose.png" class="menu_thumb" style="padding-top:3px;" title="Item Dispose"/><br />DADO</a></li>
</ul>
<!-- End BODY section -->
</div>
</div>
</asp:Content>

