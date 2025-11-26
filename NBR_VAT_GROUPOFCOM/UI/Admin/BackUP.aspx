<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_BackUP, App_Web_z1w3wddp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
     <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

 










<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="panel panel-primary">
      
<%--<head runat="server">

    <title></title>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js">

    </script>

 

    <script type = "text/javascript">

        function DisplayMessageCall() {

            var pageUrl = '<%=ResolveUrl("~/AjaxServeice.asmx")%>'

            $.ajax({

                type: "POST",

                url: pageUrl + "/HelloWorld",

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

            alert(response.status + " " + response.statusText);

        }

</script>

 

</head>
<body>

    <form id="form1" runat="server">

    <div>

    <asp:Button ID="btnGetMsg" runat="server" Text="Click Me" OnClientClick="DisplayMessageCall();return false;" /><br />

    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>

    </div>

    </form>

</body>--%>
      
        
         <div class="panel-heading text-center" style="font-family:Tahoma; font-size:18px;"> <b>Current Active User: </b><asp:Label runat="server" id="totaluser" EnableViewState="false"></asp:Label>
   
             </div>
        <div class="panel-body">
                
                <div class="form-group">
		
                    <label for="name" class="col-sm-4 control-label">Back UP Path: </label>
		
                    <div class="col-sm-4">
                        <asp:FileUpload ID="filepath" runat="server" class="form-control"/>
			            
		            </div>
                    <div class="col-sm-2">
                        <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator1" ErrorMessage="Required" ForeColor="Red" ControlToValidate="filepath" runat="server" />--%>
                    </div>
                    
	            </div>
                <div class="form-group">
		            <div class="col-sm-offset-4 col-sm-6">
                        <asp:Button class="btn btn-success btn-sm" ID="Button1" Text="BackUP Now" runat="server" OnClick="BackupVATDB_Click" style="background-color: #bf17c2" />
		            </div>
	            </div>              
              
      </div>
    
</div>
<uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>