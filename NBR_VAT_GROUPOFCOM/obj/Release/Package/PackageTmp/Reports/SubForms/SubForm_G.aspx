<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_SubForms_SubForm_G, App_Web_lb3hvxkt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=reportMain.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head><body style="margin: 50px;">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <style>
        .m
        {
            text-align:right;
            padding-right:5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="reportMain" class="container-fluid" style="padding: 2%;" runat="server" visible="true">
        <div class="row">
            <p style="text-align: center;font-weight:bold;font-size:16px;">
               সাবফর্ম-গ 
            </p>
            <hr />
        </div>
        <div class="table table-bordered">
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th style="text-align: center; background-color: #ffbb99">পণ্য/সেবা <br />বর্ণনা</th>
                    <th style="text-align: center; background-color: #ffbb99">পণ্য/সেবা বাণিজ্যিক<br /> কোড</th>
                    <th style="text-align: center; background-color: #ffbb99">পণ্য/সেবা <br />নাম</th>
                    <th style="text-align: center; background-color: #ffbb99"> পরিমাপের একক <br />(ক)</th>
                    <th style="text-align: center; background-color: #ffbb99"> পরিমাপের <br />(খ)</th>
                    <th style="text-align: center; background-color: #ffbb99">প্রকৃতি বিক্রয়/ ক্রয় মূল্য<br /> (গ)</th>
                    <th style="text-align: center; background-color: #ffbb99">সম্পূরক শুল্ক <br />(ঘ)</th>
                    <th style="text-align: center; background-color: #ffbb99">মূল্য সংযোজন কর<br /> (ঙ)</th>
                    <th style="text-align: center; background-color: #ffbb99">মন্তব্য </th>
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>                    
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        মোট 
                    </td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>