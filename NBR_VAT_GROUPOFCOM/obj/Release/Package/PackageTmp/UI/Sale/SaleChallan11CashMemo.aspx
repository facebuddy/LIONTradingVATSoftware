<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Sale_SaleChallan11CashMemo, App_Web_lqwzozjx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style>
        .btn
            {
                padding:5px;
                margin:10px;
                text-decoration:none;
            }
            .btn-default
            {
                background:#ddd;
                color:#000;
            }
             .btn-danger
            {
                background:#F26363;
                color:#fff;
            }
            td{padding-right:15px;}
    </style>
     <style media="print">
            .noPrint{ display: none;}
            @media print { table{width:100%;} tr,td {padding:5px;}
            .full_width{
                width: 100%;
            }
            } 
            .yesPrint{ display: block !important; }
            input[type=text],select,textarea,.text_box
            {
                border:none;
            }
            
        </style>

         <script type="text/javascript">
             function PrintPanel() {
                 var panel = document.getElementById("<%=pnlContents.ClientID %>");
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:Panel ID="pnlContents" runat="server">
    <div>
        <asp:Literal ID="ltChallanDetail" runat="server"></asp:Literal>
        <asp:Literal ID="ltChallanProductDetail" runat="server"></asp:Literal>
        
        <br/>
        
        
    </div>
    </asp:Panel>
<%--    <center><a href="SaleChallan_11.aspx" class="btn btn-default noPrint">Back</a> 
    <a href="#" onclick="window.print(); return false;"  data-toggle="tooltip" title="Print Page" class="btn btn-danger noPrint"><i class="fa fa-print"></i> Print</a>
          </center>--%>
          <div style = "text-align:center; margin-top: 0px; width:100%">
              <asp:Button ID="btnPrint" runat="server"  class="btn btn-danger noPrint" Text="Print" onclientclick="return PrintPanel();"/>
          <%--<asp:Button ID="btnPrint" runat="server"  class="btn btn-danger noPrint" Text="Print" OnClick="btnPrint_Click" />--%>
          </div>
</asp:Content>

