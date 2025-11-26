<%@ page language="C#" autoeventwireup="true" inherits="Reports_Mushok9_4, App_Web_o1josinq" masterpagefile="~/DashboardVTR.Master" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <style type="text/css">
        .test
        {
            width: 183px;
        }
        .style1
        {
            height: 28px;
        }
        .style2
        {
            height: 27px;
        }
        .style3
        {
            height: 26px;
        }
    </style>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
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
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <script type="text/javascript">
        function FormatIt(obj) {
            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
 
        <asp:Panel ID="pnlContents" runat="server">
            <div class="container-fluid" style="padding: 2%">
                <div class="row">
                    <p style="text-align: center">
                        গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                    <p style="text-align: center">
                        <b><u>জাতীয় রাজস্ব বোর্ড</u></b></p>
                    <p style="border: 1px solid #000; float: right; margin-right: 15px">
                        মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                            font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                            font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                            text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                            background-color: rgb(255, 255, 255); display: inline !important; float: none;">৯</span>.৪</p>
                </div>
                <div>
                </div>
                <div>
                </div>
                <p style="text-align: center">
                    <b><u>সংশোধিত দাখিলপত্র পেশের আবেদন </u></b>
                    <br />
                    [বিধি ৪৯ এর উপ-বিধি (২) দ্রষ্টব্য]
                </p>
                <br />
                <div>
                    <table class="table table-bordered" style="width: 100%; background-color: #cccccc">
                        <tr>
                            <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                                অংশ-১: করদাতার তথ্য
                            </th>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="td-width-30">
                                (১) করদাতার নাম
                            </td>
                            <td class="td-width-2">
                                </td>
                            <td>
                                <asp:Label ID="lblNameApplicant" runat="server" />
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td>
                                (২) ব্যবসায় সনাক্তকরণ সংখ্যা
                            </td>
                            <td>
                                </td>
                            <td>
                                <asp:Label ID="lblBIN" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table class="table table-bordered" style="width: 100%; background-color: #cccccc">
                        <tr>
                            <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                class="style1">
                                অংশ-২: দাখিলপত্র জমার তথ্য
                            </th>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="td-width-30">
                                (১) কর মেয়াদ
                            </td>
                            <td class="td-width-2">
                                
                            </td>
                            <td>
                                <%-- <div style="width: 70%; border: 1px; border-style: solid; float: left;">--%>
                                <asp:DropDownList ID="drpRange" runat="server" Height="25px" Width="100px" 
                                    AutoPostBack="True" onselectedindexchanged="drpRange_SelectedIndexChanged"
                                    >
                                    <asp:ListItem Value="1">মাস - বৎসর</asp:ListItem>
                                    <asp:ListItem Value="2">ত্রৈমাস - বৎসর</asp:ListItem>
                                </asp:DropDownList>
                                <%--   </div>--%>
                                <asp:DropDownList ID="drpRangeMonth" runat="server" Height="25px" Width="100px">
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="drpQuarter" runat="server" Height="25px" Width="100px">
                                    <asp:ListItem Value="1">1st Quarter</asp:ListItem>
                                    <asp:ListItem Value="2">2nd Quarter</asp:ListItem>
                                    <asp:ListItem Value="3">3rd Quarter</asp:ListItem>
                                    <asp:ListItem Value="4">4th Quarter</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="drpRangeYear" runat="server" Height="25px" Width="100px">
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                                    <asp:ListItem>2021</asp:ListItem>
                                    <asp:ListItem>2022</asp:ListItem>
                                    <asp:ListItem>2023</asp:ListItem>
                                    <asp:ListItem>2024</asp:ListItem>
                                    <asp:ListItem>2025</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td>
                                (২) দাখিলের তারিখ
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                <div style="width: 95%; float: left">
                                    <asp:TextBox ID="txtDate_Of_Submission" runat="server" type="text" Width="500px"
                                        onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"
                                        placeholder="Enter Date"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDate_Of_Submission"
                                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                        ErrorMessage="Invalid date format." CssClass="litMessage" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table class="table table-bordered" style="width: 100%; background-color: #cccccc">
                        <tr>
                            <th colspan="5" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                class="style4">
                                অংশ-৩: সংশোধিত দাখিল পত্র পেশের তথ্য
                            </th>
                        </tr>
                        <tr style = "width:100%; background-color:White">
                            <td class="style1" align="center" style = "width:15%">
                                <strong>সংশোধনের প্রকৃতি (১) </strong>
                            </td>
                            <td class="style1" align="center" style = "width:25%">
                                <strong>আইটেম নং (২)</strong>
                            </td>
                            <td class="style1" align="center" style = "width:15%">
                                <strong>বিদ্যমান তথ্য (৩)</strong>
                            </td>
                            <td class="style1" align="center" style = "width:15%">
                                <strong>সংশোধিত তথ্য (৪)</strong>
                            </td>
                            <td align="center" class="style1" style = "width:30%">
                                <strong>সংশোধনের কারণ (৫)</strong>
                            </td>
                        </tr>

                        <tr style = "background-color:White">
                            <td class="style3" align="center" >
                                <asp:DropDownList ID="drpCorrectionType" runat="server" class="drop-down" Height = "40px" Width = "100%"
                                        data-toggle="dropdown">
                                    </asp:DropDownList>
                                    
                            </td>
                            <td class="style3" align="center">
                                <asp:DropDownList ID="drpItemNo" runat="server" class="drop-down" Height = "40px" Width = "100%"
                                        data-toggle="dropdown" AutoPostBack="True" 
                                    onselectedindexchanged="drpItemNo_SelectedIndexChanged" >
                                    </asp:DropDownList>
                            </td>
                            <td class="style3" align="center">
                                <asp:Label ID="lblExistingInfo" runat="server" type="text" class="form-input" Height = "21px" Width = "100%"/>
                                
                            </td>
                            <td class="style3" align="center">
                                <asp:TextBox runat="server" type="text" class="form-input" ID="txtUpdatedInfo"  Height = "40px" Width = "100%" placeholder="0.00"></asp:TextBox>
                                
                            </td>
                            <td align="center" class="style15" rowspan="3">

                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtUpdateReason" Height = "40px" Width = "100%" 
                                    placeholder="Enter Here" TextMode="MultiLine" MaxLength="999"></asp:TextBox>
                               </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="style2" align="center" >
                                <strong></strong>
                            </td>
                            <td class="style2" align="center">
                                <strong></strong>
                            </td>
                            <td class="style2" align="center">
                                <strong></strong>
                            </td>
                            <td class="style2" align="center">
                                <strong></strong>
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="style10" align="center">
                                <strong></strong>
                            </td>
                            <td class="style11" align="center">
                                <strong></strong>
                            </td>
                            <td class="style14" align="center">
                                <strong></strong>
                            </td>
                            <td class="style13" align="center">
                                <strong></strong>
                            </td>
                        </tr>
                        <tr>
                            <asp:Label runat="server" ID="lblBankInfoShow"></asp:Label></tr>
                        <%--  <tr>
                        <td class="style10" align="center">
                            1.
                        </td>
                        <td class="style11">
                            <asp:Label runat="server" ID="lblBankInfoAccountName" />
                        </td>
                        <td class="style14">
                            <asp:Label runat="server" ID="lblBankInfoAccountNumber" />
                        </td>
                        <td class="style13">
                            <asp:Label runat="server" ID="lblBankInfoBankName" />
                        </td>
                        <td class="style15">
                            <asp:Label runat="server" ID="lblBankInfoBranchName" />
                        </td>
                    </tr>--%>
                    </table>
                </div>
                <div style="margin-top: 40px">
                    <table class="table table-bordered" style="width: 100%; background-color: #cccccc">
                        <tr>
                            <th colspan="3" style="text-align: center; background-color: #cccccc">
                                অংশ-৪: ঘোষণা
                            </th>
                        </tr>
                        <tr style = "background-color:White">
                            <td colspan="3">
                                আমরা ঘোষণা করিতেছি যে, এই দাখিলপত্রে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="td-width-20">
                                নাম
                            </td>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lblEmployeeName" />
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="td-width-20">
                                পদবী
                            </td>
                            <td class="td-width-40">
                                <asp:Label ID="lblDesignation" runat="server" />
                            </td>
                            <td rowspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="td-width-20">
                                তারিখ
                            </td>
                            <td class="td-width-40">
                                <asp:Label runat="server" ID="lblDate" />
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="td-width-20">
                                মোবাইল নম্বর
                            </td>
                            <td class="td-width-40">
                                <asp:Label runat="server" ID="lblMobileNo" />
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="td-width-20">
                                ইমেইল
                            </td>
                            <td class="td-width-40">
                                <asp:Label runat="server" ID="lblMail" />
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td style="border: 0px">
                            </td>
                            <td style="border: 0px">
                            </td>
                            <td style="text-align: center">
                                স্বাক্ষর
                            </td>
                        </tr>
                    </table>
                </div>
                 
              
        
        <div>
       
        <uc2:msgbox ID="msgBox" runat="server" />
        </div>
        </div>
        </asp:Panel>
          <div class="container-fluid" style="padding: 2%">
            <div>
                    <div style="height: 30px;">
                        <asp:Button ID="printButton" runat="server" Font-Bold="True" OnClientClick="return PrintPanel();"
                            Style="float: right" Text="Print" Width="72px" />
                        <%--  <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
                            Style="float: right"  />--%>
                        <asp:Button ID="btnSave" runat="server" Font-Bold="True" Style="float: right" Text="Save"
                            Width="72px" onclick="btnSave_Click" />
                    </div>
                  
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </div>
          </div>
 
</asp:Content>
