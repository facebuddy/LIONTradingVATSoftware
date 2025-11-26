<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Credit_Note_Form12_N, App_Web_y1tsx4fu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <%-- <link href="../../Styles/Main.css" rel="stylesheet" />--%>
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .test {
            width: 183px;
        }
          .bb
        {
            border-bottom: solid 1px black;
        }
          .hiddencol{
              display:none;
          }
    </style>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
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
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="upContent" runat="server">
        <ContentTemplate>
            <div class="panel panel-group">
                <div class="panel panel-primary panel-primary-custom">
                    <%--<div class="panel-heading" style="text-align: center; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">ডেবিট নোট (মূসক-১২ক)</div>--%>
                     <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 25px; padding-top: 0px">ক্রেডিট নোট (মূসক-৬.৭)</div>
                          <div class="panel-body">
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                  <div class="row">
                            <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateFrom" style="font-size:11pt" AutoPostBack="True" OnTextChanged="FromDateChangedGetChallan" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateTo" style="font-size:11pt" AutoPostBack="True" OnTextChanged="ToDateChangedGetChallan" />
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                                </div>
                            </div>
                        </div>
                                 <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Customer Name :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlCustomer" CssClass="form-control select2" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                              </div>
                              <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Credit Challan No :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList runat="server" CssClass="form-control select2" ID="ddlChallanId" AutoPostBack="True" OnSelectedIndexChanged="ChallanNoSelectedIndexChanged" />
                                            </div>
                                        </div>
                                    </div>
                                   <div class="col-md-4">
                                  </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" OnClick="btnShow_OnClick"><i class="fa fa-search-plus"></i>  Report</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                                    <%--<asp:LinkButton ID="btnXMLFormat" runat="server" CssClass="btn btn-info" OnClick="btnXMLFormat_OnClick"><i class="fa fa-search-plus"></i>  XML Data</asp:LinkButton>--%>
                                </div>
                                   </div>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="precisionTxtBox" runat="server"
                                ErrorMessage="Precision has to be a number between 0 to 12"
                                ForeColor="Red"
                                ValidationExpression="\d+">
                            </asp:RegularExpressionValidator> 
                            </div>

                        </div>

                    </div>
                </div>
                <div class="panel panel-primary" style="font-family: Nikosh">
                    <div class="panel panel-body">
                        <div class="col-md-12">
                            <asp:Panel ID="pnlContents" runat="server">

                                <div class="row">
                                    
                                                <div style="font-size: 16px">
                                                    
                                                    
                                                    <p style="text-align: right; padding: 5px;">
                                                        <b style="border: 1px solid gray; margin-right: 17px;">মূসক-৬.৭</b>
                                                    </p>
                                                    <p style="text-align: center; font-size: 12px; margin: 2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                                                    <p style="text-align: center; font-size: 12px; margin: 2px;">জাতীয় রাজস্ব বোর্ড</p>
                                                    <p style="text-align: center; font-size: 12px; margin: 2px;"><strong>ক্রেডিট নোট</strong></p>
                                                    <p style="text-align: center; font-size: 12px; margin: 2px;">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (ছ)]</p>

                                                    
                                                    <div class="row" style="margin-top: 1%; font-size: 16px">
                                                        <table style="border: none; width: 100%">
                                                            <tr>
                                                                <th colspan="2" scope="colgroup" style="text-align: center; font-size: 14px; border: none"></th>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <img src="../../Images/bdlogo.png" style="height: 50px; margin-left: 80px; margin-top: -140px"></img>

                                                                </td>

                                                                <td></td>

                                                        </table>

                                                    </div>
                                                </div>

                                           
                                                
                                   </div>
                               
                                 <div style="font-size:12px">
                                <div class="col-sm-4" style="float: right;">
                                    <p style="margin: 2px;">
                                       ক্রেডিট নোট নম্বর: 
                                <asp:Label runat="server" ID="Challan_No" />
                                    </p>
                                    <p style="margin: 2px;">
                                        ইস্যুর তারিখঃ 
                                <asp:Label runat="server" ID="Challan_Date" />
                                    </p>
                                    <p style="margin: 2px;">
                                        ইস্যুর সময়ঃ 
                                <asp:Label runat="server" ID="Challan_Time" />
                                    </p>
                                </div>
                                <div class="row">

                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>নিবন্ধিত ব্যাক্তির নাম :
                                                  <asp:Label ID="provider_name" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>নিবন্ধিত ব্যক্তির বিআইএন  :
                                                  <asp:Label ID="provider_BIN" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>নিবন্ধিত ব্যক্তির ঠিকানা  :
                                                  <asp:Label ID="provider_address" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                 <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>ক্রেতা/গ্রহীতার নাম  :
                                               <asp:Label ID="receiver_name" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                       
                                     <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>ক্রেতা/গ্রহীতার বিআইন   :
                                                 <asp:Label ID="receiver_BIN" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                           
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>ঠিকানা :
                                                 <asp:Label ID="receiver_address" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>           
                                         <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>যানবাহনের প্রকৃতি ও নম্বর :
                                                 <asp:Label ID="txtTransport" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>         
                                                <%-- commented onthe basis of  SRO-142 Publish Date: 11-June-2020--%>
                                                <%--  <tr style="background-color: White">

                                            <td style="width: 20%">মূল চালান নম্বর :</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="challan_no" runat="server" Text=""></asp:Label>
                                            </td>
                                              <td style="width: 20%">ক্রেডিট নোট নম্বর :</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="debit_no" runat="server" Text=""></asp:Label>
                                            </td>
                                            </tr>
                                        <tr>
                                              <td style="width: 20%">মূল চালান ইস্যুর তারিখ :</td>

                                            <td style="width: 29%">
                                                <asp:Label ID="challan_issue_date" runat="server"
                                                    Text=""></asp:Label>
                                            </td>
                                              <td style="width: 20%">ইস্যুর তারিখ :</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="receive_issue_date" runat="server" Text=""></asp:Label>
                                            </td>

                                        </tr>

                                         <tr style="background-color: White">
                                            <td style="width: 20%"></td>
                                            <td style="width: 30%">
                                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 20%">ইস্যুর সময় :</td>
                                            <td style="width: 30%">
                                                <asp:Label ID="issue_time" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>--%><%-- commented onthe basis of  SRO-142 Publish Date: 11-June-2020--%>
                                  
                                </div>
                                <table border="1" class="table" style="width: 100%; background-color: White; border-collapse: collapse">
                                    <thead>

                                        <tr>
                                           <%-- <th class="col_3_percent" style="font-weight: normal; text-align: center; border: 1px solid #000">ক্রমিক নং
                                            </th>
                                            <th  class="col_3_percent" style="font-weight: normal; text-align: center; border: 1px solid #000">ফেরতপ্রদত্ত সরবরাহের বিবরণ

                                            <th  style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">সরবরাহের একক
                                            </th>
                                            <th  style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">পরিমাণ 
                                            </th>
                                             <th  style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">একক মূল্য (টাকায়)<sup>১</sup>
                                            </th>
                                          <th style="font-weight: normal; text-align: center; border: 1px solid #000">মোট মূল্য (টাকায়)
                                            </th>--%>
                                             <th rowspan="2" class="col_3_percent" style="font-weight: normal; text-align: center; border: 1px solid #000">ক্রমিক নং
                                            </th>
                                            <th rowspan="2" class="col_3_percent" style="font-weight: normal; text-align: center; border: 1px solid #000">কর চালান পত্রের নম্বর ও তারিখ

                                            <th rowspan="2" style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">ক্রেডিট নোট ইস্যুর কারণ
                                            </th>
                                             <th  colspan="4" style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">চালানপত্রে উল্লিখিত সরবরাহের
                                            </th>
                                             <th  colspan="4" style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">হ্রাসকারী সমন্বয়ের সহিত সংশিষ্ট
                                            </th>
                                             </tr>
                                            <tr>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">মূল্য<sup>১</sup> </th>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">পরিমাণ </th>
                                                <th style="font-weight: normal; text-align: center; border: 1px solid #000">মূল্য সংযোজন করের পরিমাণ </th>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">সম্পূরক শুল্কের পরিমাণ </th>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">মূল্য<sup>১</sup> </th>
                                                <th style="font-weight: normal; text-align: center; border: 1px solid #000">পরিমাণ </th>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">মূল্য সংযোজন করের পরিমাণ </th>
                                                <th style="font-weight: normal; text-align: center; border: 1px solid #000">সম্বনয়যোগ্য সম্পূরক শুল্কের পরিমাণ </th>
                                        </tr>
                                                                                                                     

                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                            <td style="text-align: center">(৮)
                                            </td>
                                             <td style="text-align: center">(৯)
                                            </td>
                                            <td style="text-align: center">(১০)
                                            </td>
                                             <td style="text-align: center">(১১)
                                            </td>
                                        </tr>
                                        <tr>
                                            <asp:Label ID="debitNoteReport" runat="server" />
                                        </tr>
                                    </tbody>
                                </table>
                                <%--  <table  style="width: 100%; background-color: White;border-bottom:none;border-left:none;border-top:none" class="hiddencol">
                                    <tr>
                                        <td style="width: 50%;">

                                          
                                        </td>
                                        <td style="width: 50%;">

                                       <table border="1" style="border-left:none;border-bottom:none;border-top:none">
                                            
                                            <tr style="text-align:right;border-bottom:1px">
                                                 <td class="bb" style="width: 20%;">মোট মূল্য:</td>
                                       
                                            <td class="bb" style="width: 30%">
                                                <asp:Label ID="txttotal" runat="server" Text="" style="padding:3px"></asp:Label>
                                            </td>
                                                 <tr style="text-align:right">
                                          <td class="bb" style="width: 20%">বাদ কর্তন<sup>২</sup>:</td>

                                            <td class="bb" style="width: 30%">
                                                <asp:Label ID="txtotherdeduct" runat="server" Text="" style="padding:3px"></asp:Label>
                                            </td>  
                                         </tr>

                                             <tr style="text-align:right">
                                        
                                     <td style="width: 20%">মূসকসহ মূল্য:</td>

                                            <td class="bb" style="width: 30%">
                                                <asp:Label ID="txtVATtotal" runat="server" Text="" style="padding:3px"></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr style="text-align:right">
                                  
                                     <td style="width: 20%;">মূসকের পরিমাণ:</td>

                                            <td class="bb" style="width: 30%">
                                                <asp:Label ID="txtVAT" runat="server"  Text="" style="padding:3px"></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr style="text-align:right">
                                    
                                     <td style="width: 20%">সম্পূরক শুল্কের পরিমাণ:</td>

                                            <td  class="bb" style="width: 30%">
                                                <asp:Label ID="txtSD" runat="server" Text="" style="padding:3px"></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr style="text-align:right">
                                    
                                     <td  style="width: 20%">মোট কর<sup>৩</sup>:</td>

                                            <td class="bb" style="width: 30%">
                                                <asp:Label ID="txtTotalVATSD" runat="server" Text="" style="padding:3px"></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr>
                                            <asp:Label ID="debitTotal" runat="server" style="padding:3px"/>
                                        </tr>

                                         </table>
                                        </td>
                                    </tr>
                                  <%--  <tr style="text-align:right">
                                         <td></td>
                                      <td></td>
                                      <td></td>
                                      <td></td>
                                        <td style="width: 20%">মোট মূল্য:</td>
                                       
                                            <td style="width: 30%">
                                                <asp:Label ID="txttotal" runat="server" Text=""></asp:Label>
                                            </td>
                                     </tr>
                                     <tr style="text-align:right">
                                         <td></td>
                                      <td></td>
                                      <td></td>
                                      <td></td>
                                     <td style="width: 20%">বাদ কর্তন:</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="txtotherdeduct" runat="server" Text=""></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr style="text-align:right">
                                         <td></td>
                                      <td></td>
                                      <td></td>
                                      <td></td>
                                     <td style="width: 20%">মূসকসহ মূল্য:</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="txtVATtotal" runat="server" Text=""></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr style="text-align:right">
                                         <td></td>
                                      <td></td>
                                      <td></td>
                                      <td></td>
                                     <td style="width: 20%;">মূসকের পরিমাণ:</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="txtVAT" runat="server"  Text=""></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr style="text-align:right">
                                         <td></td>
                                      <td></td>
                                      <td></td>
                                      <td></td>
                                     <td style="width: 20%">সম্পূরক শুল্কের পরিমাণ:</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="txtSD" runat="server" Text=""></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr style="text-align:right">
                                         <td></td>
                                      <td></td>
                                      <td></td>
                                      <td></td>
                                     <td style="width: 20%">মোট কর:</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="txtTotalVATSD" runat="server" Text=""></asp:Label>
                                            </td>  
                                         </tr>
                                     <tr>
                                            <asp:Label ID="debitTotal" runat="server" />
                                        </tr>
                              
                                </table>--%>                            
                                
                                <div style="text-align:right;margin-right:100px;">
                                   <%-- <p>ফেরতের কারণ: <asp:TextBox ID="txtreason" runat="server" style="width:1200px"></asp:TextBox></p>--%>

                                    
                                   
                                     <p style="margin-top:15px;">দায়িত্ব প্রাপ্ত ব্যক্তির নাম:  <asp:Label style="font-size:11px;" runat="server" ID="lblDutyOfficerName"></asp:Label></p>
                                     <p style="margin-top:15px;">পদবি:    <asp:Label style="font-size:11px;" runat="server" ID="lblDutyOfficerDesignationName"></asp:Label></p>
                                     <p style="margin-top:15px;">সাক্ষর:   <asp:Label ID="Label3" runat="server"></asp:Label></p>
                                     <p style="margin-top:15px;">সিল:   <asp:Label ID="Label4" runat="server"></asp:Label></p>
                                     
                                 <br />
                                 <br />
                                 <br />  
                                 
                                    <%--<p> ১.প্রতি একক পণ্য/সেবার মূসক ও সম্পূরক শুল্কসহ মূল্য।  </p>
                                    <p>২.ফেরত প্রদানের জন্য কোনো ধরনের কর্তন থাকিলে উহার পরিমাণ। </p>
                                    <p>৩.মূসক ও সম্পূরক শুল্কের যোগফল/</p>--%>
                                </div>
                                <p>১পণ্য/সেবার মূসক ও সম্পূরক শুল্কসহ মূল্য।</p>
                                <div class="col-md-12" style="margin-top: 5px">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="System User: "></asp:Label>
                                        <asp:Label runat="server" ID="lblUser"></asp:Label>
                                        <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                        <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                    </div>
                                </div>
                      <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
                                </div>
                                 
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>



            </div>
        
        <div class="col-sm-2">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
            <%--<uc2:MsgBox ID="msgBox" runat="server"/>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

