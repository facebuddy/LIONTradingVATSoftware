
<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="VATReturnMushok19sR.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.VATReturnMushok19sR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
<%--    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />--%>
<%--     <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <script src="../Scripts/jquery-3.1.1.min.js"></script>--%>
    <script type="text/javascript">

        function Confirm() {
           
            var confirm_value = "";
            
            
                confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to save the month closing balance?"))
                {
                    confirm_value.value = "Yes";
                    document.getElementById("<%=chkClosing.ClientID%>").value = "Yes";
                }
                else
                {
                    confirm_value.value = "No";
                    document.getElementById("<%=chkClosing.ClientID%>").value = "No";
                }
                             
             
            }
        function PrintPanel() {

           
            var style = `<style>
                            .reportHeader{font-size: 11pt; }
                            .reportBody{font-size: 8pt;}
                        </style>`;
            document.getElementById('<%=details.ClientID %>').style.visibility = "hidden"; 
            document.getElementById('<%=sub27.ClientID %>').style.visibility = "hidden"; 
             document.getElementById('<%=sub32.ClientID %>').style.visibility = "hidden"; 
            var panel = document.getElementById("<%=reportMain.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            //printWindow.document.fontSize = "xxx-small";
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>.hiddencol{display:none;}</style>');
            printWindow.document.write('<style> p.reportHeader{font-size:smaller;}</style>');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;} table.allSolid th {border: 1.5px solid black;text-align:center;}table.allSolid td { border: 1.5px solid black;} table.allSolid tr { border: 1.55px solid black;} </style>');
            printWindow.document.write(`${style}</head><body style="margin: 50px;font-family: 'Times New Roman', Times, serif;">`);
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
        .m {
            text-align: right;
            padding-right: 5px;
        }
        .column {
  float: left;
  width: 50%;
 
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}


/* sabbir */
.hiddencol{
            display:none;
        } 

    .footer,
    .push {
      height: 50px;
    }

    p.reportHeader{
        font-size:14px;
    }

    
        table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;text-align:center;}
        table.allSolid td { border: 1.5px solid black;}
        table.allSolid tr { border: 1.5px solid black;}

    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-primary">
        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 35px; padding-top: 0px">মূল্য সংযোজন কর দাখিলপত্র (মূসক-৯.১)</div>
        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
            <div class="row" style="margin-top: 0.5%">
                <div class="col-md-12">
                    <div class="form-group form-group-sm">
                        <div class="col-md-4">
                            <label class="col-sm-5 comntrol-label">Date From:</label>
                            <div class="col-sm-7">
                                <asp:TextBox CssClass="form-control" runat="server" Width="40%" ID="dtpDateFrom" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom" />
                            </div>

                        </div>
                        <div class="col-md-3">
                            <label class="col-sm-4 comntrol-label">Date To:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateTo" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                            </div>

                        </div>
                        <div class="col-md-5">
                              <asp:TextBox ID="txtSubmit" runat="server" placeholder="Submit Date" style="width:80px;"></asp:TextBox>
                             <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Submit Date" style="width:80px;"></asp:TextBox>

                            <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnShow_OnClick"><i class="fa fa-search-plus"></i>  Report</asp:LinkButton>
                            <asp:LinkButton ID="btnPrint" runat="server"  CssClass="btn btn-primary btn-sm" OnClientClick="return PrintPanel();" style="background-color:#65C2DD;"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                            <%--<asp:LinkButton ID="btnXMLFormat" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnXMLFormat_OnClick"><i class="fa fa-search-plus"></i>  XML Data</asp:LinkButton>--%>

                            <%-- <button type="button" id="btnXMLFormat" class="btn btn-info btn-sm"><i class="fa fa-file-excel-o" aria-hidden="true"></i>Export XML</button>
                            <button type="button" id="btnExportCSV" class="btn btn-info btn-sm"><i class="fa fa-file-excel-o" aria-hidden="true"></i>Export CSV</button>--%>

                            <%--<button type="button" id="btnXMLFormat" onclick="export_table_to_xml()" class="btn btn-info btn-sm"><i class="fa fa-file-excel-o" aria-hidden="true"></i>Export XML</button>--%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnExportXML_OnClick"><i class="fa fa-file-excel-o"></i>  Export XML</asp:LinkButton>
                            <button type="button" id="btnExportCSV" onclick="export_table_to_csv()" class="btn btn-info btn-sm"><i class="fa fa-file-excel-o" aria-hidden="true"></i>Export CSV</button>
                            <asp:Button ID="btnSave" runat="server" Style="background-color: #0D7B78;" CssClass="btn-btn" OnClick="btnSave_Click" Text="Save"  OnClientClick = "Confirm()" />   
                          <asp:Label runat="server" ID ="lblStatus" ></asp:Label><br />
                            <asp:Label runat="server" ID ="lblError" ></asp:Label>
                        </div>
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
    <div id="reportMain" class="container-fluid" style="padding: 2%;font-family:Nikosh" runat="server" visible="true">
        <div >
  <table style="border:none;width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; font-size: 14px; border:none;" >
                    </th>
                </tr>
      <tr>
<td> <img src="../../Images/bdlogo.png" style="height:50px;margin-left:50px;margin-top:-60px"></img></td> 
    
<%--  <td>
      
            <p  class="reportHeader" style="border: 1px solid #000; float: right; margin-right: 15px; padding: 2px;"><strong>মূসক-৯.১</strong></p>
      <p class="reportHeader" style="text-align: left;margin-left:15px;"> &nbsp&nbsp গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
       <p class="reportHeader" style="text-align: left; margin-top: -1%;margin-left:50px;">জাতীয় রাজস্ব বোর্ড</p>
            
            <p class="reportHeader" style="text-align: left; margin-top: -1%;margin-left:20px;"><strong>&nbsp&nbsp মূল্য সংযোজন কর দাখিলপত্র</strong></p>

            <p class="reportHeader" style="text-align: left;margin-left:15px;">&nbsp&nbsp [বিধি ৪৭ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
      </td>--%>

            <td>
      
            <p class="reportHeader" style="border: 1px solid #000; float: right; margin-right: 15px; padding: 2px;"><strong>মূসক-৯.১</strong></p>
      <p class="reportHeader" style="text-align: left;margin-left:-3px;"> &nbsp&nbsp গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
       <p class="reportHeader" style="text-align: left; margin-top: -1%;">জাতীয় রাজস্ব বোর্ড</p>
            
            <p class="reportHeader" style="text-align: left; margin-top: -1%;margin-left:-11px;"><strong>&nbsp&nbsp মূল্য সংযোজন কর দাখিলপত্র</strong></p>

            <p class="reportHeader" style="text-align: left;margin-left:-5px;">&nbsp&nbsp [বিধি ৪৭ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
<%--            <p style="border: 1px solid #000; float: right; margin-right: 15px; padding: 2px; font-size: 18px;"><strong>মূসক-৯.১</strong></p>--%>
      </td>
          </tr>
    
      </table>

        
        </div>

        <div style="font-size:12px">
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <%--<table class="allSolid" style="width: 100%">--%>
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-১: করদাতার তথ্য
                    </th>
                </tr>
                <tr>
                    <%-- <td style="padding-left: 7px;">(১) ব্যবসায় সনাক্তকরণ সংখ্যা (ই-বিআইএন)</td>--%>
                    <td style="padding-left: 7px;">(১) ব্যবসায় সনাক্তকরণ সংখ্যা (ই-বিন)</td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left: 7px;">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationBIN" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px;">(২) করদাতার নাম
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left: 7px; padding-top: 2px; padding-bottom: 2px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationName" />
                    </td>
                </tr>
                <%--<tr>
                    <td style="padding-left:7px;">(২) ব্যবসায় সনাক্তকরণ সংখ্যা (ই-বিআইএন)</td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left:7px;">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationBIN" />
                    </td>
                </tr>--%>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px;">(৩) করদাতার ঠিকানা
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left: 7px; padding-top: 2px; padding-bottom: 2px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationAddress" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px;">(৪) মালিকানার প্রকৃতি
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left: 7px; padding-top: 2px; padding-bottom: 2px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="OrganizationBusinessNature" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px;">(৫) অর্থনৈতিক কাযক্রম এর প্রকৃতি
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left: 7px; padding-top: 2px; padding-bottom: 2px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="NatureOfBusiness" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                    <th colspan="3" style="text-align: center; background-color: #ffbb99; font-size: 12px; padding-top: 4px; padding-bottom: 2px">অংশ-২: দাখিলপত্র জমার তথ্য
                    </th>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px;">(১) কর মেয়াদ</td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left: 7px;">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTaxPeriod" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px;">(২) দাখিলপত্রের প্রকার<br />
                        [অনুগ্রহ করিয়া প্রযোজ্যটিতে টিক দিন]
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <%--<td style="padding-left: 7px">(ক) মূল্য দাখিলপত্র (ধারা-৬৪) &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp&nbsp&nbsp&nbsp<asp:CheckBox ID="ChkMainDakhil" runat="server" /><br />
                        (খ) দেরীতে প্রদত্ত দাখিলপত্র(ধারা-৬৫)&nbsp&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp&nbsp&nbsp<asp:CheckBox ID="ChkLate" runat="server" /><br />
                        (গ) সংশোধিত দাখিলপত্র(ধারা-৬৬) &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp&nbsp&nbsp<asp:CheckBox ID="ChkRevisedDakhil" runat="server" /><br />
                        (ঘ) পূর্ণ,অতিরিক্ত বা বিকল্প দাখিলপত্র (ধারা-৬৭)&nbsp&nbsp
                        <asp:CheckBox ID="ChkExtraDakhil" runat="server" /><br />
                    </td>--%>

                    <%--<td style="padding-left: 7px">(ক) মূল্য দাখিলপত্র (ধারা-৬৪) &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:CheckBox ID="ChkMainDakhil" runat="server" /><br />
                        (খ) দেরীতে প্রদত্ত দাখিলপত্র (ধারা-৬৫)&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:CheckBox ID="ChkLate" runat="server" /><br />
                        (গ) সংশোধিত দাখিলপত্র (ধারা-৬৬)&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:CheckBox ID="ChkRevisedDakhil" runat="server" /><br />
                        (ঘ) পূর্ণ,অতিরিক্ত বা বিকল্প দাখিলপত্র (ধারা-৬৭)&nbsp&nbsp<asp:CheckBox ID="ChkExtraDakhil" runat="server" /><br />
                    </td>--%>
                    
                    <td>
                    <Table style="border:hidden;font-size: 12px;">
                        <tr style="border:hidden;">
                            <td style="border:hidden;padding-left:5px;">(ক) মূল্য দাখিলপত্র (ধারা-৬৪)  <br />
                        (খ) দেরীতে প্রদত্ত দাখিলপত্র (ধারা-৬৫)  <br />
                        (গ) সংশোধিত দাখিলপত্র (ধারা-৬৬)  <br />
                        (ঘ) পূর্ণ,অতিরিক্ত বা বিকল্প দাখিলপত্র (ধারা-৬৭) <br />
                    </td>
                        

                    <td style="border:hidden;padding-left:10px;">
                        <asp:CheckBox ID="ChkMainDakhil" runat="server" /><br />
                        <asp:CheckBox ID="ChkLate" runat="server" /><br />
                        <asp:CheckBox ID="ChkRevisedDakhil" runat="server" /><br />
                        <asp:CheckBox ID="ChkExtraDakhil" runat="server" /><br />
                    </td>


                        </tr>
                    </Table>
                    </td>
                    

                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px;">(৩) বিগত করমেয়াদে কোনো কার্যক্রম সম্পাদিত হইয়াছে কি?<br/>
                        [যদি না হয় তাহা হইলে অংশ ১,২ এবং ১২ পূরণ করুন]
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left: 7px">
                        <asp:CheckBox ID="chkHa" runat="server" />
                        হ্যাঁ &nbsp &nbsp
                        <asp:CheckBox ID="chkNa" runat="server" />
                        না<br />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px;">(৪) পেশের তারিখ
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding: 10px;">
                        <asp:Label runat="server" ID="lblReturnSubmitDate" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
           
            <table class="table-bordered reportBody allSolid" style="width: 100%" runat="server" id="tbl3">
                <tr>
                    <th colspan="6" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-৩: সরবরাহ প্রদান-প্রদেয় কর
                    </th>
                </tr>
                <tr>
                    <th style="width: 55%; text-align: center; background-color: #DDDDDD" colspan="2">সরবরাহের প্রকৃতি
                    </th>
                    <th style="width: 5%; text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="width: 10%; text-align: center; background-color: #DDDDDD">মূল্য (ক)
                    </th>
                    <th style="width: 10%; text-align: center; background-color: #DDDDDD">এসডি (খ)
                    </th>
                    <th style="width: 10%; text-align: center; background-color: #DDDDDD">মূসক (গ)
                    </th>

                </tr>
                <tr>
                    <td rowspan="2" style="padding-left: 7px">শূন্যহার বিশিষ্ট পণ্য/সেবা</td>
                    <td style="padding-left: 7px">সরাসরি রপ্তানি</td>
                    <td style="font-weight: bold; text-align: center">১
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="zerorateDirectExportAmountN2P3" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                    <td style="background-color: #DDDDDD"></td>
                    <td style="background-color: #DDDDDD">
                        <asp:LinkButton ID="SubForm_3Row1K" runat="server" EnableTheming="True" OnClick="SubForm_3Row1K_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>

                    <td style="padding-left: 7px">প্রচ্ছন্ন রপ্তানি</td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">২</td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="zerorateDeemedExportAmountN1P3" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                    <td style="background-color: #DDDDDD"></td>
                    <td style="background-color: #DDDDDD"><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_3Row2K" runat="server" EnableTheming="True" OnClick="SubForm_3Row2K_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 7px">অব্যাহতিপ্রাপ্ত পণ্য/সেবা</td>
                    <td style="font-weight: bold; text-align: center">৩
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="exemptedSupplyAmountN3P3" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                    <td style="background-color: #DDDDDD"></td>
                    <td style="background-color: #DDDDDD"><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_3Row3K" runat="server" EnableTheming="True" OnClick="SubForm_3Row3K_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 7px">আদর্শ হারের পণ্য/সেবা
                    </td>
                    <td style="font-weight: bold; text-align: center">৪
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="typicalSupplyAmountN4P3" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="typicalSupplySDN4P3" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="typicalSupplyVATN4P3" />
                    </td>

                    <td><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_3Row4K" runat="server" EnableTheming="True" OnClick="SubForm_3Row4K_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 7px">সর্বোচ্চ খুচরা মূল্যভিত্তিক পণ্য
                    </td>
                    <td style="font-weight: bold; text-align: center">৫
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="note5AmountP3" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="note5SDP3" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="note5VATP3" />
                    </td>

                    <td>
                        <asp:LinkButton ID="SubForm_3Row5K" runat="server" EnableTheming="True" OnClick="SubForm_5_K_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 7px">সুনির্দিষ্ট কর ভিত্তিক পণ্য/সেবা
                    </td>
                    <td style="font-weight: bold; text-align: center">৬
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonTypicalSupplyAmountN6P3" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonTypicalSupplySDN6P3" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonTypicalSupplyVATN6P3" />
                    </td>

                        <td>
                        <asp:LinkButton ID="SubForm_3Row6K" runat="server" EnableTheming="True" onclick="SubForm_3Row6K_Click">সাবফর্ম</asp:LinkButton>
                      
                    </td>
                    <%--<td style="background-color: #DDDDDD"><a href="SubForms/SubForm_Gha_Note_6.aspx" style="text-decoration: none;">সাবফর্ম-গ</a></td>--%>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 7px">আদর্শ করহার ব্যতীত ভিন্ন করহার ভিত্তিক পণ্য/সেবা</td>
                    <td style="font-weight: bold; text-align: center">৭</td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshoHarBatitoMullo" /></td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshHarBatitoSD" /></td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshoHarBatitoMushok" /></td>

                    <td>
                        <asp:LinkButton ID="SubForm_3Row7K" runat="server" EnableTheming="True" OnClick="SubForm_3Row7K_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 7px">খুচরা/পাইকারী/ব্যবসায়ী ভিত্তিক সরবরাহ</td>
                    <td style="font-weight: bold; text-align: center">৮</td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label2" /></td>
                    <td class="text-right" style="background-color: #DDDDDD">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label4" /></td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label3" /></td>

                    <td style="background-color: #DDDDDD"><%--<a href="SubForms/SubForm_kH.aspx" style="text-decoration:none;">সাবফর্ম-খ</a>--%>
                        <asp:LinkButton ID="SubForm_3Row8KH" runat="server" EnableTheming="True" OnClick="SubForm_3Row8KH_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 7px">মোট বিক্রয়মূল্য ও মোট প্রদেয় কর
                    </td>
                    <td style="font-weight: bold; text-align: center">৯
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalPriceP3" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatN7P3" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblNineMushokKhaTotal" />
                    </td>

                </tr>
            </table>
        </div>
        <div>
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                    
                    <%--<th colspan="6" style="text-align: center; font-size: 14px; background-color: #ffbb99">অংশ-৪: ক্রয় – উপকরণ কর<br />
                        (১)আপনার সরবরাহকৃত সকল পণ্য যদি আদর্শ হারের হয়, সেক্ষেত্রে নোট ১০-২০ পূরণ করুন।<br />
                        (২)আপনার সরবরাহকৃত সকল পণ্য যদি আদর্শ হারের না হয়, অথবা ধারা ৪৬ এ বর্ণিত সময়ের মধ্যে রেয়াত না নিলে সেক্ষেত্রে নোট্ ২১-২২ পূরণ করুন।<br />
                        (৩)আপনার সরবরাহকৃত সকল পণ্য যদি আদর্শ হারের  এবং আদর্শ হার ব্যতীত উভয় হয়,সেক্ষেত্রে আদর্শ হারের পণ্য উৎপাদন বা সরবরাহে ব্যবহৃত উপকরণের জন্য নোট ১০-২০ পূরণ করুন এবং আদর্শ হার ব্যতীত অন্যান্য হারের জন্য নোট ২১-২২ পূরণ করুন  এবং ব্যবহার অনুযায়ী উপকরণ মূল্য আনুপাতিক হরে প্রযোজ্যতা অনুযায়ী নোট ১০-২২ এ প্রদর্শন করুন |
                    </th>--%>

                    <th colspan="6" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-৪: ক্রয় – উপকরণ কর
                        <p style="text-align: left; font-weight:normal;font-size:10px;margin-left:unset;">(১)আপনার সরবরাহকৃত সকল পণ্য যদি আদর্শ হারের হয়, সেক্ষেত্রে নোট ১০-২০ পূরণ করুন।<br />
                        (২)আপনার সরবরাহকৃত সকল পণ্য যদি আদর্শ হারের না হয়, অথবা ধারা ৪৬ এ বর্ণিত সময়ের মধ্যে রেয়াত না নিলে সেক্ষেত্রে নোট্ ২১-২২ পূরণ করুন।<br />
                        (৩)আপনার সরবরাহকৃত সকল পণ্য যদি আদর্শ হারের  এবং আদর্শ হার ব্যতীত উভয় হয়,সেক্ষেত্রে আদর্শ হারের পণ্য উৎপাদন বা সরবরাহে ব্যবহৃত উপকরণের জন্য নোট ১০-২০ পূরণ করুন এবং আদর্শ হার ব্যতীত অন্যান্য হারের জন্য নোট ২১-২২ পূরণ করুন  এবং ব্যবহার অনুযায়ী উপকরণ মূল্য আনুপাতিক হরে প্রযোজ্যতা অনুযায়ী নোট ১০-২২ এ প্রদর্শন করুন |
                        </p>
                        
                    </th>

                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD" colspan="2">ক্রয়ের প্রকৃতি
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">মূল্য (ক)
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">মূসক (খ)
                    </th>
                </tr>
                <tr>
                    <td rowspan="2" style="padding-left: 7px">শূন্যহার বিশিষ্ট পণ্য/সেবা 
                    </td>
                    <td style="padding-left: 7px">স্থানীয় ক্রয়
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">১০
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="zerorateLocalPurchaseAmountN10P4" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                    <td style="background-color: #DDDDDD"><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_4ROW10K" runat="server" EnableTheming="true" OnClick="SubForm_4Row10k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">আমদানি
                    </td>
                    <td style="font-weight: bold; text-align: center">১১
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="zerorateForeignPurchaseAmountN11P4" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                    <td style="background-color: #DDDDDD"><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_4ROW11k" runat="server" EnableTheming="true" OnClick="SubForm_4ROW11K_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2" style="padding-left: 7px">অব্যাহতিপ্রাপ্ত পণ্য/সেবা
                    </td>
                    <td style="padding-left: 7px">স্থানীয় ক্রয়
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">১২
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="exemptedLocalPurchaseAmountN8P4" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                    <%--<td style="background-color: #DDDDDD"><a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a></td>--%>
                    <td style="background-color: #DDDDDD">
                        <%--<a href="SubForms/SubForm_k_Note12.aspx" style="text-decoration: none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_4ROW12k" runat="server" EnableTheming="true" OnClick="SubForm_4Row12k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">আমদানি
                    </td>
                    <td style="font-weight: bold; text-align: center">১৩
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="exemptedForeignPurchaseAmountN9P4" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                    <%-- <td style="background-color: #DDDDDD"><a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a></td>--%>
                    <td style="background-color: #DDDDDD">
                        <%--<a href="SubForms/SubForm_k_Note13.aspx" style="text-decoration: none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_4ROW13k" runat="server" EnableTheming="true" OnClick="SubForm_4Row13k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <%--<tr>
                    <td rowspan="2" style="padding-left:7px">শূন্যহার বিশিষ্ট ক্রয় 
                    </td>
                    <td style="padding-left:7px">সরবরাহ
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">১০
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="zerorateLocalPurchaseAmountN10P4" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                </tr>
                <tr>
                    <td style="padding-left:7px">আমদানি
                    </td>
                    <td style="font-weight: bold; text-align: center">১১
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="zerorateForeignPurchaseAmountN11P4" />
                    </td>
                    <td style="background-color: #DDDDDD"></td>
                </tr>--%>
                <tr>
                    <td rowspan="2" style="padding-left: 7px">আদর্শ হারের পণ্য/সেবা
                    </td>
                    <td style="padding-left: 7px">স্থানীয় ক্রয়
                    </td>
                    <td style="font-weight: bold; text-align: center">১৪
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="standardLocalPurchaseAmountN12P4" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="standardLocalPurchaseVatN12P4" />
                    </td>
                    <td><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_4Row14k" runat="server" EnableTheming="True" OnClick="SubForm_4Row14k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">আমদানি
                    </td>
                    <td style="font-weight: bold; text-align: center">১৫
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="standardForeignPurchaseAmountN13P4" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="standardForeignPurchaseVatN13P4" />
                    </td>
                    <td><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>

                        <asp:LinkButton ID="SubForm_4Row15k" runat="server" EnableTheming="True" OnClick="SubForm_4Row15k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2" style="padding-left: 7px">আদর্শ হার ব্যতীত অন্যান্য হারের পণ্য/সেবা
                    </td>
                    <td style="padding-left: 7px">স্থানীয় ক্রয়
                    </td>
                    <td style="font-weight: bold; text-align: center">১৬
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshoHarBatitoMulloLcl" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshoHarBatitoMushokLcl" />
                    </td>
                    <td>
                        <asp:LinkButton ID="SubForm_4Row16k" runat="server" EnableTheming="true" OnClick="SubForm_4Row16k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">আমদানি
                    </td>
                    <td style="font-weight: bold; text-align: center">১৭
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshoHarBatitoMulloImp" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshoHarBatitoMushokImp" />
                    </td>
                    <td><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;"></a>--%>
                        <asp:LinkButton ID="SubForm_4Row17k" runat="server" EnableTheming="true" OnClick="SubForm_4Row17k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">সুনির্দিষ্ট কর ভিত্তিক পণ্য/সেবা
                    </td>
                    <td style="padding-left: 7px">স্থানীয় ক্রয়
                    </td>
                    <td style="font-weight: bold; text-align: center">১৮
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="partialRebatePurchaseAmountN14P4" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="partialRebatePurchaseVatN14P4" />
                    </td>
                    <%-- <td>
                        <asp:LinkButton ID="SubForm_Gha_Note_18" runat="server" EnableTheming="true" OnClick="SubForm_Gha_Note_18_Click">সাবফর্ম-গ</asp:LinkButton>
                        </td>--%>
                    <td style="background-color: #DDDDDD">
                        <%--<a href="SubForms/SubForm_Gha_Note_18.aspx" style="text-decoration: none;">সাবফর্ম-গ</a>--%>
                        <asp:LinkButton ID="SubForm_4Row18k" runat="server" EnableTheming="true" OnClick="SubForm_4Row18k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2" style="padding-left: 7px">রেয়াতযোগ্য নয় এরূপ পণ্য/সেবা (স্থানীয় ক্রয়)
                    </td>
                    <td style="padding-left: 7px">টাৰ্ণওভার প্রতিষ্ঠান হইতে
                    </td>
                    <td style="font-weight: bold; text-align: center">১৯
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonRebatePurchaseAmountN15P4" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonRebatePurchaseVatN15P4" />
                    </td>
                    <td>
                            <asp:LinkButton ID="SubForm_k19" runat="server" EnableTheming="true" OnClick="SubForm_4Row19k_Click">সাবফর্ম</asp:LinkButton>
                        <%--<a href="SubForms/SubForm_k19.aspx" style="text-decoration: none;">সাবফর্ম-ক</a>--%>
                        <%-- <a href="#" style="text-decoration: none;">সাবফর্ম-ক</a>--%>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">অনিবন্ধিত প্রতিষ্ঠান হইতে
                    </td>
                    <td style="font-weight: bold; text-align: center">২০
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label9" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label10" />
                    </td>
                    <td>
                        <asp:LinkButton ID="SubForm_4Row20k" runat="server" EnableTheming="true" OnClick="SubForm_4Row20k_Click">সাবফর্ম</asp:LinkButton>
                        <%-- <a href="SubForms/SubForm_k20.aspx" style="text-decoration: none;">সাবফর্ম-ক</a>--%>
                        <%-- <a href="#" style="text-decoration: none;">সাবফর্ম-ক</a>--%>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2" style="padding-left: 7px">রেয়াতযোগ্য নয় এরূপ পণ্য/সেবা (যে সকল করদাতা শুধুমাত্র অব্যাহতিপ্রাপ্ত/<br />
                        সুনির্দিষ্ট কর /আদর্শ হার ব্যতীত অন্যান্য হারে পণ্য/সেবা সরবরাহ করেন )
                    </td>
                    <td style="padding-left: 7px">স্থানীয় ক্রয়
                    </td>
                    <td style="font-weight: bold; text-align: center">২১
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label11" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label12" />
                    </td>
                    <%-- <td><a href="SubForms/SubForm_k.aspx" style="text-decoration: none;">সাবফর্ম-ক</a></td>--%>
                    <td>
                        <%--<a href="SubForms/Sub_Form_K_Note_21.aspx" style="text-decoration: none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_4Row21k" runat="server" EnableTheming="true" OnClick="SubForm_4Row21k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">আমদানি
                    </td>
                    <td style="font-weight: bold; text-align: center">২২
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label13" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label14" />
                    </td>
                    <td>
                        <%--<a href="SubForms/Sub_Form_K_Note_22.aspx" style="text-decoration: none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_4Row22k" runat="server" EnableTheming="true" OnClick="SubForm_4Row22k_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 7px">মোট উপকরণ কর রেয়াত
                    </td>
                    <td style="font-weight: bold; text-align: center">২৩
                    </td>
                    <%--   <td style="background-color: #DDDDDD">--%>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalPriceP4" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatN16P4" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <br />
            <br />
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                    <th colspan="4" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-৫: বৃদ্ধিকারী সমন্বয় (মূল্য সংযোজন কর)
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">সমন্বয় ঘটনা
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD; border-right: 1px solid gray">পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td class="td-width-70" style="padding-left: 7px">সরবরাহ গ্রহীতা কর্তৃক উৎসে কর্তনের জন্য
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">২৪
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="receiveVDSAmountN17P5" />
                    </td>
                    <td>
                        <asp:LinkButton ID="SubForm_5Row24GHA" runat="server" EnableTheming="true" OnClick="SubForm_5Row24GHA_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">ব্যাংকিং চ্যানেলে মূল্য পরিশোধিত হয় নাই এমন সরবরাহের জন্য
                    </td>
                    <td style="font-weight: bold; text-align: center">২৫ 
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonBankingPaymentVatN18P5" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">ডেবিট নোটের জন্য
                    </td>
                    <td style="font-weight: bold; text-align: center">২৬
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="changePurchaseAllVatN19P5" />
                    </td>

                    <td runat="server" id="sub26">
                        <asp:LinkButton ID="link26" runat="server" EnableTheming="true" OnClick="Subform26_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <%--<tr>
                    <td style="padding-left: 7px">অন্যকোনো সমন্বয় ঘটনার জন্য(নিচে বর্ণনা করুন)
                    </td>
                    <td style="font-weight: bold; text-align: center">২৭
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="otherAdjusmentVatN20P5" />
                    </td>
                </tr>--%>

                <tr>
                    <td class="td-width-70" style="padding-left: 7px">অন্যকোনো সমন্বয় ঘটনার জন্য(নিচে বর্ণনা করুন)
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">২৭
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="otherAdjusmentVatN20P5" />
                    </td>
                    <td runat="server" id="sub27">
                        <asp:LinkButton ID="link27" runat="server" EnableTheming="true" OnClick="Details27_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>

                <tr>
                    <td style="padding-left: 7px">মোট বৃদ্ধিকারী সমন্বয়
                    </td>
                    <td style="font-weight: bold; text-align: center">২৮
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatN21P5" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                    <th colspan="4" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-৬: হ্রাসকারী সমন্বয় (মূল্য সংযোজন কর)
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">সমন্বয় ঘটনা
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td class="td-width-70" style="padding-left: 7px">প্রদত্ত সরবরাহ হইতে উৎসে কর্তনের জন্য
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">২৯ 
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="paidVDSAmountN22P6" />
                    </td>
                    <td>
                        <asp:LinkButton ID="SunForm_6Row29UMO" runat="server" EnableTheming="true" OnClick="SunForm_6Row29UMO_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">আমদানি পর্যায়ে প্রদেয় আগাম কর
                    </td>
                    <td style="font-weight: bold; text-align: center">৩০ 
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="changeSaleAllVatN23P6" />
                    </td>
                    <td>
                        <%--<a href="SubForms/SubForm_CH.aspx" style="text-decoration: none;">সাবফর্ম-চ</a>--%>
                        <asp:LinkButton ID="SubForm_6Row30CH" runat="server" EnableTheming="true" OnClick="SubForm_6Row30CH_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <%--commented on 26-JAN-2020--%>
                <%-- <tr>
                    <td style="padding-left: 7px">রপ্তানি পণ্য উৎপাদনে ব্যৱহৃত কাঁচামালের বিপরীতে প্রদেয় মূল্য সংযোজন কর
                    </td>
                    <td style="font-weight: bold; text-align: center">৩১
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="SDAmountN24P6" />
                    </td>
                </tr>--%>
                <tr>
                    <td style="padding-left: 7px">ক্রেডিট নোট্ ইস্যুর জন্য
                    </td>
                    <td style="font-weight: bold; text-align: center">৩১
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblforCreditNoteIssue" />
                    </td>

                    <td runat="server" id="sub31">
                        <asp:LinkButton ID="link31" runat="server" EnableTheming="true" OnClick="Subform31_Click">সাবফর্ম</asp:LinkButton>
                    </td>

                </tr>
                <tr>
                    <td class="td-width-70" style="padding-left: 7px">অন্যকোনো সমন্বয় ঘটনার জন্য(নিচে বর্ণনা করুন)
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">৩২
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="otherAdjusmentAmountN25P6" />
                    </td>
                    <td runat="server" id="sub32">
                        <asp:LinkButton ID="link33" runat="server" EnableTheming="true" OnClick="Details33_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">মোট হ্রাসকারী সমন্বয় 
                    </td>
                    <td style="font-weight: bold; text-align: center">৩৩
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatN26P6" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                    <th colspan="4" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-৭: নীট কর হিসাব
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td class="td-width-70" style="padding-left: 7px">বর্তমান করমেয়াদে প্রদেয় মোট মূসক
                        (সমাপনী জের এর সহিত সমন্বয় ব্যতীত) (ধারা-৪৫)
                        (৯গ-২৩খ+২৮-৩৩)
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">৩৪
                        <br />
                        <button type="button" data-toggle="modal" data-target="#detail35Modal" runat="server" id ="details">Details</button>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TotalVatSDAmountN27P7" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">
                        সমাপনী জের এবং মূসক ১৮.৬ হতে প্রাপ্ত জের এর সহিত সমন্বয়ের পর বর্তমান মেয়াদে প্রদেয় মোট মূসক  [৩৪-(৫২+৫৬)]
                    </td>
                    <td style="font-weight: bold; text-align: center">৩৫
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="AdvanceVatAmountN28P7" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">বর্তমান করমেয়াদে প্রদেয় মোট সম্পূরক শুল্ক (সমাপনী জের এর সহিত সমন্বয় ব্যতীত)
                        [৯খ+৩৮-(৩৯+৪০)]
                    </td>
                    <td style="font-weight: bold; text-align: center">৩৬
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="PrevAdvanceAmountN29P7" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">
                        সমাপনী জের এবং মূসক ১৮.৬ হতে প্রাপ্ত জের এর সহিত সমন্বয়ের পর বর্তমান করমেয়াদে প্রদেয় মোট সম্পূরক শুল্ক [৩৬-(৫৩+৫৭)]
                    </td>
                    <td style="font-weight: bold; text-align: center">৩৭
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="ExciseDutyN30P7" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">ডেবিট নোট ইস্যুর জন্য সমন্বয়কৃত সম্পূরূক শুল্ক
                    </td>
                    <td style="font-weight: bold; text-align: center">৩৮
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="SurchargeN31P7" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">ক্রেডিট নোট ইস্যুর জন্য সমন্বয়কৃত সম্পূরূক শুল্ক
                    </td>
                    <td style="font-weight: bold; text-align: center">৩৯
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label16" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">রপ্তানি পণ্য উৎপাদনে ব্যবহৃত কাঁচামালের বিপরীতে প্রদেয় সম্পূরক শুল্ক
                    </td>
                    <td style="font-weight: bold; text-align: center">৪০
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label17" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">অপরিশোধিত মূসকের জন্য সুদ (নোট ৩৫ এর ভিত্তিতে)
                    </td>
                    <td style="font-weight: bold; text-align: center">৪১
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label18" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">অপরিশোধিত সম্পূরূক শুল্ক এর জন্য সুদ(নোট ৩৭ এর ভিত্তিতে)
                    </td>
                    <td style="font-weight: bold; text-align: center">৪২
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label19" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">সময়মতো দাখিলপত্র জমা না দেয়ার জন্য অর্থদণ্ড ও জরিমানা
                    </td>
                    <td style="font-weight: bold; text-align: center">৪৩
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label20" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">অন্যান্য অর্থদণ্ড/জরিমানা/সুদ
                    </td>
                    <td style="font-weight: bold; text-align: center">৪৪
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label5" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">আবগারি শুল্ক
                    </td>
                    <td style="font-weight: bold; text-align: center">৪৫
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label21" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">উন্নয়ন ও সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">৪৬
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label22" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">তথ্য প্রযুক্তি উন্নয়ন সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">৪৭
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label23" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">স্বাস্থ্য সুরক্ষা সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">৪৮
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label24" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">পরিবেশ সুরক্ষা সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">৪৯
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label25" />
                    </td>
                </tr>
            <tr>
                <td style="padding-left: 7px">ট্রেজারী জমার জন্য নীট প্রদেয় মূল্য সংযোজন কর (৩৫+৪১+৪৩+৪৪)
                </td>
                <td style="font-weight: bold; text-align: center">৫০
                </td>
                <td class="text-right">
                    <asp:Label Style="font-weight: bold" runat="server" ID="lbl50" />
                </td>
            </tr>
            <tr>
                <td style="padding-left: 7px">ট্রেজারী জমার জন্য নীট প্রদেয় সম্পূরক শুল্ক (৩৭+৪২)
                </td>
                <td style="font-weight: bold; text-align: center">৫১
                </td>
                <td class="text-right">
                    <asp:Label Style="font-weight: bold" runat="server" ID="Label6" />
                </td>
            </tr>
                <tr>
                    <td style="padding-left: 7px">শেষ করমেয়াদের সমাপনী জের(মূসক)
                    </td>
                    <td style="font-weight: bold; text-align: center">৫২
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label26" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">শেষ করমেয়াদের সমাপনী জের(সম্পূরক শুল্ক)
                    </td>
                    <td style="font-weight: bold; text-align: center">৫৩
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label27" />
                    </td>
                </tr>


            </table>
        </div>
        <div>
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <%-- <tr>
                    <th colspan="4" style="text-align: center; font-size: 16px; background-color: #ffbb99">অংশ-৮: পুরাতন চলতি হিসাবের জের সমন্বয়
                    </th>
                </tr>--%>
                <tr>
                    <th colspan="4" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-৮: পুরাতন চলতি হিসাবের জের সমন্বয়
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td class="td-width-70" style="padding-left: 7px">মূসক-১৮.৬ হতে অবশিষ্ট জের (মূসক) [বিধি-১১৮(৫)]
                    </td>
                    <td style="font-weight: bold; text-align: center">৫৪
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="txtnote54" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">মূসক-১৮.৬ হতে অবশিষ্ট জের (সম্পূরক শুল্ক) [বিধি-১১৮(৫)]
                    </td>
                    <td style="font-weight: bold; text-align: center">৫৫
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="txtnote55" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">নোট ৫৪ হতে হ্রাসকারী সমন্বয় (নোট ৩৪ এর সর্বোচ্চ ৩০%)
                    </td>
                    <td style="font-weight: bold; text-align: center">৫৬
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="txtnote56" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">নোট ৫৫ হতে হ্রাসকারী সমন্বয় (নোট ৩৬ এর সর্বোচ্চ ৩০%)
                    </td>
                    <td style="font-weight: bold; text-align: center">৫৭
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="txtnote57" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                    <%--<th colspan="4" style="text-align: center;font-size:16px; background-color: #ffbb99">অংশ-৮: কর পরিশোধের তফসিল(ট্রেজারী জমা)--%>
                    <th colspan="4" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-৯: কর পরিশোধের তফসিল(ট্রেজারী জমা)
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">অর্থনৈতিক কোড
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">পরিমাণ (টাকা)
                    </th>
                </tr>
                <tr>
                    <td style="padding-left: 7px">বর্তমান করমেয়াদে পরিশোধিত মোট মূসক
                    </td>
                    <%--<td class="td-width-5" style="font-weight: bold; text-align: center">৫২--%>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">৫৮
                    </td>
                    <td style="padding-left: 7px">
                        <asp:Label runat="server" ID="oc1"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TotalVatN32P8" />
                    </td>
                    <td>
                        <%--<a href="SubForms/SubForm_CHA.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a>--%>
                        <asp:LinkButton ID="SubForm_9Row58CHA" runat="server" EnableTheming="true" OnClick="SubForm_9Row58CHA_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">বর্তমান করমেয়াদে পরিশোধিত মোট সম্পূরক শুল্ক
                    </td>
                    <%--<td style="font-weight: bold; text-align: center">৫৩--%>
                    <td style="font-weight: bold; text-align: center">৫৯
                    </td>
                    <td style="padding-left: 7px"><%--১/১১৩৩/অপারেশনাল কোড/০৬০১--%>
                        <asp:Label runat="server" ID="oc2"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="SDdepositN33P8" />
                    </td>
                    <td>
                        <%--<a href="SubForms/Sub_Form_CHA_Note53.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a>--%>
                        <asp:LinkButton ID="SubForm_9Row59CHA" runat="server" EnableTheming="true" OnClick="SubForm_9Row59CHA_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <%--<tr>
                    <td style="padding-left: 7px">অপরিশোধিত মূসকের জন্য সুদ
                    </td>
                   
                    <td style="font-weight: bold; text-align: center">৫৮
                    </td>
                    <td style="padding-left: 7px">
                        <asp:Label runat="server" ID="oc3"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="DueVatN34P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note54.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a></td>
                </tr>--%>
                <%-- <tr>
                    <td style="padding-left: 7px">অপরিশোধিত সম্পূরূক শুল্ক এর জন্য সুদ
                    </td>
                    <td style="font-weight: bold; text-align: center">৫৯
                    </td>
                    <td style="padding-left: 7px">
                        <asp:Label runat="server" ID="oc4"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="DueSDN34P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note55.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a></td>
                </tr>--%>
                <%-- <tr>
                    <td style="padding-left: 7px">অর্থদণ্ড ও জরিমানা
                    </td>
                    <td style="font-weight: bold; text-align: center">৬০
                    </td>
                    <td style="padding-left: 7px">
                        <asp:Label runat="server" ID="oc5"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="FinepenaltyN34P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note56.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a></td>
                </tr>--%>
                <tr>
                    <td style="padding-left: 7px">আবগারি শুল্ক
                    </td>
                    <%-- <td style="font-weight: bold; text-align: center">৫৭--%>
                    <td style="font-weight: bold; text-align: center">৬০
                    </td>
                    <td style="padding-left: 7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                        <asp:Label runat="server" ID="oc6"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="ExciseDutyN33P8" />
                    </td>
                    <td>
                        <%-- <a href="SubForms/Sub_Form_CHA_Note57.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a>--%>
                        <asp:LinkButton ID="SubForm_9Row60CHA" runat="server" EnableTheming="true" OnClick="SubForm_9Row60CHA_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">উন্নয়ন ও সারচার্জ
                    </td>
                    <%--<td style="font-weight: bold; text-align: center">৫৮--%>
                    <td style="font-weight: bold; text-align: center">৬১
                    </td>
                    <td style="padding-left: 7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                        <asp:Label runat="server" ID="oc7"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="DevelopmentN33P8" />
                    </td>
                    <td>
                        <%--<a href="SubForms/Sub_Form_CHA_Note58.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a>--%>
                        <asp:LinkButton ID="SubForm_9Row61CHA" runat="server" EnableTheming="true" OnClick="SubForm_9Row61CHA_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">তথ্য প্রযুক্তি উন্নয়ন সারচার্জ
                    </td>
                    <%--<td style="font-weight: bold; text-align: center">৫৯--%>
                    <td style="font-weight: bold; text-align: center">৬২
                    </td>
                    <td style="padding-left: 7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                        <asp:Label runat="server" ID="oc8"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="ICTN33P8" />
                    </td>
                    <td>
                        <%--<a href="SubForms/Sub_Form_CHA_Note59.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a>--%>
                        <asp:LinkButton ID="SubForm_9Row62CHA" runat="server" EnableTheming="true" OnClick="SubForm_9Row62CHA_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">স্বাস্থ্য সুরক্ষা সারচার্জ
                    </td>
                    <%-- <td style="font-weight: bold; text-align: center">৬০--%>
                    <td style="font-weight: bold; text-align: center">৬৩
                    </td>
                    <td style="padding-left: 7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                        <asp:Label runat="server" ID="oc9"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="HealthN33P8" />
                    </td>
                    <td>
<%--                        <a href="SubForms/Sub_Form_CHA_Note60.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a>--%>
                        <asp:LinkButton ID="SubForm_9Row63CHA" runat="server" EnableTheming="true" OnClick="SubForm_9Row63CHA_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">পরিবেশ সুরক্ষা সারচার্জ
                    </td>
                    <%--<td style="font-weight: bold; text-align: center">৬১--%>
                    <td style="font-weight: bold; text-align: center">৬৪
                    </td>
                    <td style="padding-left: 7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                        <asp:Label runat="server" ID="oc10"></asp:Label>
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="EnvironmentN33P8" />
                    </td>
                    <td>
                        <%--<a href="SubForms/Sub_Form_CHA_Note61.aspx" style="text-decoration: none;">সাবফর্ম-ছ</a>--%>
                        <asp:LinkButton ID="SubForm_9Row64CHA" runat="server" EnableTheming="true" OnClick="SubForm_9Row64CHA_Click">সাবফর্ম</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                    <th colspan="4" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-১০: সমাপনী জের(পরবতী কর মেয়াদের প্রারম্ভিক জের)
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td style="width: 50%; padding-left: 7px">সমাপনী জের (মূল্য সংযোজন কর) [৫৮-(৫০+৬৭) + রিফান্ডের পরিমাণ যা অনুমোদন করা হয়নি]
                    </td>
                    <td style="font-weight: bold; text-align: center; width: 5%">৬৫
                    </td>
                    <%--<td colspan="2" >--%>
                    <td  style="text-align:center" >    
                        <asp:TextBox runat="server" ID="txtRefundMoneyN35P9" Width="50%" Style="border:hidden" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 27.5%; padding-left: 7px">সমাপনী জের (সম্পুরক কর) [৫৯-(৫১+৬৮) + রিফান্ডের পরিমাণ যা অনুমোদন করা হয়নি]
                    </td>
                    <td style="font-weight: bold; text-align: center; width: 5%">৬৬
                    </td>
                    <%--<td colspan="2">--%>
                    <td  style="text-align:center" >
                        <asp:TextBox runat="server" ID="txtRefundSD" Width="50%" Style="border:hidden" />
                    </td>
                </tr>
                <%--  <tr>
                    <td colspan="4" style="text-align: center; font-size: 14px; background-color: #DDDDDD; for"><b>অংশ-১১: ফেরত</b></td>
                </tr>
                <tr>
                    <td style="padding-left: 7px">আমি সমাপনী জেরে উল্লিখিত অর্থ ফেরৎ গ্রহনে ইছুক
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox3" runat="server" />
                        হ্যাঁ &nbsp &nbsp
                        <asp:CheckBox ID="CheckBox4" runat="server" />
                        না
                    </td>
                </tr>--%>

            </table>
        </div>

        <br />
         <br />
        <div>
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                   <%-- <th colspan="5" style="text-align: center; font-size: 14px; background-color: #ffbb99">অংশ-১১: ফেরত
                    </th>--%>
                     <th colspan="5" style="text-align: center; font-size: 12px; background-color: #ffbb99">অংশ-১১: ফেরত
                    </th>
                </tr>
                <tr>
                    <th class="td-width-10" style="text-align: center;" rowspan="3">আমি সমাপনী জেরে উল্লিখিত অর্থ ফেরৎ গ্রহনে ইছুক
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD;">আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD;">নোট
                    </th>
                    <th colspan="2" style="text-align: center; background-color: #DDDDDD;"><asp:CheckBox ID="chk11Ha" runat="server" />
                        হ্যাঁ &nbsp &nbsp
                        <asp:CheckBox ID="chk11Na" runat="server" />
                        না
                    </th>
                </tr>
                <tr>
                    <td class="td-width-60" style="padding-left: 7px">দাবীকৃত ফেরতের পরিমাণ (ভ্যাট)
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">৬৭
                        
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label7" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label15" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-60" style="padding-left: 7px">
                        দাবীকৃত ফেরতের পরিমাণ (সম্পূরক শুল্ক)
                    </td>
                    <td style="font-weight: bold; text-align: center">৬৮
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label8" />
                    </td>
                    <td class="text-right">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label28" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-top: 25px">
            <table class="table-bordered reportBody allSolid" style="width: 100%">
                <tr>
                    <th colspan="3" style="text-align: center; font-size: 12px; background-color: #DDDDDD">অংশ-১২: ঘোষণা
                    </th>
                </tr>
                <tr>
                    <td colspan="3" style="padding-left: 7px">আমি ঘোষণা করিতেছি যে, এই দাখিলপত্রে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।
                        কোনো অসম্পূর্ণ বা অসত্য তথ্যের জন্য মূল্য সংযোজন কর ও সম্পূরক শুল্ক আইন, ২০১২ অথবা আপাতত বলবৎ এসংক্রান্ত যেকোন আইনের আওতায় দণ্ডনীয় অপরাধী হব।
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px">নাম
                    </td>
                    <td class="td-width-5" style="text-align: center;font-weight:bold">:
                    </td>
                    <td class="td-width-65" style="padding-left: 7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxpayerNameP10" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px">পদবী
                    </td>
                    <td class="td-width-5" style="text-align: center;font-weight:bold">:
                    </td>
                    <td class="td-width-65" style="padding-left: 7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxpayerDesignationP10" />
                    </td>
                    <td rowspan="6"></td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px">মোবাইল নম্বর
                    </td>
                    <td class="td-width-5" style="text-align: center;font-weight:bold">:
                    </td>
                    <td class="td-width-65" style="padding-left: 7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxpayerMobileNoP10" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px">জাতীয় পরিচয়পত্র/পাসপোর্ট নাম্বার
                    </td>
                    <td class="td-width-5" style="text-align: center;font-weight:bold">:
                    </td>
                    <td class="td-width-65" style="padding-left: 7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="txtNID" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left: 7px">ই-মেইল
                    </td>
                    <td class="td-width-5" style="text-align: center;font-weight:bold">:
                    </td>
                    <td class="td-width-65" style="padding-left: 7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxpayerEmailP10" />
                    </td>
                </tr>
                <%--<tr>
                    <td class="td-width-30" style="padding-left: 7px">তারিখ
                    </td>
                    <td class="td-width-5" style="text-align: center">:
                    </td>
                    <td class="td-width-65" style="padding-left: 7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxPaymentDateP10" />
                    </td>
                </tr>--%>
               
                <tr>
                    <td class="td-width-30" style="padding-left: 7px">স্বাক্ষর<br/>(অনলাইনে দাখিলের ক্ষেত্রে প্রয়োজন নাই )
                    </td>
                    <td class="td-width-5" style="text-align: center;font-weight:bold">:
                    </td>
                    <td class="td-width-65" style="padding-left: 7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label30" />
                    </td>
                     <asp:TextBox ID="chkClosing" runat="server"  CssClass="hiddencol"></asp:TextBox>
                </tr>


              <%--  <tr>
                    <td style="border: 0px"></td>
                    <td style="border: 0px"></td>
                    <td style="float: right">স্বাক্ষর
                    </td>
                </tr>--%>


                <%--<tr>
                    <td colspan="2" style="border: 0px">
                        <asp:Label runat="server" Text="System User: "></asp:Label>
                        <asp:Label runat="server" ID="lblUser"></asp:Label></td>
                    <td style="float: right; border: none">
                        <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                        <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label></td>
                </tr>--%>
            </table>
            <br />
        </div>

        <div>
        <footer style="bottom:0;">
            <%--<table style="width:100%;position: fixed;bottom: 0;border:hidden;">--%>
            <table style="width:100%;border:hidden;">
                <tr>
                    <td colspan="2" style="border: 0px">
                        <asp:Label runat="server" Text="System User: "></asp:Label>
                        <asp:Label runat="server" ID="lblUser"></asp:Label></td>
                    <td style="float: right; border: none">
                        <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                        <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label></td>
                </tr>
            </table>
            <br />
             <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
        </footer>
            </div>

       <asp:Panel ID="pnYesNoModal" runat="server" Width="700" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
    <%--<asp:Panel ID="pnYesNoModal" runat="server" CssClass="input-table col-md-5 center paddinglrb popupBlock" Visible="false">--%>
        <div class="panel panel-primary panel-primary-custom">
            <div class="panel-heading panel-heading-custom">
                <div class="col-md-6 col-sm-6 col-xs-12"><h4 style="float:left">Confirmation</h4></div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:Button ID="btnOK" runat="server" Text="Update" Style="background-color: #0D7B78" class="btn-btn" OnClick="btnOkToReload" />
                    <asp:Button ID="btnNoCancel" runat="server" Text="Cancel" Style="background-color: #0D7B78" class="btn-btn" OnClick="btnCancelToSaveInvoice "/>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class='panel-body'>
                <div id="div_model_content">
                    <b><asp:Label ID="lblMessage" runat="server" Text="Already exists for this month. Do you want to update it?"></asp:Label></b>
                </div>
            </div>
        </div>
    </asp:Panel>

    </div>
    <asp:Button ID="btnHideButton" runat="server" Text="Close" CssClass="hide"  />
     <ajaxToolkit:ModalPopupExtender ID="mpeYesNoModal" runat="server" 
        PopupControlID="pnYesNoModal" TargetControlID="btnHideButton" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>
    <div class="modal fade" id="detail35Modal" role="dialog">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upDetail35Modal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Summary of Net Payable</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th class="text-center">&nbsp;</th>
                                                <th class="text-center">Note</th>
                                                <th class="text-center">&nbsp;</th>
                                                <th class="text-center">Value</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Opening Balance</td>
                                                <td>Note-50</td>
                                                <td>&nbsp;</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="node50Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Supply Output TAX</td>
                                                <td>Note-09</td>
                                                <td>&nbsp;</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="node9Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Total</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="totalOf50and9Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Purchase Input TAX</td>
                                                <td>Note-23</td>
                                                <td>Local Purchase</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="localPurchase23Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Import</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="import23Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>SubTotal</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="subTotal23Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Total</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="total23Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Increasing Adjusment (VAT)</td>
                                                <td>Note-28</td>
                                                <td>&nbsp;</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="node28Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Total</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="node28Total"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Decreasing Adjusment (VAT)</td>
                                                <td>Note-34</td>
                                                <td>&nbsp;</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="node34Value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>Net</td>
                                                <td>Total</td>
                                                <td class="text-right">
                                                    <asp:Label runat="server" ID="node34Total"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                    <uc1:MsgBoxs runat="server" ID="MsgBoxs" />
                 <%--    <uc2:MsgBox ID="msgBox" runat="server" />--%>
                    <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 17.06.2021
            </div>    

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    
    <script>

        function download_csv(csv, filename) {
            var csvFile;
            var downloadLink;
            textEncoder = new TextEncoder('windows-1252');
            var csvContentEncoded = textEncoder.encode([csv]);

            csvFile = new Blob([csvContentEncoded], { type: "text/csv;charset=utf-8,%EF%BB%BF;" });
            downloadLink = document.createElement("a");
            downloadLink.download = filename;
            downloadLink.href = window.URL.createObjectURL(csvFile);
            downloadLink.style.display = "none";
            document.body.appendChild(downloadLink);
            downloadLink.click();

            window.location = "";
        }

        function export_table_to_csv() {
            // var html = document.querySelector("table").outerHTML;
            var filename = "table.csv";
            var csv = [];
            var rows = document.querySelectorAll("table tr");

            for (var i = 0; i < rows.length; i++) {
                var row = [], cols = rows[i].querySelectorAll("td, th");

                // console.log(cols);

                $.each(cols, function (i, n) {
                    var inputs = $(n).find("input");
                    if (inputs.length) {
                        $.each(inputs, function (j, input) {
                            //console.log(input.value);
                            $(input).replaceWith("<span>" + input.value + "</span>");
                        });
                    }

                    row.push(n.innerText);
                });

                csv.push(row.join(","));
            }

            //console.log(csv);
            //return false;

            download_csv(csv.join("\n"), filename);
        }

        // exporting csv end
        // exporting xml start
        function export_table_to_xml () {
            var html = document.querySelectorAll("table");
            var filename = "table.xml";
            var xmlString = "<root>";
            var cnt = html.length;
            var re = new RegExp("&nbsp;", 'g');
            for (var i = 0; i < cnt; i++) {
                var inputs = html[i].querySelectorAll("input");
                for (var j = 0; j < inputs.length; j++) {
                    var inpValue = html[i].querySelectorAll("input")[0].value;
                    var para = document.createElement("span");
                    var node = document.createTextNode(inpValue);
                    para.appendChild(node);
                    html[i].querySelectorAll("input")[0].remove();
                }
                var brs = html[i].querySelectorAll("br");
                for (var j = 0; j < brs.length; j++) {
                    html[i].querySelectorAll("br")[0].remove();
                }
                xmlString += html[i].outerHTML.replace(re, " ");
            }
            xmlString += "</root>";
            
            download_xml(xmlString, filename);
        }

        function download_xml(xml, filename) {
            var xmlFile;
            var downloadLink;
            xmlFile = new Blob([xml], { type: "text/plain;" });
            downloadLink = document.createElement("a");
            downloadLink.download = filename;
            downloadLink.href = window.URL.createObjectURL(xmlFile);
            downloadLink.style.display = "none";
            document.body.appendChild(downloadLink);
            downloadLink.click();
            window.location = "";
        }
        // exporting xml end
    </script>

</asp:Content>

