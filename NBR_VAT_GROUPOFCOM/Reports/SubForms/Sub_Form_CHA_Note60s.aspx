
<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Sub_Form_CHA_Note60s.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.SubForms.Sub_Form_CHA_Note60s" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=reportMain.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;text-align:center;}table.allSolid td { border: 1.5px solid black;}</style>');
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
        
        table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;text-align:center;}
        table.allSolid td { border: 1.5px solid black;}

    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
     <div style="float:right">
         <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
    </div>
    <div id="reportMain" class="container-fluid" style="padding: 2%;" runat="server" visible="true">
        <div class="row">
            <p style="text-align: center;font-weight:bold;font-size:14px;">
              স্বাস্থ্য সুরক্ষা সারচার্জ নোট(৬৩)
            </p>
            <hr />
        </div>

        <%-- <div class="gridDiv table-responsive paddingsmall">  
                                <asp:GridView ID="gvSubForm_CHA" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSubForm_CHA_RowDataBound" ShowFooter="true" CssClass="sGrid" Width="100%">
                                    <Columns>
                                        <asp:BoundField HeaderText="ক্রমিক নং" DataField="sl_no" /> 
                                        <asp:BoundField HeaderText="ট্রেজারি চালান নম্বর" DataField="tr_challan_no" />
                                        <asp:BoundField HeaderText="ব্যাংক" DataField="bank_name" />
                                        <asp:BoundField HeaderText="শাখা" DataField="branch_name"  FooterText="মোট"/>
                                        <asp:BoundField HeaderText="তারিখ" DataField="date_challan" DataFormatString="{0:dd/MM/yyyy}"/>
                                        <asp:BoundField HeaderText="একাউন্ট কোড কর পরিশোধিত" DataField="code_no" />
                                        <asp:BoundField HeaderText="পরিমান" DataField="amount" DataFormatString="{0:#,#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField HeaderText="মন্তব্য" DataField="remarks"/>
                                    </Columns>
                                    <FooterStyle  HorizontalAlign="Right"/>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>--%>
      <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <%--<table border="1" class="table" style="width: 100%; border-collapse: collapse">--%>
                                       <table class="allSolid" style="font-size:11px; width:100%; border-collapse: collapse;">
                                        <thead>
                                            <tr  style="border: 2px solid;">
                                               
                                               <%-- <th>ক্রমিক নং</th>                                                
                                                <th>ট্রেজারি চালান নম্বর</th>
                                                <th>ব্যাংক</th>
                                                <th>শাখা</th>
                                                <th>তারিখ</th>
                                                <th>একাউন্ট কোড কর পরিশোধিত</th>                                               
                                                <th>পরিমাণ</th>
                                                <th style="min-width:60px;">মন্তব্য</th>--%>

                                                <th>ক্রমিক নং</th>                                                
                                                <th>ট্রেজারি চালান নম্বর/টোকেন নম্বর</th>
                                                <th>ব্যাংক/সিজিএ</th>
                                                <th>শাখা/সিএএফও</th>
                                                <th>তারিখ</th>
                                                <th>একাউন্ট কোড কর পরিশোধিত</th>                                               
                                                <th>পরিমাণ</th>
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
    </div>
</asp:Content>
