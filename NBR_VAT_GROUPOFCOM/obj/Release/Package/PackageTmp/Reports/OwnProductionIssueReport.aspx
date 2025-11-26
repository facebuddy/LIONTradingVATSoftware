<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_wnProductionIssueReport, App_Web_pj2ymx2u" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=print.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;}table.allSolid td { border: 1.5px solid black;}</style>');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <%--<div class="panel-heading" style="text-align: center; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">ক্রয় হিসাব পুস্তক (মূসক-১৬)</div>--%>
                        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 35px; padding-top: 0px">Issue/ উৎপাদনের চালানপত্র</div>
                        <div class="panel panel-body">
                             <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateFrom" style="font-size:11pt" />
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateTo" style="font-size:11pt" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Challan No :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="ddlChallanId"  />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                       
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Batch No :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlbatchNo" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                            
                           <asp:LinkButton ID="btnShow"  runat="server" CssClass="btn btn-success btn-sm " style="float:right" OnClick="btnShow_OnClick" ><i class="	fa fa-archive"></i> Report</asp:LinkButton>&nbsp&nbsp
                          <asp:LinkButton ID="btnPrint" runat="server" style="float:right" CssClass="btn btn-info btn-sm" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>Print</asp:LinkButton>
                          <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px;float:right"></asp:TextBox>
                              </div>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator> 
                    </div>
                  </div>
               
          
                        </div>
                    </div>
                     <div runat="server" id="print">
                     <div class="row">
                        <table style="border:none;width: 100%;">
                
                             <tr>
                              <%-- <td> <img src="../../Images/bdlogo.png" style="height:50px;margin-left:80px;" ></img></td>--%>
                         <td>
                         <div class="row" style=" font-size: 16px;">
                                       
                                 <p style="text-align: center"><b>Issue/ উৎপাদনের চালানপত্র </b> </p>  
                               <%--  <p> <strong style="text-align: center; border: 1px solid gray; float: right;font-size:20px">মূসক-৬.৪</strong> </p>  
                                 <p>  [বিধি ৪০ এর উপ-বিধি (১) এর দফা (ঘ) দ্রষ্টব্য]</p>        --%> 
                          </div>    
                      </td>
    
       </table>
  
                    </div>
                    <div style="font-size:12px">
                    <div class="row" style="margin-top: 4%">
                        <p style="margin-left: 35%">নিবন্ধিত ব্যাক্তির নাম :<asp:Label runat="server" ID="OrgName" /></p>
                         <p style="margin-left: 35%">নিবন্ধিত ব্যাক্তির বিআইএন :<asp:Label runat="server" ID="OrgBIN" /></p>
                         <p style="margin-left: 35%">চালান ইস্যুর ঠিকানা :<asp:Label runat="server" ID="OrgAddress" /></p>
                       <%-- <p style="margin-left: 35%">করদাতা সনাক্তকরণ সংখ্যা :<asp:Label runat="server" ID="OrgBIN" Visible="false" /></p>--%>
                    </div>
                    <div class="row">
                        <div class="col-sm-6" style="width: 50%; float: left">
                            <p>
                               <%-- উৎপাদনকারী প্রতিষ্ঠানের নাম :--%>
                                পণ্য গ্রহিতার নাম :
                                <asp:Label runat="server" ID="PartyName" /></p>
                            
                            <p>
                               <%-- করদাতা সনাক্তকরণ সংখ্যা :--%>
                                গ্রহীতার বিআইএন :
                                <asp:Label runat="server" ID="PartyBIN" /></p>
                           
                            <p>
                              <%--  ঠিকানা :--%>
                                গন্তব্যস্থল :
                                <asp:Label runat="server" ID="PartyAddress" /></p>
                             <p style="display:none;">যানবাহনের প্রকৃতি ও নম্বর :
                                <asp:Label runat="server" ID="vehicleType" /></p>
                        </div>
                        <div class="col-sm-6" style="width: 49%; float: left">
                           <%-- <p>চালান পত্রের ক্রমিক সংখ্যা :--%>
                             <p>চালানপত্র নম্বর :
                                <asp:Label runat="server" ID="ChallanNo" /></p>
                            <p>
                               <%-- চালানপত্র প্রদানের তারিখ :--%>
                                ইস্যুর তারিখ :
                                <asp:Label runat="server" ID="ChallanIssueDate" /></p>
                            <p>
                               <%-- চালানপত্র প্রদানের সময় :--%>
                                ইস্যুর সময় :
                                <asp:Label runat="server" ID="ChallanIssueTime" /></p>
                            <p style="display:none;">উপকরণ অপসারণের প্রকৃত তারিখ ও সময় :
                                <asp:Label runat="server" ID="ChallanDeliverDate" /></p>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 3%">
                        <table class="table table-bordered" style="width: 100%; text-align: center; background: none; border-collapse: collapse">
                            <tr>
                                <td style="border: 1px solid gray">ক্রমিক নং
                                </td>
                               <%-- <td style="border: 1px solid gray">সরবরাহকৃত উপকরণ নাম ও বিবরণ
                                </td>--%>
                                 <td style="border: 1px solid gray">  প্রকৃতি (উপকরণ বা উৎপাদিত পণ্য)
                                </td>
                               <td style="border: 1px solid gray">  পণ্যের বিবরণ
                                </td>
                                <td style="border: 1px solid gray">পরিমাণ
                                </td>
                                <%--<td style="border: 1px solid gray">মূল্য (করসহ) 
                                </td>--%>
                                <td style="border: 1px solid gray">মন্তব্য
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid gray">(১)
                                </td>
                                <td style="border: 1px solid gray">(২)
                                </td>
                                <td style="border: 1px solid gray">(৩)
                                </td>
                                <td style="border: 1px solid gray">(৪)
                                </td>
                                <td style="border: 1px solid gray">(৫)
                                </td>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="HaiMan"></asp:Label>
                            </tr>
                        </table>
                    </div>
                    <div class="row" style="margin-top: 10px">
                        <p>
                           <%-- সত্ত্বাধিকারী/ব্যবস্থাপনা কর্তৃপক্ষের স্বাক্ষর--%>
                            দায়িত্বপ্রাপ্ত কর্মকর্তার স্বাক্ষর
                        </p>
                        <p>
                            নাম : 
                            <asp:Label runat="server" ID="lblDutyOfficer" />
                        </p>
                          <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
                    </div>
                </div>
                 </div>
                     </div>
            </div>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>