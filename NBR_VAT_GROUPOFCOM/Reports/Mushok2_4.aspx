<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok2_4, App_Web_y1tsx4fu" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%--<head runat="server">--%>
    <title>Mushok-2.4</title>
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
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
    <style type="text/css">
        .style4
        {
            height: 22px;
        }
        
        .test
        {
            width: 183px;
        }
        .style19
        {
            font-size: 11.0pt;
            font-family: Calibri, sans-serif;
            margin-left: 0in;
            margin-right: 0in;
            margin-top: 0in;
            margin-bottom: .0001pt;
        }
    </style>
    <%--</head>--%>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <asp:Panel ID="pnlContents" runat="server">
        <div class="container-fluid" style="padding: 2%">
            <div class="row">
                <p style="text-align: center">
                    গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                <p style="text-align: center">
                    জাতীয় রাজস্ব বোর্ড</p>
                <p style="border: 1px solid #000; float: right; margin-right: 15px">
                    মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                        font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                        font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                        text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                        background-color: rgb(255, 255, 255); display: inline !important; float: none;">২.৪</span></p>
            </div>
            <div style="height: 20px">
            </div>
            <div class="row">
                <p style="text-align: center">
                    <b><u>মূল্য সংযোজন কর নিবন্ধন/টার্নওভার কর তালিকাভুক্তি বাতিল ও কর-প্রকৃতি পরিবর্তনের
                        আবেদনপত্র</u></b>
                </p>
                <p style="text-align: center">
                    [বিধি ৮ এর উপ-বিধি (১) ও বিধি ৯ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
                <p style="text-align: center">
                    [বিধি ৪ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
            </div>
            <div style="height: 10px">
            </div>
            <div>
                <table class="table table-bordered" style="width: 100%">
                    <%--<tr>
                        <th colspan="3" scope="colgroup" style="text-align: center; background-color: white; border-width:0px" >
                           <b>  </b>
                            <br />  <br />
                            
                        </th>
                    </tr>--%>
                    <tr style="background-color: White">
                        <td>
                            <p class="style19">
                                <span lang="BN-BD">১। আবেদনের তারিখ<o:p></o:p></span></p>
                        </td>
                        <td>
                        </td>
                        <td>
                            <div style="width: 88%; float: left">
                                <asp:TextBox ID="txtApplication" runat="server" type="text" Width="500px" onkeydown="return (event.keyCode!=13);"
                                    onkeyup="FormatIt(this);" MaxLength="10" placeholder="Enter Date"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtApplication"
                                    ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                    ErrorMessage="Invalid date format." CssClass="litMessage" />
                            </div>
                            <div style="width: 11; float: right">
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: White">
                        <td>
                            ২। বাতিল কার্যকর হওয়ার তারিখ
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtExecutionDate" runat="server" type="text" Width="500px" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" MaxLength="10" placeholder="Enter Date"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtExecutionDate"
                                ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                ErrorMessage="Invalid date format." CssClass="litMessage" />
                        </td>
                    </tr>
                    <tr style="background-color: White">
                        <td>
                            ৩। আবেদনকারী ব্যক্তির নাম
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblNameApplicant" />
                        </td>
                    </tr>
                    <tr style="background-color: White">
                        <td>
                            ৪। ব্যবসায় সনাক্তকরণ সংখ্যা
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblBIN" />
                        </td>
                    </tr>
                    <tr style="background-color: White">
                        <td>
                            ৫। নিবন্ধন বা তালিকাভুক্তি
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblRegistered_Enlisted" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <div>
                    <table class="table
        table-bordered" style="width: 100%">
                        <tr>
                            <th scope="colgroup" style="text-align: center; background-color: #cccccc" class="style4">
                                ৬। বাতিলের কারণ [প্রযোজ্যটিতে বা প্রযোজ্যগুলোতে টিক (✓) চিহ্ন দিন]
                            </th>
                        </tr>
                        <tr>
                            <asp:GridView ID="grdReason" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                ShowHeader="False" DataKeyNames="code_id_d" Width="100%" Style="width: 100%;
                                margin-left: 0px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid"
                                BorderWidth="1px" CellPadding="3">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkRow" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:BoundField HeaderText="BIN" DataField="Branch_unit_bin" />--%>
                                    <asp:BoundField DataField="code_name" />
                                </Columns>
                            </asp:GridView>
                        </tr>
                        <%--<asp:Label runat="server"
        ID="lblBankInfoShow"></asp:Label>--%>
                    </table>
                    <div style="height: 30px">
                    </div>
                </div>
                <div>
                    <table class="table table-bordered" style="width: 100%">
                        <tr style="background-color: White">
                            <td style="width: 30%" align="left" rowspan="4">
                                ৭। বাতিল পরবর্তী কার্যক্রম
                            </td>
                            <td style="width: 69%" align="left">
                                (ক) নিবন্ধন চূড়ান্ত বাতিলকরণ
                            </td>
                        </tr>
                        <tr style="background-color: White">
                            <td style="width: 69%" align="left">
                                (খ) তালিকাভুক্তি চূড়ান্ত বাতিলকরণ
                            </td>
                        </tr>
                        <tr style="background-color: White">
                            <td style="width: 69%" align="left">
                                (গ) নিবন্ধন বাতিল করিয়া তালিকাভুক্তিকরণ
                            </td>
                        </tr>
                        <tr style="background-color: White">
                            <td style="width: 69%" align="left">
                                (ঘ) তালিকাভুক্তি বাতিল করিয়া নিবন্ধীকরণ
                            </td>
                        </tr>
                        <tr>
                            <asp:Label runat="server" ID="Label1"></asp:Label></tr>
                    </table>
                    <p>
                        ঘোষণা<br />
                        <br />
                        আমি ঘোষণা করিতাছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও
                        <br />
                        নির্ভুল।
                        <br />
                        <br />
                        <div>
                            <p>
                                নাম&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                                    ID="txtEmployeeName" runat="server" type="text" Width="500px" placeholder="Enter Name"
                                    ReadOnly="True"></asp:TextBox>
                            </p>
                        </div>
                        <p>
                            পদবি&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtDesignation" runat="server" type="text" Width="500px" placeholder="Enter
        Designation" ReadOnly="True"></asp:TextBox>
                            <br />
                            <br />
                        </p>
                        <p>
                            &nbsp;</p>
                        <p>
                            <br />
        স্বাক্ষর ও সীল
    
    </p> 
    </div>
    
    </div> </div>
    
    <uc2:MsgBox ID="msgBox" runat="server" />
    </asp:Panel>


     <div class="container-fluid" style="padding: 2%">
     <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
            Style="float: right" OnClick="btnSave_Click" />
        <asp:Button ID="printbutton" runat="server" Text="Print" Width="72px" Font-Bold="True"
            Style="float: right" OnClick="btnSave_Click" OnClientClick="return PrintPanel();" />
            </div>

            <div class="col-sm-2">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
    </div>

     </div>
</asp:Content>
