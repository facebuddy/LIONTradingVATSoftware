<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok18_3, App_Web_o1josinq" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
                        দাপ্তরিক নাম, লগো ঠিকানা</p>
                </div>
                <div class="row">
                    <p style="border: 1px solid #000; float: right; margin-right: 15px">
                        মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                            font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                            font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                            text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                            background-color: rgb(255, 255, 255); display: inline !important; float: none;">১৮.৩</span></p>
                </div>
                <div style="height: 10px">
                </div>
                <div class="row">
                    <p style="text-align: center">
                        <b><u>মূসক ছাড়পত্র প্রাপ্তির আবেদনপত্র</u></b>
                    </p>
                    <p style="text-align: center">
                        [বিধি ১১৬ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
                </div>
                <div style="height: 10px">
                </div>
                <div class="row">
                    <p style="text-align: left">
                    </p>
                    <p style="text-align: left">
                        তারিখঃ&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtApplicationDate" runat="server" placeholder="Enter Here" onkeydown="return (event.keyCode!=13);"
                            onkeyup="FormatIt(this);" MaxLength="10" Width="90px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtApplicationDate"
                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                            ErrorMessage="Invalid date format." CssClass="litMessage" />
                    </p>
                </div>
                <div class="row">
                    <p style="text-align: left">
                    </p>
                    <p style="text-align: left">
                        বরাবর
                    </p>
                    <p style="text-align: left">
                        কমিশনার
                    </p>
                    <p style="text-align: left">
                        কাস্টমস, এক্সাইজ ও ভ্যাট কমিশনারেট, <asp:DropDownList ID="drpCircle" runat="server" Style="text-align: center" Height="25px"
                                Width="300px">
                            </asp:DropDownList>
                        </p>
                    <p style="text-align: left">
                        <b>বিষয়ঃ মুসক ছাড়পত্র প্রাপ্তির আবেদনপত্র</b>
                    </p>
                    <br />
                    <p style="text-align: left">
                    </p>
                    <p style="text-align: left">
                        জনাব,&nbsp;&nbsp;
                    </p>
                    <p style="text-align: left">
                        আমি&nbsp;
                        <asp:Label ID="lblAppName" runat="server" Style="text-align: center" MaxLength="10"
                            Width="200px"></asp:Label>
                        &nbsp;আপনার কর্মএলাকায় নিবন্ধিত একটি মূল্য সংযোজন করযোগ্য ব্যবসায় নিয়োজিত এবং নিয়মিত
                        করদাতা। মূল্য সংযোজন কর ও সম্পূরক শুল্ক আইন, ২০১২ এবং মূল্য সংযোজন কর ও সম্পূরক
                        শুল্ক বিধিমালা, ২০১৬ এর আওতায় আমার বিরুদ্ধে কোনো অভিযোগ নাই। আমার নিকট উক্ত আইন
                        ও বিধিমালার আওতায় সরকারের কোনো বকেয়া কর পাওনা নাই।
                    </p>
                    <p style="text-align: left">
                        নিম্নবর্ণিত কারণে আমার একটি মূসক ছাড়পত্রের প্রয়োজন, যথাঃ
                    </p>
                    <table class="table table-bordered" style="width: 500px; margin-left: 41px">
                        <tr style = "background-color:White">
                            <td class="style17">
                                (ক)
                            </td>
                            <td class="style16">
                                <asp:TextBox ID="txtka" runat="server" type="text" Width="700px" placeholder="Enter Here"
                                    MaxLength="499"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style = "background-color:White">
                            <td class="style17">
                                (খ)
                            </td>
                            <td class="style16">
                                <asp:TextBox ID="txtkha" runat="server" type="text" Width="700px" placeholder="Enter Here"
                                    MaxLength="499"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <p style="text-align: left">
                        এমতাবস্থায়, আমার অনুকূলে একটি মূসক ছাড়পত্র জারি করিতে অনুরোধ করা হইল।
                    </p>
                </div>
                <div>
                </div>
                <div class="row">
                    <div>
                        <div style="text-align: left">
                            <p style="text-align: left">
                                ৪। ঘোষণা<br />
                                <br />
                                আমি ঘোষণা করিতাছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও
                                <br />
                                নির্ভুল।
                                <br />
                                <br />
                                <div>
                                    <p>
                                        নাম&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                                            ID="txtEmployeeName" runat="server" type="text" Width="700px" style = "margin-left:11px" ReadOnly="True"></asp:TextBox>
                                    </p>
                                </div>
                                <p>
                                    ঠিকানা&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                                        ID="txtApplicant_Name_Address" style = "margin-left:8px" runat="server" type="text" Width="700px" ReadOnly="True"></asp:TextBox>
                                </p>
                                <p>
                                    বিআইএন&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtApplicantBin_Phone" runat="server" type="text" Width="700px"
                                        ReadOnly="True"></asp:TextBox>
                                    <br />
                                    <br />
                                </p>
                                <p>
                                    &nbsp;</p>
                        </div>
                    </div>
                    
                </div>
            </div>
       
       
        </asp:Panel>

         <div class="container-fluid" style="padding: 2%">

         <div style="height: 30px">
                        <asp:Button ID="printButton" runat="server" Text="Print" Width="72px" Font-Bold="True"
                            Style="float: right" OnClientClick="return PrintPanel();" />
                        <%--  <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
                            Style="float: right"  />--%>
                        <asp:Button ID="btnSave" runat="server" Font-Bold="True" Style="float: right" Text="Save"
                            Width="72px" OnClick="btnSave_Click" />
                    </div>

                         <div class="col-sm-2">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>
         </div>

    
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <body>
            <asp:Panel ID="pnlContents1" runat="server">
                <div>
                    <div class="container-fluid" style="padding: 2%">
                        <div class="row">
                            <p style="text-align: center">
                                দাপ্তরিক নাম, লগো ঠিকানা</p>
                        </div>
                        <div class="row">
                            <p style="border: 1px solid #000; float: right; margin-right: 15px">
                                মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                                    font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                                    font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                                    text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                                    background-color: rgb(255, 255, 255); display: inline !important; float: none;">১৮.৩</span></p>
                        </div>
                        <div style="height: 10px">
                        </div>
                        <div class="row">
                            <p style="text-align: center">
                                <b><u>মূসক ছাড়পত্র প্রাপ্তির আবেদনপত্র</u></b>
                            </p>
                            <p style="text-align: center">
                                [বিধি ১১৬ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
                        </div>
                        <div style="height: 10px">
                        </div>
                        <div class="row">
                            <p style="text-align: left">
                            </p>
                            <p style="text-align: left">
                                তারিখঃ&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label3" runat="server" Style="text-align: center" MaxLength="10" Width="200px"></asp:Label>
                            </p>
                        </div>
                        <div class="row">
                            <p style="text-align: left">
                            </p>
                            <p style="text-align: left">
                                বরাবর
                            </p>
                            <p style="text-align: left">
                                কমিশনার
                            </p>
                            <p style="text-align: left">
                                কাস্টমস, এক্সাইজ ও ভ্যাট কমিশনারেট,
                                <asp:TextBox ID="TextBox2" runat="server" type="text" Width="200px" placeholder="Enter Here"></asp:TextBox>
                            </p>
                            <p style="text-align: left">
                                <b>বিষয়ঃ মুসক ছাড়পত্র প্রাপ্তির আবেদনপত্র</b>
                            </p>
                            <br />
                            <p style="text-align: left">
                            </p>
                            <p style="text-align: left">
                                জনাব,&nbsp;&nbsp;
                            </p>
                            <p style="text-align: left">
                                আমি&nbsp;
                                <asp:Label ID="Label1" runat="server" Style="text-align: center" MaxLength="10" Width="200px"></asp:Label>
                                &nbsp;আপনার কর্মএলাকায় নিবন্ধিত একটি মূল্য সংযোজন করযোগ্য ব্যবসায় নিয়োজিত এবং নিয়মিত
                                করদাতা। মূল্য সংযোজন কর ও সম্পূরক শুল্ক আইন, ২০১২ এবং মূল্য সংযোজন কর ও সম্পূরক
                                শুল্ক বিধিমালা, ২০১৬ এর আওতায় আমার বিরুদ্ধে কোনো অভিযোগ নাই। আমার নিকট উক্ত আইন
                                ও বিধিমালার আওতায় সরকারের কোনো বকেয়া কর পাওনা নাই।
                            </p>
                            <p style="text-align: left">
                                নিম্নবর্ণিত কারণে আমার একটি মূসক ছাড়পত্রের প্রয়োজন, যথাঃ
                            </p>
                            <table class="table table-bordered" style="width: 500px; margin-left: 41px">
                                <tr style = "background-color: White">
                                    <td class="style17" >
                                        (ক)
                                    </td>
                                    <td class="style16">
                                        <asp:TextBox ID="TextBox3" runat="server" type="text" Width="700px" placeholder="Enter Here"
                                            MaxLength="499"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style = "background-color: White">
                                    <td class="style17">
                                        (খ)
                                    </td>
                                    <td class="style16">
                                        <asp:TextBox ID="TextBox4" runat="server" type="text" Width="700px" placeholder="Enter Here"
                                            MaxLength="499"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <p style="text-align: left">
                                এমতাবস্থায়, আমার অনুকূলে একটি মূসক ছাড়পত্র জারি করিতে অনুরোধ করা হইল।
                            </p>
                        </div>
                        <div>
                        </div>
                        <div class="row">
                            <div>
                                <div style="text-align: left">
                                    <p style="text-align: left">
                                        ৪। ঘোষণা<br />
                                        <br />
                                        আমি ঘোষণা করিতাছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও
                                        <br />
                                        নির্ভুল।
                                        <br />
                                        <br />
                                        <div>
                                            <p>
                                                নাম&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                                                    ID="TextBox5" runat="server" type="text" Width="700px" ReadOnly="True"></asp:TextBox>
                                            </p>
                                        </div>
                                        <p>
                                            ঠিকানা&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                                                ID="TextBox6" runat="server" type="text" Width="700px" ReadOnly="True"></asp:TextBox>
                                        </p>
                                        <p>
                                            বিআইএন&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="TextBox7" runat="server" type="text" Width="700px" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <br />
                                        </p>
                                        <p>
                                            &nbsp;</p>
                                        <p>
                                            <br />
                                        </p>
                                </div>
                            </div>
                            <div style="height: 30px">
                                <%--  <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
                            Style="float: right"  />--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <uc2:MsgBox ID="msgBox" runat="server" />
            </asp:Panel>
        </body>
    </asp:Panel>
</asp:Content>
