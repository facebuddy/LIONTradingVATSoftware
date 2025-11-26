<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_RawMaterialConsumptionReport, App_Web_y1tsx4fu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
    </style>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=bill.ClientID %>");
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
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold;
                    height: 30px; padding-top: 0px">
                    Raw Material Consumption Report</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row" style="margin-top: 1%">

                      <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Date From:</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox ID="dtpDateFrom" runat="server" class="form-control" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" MaxLength="10" placeholder="DD/MM/YYYY"></asp:TextBox>
                            <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                            <asp:Label ID="lblfromDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                      <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Date To:</label>
                            <div class="col-sm-7 m">
                                <asp:TextBox  ID="dtpDateTo" runat="server" class="form-control" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" MaxLength="10" placeholder="DD/MM/YYYY"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                            <asp:Label ID="lblToDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                      <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Challan Number:</label>
                            <div class="col-sm-7 m">
                               <asp:TextBox runat="server" ID="txtChallanNumber" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                                           
                    </div>
                    <div class="row">

                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Ingredience :</label>
                            <div class="col-sm-7 m">
                                <asp:DropDownList runat="server" ID="drpIngredient" CssClass="form-control select2">
                            </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right">Finish Product Production :</label>
                            <div class="col-sm-7 m">
                                <asp:DropDownList runat="server" ID="drpFinishedProduct" CssClass="form-control select2">
                            </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                 
                        <div class="col-sm-4" style="text-align:right">
                             <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                            <asp:Button ID="btnShowReport" runat="server" CssClass="btn-btn" OnClick="btnShowReport_Click"
                                Text="Show Report" Style="background-color:#5CB85C;" />
                              <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" OnClick="btnSearch_Click"
                                Text="Search" Style="background-color:#337ab7;" />
                        </div>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator>
                    </div>

                    <%--suggested by Ruhul vai to add this dropdown to use as search filter by sabbir 27/2/20--%>
                    <div class="row" style=" margin-bottom: 4px">
                   
                     </div>

                </div>
            </div>
            <div id="bill" runat="server" visible="true" class="container-fluid" style="margin-top: 2%;font-family:Nikosh;font-size:12px">
                <div class="row">
                    <p style="text-align: center">
                        <asp:Label runat="server" ID="lblOrgName" Style="font-size: 20px; font-weight: bold" /></p>
                    <p style="text-align: center">
                        BIN:&nbsp<asp:Label runat="server" ID="lblOrgBin" /></p>
                    <p style="text-align: center; font-weight: bold">
                        Raw Material Consumption Report</p>
                </div>
                <div class="row" style="margin-top: 3%">
                    <p>
                        <asp:Label runat="server" ID="lblParamaters" /></p>
                </div>
                <div class="row">
                    <table class="table table-bordered" style="width: 100%; background: none">
                        <tr>

                            <td style="text-align: center;">
                                চালান ধরন
                            </td>

                            <td style="text-align: center;">
                                চালান নং
                            </td>
                            <td style="text-align: center;">
                                চালান তারিখ
                            </td>
                            <td style="text-align: center;">
                                প্রারম্ভিক জের
                            </td>
                            <td style="text-align: center;">
                                পণ্যের নাম
                            </td>
                            <td style="text-align: center">
                                পণ্যের একক
                            </td>
                           <%-- <td style="text-align: center;">
                                ইস্যু পরিমাণ
                            </td>--%>

                            <%--<td style="text-align: center">
                                উৎপাদিত পণ্যের জন্য পরিমান
                            </td>--%>

                            <td style="text-align: center">
                                উৎপাদিত পণ্যের পরিমান
                            </td>
                            <td style="text-align: center">
                                ব্যবহারের পরিমাণ
                            </td>
                            <td style="text-align: center">
                                অপচয়%
                            </td>
                            <td style="text-align: center">
                                অপচয় পরিমাণ
                            </td>

                           <%-- <td style="text-align: center">
                                WIP quantity
                            </td>--%>

                           <%-- <td style="text-align: center">
                                মজুদের পরিমাণ
                            </td>--%>
                        </tr>
                        <tr>
                            <asp:Label runat="server" ID="lblFinishProductRpt" />
                        </tr>
                    </table>
                </div>
            </div>
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-default"
                Style="float: right" OnClientClick="return PrintPanel();" />
        </div>
    </div>
</asp:Content>
