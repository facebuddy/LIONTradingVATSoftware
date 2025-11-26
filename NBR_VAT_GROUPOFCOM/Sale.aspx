<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Sale, App_Web_qr4mw4bg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
<link href="Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div id="page_description">Sale Administration <br /> <span class="description">Here are all types of user</span> <br />
<div id="report_list"><span class="report_title">Sale</span>
<ul>
<li><a href="#">Sale Return</a> </li>
<li><a href="UI/Sale/CashMemo.aspx">Cash memo</a> </li>
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
<p class="page_title">Sale</p>
<div id="divBoarder" style="text-align:center; height:300px">
<!-- Start BODY section -->
<ul id="box_icon" class="topmenu">
    <li class="topmenu"><a href="#"><img src="Images/Sale_Return2.png" class="menu_thumb" title="Sale Return"/><br />Sale Return</a></li>
    <li class="topmenu"><a href="UI/Sale/CashMemo.aspx"><img src="Images/cash-memo.png" class="menu_thumb" title="Cash Memo"/><br />Cash Memo</a></li>
</ul>
<!-- End BODY section -->
</div>
</div>
</asp:Content>

