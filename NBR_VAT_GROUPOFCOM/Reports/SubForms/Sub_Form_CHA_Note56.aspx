<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_SubForms_Sub_Form_Note55, App_Web_lb3hvxkt" %>

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
            <p style="text-align: center;font-weight:bold;font-size:14px;">
              অর্থদণ্ড ও জরিমানা (নোট-৬০) সাবফর্ম-ছ
            </p>
            <hr />
        </div>

      <%--   <div class="gridDiv table-responsive paddingsmall">  
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
                                    <HeaderStyle Height="25px" />
                                   <FooterStyle  HorizontalAlign="Right"/>
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>--%>
         <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>ট্রেজারি চালান নম্বর</th>
                                                <th>ব্যাংক</th>
                                                <th>শাখা</th>
                                                <th>তারিখ</th>
                                                <th>একাউন্ট কোড কর পরিশোধিত</th>                                               
                                                <th>পরিমান</th>
                                                <th>মন্তব্য</th>
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
      <%--  <div class="table table-bordered">
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th style="text-align: center; background-color: #ffbb99">ট্রেজারি চালান নম্বর</th>
                    <th style="text-align: center; background-color: #ffbb99">ব্যাংক</th>
                    <th style="text-align: center; background-color: #ffbb99">শাখা</th>
                    <th style="text-align: center; background-color: #ffbb99">তারিখ </th>                   
                    <th style="text-align: center; background-color: #ffbb99">একাউন্ট কোড  কর পরিশোধিত</th>                   
                    <th style="text-align: center; background-color: #ffbb99">পরিমান</th>                   
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
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
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
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                   
                </tr>
            </table>
        </div>--%>
    </div>
</asp:Content>
