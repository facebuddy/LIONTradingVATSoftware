<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_SubForms_Subform_Note_31, App_Web_zkqczdrh" %>


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
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;text-align:center;}table.allSolid td { border: 1.5px solid black;} p.printHeader{font-size:16px;}</style>');
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
        
        p.printHeader{font-size:14px;}

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="float:right">
         <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
    </div>
    <div id="reportMain" class="container-fluid" style="padding: 2%;" runat="server" visible="true">
        <div class="row">
           <%-- <p class="printHeader" style="text-align: center;font-weight:bold;">Details of Note 27</p>--%>
             <p class="printHeader" style="text-align: center;font-weight:bold;">ক্রেডিট নোট্ ইস্যুর জন্য (নোট-৩১)</p>
              <hr />
        </div>
       
 <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <%--<table border="1" class="table" style="width: 100%; border-collapse: collapse">--%>
                                       <table class="allSolid" style="font-size:11px; width:100%; border-collapse: collapse;">
                                        <thead>
                                            <tr  style="border: 2px solid;">

                                                <th>ক্রমিক নং</th>
                                                <th>ক্রেডিট নোট নং</th>
                                                <th>ইস্যু তারিখ</th>
                                                <th>ভ্যাট চালান নং</th>                                                
                                                <th>ভ্যাট চালান তারিখ</th>
                                                <th>হ্রাসকারী সমন্বয়ের সহিত মূল্য</th>
                                                <th>হ্রাসকারী সমন্বয়ের সহিত পরিমান</th>
                                                <th>হ্রাসকারী সমন্বয়ের সহিত মূল্য সংযোজন কর</th>
                                                <th>হ্রাসকারী সমন্বয়ের সহিত সম্পূরক শুল্ক</th>
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
    </div>
</asp:Content>

