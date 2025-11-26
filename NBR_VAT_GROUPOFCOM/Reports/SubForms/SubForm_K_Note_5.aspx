<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_SubForms_SubForm_K_Note_5, App_Web_vvnwjv0y" %>

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
            <p style="text-align: center;font-weight:bold;font-size:20px;">
               সাবফর্ম-ক 
            </p>
        </div>
        <div class="panel panel-primary panel-primary-custom">
                        <div class="panel-body">
                            <div class="gridDiv table-responsive paddingsmall">  
                                <asp:GridView ID="gvSubForm_K" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%">
                                    <Columns>
                                        <asp:BoundField HeaderText="পণ্য/সেবা বর্ণনা" DataField="details" />
                                        <asp:BoundField HeaderText="পণ্য/সেবা কোড" DataField="hs_code" />
                                        <asp:BoundField HeaderText="পণ্য/সেবা নাম" DataField="item_name" />
                                        <asp:BoundField HeaderText="মূল্য" DataField="price" DataFormatString="{0:#,#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField HeaderText="সম্পূরক শুল্ক" DataField="sd" DataFormatString="{0:#,#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField HeaderText="মূল্য সংযোজন কর" DataField="vat" DataFormatString="{0:#,#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField HeaderText="মন্তব্য" DataField="remarks" />
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
    </div>
</asp:Content>