<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_AtActualComparison, App_Web_o1josinq" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="/resources/demos/style.css">
    <link href="../../Styles/panel.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>

    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=print.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            //printWindow.document.write('</head><body style="margin: 20px;">');
            printWindow.document.write('</head><body style="margin: 20px;font-size:smaller;">');
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%;">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Actual Consumption Report
                </div>


                <div class="panel panel-primary" style="font-family: Nikosh">
                    <div class="panel panel-body">
                        <div class="col-md-12">
                            <div class="row">

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label"><span class="required">* </span>পণ্য :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpItem" runat="server" Width="100%" CssClass="select2" Height="25px" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label"><span class="required">* </span>মূল্য ঘোষণা নম্বর:</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpPriceDecNo" runat="server" Width="100%" CssClass="select2"
                                                Height="25px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Issue Challan No :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList class="form-control select2" ID="ddlProvidedChallan" runat="server"></asp:DropDownList>
                                       <asp:Label runat="server" ID="priceDecId" CssClass="hiddencol"></asp:Label>
                                            </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Receive Challan No :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList class="form-control select2" ID="ddlReceiveChallan" runat="server"></asp:DropDownList>
                                      
                                            </div>
                                    </div>
                                </div>
                               <div class="col-md-4">
                                    <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn-btn" Style="background-color: #59BA68;" OnClick="btnReport_Click" />
                                    
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-btn" Style="background-color: #65C2DD;" OnClientClick="return PrintPanel();" Width="64px" />
                                </div>
                            </div>
                                
                            </div>
                        
                        </div>
                   </div>

                </div>
            </div>
        </div>
     
            <div  runat="server" id="print" visible="false">
                  
                                    <table border="1" class="allSolid" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                            <th colspan="7" style="text-align:center;background-color:#a5dce6;">একক পণ্য উৎপাদনে ব্যবহার্য  উপকরণ/ কাঁচামালের পরিমান (উপকরণভিত্তিক অপচয়ের শতকরা হারসহ)</th>
                                               <th colspan="6" style="text-align:center;background-color:#8d9154;">As per 4.3 Price Declaraion</th>
                                            <th colspan="6" style="text-align:center;background-color:#b9ebc4;">At Actual</th>
                                              <th colspan="6" style="text-align:center;background-color:#d2d69c;">Difference</th>
                                         </tr>
                                            <tr style="background-color: white; text-align: center; font-size: 12px;">
                                                <th class="col_3_percent" style=": normal; background-color: #a5dce6; text-align: center">উৎপাদনে ব্যবহৃত উপকরণ সমূহের নাম </th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #a5dce6; text-align: center">গ্রস ব্যবহার</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #a5dce6; text-align: center">একক (গ্রস ব্যবহার)</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #a5dce6; text-align: center">অপচয় %</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #a5dce6; text-align: center">অপচয়</th>
                                                <th class="col_5_percent" style="font-weight: normal; background-color: #a5dce6; text-align: center">নীট ব্যবহার</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #a5dce6; text-align: center">নীট ব্যবহারের  একক</th>

                                                <th class="col_3_percent" style="font-weight: normal; background-color: #8d9154; text-align: center">গ্রস ব্যবহার</th>
                                                <th class="col_3_percfont-weightent" style="font-weight: normal; background-color: #8d9154; text-align: center">একক (গ্রস ব্যবহার)</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #8d9154; text-align: center">অপচয় %</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #8d9154; text-align: center">অপচয়</th>
                                                <th class="col_5_percent" style="font-weight: normal; background-color: #8d9154; text-align: center">নীট ব্যবহার</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #8d9154; text-align: center">নীট ব্যবহারের  একক</th>



                                              
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #b9ebc4; text-align: center">গ্রস ব্যবহার</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #b9ebc4; text-align: center">একক (গ্রস ব্যবহার)</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #b9ebc4; text-align: center">অপচয় %</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #b9ebc4; text-align: center">অপচয়</th>
                                                <th class="col_5_percent" style="font-weight: normal; background-color: #b9ebc4; text-align: center">নীট ব্যবহার</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #b9ebc4; text-align: center">নীট ব্যবহারের  একক</th>



                                                <%--<th class="col_3_percent" style="font-weight: normal; background-color: #CBAA90; text-align: center">উৎপাদনে ব্যবহৃত উপকরণ সমূহের নাম </th>--%>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #d2d69c; text-align: center">গ্রস ব্যবহার</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #d2d69c; text-align: center">একক (গ্রস ব্যবহার)</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #d2d69c; text-align: center">অপচয় %</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #d2d69c; text-align: center">অপচয়</th>
                                                <th class="col_5_percent" style="font-weight: normal; background-color: #d2d69c; text-align: center">নীট ব্যবহার</th>
                                                <th class="col_3_percent" style="font-weight: normal; background-color: #d2d69c; text-align:center">নীট ব্যবহারের  একক</th>
                                        
                                            </tr>
                                                </thead>
                                       
                                        <tbody style="font-size: 11px;">

                                            <tr style=" text-align: center;">
                                                <td style="background-color: #a5dce6;">(১)</td>
                                                <td style="background-color: #a5dce6;">(২)</td>
                                                <td style="background-color: #a5dce6;">(৩)</td>
                                                <td style="background-color: #a5dce6;">(৪)</td>
                                                <td style="background-color: #a5dce6;">(৫)</td>
                                                <td style="background-color: #a5dce6;">(৬)</td>
                                                <td style="background-color: #a5dce6;">(৭)</td>
                                                <td style="background-color: #8d9154;">(৮)</td>
                                                <td  style="background-color: #8d9154;">(৯)</td>
                                                <td  style="background-color: #8d9154;">(১০)</td>
                                                <td  style="background-color: #8d9154;">(১১)</td>
                                                <td  style="background-color: #8d9154;">(১২)</td>
                                                <td  style="background-color: #8d9154;">(১৩)</td>
                                                <td  style="background-color: #b9ebc4;">(১৪)</td >
                                                <td style="background-color: #b9ebc4;">(১৫)</td>
                                                <td style="background-color: #b9ebc4;">(১৬)</td>
                                                <td style="background-color: #b9ebc4;">(১৭)</td>
                                                <td style="background-color: #b9ebc4;">(১৮)</td>
                                                <td  style="background-color: #b9ebc4;">(১৯)</td>
                                                 <td style="background-color: #d2d69c;">(২০)</td>
                                                <td style="background-color: #d2d69c;">(২১)</td>
                                                <td style="background-color: #d2d69c;">(২২)</td>
                                                <td style="background-color: #d2d69c;">(২৩)</td>
                                                <td style="background-color: #d2d69c;">(২৪)</td>
                                                <td style="background-color: #d2d69c;">(২৫)</td>

                                            </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblInfoShow" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>  
                                   
  
                       </asp:Content>
