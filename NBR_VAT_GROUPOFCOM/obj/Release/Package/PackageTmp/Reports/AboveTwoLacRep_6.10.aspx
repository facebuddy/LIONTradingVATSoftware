<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="AboveTwoLacRep_6_10, App_Web_y1tsx4fu" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<%@ Register assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <style type="text/css">
        .style2
        {
            width: 16%;
        }
        .style3
        {
            width: 15%;
        }
        
       table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;}
        table.allSolid td { border: 1.5px solid black;}
        
    </style>

    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=cnPrint.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;font-size:smaller;} table.allSolid th { border: 1.5px solid black;font-size:smaller;} table.allSolid td { border: 1.5px solid black;}</style>');
            //            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            //printWindow.document.write('</head>');
            //printWindow.document.write('<body style="margin: 50px;font-family: "Times New Roman", Times, serif; font-size:smaller">');
            printWindow.document.write('</head><body style="margin:50px;font-family: Times New Roman, Times, serif;font-size:smaller;">');
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
    <%--<script type="text/javascript">
        $(function () {
            $("#txtFormDate").datepicker();
        });

        function addVat(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

//            var presentValue = document.getElementById("<%=txtAmount.ClientID%>").value;
//            if (presentValue == "") {
//                presentValue = 0;
//            }
//            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvChallanItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

//            document.getElementById("<%=txtAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
//            document.getElementById("<%=txtAmount.ClientID%>").style.background = "#cfc";


        }

        function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvChallanItem.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked != IsChecked) {
                        items[i].click();
                    }
                }
            }

        }


        function clearChkBox(radioBtnNonChallan) {

            var isRadioBtnNonChallan = radioBtnNonChallan.checked;

            var jsGvItem = document.getElementById("<%=gvChallanItem.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked == isRadioBtnNonChallan) {
                        items[i].click();
                    }
                }
            }

        }

        function calledFn() {
            alert("code fired");
        }

    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div class="container-fluid">
    <div class="panel-group">
      <div class="panel panel-primary">
        <div class="panel-heading" style="text-align:center;  font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">দুই লক্ষ টাকার বেশি মূল্য মানের ক্রয়-বিক্রয় চালানপত্রের তথ্য (মূসক-৬.১০)</div>
          <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
            <div class="row" style="margin-top:1%">
            <div class="col-sm-6">
                <fieldset class="scheduler-border-report" style="margin:-9px; padding:0em">
                <legend title="" class="scheduler-border-report">কর মেয়াদ</legend>
                <div class="col-sm-6" style="padding:0px">
                 <asp:Label ID="Label2" runat="server" style="margin-top:3px" Text="Date From:" class="present-address-lbl"></asp:Label>
                     <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateFrom" DateFormat="dd/MM/yyyy" />
                     <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom" />

                 <%--<ww:jQueryDatePicker ID="dtpDateFrom" style="width:50%;" runat="server" class="present-address-tb" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>--%>
               </div>
               <div class="col-sm-6" style="padding:0px">
                 <asp:Label ID="Label1" runat="server" style="margin-top:3px" Text="Date To:" class="present-address-lbl"></asp:Label>
                     <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateTo" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                 <%--<ww:jQueryDatePicker ID="dtpDateTo" style="width:50%;" runat="server" class="present-address-tb" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>--%>
               </div>
              </fieldset>
            </div>
               <div class="col-sm-3" style="padding:0px">
                 <asp:Label ID="Label3" runat="server" style="margin-top:4px" class="present-address-lbl" Text="Challan Number:"/>
                 <asp:TextBox runat="server" ID="txtChallanNumber" Width="150px" class="present-address-tb"></asp:TextBox>
                   </div>
                 <div class="col-sm-3">
                     
                            <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                      
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator>
                   
               </div> 
               <div class="col-sm-12" style="text-align:right">
                <%-- <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" CssClass="button" />--%>
                 <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show Report" CssClass="btn btn-success btn-sm" />
             <%--  <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show Report" CssClass="btn btn-success btn-sm"> <i class="fa fa-search-plus"></i></asp:Button>--%>
         <%--<asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnShow_Click"><i class="fa fa-search-plus"></i>  Report</asp:LinkButton>--%>
               
               </div>      
            </div>
      <div class="row" style="margin-top:1%"  runat="server" >
      
       <div class="panel-heading" runat="server" visible="false" id="purchase" style="text-align:center; font-size:14px; font-weight:bold; height:20px; padding-top:0px">ক্রয় হিসাব তথ্য</div>
        <div class="panel-body">
             <div class="" runat="server" id="gridviewPurchase" visible="true">
                <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    DataKeyNames="RowId" Width="100%" OnRowDeleting="gvItem_RowDeleting" 
                     ShowHeaderWhenEmpty="True" BackColor="#DEBA84" BorderColor="#DEBA84" 
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:BoundField HeaderText="Trns Type" DataField="TrnsType" />
                        <asp:BoundField HeaderText="Vat Type" DataField="VatType" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Challan No" DataField="ChallanNo" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderText="Date" DataField="Date" />
                        <asp:BoundField HeaderText="BIN" DataField="Bin" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" 
                        ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
            </div>
        </div>
    
   </div>
   <div class="row" style="margin-top:1%" >
      
       <div class="panel-heading" runat="server" visible="false" id="sale" style="text-align:center; font-size:14px; font-weight:bold; height:20px; padding-top:0px">বিক্রয় হিসাব তথ্য</div>
        <div class="panel-body">
             <div class="" runat="server" id="gridviewSale"  visible="true">
                <asp:GridView ID="gvSale" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    DataKeyNames="RowId" Width="100%" OnRowDeleting="gvItem_RowDeleting" 
                     ShowHeaderWhenEmpty="True" BackColor="#DEBA84" BorderColor="#DEBA84" 
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:BoundField HeaderText="Trns Type" DataField="TrnsType" />
                        <asp:BoundField HeaderText="Vat Type" DataField="VatType" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Challan No" DataField="ChallanNo" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderText="Date" DataField="Date" />
                        <asp:BoundField HeaderText="BIN" DataField="Bin" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" 
                        ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
            </div>
        </div>
    
   </div>   
  </div>
 </div>
          
        
      <div id="cnPrint" class="container-fluid" style="margin-top:1%; margin-left:5%;margin-right:5%;font-family:Nikosh" runat="server" visible="false">
        <div class="row" style="margin-top:1%">
            
          <div class="row" >
              
              <%--<img src="../../Images/bdlogo.png" style="height:50px;margin-left:80px;" />
              <p style="text-align:right; padding:5px"><b style="border:1px solid gray;margin-right: 17px;">ফরম ৬.১০</b></p>
                <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
               <p style="text-align:center">জাতীয় রাজস্ব বোর্ড</p>              
               <p style="text-align:center;"><strong>২ (দুই) লক্ষ টাকার বেশি মূল্য মানের ক্রয়-বিক্রয় চালান পত্রের তথ্য</strong></p>
               <p style="text-align:center">[বিধি ৪২ এর উপ-বিধি (১) দ্রষ্টব্য]</p>--%>

              <table style="border:none;width: 100%;">
                               <tr>
                                   <td> <img src="../../Images/bdlogo.png" style="height:50px;margin-left:80px;" /> </td>
                                   <%--<td style="padding-right:50px;">--%>
                                   <td>
                                         <p style="text-align:center; font-size:12px; margin:2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                                         <p style="text-align:center; font-size:12px; margin:2px;">জাতীয় রাজস্ব বোর্ড</p>      
                                         <p style="text-align:center;font-size:12px; margin:2px;"><strong>(দুই) লক্ষ টাকার বেশি মূল্য মানের ক্রয়-বিক্রয় চালান পত্রের তথ্য</strong></p>
                                         <p style="text-align:center;font-size:12px; margin:2px;">[বিধি ৪২ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
                                   </td>

                                   <td>
                                        <p style="text-align:right;">
                                        <b style="border:1px solid gray; margin-right: 17px;">&nbsp&nbsp মূসক- ৬.১০ &nbsp&nbsp</b></p> 
                                   </td>
                               </tr>

                  
                           </table> 
              <br />

               <p style="text-align:left;margin-left:14px;font-size:12px;">নিবন্ধিত/তালিকাভুক্ত ব্যক্তির নামঃ&nbsp <asp:Label runat="server" ID="lblPersonName" style="width:150px"></asp:Label></p> 
                 <p style="text-align:left;margin-left:14px;font-size:12px;">   বিআইএনঃ &nbsp&nbsp<asp:Label runat="server" ID="lblBIN" style="width:150px"></asp:Label></p>
              
         </div>      
            </div>
          <div >
            <div class="row" style="margin-top:1%;font-size:12px;">
                <p style="margin-left:0;"><strong>অংশ কঃ  ক্রয় হিসাব তথ্য</strong></p>
                <%--<table border="1" style="width:100%; text-align:center">--%>
                 <table border="1" class="allSolid" style="width: 100%; border-collapse: collapse">
                    <tr>
                      <th rowspan="2" style="text-align:center">ক্রমিক নং</th>
                      <th colspan="6" style="text-align:center">ক্রয়</th>
                    </tr>
                    <tr>
                      <th style="text-align:center;">চালানপত্র নং</th>
                      <th style="text-align:center;">ইস্যুর তারিখ</th>
                      <th style="text-align:center;">মূল্য </th>
                      <th style="text-align:center;"> বিক্রেতার নাম</th>
                      <th style="text-align:center;"> বিক্রেতার ঠিকানা</th>
                      <th style="text-align:center;">বিক্রেতার বিআইএন/জাতীয় পরিচয়পত্র নং*</th>
                    </tr>
                    <tr>
                      <th style="text-align:center;">(১)</th>
                      <th style="text-align:center;">(২)</th>
                      <th style="text-align:center;">(৩)</th>
                      <th style="text-align:center;">(৪)</th>
                      <th style="text-align:center;">(৫)</th>
                      <th style="text-align:center;">(৬)</th>
                      <th style="text-align:center;">(৭)</th>
                    </tr>
                    <tr>
                      <asp:Label runat="server" ID="lblPurchase"></asp:Label>
                    </tr>
                    <tr>
                    <asp:Label runat="server" ID="lblPurchaseReport"></asp:Label>
                    </tr>
                </table>
            </div>
              </div>
            <div class="row" style="margin-top:1%;font-size:12px;">
                <p style="margin-left:0;"><strong>অংশ খঃ  বিক্রয় হিসাব তথ্য</strong></p>
                <%--<table border="1" style="width:100%;text-align:center">--%>
                <table border="1" class="allSolid" style="width: 100%; border-collapse: collapse">
                    <tr>
                      <th rowspan="2" style="text-align:center">ক্রমিক নং</th>
                      <th colspan="6" style="text-align:center">বিক্রয়</th>
                    </tr>
                    <tr>
                      <th style="text-align:center;">চালানপত্র নং</th>
                      <th style="text-align:center;">ইস্যুর তারিখ</th>
                      <th style="text-align:center;">মূল্য </th>
                      <th style="text-align:center;"> ক্রেতার নাম</th>
                      <th style="text-align:center;"> ক্রেতার ঠিকানা</th>
                      <th style="text-align:center;">ক্রেতার বিআইএন/জাতীয় পরিচয়পত্র নং*</th>
                    </tr>
                    <tr>
                      <th style="text-align:center;">(১)</th>
                      <th style="text-align:center;">(২)</th>
                      <th style="text-align:center;">(৩)</th>
                      <th style="text-align:center;">(৪)</th>
                      <th style="text-align:center;">(৫)</th>
                        <th style="text-align:center;">(৬)</th>
                      <th style="text-align:center;">(৭)</th>
                    </tr>
                    <tr>
                       <asp:Label runat="server" ID="lblSale"></asp:Label>
                    </tr>
                </table>
            </div>
            <div class="row" style="margin-top:2%;">
             <p style="margin-left:0;font-size:11px;">দায়িত্ব প্রাপ্ত ব্যক্তির স্বাক্ষরঃ</p> 
             <p style="margin-left:0;font-size:11px;"> নামঃ&nbsp&nbsp<asp:Label runat="server" ID="emp_name"/></p>                          
             <p  style="margin-left:0;font-size:11px;">তারিখঃ&nbsp&nbsp<asp:Label runat="server" ID="date"/></p>
            </div>
            <div class="row" style="margin-top:2%">             
              <p style="margin-left: 0px;"><strong>*যেইক্ষেত্রে অনিবন্ধিত ব্যক্তির নিকট হইতে পণ্য/সেবা ক্রয় করা হইবে বা অনিবন্ধিত ব্যক্তির নিকট হইতে পণ্য সেবা বিক্রয় করা হইবে,সেইক্ষেত্রে উক্ত ব্যক্তির পূর্ণাঙ্গ নাম,ঠিকানা ও জাতীয় পরিচয়পত্র  নম্বর যথাযথভাবে সংশ্লিষ্ট কলামে[(৭),(৮) ও (৯)] আবশ্যিকভাবে উল্লেখ করিতে হইবে</strong></p>
            </div>

              <div class="col-md-12" style="margin-top: 5px;border-top:solid;border-width: thin;"></div>
                 <div class="col-md-12" style="margin-top: 5px;">
                     <sup>১</sup> এসআরও নং-১৭১-আইন/২০১৯/২৮-মূসক, তারিখঃ১৩ জুন,২০১৯ দ্বারা প্রতিস্থাপিত।

                     </div>
           <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
              </div>
          
        </div>
           <asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" style="float:right" Text="Print" OnClientClick="return PrintPanel();" Visible="false"/>
        </div>
</asp:Content>