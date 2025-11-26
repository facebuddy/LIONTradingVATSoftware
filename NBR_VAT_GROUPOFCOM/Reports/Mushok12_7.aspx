<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok12_7, App_Web_pj2ymx2u" %>

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
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }



        function isAlfa(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }


    </script>
    <style type="text/css">
        .style1
        {
            height: 31px;
        }
    </style>
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
       
            <div>
                <div class="container-fluid" style="padding: 2%">
                    <div class="row">
                        <p style="text-align: center">
                           <b> জব্দকৃত যানবাহন ছাড়করণের আবেদনপত্র </b></p>
                        <p style="text-align: center">
                            [বিধি ৬৩ এর উপ-বিধি (৩) এর দফা (ক) দ্রষ্টব্য]</p>
                        <p style="border: 1px solid #000; float: right; margin-right: 15px">
                            মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                                font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                                font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                                text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                                background-color: rgb(255, 255, 255); display: inline !important; float: none;">১২.৭</span></p>
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
                            কাস্টমস, এক্সাইজ ও ভ্যাট কমিশনারেট,&nbsp;
                            <%--<asp:TextBox ID="txtCircle" runat="server" type="text" Width="200px" 
                                placeholder="Enter Here"></asp:TextBox>--%>
                            <asp:DropDownList ID="drpCircle" runat="server" Style="text-align: center" Height="25px"
                                Width="300px">
                            </asp:DropDownList>
                        </p>
                        <p style="text-align: center">
                            <b>বিষয়ঃ জব্দকৃত যানবাহ ছাড়করণের আবেদনপত্র</b>
                        </p>
                        <p style="text-align: left">
                        </p>
                        <p style="text-align: left">
                            সূত্রঃ
                        </p>
                        <p style="text-align: left">
                            জনাব,&nbsp;&nbsp;
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSeizedDate"
                                ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                ErrorMessage="Invalid date format." CssClass="litMessage" />
                        </p>
                        <p style="text-align: left">
                            বিগত&nbsp;
                            <asp:TextBox ID="txtSeizedDate" runat="server" placeholder="Enter Here" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" MaxLength="10" Width="90px"></asp:TextBox>
                            &nbsp;তারিখে জব্দকৃত নিম্নবর্ণিত যানবাহনটি আমার নামে নিবন্ধিত। আমি নিম্নস্বাক্ষরকারী
                            মূল্য সংযোজন কর ও সম্পূরক শুল্ক আইন, ২০১২ এবং মূল্য সংযোজন কর ও সম্পূরক শুল্ক বিধিমালা,
                            ২০১৬ এর বিধি ৬৩ এর আওতায় যানবাহনটি আমার অনুকূলে ছাড় প্রদানের জন্য বিনীত অনুরোধ করিতেছি।
                        </p>
                    </div>
                    <div style="height: 10px">
                    </div>
                    <div>
                        <table class="table table-bordered" style="width: 100%; margin-left: 22px">
                            <tr>
                                <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                    class="style4">
                                    ০২। জব্দকৃত যানবাহনের
                                </th>
                            </tr>
                            <tr style = "background-color:White">
                                <td class="style17">
                                    (ক) রেজিস্ট্রেশন নম্বরঃ
                                </td>
                                <td class="style16" >
                                    <asp:TextBox ID="txtRegistrationNo" runat="server" type="text" Width="500px" 
                                        placeholder="Enter Here" onkeypress="return isNumberKey(event)" MaxLength="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style = "background-color:White">
                                <td class="style17">
                                    (খ) চেসিস নম্বরঃ
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtChesisNo" onkeypress="return isNumberKey(event)" 
                                        runat="server" type="text" Width="500px" placeholder="Enter Here" 
                                        MaxLength="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style = "background-color:White">
                                <td class="style1">
                                    (গ) ইঞ্জিন নম্বরঃ
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="txtEngineNo" runat="server" 
                                        onkeypress="return isNumberKey(event)" type="text" Width="500px" 
                                        placeholder="Enter Here" MaxLength="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style = "background-color:White">
                                <td class="style17">
                                    (ঘ) যে নামে নিবন্ধিতঃ
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtRegisteredName" onkeypress="return isAlfa(event)"
                                     runat="server" type="text" Width="500px" placeholder="Enter Here" 
                                        MaxLength="49"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="table table-bordered" style="width: 100%; margin-left: 22px">
                            <tr>
                                <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                    class="style4">
                                    ০৩। এই আবেদনের সহিত নিম্নরূপ দলিলাদি সংযুক্ত করা হইলঃ
                                </th>
                            </tr>
                            <tr style = "background-color:White">
                                <td class="style17">
                                    (ক) ফরম “মূসক-১২.৮” এ ব্যক্তিগত মুচলেকা
                                </td>
                                <td class="style16">
                                    <asp:FileUpload ID="KaFileUploadControl" runat="server" />
                                    <asp:Button runat="server" ID="KaUploadButton" Text="Upload" OnClick="KaUploadButton_Click"
                                        Visible="False" />
                                    <br />
                                    <br />
                                    <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " Visible="False" />
                                </td>
                            </tr>
                            <tr style = "background-color:White">
                                <td class="style17">
                                    (খ) যানবাহন নিবন্ধনের দলিলাদি
                                </td>
                                <td class="style16">
                                    <asp:FileUpload ID="KhaFileUploadControl" runat="server" />
                                    <asp:Button runat="server" ID="KhaUploadButton" Text="Upload" OnClick="KhaUploadButton_Click"
                                        Visible="False" />
                                    <br />
                                    <br />
                                    <asp:Label runat="server" ID="Label1" Text="Upload status: " Visible="False" />
                                </td>
                            </tr>
                            <tr style = "background-color:White">
                                <td class="style17">
                                    (গ) জব্দ তালিকা (মূসক- ১২.৩ ) এর প্রতিলিপি।
                                </td>
                                <td class="style16">
                                    <asp:FileUpload ID="GaFileUploadControl" runat="server" />
                                    <asp:Button runat="server" ID="GaUploadButton" Text="Upload" OnClick="GaUploadButton_Click"
                                        Visible="False" />
                                    <br />
                                    <br />
                                    <asp:Label runat="server" ID="Label2" Text="Upload status: " Visible="False" />
                                </td>
                            </tr>
                            <tr style = "background-color:White">
                                <td class="style17">
                                    (ঘ) জাতীয় পরিচয়পত্র/পাসপোর্টের প্রতিলিপি।
                                </td>
                                <td class="style16">
                                    <asp:FileUpload ID="GhaFileUploadControl" runat="server" />
                                    <asp:Button runat="server" ID="GhaUploadButton" Text="Upload" OnClick="GhaUploadButton_Click"
                                        Visible="False" />
                                    <br />
                                    <br />
                                    <asp:Label runat="server" ID="Label3" Text="Upload status: " Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </div>
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
                                        নাম&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                                            ID="txtEmployeeName" runat="server" type="text" Width="500px" placeholder="Enter Name"
                                            ReadOnly="True"></asp:TextBox>
                                    </p>
                                </div>
                                <p>
                                    পদবি&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtDesignation" runat="server" type="text" Width="500px" placeholder="Enter Designation"
                                        ReadOnly="True"></asp:TextBox>
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
                           
                    </div>
                    
                </div>
               
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
            </asp:Panel>

             <div class="container-fluid" style="padding: 2%">
             <div style="height: 30px">
                        <asp:Button ID="printButton" runat="server" Text="Print" Width="72px" Font-Bold="True"
                            Style="float: right" OnClientClick="return PrintPanel();" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
                            Style="float: right" OnClick="btnSave_Click" />
                    </div>

                     <div class="col-sm-2">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </div>
             </div>
      
 
</asp:Content>
