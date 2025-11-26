
<%@ control language="C#" autoeventwireup="true"  CodeBehind="DatePicker.ascx.cs" Inherits="NBR_VAT_GROUPOFCOM.UserControls.DatePicker" %>
    <link rel="stylesheet" type="text/css" href="Styles/jquery-ui.css" />
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.12.1.js"></script>

 <script type="text/javascript" >
     //$(function () {
     //    $("#datepicker").datepicker({ dateFormat: "dd/mm/yy" });
     //});
     $(document).ready(function () {
         $("#<%=datepicker.ClientID %>").datepicker({ dateFormat: "dd/mm/yy" });
     });
    </script>

          
 <%--<input type="text" id="datepicker" />--%>
<asp:TextBox runat="server" ID="datepicker" CssClass="form-control" />

   