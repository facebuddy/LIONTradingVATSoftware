<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_SubForms_SubForm_KH, App_Web_zkqczdrh" %>

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
               সাবফর্ম-খ 
            </p>
            <hr />
        </div>
        <div class="table table-bordered">
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th style="text-align: center; background-color: #ffbb99">ক্যাটাগরি</th>
                    <th style="text-align: center; background-color: #ffbb99">পণ্য/সেবা বাণিজ্যিক বর্ণনা</th>
                    <th style="text-align: center; background-color: #ffbb99">পণ্য/সেবা কোড</th>
                    <th style="text-align: center; background-color: #ffbb99">পণ্য/সেবা নাম</th>
                    <th style="text-align: center; background-color: #ffbb99"> মূল্য (ক)</th>
                    <th style="text-align: center; background-color: #ffbb99">সম্পূরক শুল্ক () </th>
                    <th style="text-align: center; background-color: #ffbb99">মূল্য সংযোজন কর </th>
                    <th style="text-align: center; background-color: #ffbb99">মন্তব্য </th>                    
                </tr>
                <tr>
                    <td>বাণিজ্যিক আমদানিকারক</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>পেট্রোলিয়াম জাতীয় পণ্য</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>সুপার শপ</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>ওষুধ জাতীয় পণ্য</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>অন্যান্য ব্যবসায়ী</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td >
                        &nbsp
                    </td>
                    <td colspan="2" style="text-align:center">মোট</td>
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

