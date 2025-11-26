<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_QuantityWiseSaleReport, App_Web_o1josinq" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=rptPrint.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
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
        <div class="panel-group">
            <div class="panel panel-primary">
        
         <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold;
                    height: 30px; padding-top: 0px">
                   Sale Sub Report</div>
        
       
  
        <div class="container-fluid">
                
                     
            <div class="panel panel-body">
                           <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">পণ্যের নাম :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date From :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="dtpDateFrom" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date To :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="dtpDateTo" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                </div>
                           <div class="row">
                                <div class="col-md-12" style="text-align:right;margin-top:10px">
                                    <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox> 
                                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="showReport_OnClick" ><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                                </div>
                            </div>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator>
                        </div>
            
    
          <div class="col-md-12" runat="Server" id="rptPrint">
                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                  <%-- <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse">--%>
                                       <table class="allSolid" style="font-size:11px; width:100%; border-collapse: collapse;">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>পণ্য/সেবার নাম</th>
                                                <th>পণ্য/সেবার কোড</th>
                                                <th>পণ্য/সেবার সংখ্যা</th>
                                                <th>মূল্য (ক)</th>
                                                <th>সম্পূরক শুল্ক (খ)</th>                                               
                                                <th>মূল্য সংযোজন কর (গ)</th>
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

    </div>
            </div>
        </div>
</asp:Content>