<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="OnlineChalanVerification, App_Web_qhrdyc5n" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<iframe id="myFrame1" src="http://103.48.16.132/echalan/" style="height:450px;width:50%"></iframe>--%>
    <iframe id="myFrame2" src="http://old.cga.gov.bd/index.php?option=com_wrapper&Itemid=497" style="height:450px;width:100%"></iframe>
</asp:Content>

