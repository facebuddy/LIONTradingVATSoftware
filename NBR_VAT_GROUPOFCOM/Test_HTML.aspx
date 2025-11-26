<%@ page language="C#" autoeventwireup="true" inherits="Test_HTML, App_Web_10xevz1n" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="JavaScript" type="text/javascript">
        DA = (document.all) ? 1 : 0
        function HandleError() {
            alert('\nNothing was printed. \n\nIf you do want to print ' +
          'this page, then\n click on the printer icon in the ' +
          'toolbar above.')
            return true;
        }
  </script>
</head>
<body onload="Print();">
<object ID="WebBrowser1" width="400" height="800" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object>
  <form>   
      <asp:PlaceHolder ID="phViewTemplate" runat="server"></asp:PlaceHolder>
  </form>
  <script language="VBScript">
    
    Sub Print()
      OLECMDID_PRINT = 6
      OLECMDEXECOPT_DONTPROMPTUSER = 2
      OLECMDEXECOPT_PROMPTUSER = 1
      If DA Then
        call WebBrowser1.ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_DONTPROMPTUSER,1)
      Else
        call WebBrowser1.IOleCommandTarget.Exec _ 
            (OLECMDID_PRINT ,OLECMDEXECOPT_DONTPROMPTUSER,"","","")
      End If

    End Sub
   
  </script>
</body>
</html>
