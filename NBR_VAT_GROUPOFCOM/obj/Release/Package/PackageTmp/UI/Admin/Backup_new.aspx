<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_Backup_new, App_Web_bxnrqbtx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
     <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
<script type = "text/javascript">

        function DisplayMessageCall() {
          
            $.ajax({

                type: "POST",

                url: "Backup_new.aspx/GetCurrentTime",
                data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",

                dataType: "json",

                success: OnSuccessCall,

                error: OnErrorCall

            });

        }

        function OnSuccessCall(response) {
             
            $('#<%=lblOutput.ClientID%>').html(response.d);

        }

        function OnErrorCall(response) {
            alert('sorry');
           // alert(response.status + " " + response.statusText);

        }
      
</script>

    <div>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <asp:Button ID="btnGetMsg" runat="server" Text="Click Me" OnClientClick="DisplayMessageCall();return false;" /><br />
    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    </div>

    </asp:Content>