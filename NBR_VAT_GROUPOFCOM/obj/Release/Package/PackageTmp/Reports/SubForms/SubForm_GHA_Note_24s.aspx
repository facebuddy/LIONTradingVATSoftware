<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="SubForm_GHA_Note_24s.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.SubForms.SubForm_GHA_Note_24s" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
      
    <script type="text/javascript">
        function PrintPanel() {
                 document.getElementById('<%=btnPrint.ClientID %>').style.visibility = "hidden"; 
            var panel = document.getElementById("<%=reportMain.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;text-align:center;}table.allSolid td { border: 1.5px solid black;} p.printHeader{font-size:19px;}</style>');
            printWindow.document.write('</head><body style="margin: 50px;font-size:smaller;">');
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
        .hiddencol{
            display:none;
        }  
                  
        table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;text-align:center;}
        table.allSolid td { border: 1.5px solid black;}

        p.printHeader{font-size:14px;}


    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="reportMain" class="container-fluid" style="padding: 2%;" runat="server" visible="true">
        <div class="row">
            <p class="printHeader" style="text-align: center;font-weight:bold;">
              সরবরাহকারীর সরবরাহ থেকে উৎসে কর্তনের জন্য (নোট-২৪)</p>
            <hr />
        </div>
       <%-- <div class="panel panel-primary panel-primary-custom">
                        <div class="panel-body">
                            <div class="gridDiv table-responsive paddingsmall">  
                                <asp:GridView ID="gvSubForm_K" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSubForm_K_RowDataBound" ShowFooter="true" CssClass="sGrid" Width="100%">
                                    <Columns>
                                        <asp:BoundField HeaderText="ক্রমিক নং" DataField="sl_no" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="সরবরাহকারী বিআইএন নম্বর" DataField="party_bin" />
                                        <asp:BoundField HeaderText="সরবরাহকারীর নাম" DataField="party_name" />
                                        <asp:BoundField HeaderText="সরবরাহকারীর ঠিকানা" DataField="party_address" FooterText="Total"/>
                                        <asp:BoundField HeaderText="সরবরাহ মূল্য" DataField="price" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField HeaderText="কর্তিত মূল্য সংযোজন কর" DataField="Vat" DataFormatString="{0:#,#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField HeaderText="ইনভয়েস নং (চালান পত্র/বিল নম্বর ইত্যাদি)" DataField="challan_no" />
                                        <asp:BoundField HeaderText="ইনভয়েস/চালান/বিল তারিখ" DataField="date_challan" />

                                        <asp:BoundField HeaderText="উৎসে কর্তন সার্টিফিকেট নং" DataField="vds_cert_issued_no" />
                                        <asp:BoundField HeaderText="উৎসে কর্তন সার্টিফিকেট তারিখ" DataField="vds_cert_issued_date" ItemStyle-HorizontalAlign="Center" />

                                        <asp:BoundField HeaderText="একাউন্ট কোড কর পরিশোধিত" DataField="account_code" />
                                        
                                        <asp:BoundField HeaderText="ট্যাক্স ডিপোজিট বুক ট্রান্সফার সিরিয়াল নং" DataField="tax_deposit_serial_no" />
                                        <asp:BoundField HeaderText="ট্যাক্স ডিপোজিট তারিখ" DataField="vds_cert_issued_date" />

                                        <asp:BoundField HeaderText="মন্তব্য" DataField="remarks" />
                                        <asp:BoundField HeaderText="মন্তব্য" DataField="price1" DataFormatString="{0:#,#0.00}" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" FooterStyle-CssClass="hiddencol" />
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <FooterStyle  HorizontalAlign="Right"/>
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>--%>
        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                               <%--<table border="1" class="table" style="width: 100%; border-collapse: collapse">--%>
                                       <table class="allSolid" style="font-size:11px; width:100%; border-collapse: collapse;">
                                        <thead>
                                            <tr  style="border: 2px solid;">
                                               <th>ক্রমিক নং</th>                                                
                                                <th>সরবরাহকারী বিআইএন নম্বর</th>
                                                <th>সরবরাহকারীর নাম</th>
                                                <th>সরবরাহকারীর ঠিকানা</th>
                                                <th>সরবরাহ মূল্য</th>
                                                <th>কর্তিত মূল্য সংযোজন কর</th>                                               
                                                <th>ইনভয়েস নং (চালান পত্র/বিল নম্বর ইত্যাদি)</th>
                                                <th>ইনভয়েস/চালান/বিল তারিখ</th>
                                                 <th>উৎসে কর্তন সার্টিফিকেট নং</th>
                                                <th>উৎসে কর্তন সার্টিফিকেট তারিখ</th>
                                                <th>একাউন্ট কোড কর পরিশোধিত</th>
                                                <th>ট্যাক্স ডিপোজিট বুক ট্রান্সফার সিরিয়াল নং</th>
                                                <th>ট্যাক্স ডিপোজিট তারিখ</th>
                                                 <th style="width:60px;">মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody>                                          
                                            <tr>
                                                <asp:Label runat="server" ID="lblReportHtml" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                      
                       </div>
        <div style="text-align:right">

              <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="return PrintPanel();" style="background-color:#65C2DD;"><i class="fa fa-print"></i>  Print</asp:LinkButton>
        </div>

    </div>
</asp:Content>