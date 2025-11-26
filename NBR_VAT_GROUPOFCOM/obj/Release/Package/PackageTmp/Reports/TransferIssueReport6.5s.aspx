<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="TransferIssueReport6.5s.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.TransferIssueReport6__5s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
     <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=ptPrint.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            //printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head>');
            printWindow.document.write('<body style="margin: 50px;font-family: "Times New Roman", Times, serif; font-size:16px">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
     </script>
    <style>
        .hiddencol{
            display:none;
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

     <div class="container-fluid" style="padding-right:0%; padding-left:0%">
      <div class="panel-group">
        <div class="panel panel-primary">
           <div class="panel-heading" style="text-align:center; font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">
               <%--Issue/পণ্য স্থানান্তর চালানপত্র--%>
                  Issue / কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র (মুসক-৬.৫)
           </div>
            
            <div class="panel-body" style="padding-top:0px; padding-bottom:2px;padding-right:2px">
                <div class="row" style="margin-top:5px;">
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>প্রেরণকারী শাখার নাম :</label>
                            <div class="col-sm-7 m">
                                <asp:DropDownList ID="drpProviderBranch" runat="server" class="form-control" 
                                    AutoPostBack="True" OnSelectedIndexChanged="drpProviderBranch_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                       <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>গ্রহীতা শাখার নাম :</label>
                            <div class="col-sm-7 m">
                                <asp:DropDownList ID="drpReceipentBranch" runat="server" class="form-control" 
                                    AutoPostBack="True" OnSelectedIndexChanged="drpReceipentBranch_SelectedIndexChanged"></asp:DropDownList>
                    
                            </div>
                        </div>
                    </div>
                     <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>চালান নম্বর :</label>
                            <div class="col-sm-7 m">
                                 <asp:DropDownList ID="drpChallanNo" runat="server" class="form-control"></asp:DropDownList>
                            
                            </div>
                        </div>
                    </div>
                   
                </div>
                <div class="row hiddencol">
                 
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">গ্রহীতা শাখার ঠিকানা :</label>
                            <div class="col-sm-7 m">
                               <asp:TextBox ID="txtReceipentAddress" runat="server" 
                                   CssClass="form-control" placeholder="গ্রহীতা শাখার ঠিকানা লিখুন " ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">বিআইএন :</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox ID="txtReceipentBIN" ReadOnly="true" runat="server" CssClass="form-control" placeholder="গ্রহীতা শাখার বিআইএন লিখুন "></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">প্রেরণকারী শাখার ঠিকানা :</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox ID="txtProviderAddress" runat="server" CssClass="form-control"  ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">বিআইএন :</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox ID="txtProviderBIN" ReadOnly="true"  runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                   
               <div class="col-md-12" style="text-align:right">

                    <asp:Button ID="btnShowReport" style="background-color:#5CB85C;margin-top:15px;" runat="server" class="btn-btn" OnClick="btnShowReport_OnClick" Text="Show Report" />
                     <asp:Button runat="server" style="background-color:#5bc0de;" CssClass="btn-btn" Text="Print" ID="btnPrint" OnClientClick="return PrintPanel()" />
               </div>
                </div>
                   </div>
            </div>
          </div>
         </div>
 <div class="container-fluid" id="ptPrint" runat="server" style="font-family:Nikosh">
     <div class="row"  style="font-size:16px">
       <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
       <p style="text-align:center">জাতীয় রাজস্ব বোর্ড</p>
       <p style="text-align:right;"><strong style="border:1px solid gray;font-size:20px">মূসক-৬.৫</strong></p>
       <%--<p style="text-align:center">পণ্য স্থানান্তর চালানপত্র </p>--%>
         <p style="text-align:center;font-size:20px">কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র </p>
       <p style="text-align:center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (ঙ) দ্রষ্টব্য]</p>
     </div>
       <div style="font-size:12px">
       <div class="row" style="height:10px;"></div>
     <div class="row">
       <p>নিবন্ধিত ব্যক্তির নামঃ  <asp:Label runat="server" ID="lblOrgName" /></p>
       <p>নিবন্ধিত ব্যক্তির বিআইএনঃ  <asp:Label runat="server" ID="lblOrgBIN" /></p>
       <%--<p style="margin-left:35%">প্রেরণকারী শাখার নাম ও ঠিকানাঃ  <asp:Label runat="server" ID="lblPNameAddress" /></p>--%>
        <p>প্রেরণকারী শাখা/পণ্যাগারের নাম ও ঠিকানাঃ  <asp:Label runat="server" ID="lblPNameAddress" /></p>
       
     </div>
        <div class="row" style="height:10px;"></div>
        <div class="row">
            <p>গ্রহীতা শাখা/পণ্যাগারের নাম ও ঠিকানাঃ  <asp:Label runat="server" ID="lblReceipentAddress" /></p>
        </div>
         <div class="row" style="height:10px;"></div>
     <div class="row" style="width:100%; height:0px;">
       <div class="col-sm-6" style="width:50%; height:150px; float:left">
        <%-- <p>গ্রহীতার শাখার নামঃ  <asp:Label runat="server" ID="lblReceipentName" /></p>
          <p>গ্রহীতা শাখার ঠিকানাঃ  <asp:Label runat="server" ID="lblReceipentAddress" /></p>--%>
       </div>
       <div class="col-sm-6" style="width:49%; float:left">
          <p>চালানপত্রের নম্বর:  <asp:Label runat="server" ID="lblChallanNo" /></p>
          <p>ইস্যুর তারিখ:  <asp:Label runat="server" ID="lblIssueDate" /></p>
          <p>ইস্যুর সময়:  <asp:Label runat="server" ID="lblIssueTime" /></p>
            <p>যানবাহনের প্রকৃতি ও নম্বর:  <asp:Label runat="server" ID="txtTransport" /></p>
       </div>
     </div>
     <div>
       <table class="table table-bordered" style="background:none; border-collapse:collapse; width:100%">
         <tr>
           <td style="border:1px solid gray; width:5%; text-align: center;">ক্রমিক নং</td>
           <td style="border:1px solid gray; width:30%; text-align: center;">পণ্যের(প্রযোজ্য ক্ষেত্রে সুনির্দিষ্ট ব্র্যান্ড নামসহ) বর্ণনা
           </td>
           <td style="border:1px solid gray;width:15%; text-align: center;">পরিমাণ</td>
              <td style="border:1px solid gray;width:15%; text-align: center;">মূল্য</td>
             
           <td style="border:1px solid gray;width:20%; text-align: center;">মন্তব্য</td>
         </tr>
         <tr>
            <td style="border:1px solid gray; text-align: center;">(১)</td>
           <td style="border:1px solid gray; text-align: center;">(২)</td>
           <td style="border:1px solid gray; text-align: center;">(৩)</td>
           <td style="border:1px solid gray; text-align: center;">(৪)</td>
           <td style="border:1px solid gray; text-align: center;">(৫)</td>       
         </tr>
         <tr>
           <asp:Label runat="server" ID="tblProductTransferChallan"></asp:Label>
         </tr>
       </table>
     </div>
     <div>
       <%--<p style="margin-top:55px">দায়িত্ব প্রাপ্ত কর্মকর্তার স্বাক্ষর</p>--%>
       <p style="margin-top:55px">প্রতিষ্ঠান কর্তৃপক্ষের দায়িত্বপ্রাপ্ত ব্যাক্তির নাম : <asp:Label runat="server" ID="lblDutyOfficer"/></p> 
       <p>পদবী :  <asp:Label runat="server" ID="lblDutyOfficerDesignationName"/></p>
       <p> স্বাক্ষর:  <asp:Label runat="server" ID="Label2"/></p>
       <p> সিল:  <asp:Label runat="server" ID="Label3"/></p>
        
     </div>

             <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
   </div>
 
  
</div>
    

             
</asp:Content>