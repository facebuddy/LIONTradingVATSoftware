<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok_1, App_Web_y1tsx4fu" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <%-- <link href="../../Styles/Main.css" rel="stylesheet" />--%>
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style4 {
            height: 22px;
        }

        .style10 {
            width: 116px;
        }

        .style11 {
            width: 195px;
        }

        .style13 {
            width: 221px;
        }

        .style14 {
            width: 318px;
        }

        .style15 {
            width: 115px;
        }

        .test {
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
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }
    </script>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid" style="padding: 2%;font-family:Nikosh">
        <div class="row" style="font-size:16px">
            <p style="text-align: center">
                গণপ্রজাতন্ত্রী বাংলাদেশ সরকার
            </p>
            <p style="text-align: center">
                জাতীয় রাজস্ব বোর্ড
            </p>
            <%--<p style="text-align: center">
                        মূল্য সংযোজন কর</p>--%>
            <%--  <p style="text-align: center">
                [বিধি
            </p>--%>
            <p style="border: 1px solid #000; float: right; margin-right: 15px">
              <%--  মূসক-<b><span lang="BN-BD">১</span></b>.--%>
                  মূসক-<b><span lang="BN-BD">৪.৩</span></b>.
            </p>
        </div>
        <div>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator>
            <div style="font-size:12px">
            <table class="table table-bordered" style="width: 99%">
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">&nbsp;
                    </th>
                </tr>
                <tr style="background-color: White">
                    <td class="td-width-30">মূল্য ঘোষণা নম্বর
                    </td>
                    <td class="td-width-2"></td>
                    <td>
                        <div style="width: 60%; border: 1px; border-style: solid; float: left;">
                            <asp:DropDownList ID="drpDeclaretionNo" runat="server" Width="100%" Height="25px" CssClass="select2">
                            </asp:DropDownList>
                        </div>
                        <span>
                            <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                        </span>
                        <div style="width: 20%; border: 1px; border-style: solid; float: right; font-weight: bold">
                            <asp:Button ID="btnReport" runat="server" Text="Report"  CssClass="btn-btn" Style="background-color:#59BA68;" OnClick="btnReport_Click" />
                            <asp:Button ID="btnPrint" runat="server" Text="Print"  CssClass="btn-btn" Style="background-color:#65C2DD;" OnClientClick="return PrintPanel();"
                                Width="64px" />
                            <%--<asp:Button ID="btnPrint" runat="server" Text="Print" Width="64px" OnClick="btnPrint_Click" />--%>
                        </div>

                    </td>
                </tr>
            </table>
        </div>
        <div>

            <asp:Panel ID="pnlContents" runat="server">
                <table border="1" class="table table-bordered" style="width: 99%; border-collapse: collapse">
                    <tr>
                        <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc"
                            class="style4">Cost Analysis Sheet
                        </th>
                    </tr>
                    <tr style="background-color: White">
                        <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                          <%--  <strong>পণ্য</strong>--%>
                              <strong>উপকরণ/সংযোজন খাত</strong>
                        </td>
                         <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>পরিমান (কেজি/পিস্)</strong>
                        </td>
                         <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>শুল্কায়নযোগ্য মূল্য (টাকা)</strong>
                        </td>
                       <%-- <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>গ্রস ব্যবহার</strong>
                        </td>--%>
                       <%-- <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>একক</strong>
                        </td>--%>
                         <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>আমদানি শুল্ক</strong>
                        </td>
                       <%-- <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>অপচয়%</strong>
                        </td>--%>
                         <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>আরডি (টাকা)</strong>
                        </td>
                       <%-- <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>অপচয়</strong>
                        </td>--%>
                         <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>অন্যান্য ব্যয় (টাকা)</strong>
                        </td>
                        <%--<td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>নীট ব্যবহার</strong>
                        </td>--%>
                        <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>মোট মূল্য</strong>
                        </td>
                         <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>অপচয়সহ ব্যবহার (গ্রাম/পিস্)</strong>
                        </td>
                        
                       <%-- <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>চালান মূল্য</strong>
                        </td>--%>
                       <%-- <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>চালান পরিমান</strong>
                        </td>--%>
                       <%-- <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>উৎপাদন সংখ্যা</strong>
                        </td>--%>
                        <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">
                            <strong>মূল্য</strong>
                        </td>
                    </tr>
                    <tr>
                        <asp:Label runat="server" ID="lblInfoShow"></asp:Label>
                    </tr>
                </table>
                <div class="col-md-12" style="margin-top: 5px">
                    <div class="form-group form-group-sm">
                        <asp:Label runat="server" Text="System User: "></asp:Label>
                        <asp:Label runat="server" ID="lblUser"></asp:Label>
                        <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                        <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                    </div>
                </div>
                  <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
            </asp:Panel>


        </div>
        </div>
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
    <div class="col-sm-2">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
    </div>
    <%--<uc2:MsgBox ID="msgBox" runat="server"/>--%>
</asp:Content>
