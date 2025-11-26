<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="TestR_D, App_Web_qr4mw4bg" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <%-- <link href="../../Styles/Main.css" rel="stylesheet" />--%>
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.rawgit.com/niklasvh/html2canvas/master/dist/html2canvas.min.js"></script>
    <style type="text/css">
        .style4
        {
            height: 22px;
        }
        .style10
        {
            width: 116px;
        }
        .style11
        {
            width: 195px;
        }
        .style13
        {
            width: 221px;
        }
        .style14
        {
            width: 318px;
        }
        .style15
        {
            width: 115px;
        }
        
        .test
        {
            width: 183px;
        }
    </style>
    <script type="text/javascript">
        function PrintPanel() {

            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            document.getElementById('<%=btnPrint.ClientID%>').click();

            setTimeout(function () {
                printWindow.print();
                

            }, 500);
            return false;
        }

//        function Print() {



//            setTimeout(function () {
//                window.print();

//            }, 500);
//            return false;
//        }
//     
//   
//        function ConvertToImage(btnExport) {
//            html2canvas($("#PrintDiv")[0]).then(function (canvas) {
//                var base64 = canvas.toDataURL();
//                $("[id*=hfImageData]").val(base64);
//                __doPostBack(btnExport.name, "");
//            });
//            return false;
//        }
    </script>



</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid" style="padding: 2%">
        <div class="row">
            <p style="text-align: center">
                গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
            <p style="text-align: center">
                জাতীয় রাজস্ব বোর্ড</p>
            <%--<p style="text-align: center">
                        মূল্য সংযোজন কর</p>--%>
            <%--  <p style="text-align: center">
                [বিধি
            </p>--%>
            <p style="border: 1px solid #000; float: right; margin-right: 15px">
                মূসক-<b><span lang="BN-BD">১</span></b>.</p>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                        &nbsp;
                    </th>
                </tr>
                <tr style="background-color: White">
                    <td class="td-width-30">
                        মূল্য ঘোষণা নম্বর
                    </td>
                    <td class="td-width-2">
                    </td>
                    <td>
                        <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                            <asp:DropDownList ID="drpDeclaretionNo" runat="server" Width="100%" Height="25px">
                            </asp:DropDownList>
                        </div>
                        <div style="width: 29%; border: 1px; border-style: solid; float: right; font-weight: bold">
                            <asp:Button ID="btnReport" runat="server" Text="Report" Width="64px" OnClick="btnReport_Click" />
                            <%-- <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="return PrintPanel();"
                                    Width="64px" onclick="btnPrint_Click" />--%>
                            <asp:Button ID="btnPrint" runat="server" Text="Print" Width="64px" OnClick="btnPrint_Click" />

                            
                        </div>
                       
                    </td>
                </tr>
            </table>
        </div>
        <div id="PrintDiv">
            <asp:Panel ID="panel1" runat="server">
                <asp:Panel ID="pnlContents" runat="server">
                    <table class="table table-bordered" style="width: 100%; border-style: solid; border-width: 2px">
                        <tr>
                            <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                class="style4">
                                Cost Analysis Sheet
                            </th>
                        </tr>
                        <tr style="background-color: White">
                            <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>পণ্য</strong>
                            </td>
                            <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>গ্রস ব্যবহার</strong>
                            </td>
                            <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>একক</strong>
                            </td>
                            <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>অপচয়%</strong>
                            </td>
                            <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>অপচয়</strong>
                            </td>
                            <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>নীট ব্যবহার</strong>
                            </td>
                            <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>চালান মূল্য</strong>
                            </td>
                            <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>চালান পরিমান</strong>
                            </td>
                            <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>উৎপাদন সংখ্যা</strong>
                            </td>
                            <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">
                                <strong>মূল্য</strong>
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="style10" align="center" style="width: 10%">
                            </td>
                            <td class="style11" align="center" style="width: 10%">
                            </td>
                            <td class="style14" align="center" style="width: 10%">
                            </td>
                            <td class="style13" align="center" style="width: 10%">
                            </td>
                            <td align="center" class="style15" style="width: 10%">
                            </td>
                            <td class="style10" align="center" style="width: 10%">
                            </td>
                            <td class="style11" align="center" style="width: 10%">
                            </td>
                            <td class="style14" align="center" style="width: 10%">
                            </td>
                            <td class="style13" align="center" style="width: 10%">
                            </td>
                            <td align="center" class="style15" style="width: 10%">
                            </td>
                        </tr>--%>
                        <tr>
                            <asp:Label runat="server" ID="lblInfoShow"></asp:Label></tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
        </div>
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
    <div class="col-sm-2">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
    </div>
    <%--<uc2:MsgBox ID="msgBox" runat="server"/>--%>
</asp:Content>
