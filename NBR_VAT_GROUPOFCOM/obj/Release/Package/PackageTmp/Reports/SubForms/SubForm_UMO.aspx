<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_SubForms_SubForm_UMO, App_Web_vvnwjv0y" %>
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
               সাবফর্ম-ঙ 
            </p>
        </div>
        <div class="table table-bordered">
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th style="text-align: center; background-color: #ffbb99">ক্রেতা বিআইএন<br/>নম্বর</th>
                    <th style="text-align: center; background-color: #ffbb99">ক্রেতা<br /> নাম</th>
                    <th style="text-align: center; background-color: #ffbb99">ক্রেতা<br /> ঠিকানা</th>
                    <th style="text-align: center; background-color: #ffbb99">মূল্য</th>
                    <th style="text-align: center; background-color: #ffbb99">কর্তিত মূল্য<br /> সংযোজন কর</th>
                    <th style="text-align: center; background-color: #ffbb99">ইনভয়েস নং<br /> (চালান পত্র/বিল নম্বর ইত্যাদি) </th>
                    <th style="text-align: center; background-color: #ffbb99">ইনভয়েস<br /> /বিলের তারিখ </th>
                    <th style="text-align: center; background-color: #ffbb99">একাউন্ট কোড<br /> কর পরিশোধিত</th>
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
                    <td>&nbsp</td>
                    <td colspan="2" style="text-align:center">
                        মোট 
                    </td>
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
