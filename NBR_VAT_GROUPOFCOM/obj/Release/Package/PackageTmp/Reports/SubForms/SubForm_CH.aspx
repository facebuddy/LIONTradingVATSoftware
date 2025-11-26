<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_SubForms_SubForm_CH, App_Web_lb3hvxkt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="reportMain" class="container-fluid" style="padding: 2%;" runat="server" visible="true">
        <div class="row">
            <p style="text-align: center;font-weight:bold;font-size:14px;">
                আমদানি পর্যায়ে প্রদেয় আগাম কর (নোট-৩০)
            </p>
            <hr />
        </div>
        <%--<div class="table table-bordered">
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th style="text-align: center; background-color: #ffbb99">বিল অব এন্ট্রি নম্বর</th>
                    <th style="text-align: center; background-color: #ffbb99">তারিখ</th>
                    <th style="text-align: center; background-color: #ffbb99">কাস্টম হাউস/শুল্ক স্টেশন</th>
                    <th style="text-align: center; background-color: #ffbb99">আগাম করের পরিমাণ</th>                   
                    <th style="text-align: center; background-color: #ffbb99">মন্তব্য </th>
                </tr>
                <tr>
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
                    
                </tr>
                <tr>
                    
                    <td style="text-align:center">
                        মোট 
                    </td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                   
                </tr>
            </table>
        </div>--%>

       <%-- <div class="panel-body">
                            <div class="gridDiv table-responsive paddingsmall">  
                                <asp:GridView ID="gvSubForm_K" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSubForm_K_RowDataBound" ShowFooter="true" CssClass="sGrid" Width="100%">
                                    <Columns>
                                        <asp:BoundField HeaderText="ক্রমিক নং" DataField="sl_no" /> 
                                        <asp:BoundField HeaderText="বিল অব এন্ট্রি নম্বর" DataField="challan_no" />
                                        <asp:BoundField HeaderText="তারিখ" DataField="date_challan" />
                                        <asp:BoundField HeaderText="কাস্টম হাউস/কাস্টমস স্টেশন" DataField="custom_house"  FooterText="মোট"/>
                                        <asp:BoundField HeaderText="আগাম করের পরিমাণ" DataField="at" DataFormatString="{0:#,#0.00}" ItemStyle-HorizontalAlign="Right"/>                                        
                                        <asp:BoundField HeaderText="মন্তব্য" DataField="remarks" />
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <FooterStyle  HorizontalAlign="Right"/>
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
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
                                                <th>বিল অব এন্ট্রি নম্বর</th>
                                                <th>তারিখ</th>
                                                <th>কাস্টম হাউস/কাস্টমস স্টেশন</th>
                                                <th>আগাম করের পরিমাণ</th>                                            
                                                <th style="min-width:60px;">মন্তব্য</th>
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

