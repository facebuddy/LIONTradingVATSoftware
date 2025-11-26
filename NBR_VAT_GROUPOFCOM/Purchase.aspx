<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Purchase, App_Web_1kre2rwf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
<link href="Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="page_description">Purchase Administration <br /> <span class="description">Here are all types of user</span> <br />
<div id="report_list"><span class="report_title">Purchase</span>
<ul>
<li><a href="UI/Challan.aspx">Purchase Challan<br />(VAT Form-11)</a> </li>
<li><a href="UI/Purchase/PurchaseReturn.aspx">Purchase Return</a> </li>
<li><a href="UI/Purchase/Bill_Of_Entry.aspx">Bill of Entry</a> </li>
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
<p class="page_title">Purchase</p>
<div id="divBoarder" style="text-align:center; height:300px">
<!-- Start BODY section -->
<ul id="box_icon" class="topmenu">
	<li class="topmenu"><a href="UI/Challan.aspx"> <img src="Images/Challan_Purchase.png" class="menu_thumb" title="Purchase Challan (VAT Form-11)" style="padding-top:3px;" /><br />Purchase Challan</a></li>
    <li class="topmenu"><a href="UI/Purchase/PurchaseReturn.aspx"><img src="Images/Purchase_Return.png" class="menu_thumb" style="padding-top:3px;" title="Purchase Return"/><br />Purchase Return</a></li>
    <li class="topmenu"><a href="UI/Purchase/Bill_Of_Entry.aspx"><img src="Images/Bill_Of_Entry.png" class="menu_thumb" style="padding-top:3px;" title="Bill of Entry"/><br />Bill of Entry</a></li>
</ul>
<!-- End BODY section -->
</div>
</div>
</asp:Content>

