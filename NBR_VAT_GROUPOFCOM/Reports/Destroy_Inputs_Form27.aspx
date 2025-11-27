<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Destroy_Inputs_Form27.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.Destroy_Inputs_Form27" %>

<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagName="MsgBoxs" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
    function PrintPanel() {
           var panel = document.getElementById("<%=print.ClientID %>");
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
       };
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">দুর্ঘটনায় ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত পণ্য নিষ্পত্তির আবেদনপত্র (মূসক-৪.৫)</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row" style="margin-top: 1%">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="fromDate" CssClass="form-control" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10" placeholder="DD/MM/YYYY" />
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="fromDate" />
                                    <asp:Label ID="lblfromDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="toDate" CssClass="form-control" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10" placeholder="DD/MM/YYYY" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="toDate" />
                                    <asp:Label ID="lblToDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                        </div>
                       <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">পণ্যের নাম :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                           </div>

                        <div class="row">
                        <div class="col-md-12" style="text-align:right">
                            <div class="form-group form-group-sm">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-primary" Style="float: right" Text="Search" OnClick="btnSearch_OnClick" />
                                  <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-info" OnClientClick="return PrintPanel();" Visible="false" />
                            </div>

                        </div>
                        <div class="col-md-3">
                            <div class="form-group form-group-sm">

                            </div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Challan No :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="droChallanNo" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8" style="text-align:right">
                            <div class="form-group form-group-sm">
                                <asp:Button ID="btnApplication" runat="server" Text="Application" CssClass="btn btn-success" OnClick="btnShowApplication_OnClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
       <div runat="server" id="print" style="font-family:Nikosh">
            <div class="col-md-12">
                <div class="form-group form-group-sm">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                    
                       <center>
                         <asp:Label runat="server" class="control-label" style="font-size:16px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</asp:Label>                             
                           </center>  
                                                 
                             <center>                       
                         <asp:Label runat="server" class="control-label" style="font-size:16px;">জাতীয় রাজস্ব বোর্ড </asp:Label><br />
                         <asp:Label runat="server" class="control-label" style="font-size:16px;">ঢাকা</asp:Label>
                     </center>
                    </div>
                    <div class="col-sm-4">
                        <p style="text-align: right; padding: 5px;">
                            <b style="border: 1px solid gray;">মূসক-৪.৫</b>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group form-group-sm">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        <center>
                     <asp:Label runat="server" class="control-label" style="font-size:16px; font-weight:bold">দুর্ঘটনায় ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত পণ্য নিষ্পত্তির আবেদনপত্র</asp:Label><br />
                    </center>
                        <center>
                         <asp:Label runat="server" class="control-label">[ বিধি ২৪খ এর উপ-বিধি (১) দ্রষ্টব্য ]</asp:Label>
                     </center>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
         
            <br />
             <br />
             <br />
            <div class="col-md-12">
                
                    <div class="table-responsive">
                       <table class="table" border="1" style="background:none;border-collapse:collapse;width:100%">
                             <tbody>
                                <tr>
                                    <td>নিবন্ধিত/ তালিকাভুক্ত ব্যক্তির নাম :
                                        <asp:Label runat="server" ID="orgName" />  </td>                         
                                       <td>বিআইন :
                                        <asp:Label runat="server" ID="orgBIN" /></td>
                                </tr>
                                <tr>
                                    <td>ঠিকানা :
                                        <asp:Label runat="server" ID="orgAddress" /></td>
                                    <td>পণ্যের এইচএস কোড :
                                        <asp:Label runat="server" ID="lblItem"/></td>
                                </tr>
                                 </tbody>
                        </table>
                        </div>
                        </div>
              <div class="col-md-12">
                         <div class="table-responsive">
                        <table class="table" border="1" style="background:none;border-collapse:collapse;width:100%">
                           <thead>
                                <tr>
                                    <th style="text-align: center">ক্রমিক সংখ্যা </th>
                                    <th style="text-align: center">পণ্যের নাম</th>                                                                      
                                    <th style="text-align: center">পরিমাণ</th>
                                    <th style="text-align: center">প্রকৃত মূল্য </th>                                   
                                    <th style="text-align: center">প্রস্তাবিত মূল্য </th>
                                    <th style="text-align: center">অনুপোযোগিতার কারণ</th>
                                </tr>
                            </thead>

                            <tbody>
                                <tr>
                                    <td style="text-align: center">(১)</td>
                                    <td style="text-align: center">(২)</td>
                                    <td style="text-align: center">(৩)</td>
                                    <td style="text-align: center">(৪)</td>
                                    <td style="text-align: center">(৫)</td>
                                    <td style="text-align: center">(৬)</td>
                                   
                                    
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="lblReportHtml" />
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
           
            <div class="col-md-12">
                <asp:Label runat="server" style="margin-left:10px;">আমি ঘোষণা করছি যে,এই আবেদনপত্রে প্রদত্ত সকল তথ্য সত্য ও সঠিক।</asp:Label>
                <br />
             <br />
             <br />
            </div>
             
            <div class="col-md-12"><asp:Label runat="server">তারিখ:....................... </asp:Label></div>
            <div class="col-md-12">
               <table  style="width: 100%;border-bottom:none;border-left:none;border-top:none;border-right:none"" >
                
                 <tr>
                                        <td style="width: 60%;">                                          
                                        </td>
                                        <td style="width: 40%;">  
                   
                    <table style="border-left:none;border-bottom:none;border-right:none;border-top:solid">
                   
                   <tr><td></td><td><asp:Label runat="server">প্রতিষ্ঠানের দায়িত্বপ্রাপ্ত ব্যক্তির নামঃ</asp:Label><asp:Label style="font-size:11px;" runat="server" ID="lblDutyOfficerName"></asp:Label>
               </td>  </tr><tr><td></td><td><asp:Label runat="server">পদবিঃ</asp:Label> <asp:Label style="font-size:11px;" runat="server" ID="lblDutyOfficerDesignationName"></asp:Label>
                 </td></tr><tr><td></td><td><asp:Label runat="server">স্বাক্ষরঃ</asp:Label>
             </td>   </tr><tr><td></td><td> <asp:Label runat="server"> সিলঃ</asp:Label></td></tr>
                        </table>
                   </table>
            </div>
            <div class="col-md-12" style="margin-top: 5px">
                <div class="form-group form-group-sm">
                    <asp:Label runat="server" Text="System User: "></asp:Label>
                    <asp:Label runat="server" ID="lblUser"></asp:Label>
                    <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                    <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                </div>
            </div>
              </div>
    <uc2:MsgBoxs ID="msgBox" runat="server" />
</asp:Content>
