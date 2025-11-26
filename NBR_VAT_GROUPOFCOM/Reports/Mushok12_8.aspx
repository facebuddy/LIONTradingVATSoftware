<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok12_8, App_Web_y1tsx4fu" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
     <script type = "text/javascript">
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
            height: 27px;
        }
        .style2
        {
            height: 25px;
        }
    </style>
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
  
        <asp:Panel id="pnlContents" runat = "server">
            <div>
                <div class="container-fluid" style="padding: 2%">
                <div class="row"><p style="border: 1px solid #000; float: right; margin-right: 15px">
                            মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                                font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                                font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                                text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                                background-color: rgb(255, 255, 255); display: inline !important; float: none;">১২.৮</span></p>
                                </div>
                                <div style="height: 10px">
                    </div>
                    <div class="row">
                        
                        <p style="text-align: center">
                          <b>  জব্দকৃত যানবাহন অন্তর্বর্তীকালীন ছাড়ের জন্য ব্যক্তিগত মুচলেকা </b></p>
                        <p style="text-align: center">
                            [বিধি ৬৩ এর উপ-বিধি (৩) এর দফা (খ) দ্রষ্টব্য]</p>
                              <p style="text-align: center">
                            <u>অংশ-ক</u></p>
                        <p style="text-align: center">
                            [আবেদনকারী কর্তৃক পূরণীয়]</p>
                            </div>
                        
                    
                    <div class="row">
                        <p style="text-align: left">
                        </p>
                        
                       
                        <p style="text-align: left">
                        </p>
                        <p style="text-align: left">
                           
                        </p>
                        <p style="text-align: left">
                           &nbsp;&nbsp;
                            
                        </p>
                        <p style="text-align: left">
                            আমি/আমার (যানবাহনের মালিকের/মালিকগণের নাম, প্রতিষ্ঠানের নিবন্ধন নম্বর ও ঠিকানা) 
                        <%--</p>
                         <p style="text-align: left">--%>
                            <asp:TextBox ID="txtgeneral_description" runat="server" type="text" Width="100%" 
                                 placeholder="Enter Here" TextMode="MultiLine" MaxLength="999"></asp:TextBox>
                        <%--</p>
                         <p style="text-align: left">--%>
                         মূল্য সংযোজন কর ও সম্পূরক শুল্ক বিধিমালা, ২০১৬ এর বিধি ৬৩ মোতাবেক নিম্নবর্ণিত যানবাহনের অন্তর্বর্তীকালীন ছাড় প্রদানের জন্য আবেদন পূর্বক কমিশনার, কাস্টমস, এক্সাইজ ও ভ্যাট কমিশনারেট, (অফিসের নাম) 
                         <%--</p>
                         <p>--%>
                            <asp:TextBox ID="txtcorporate_office_name" runat="server" type="text" Width="500px" 
                                placeholder="Enter Here" MaxLength="199"></asp:TextBox> 
                             &nbsp;এর মাধ্যমে গণপ্রজাতন্ত্রী বাংলাদেশ সরকার বরাবরে এইমর্মে অঙ্গীকারনামা প্রদান 
                             করিতাছি যে, (১) আটককৃত যানবাহন সংশ্লিষ্ট মামলার ন্যায় নির্ণয়নের প্রয়োজনে ন্যায় 
                             নির্ণয়কারী কর্মকর্তা কর্তৃক নির্দেশিত স্থান, সময় ও পদ্ধতিতে যানবাহনুটি উপস্থাপন 
                             করিতে বাধ্য থাকিব এবং উত্তররূপে উপস্থাপন করিতে ব্যর্থ হইলে মূল্য সংযোজন কর 
                             কর্তৃপক্ষ কর্তৃক গৃহীত আইনানুগ ব্যবস্থা নিঃশর্তভাবে মানিয়া নিব, এবং (২) ন্যায় 
                             নির্ণয়কারী কর্মকর্তার দপ্তরে মামলার ন্যায় নির্ণয়ন সম্পর্কিত সকল সহায়তা প্রদান 
                             করিতে বাধ্য থাকিব।
                         </p>
                    </div>
                    <div style="height: 10px">
                    </div>
                    <div>
                        <table class="table table-bordered" style="width: 100%; margin-left: 22px">
                            <tr>
                                <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                    class="style4">
                                   ২।  আটককৃত পণ্য/যানবাহন সম্পর্কৃত তথ্যাবলিঃ
                                </th>
                            </tr>
                            <tr>
                                <td class="style17">
                                   (১) আটক মামলা নম্বরঃ
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtCaseNo" runat="server" type="text" Width="500px" 
                                        placeholder="Enter Here" MaxLength="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    (২)  যানবাহনঃ
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtMamlaNo0" runat="server"
                                        type="text" Width="100%" Enabled="False"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td class="style17" align="left" style="padding-left:100px">
                                    (ক) যানবাহনের ধরন 
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtvehicle_type" runat="server" type="text" Width="500px" 
                                        placeholder="Enter Here"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17" align="left" style="padding-left:100px"">
                                    (খ) মডেল ও তৈরির সন 
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtModel_Year" runat="server" type="text" Width="500px" onkeypress="return isNumberKey(event)"
                                        placeholder="Enter Here" Height="25px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17" align="left" style="padding-left:100px">
                                    (গ) চেসিস নম্বর 
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtChesisNo" runat="server" type="text" Width="500px" 
                                    onkeypress="return isNumberKey(event)"    placeholder="Enter Here" 
                                        MaxLength="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17" align="left" style="padding-left:100px">
                                    (ঘ) ইঞ্জিন নম্বর 
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtEngineNo" runat="server" type="text" Width="500px" 
                                     onkeypress="return isNumberKey(event)"   placeholder="Enter Here" 
                                        MaxLength="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17" align="left" style="padding-left:100px">
                                    (ঙ) রেজিস্ট্রেশনের স্থান  
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtPlaceOfRegistration" runat="server" type="text" 
                                        Width="500px" placeholder="Enter Here" MaxLength="99"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17" align="left" style="padding-left:100px">
                                    (চ) রেজিস্ট্রেশনের নম্বর 
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtRegistrationNo" runat="server" type="text" Width="500px" 
                                     onkeypress="return isNumberKey(event)"   placeholder="Enter Here" 
                                        MaxLength="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17" align="left" style="padding-left:100px">
                                    (ছ) রেজিস্ট্রেশনের মেয়াদ
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtregistration_expire" runat="server" type="text" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" MaxLength="10"   
                                         Width="500px" placeholder="Enter Date"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtregistration_expire"
                                ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                ErrorMessage="Invalid date format." CssClass="litMessage" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" align="left" style="padding-left:100px">
                                    (জ) মালিকের নাম ও ঠিকানা 
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="txtowner_information" runat="server" type="text" Width="500px" 
                                        placeholder="Enter Here" MaxLength="499"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17" align="left" style="padding-left:100px">
                                    (ঝ) যানবাহনের অন্যান্য বিবরণ (যদি থাকে) 
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtOtherDetails" runat="server" type="text" Width="500px" 
                                        placeholder="Enter Here" MaxLength="499"></asp:TextBox>
                                </td>
                            </tr>
                            
                            
                        </table>
                        
                    </div>
                    <div class="row">
                      <p style="text-align: center">
                           <u>অংশ-খ</u> </p>
                      
                            </div>
                    <div>
                        <div style="text-align: left">
                            <p style="text-align: left">
                                
                                <br />
                                উপরি-উক্ত জব্দকৃত যানবাহন উহার মালিক/মালিকগণের ব্যাক্তিগত জিম্মায় ছাড় প্রদান করা হইল।
                                <br />
                                
                                </p>
                                <br />
                                <p style = "text-align:right">
                                    
                                    ছাড় প্রদানকারী কর্মকর্তার <br />
                              <%--</p>
                                <p style = "text-align:right">--%>
                                 
                                    স্বাক্ষর, তারিখ, নাম ও পদবী
                                </p>
                        </div>
                        <div style = "height:15px"></div>
                    </div>
                    
                </div>
               
            </div>
            </asp:Panel>
        
 <div class="container-fluid" style="padding: 2%">

 <div style="height: 30px">
                        <asp:Button ID="printButton" runat="server" Text="Print" Width="72px" Font-Bold="True"
                            Style="float: right" OnClientClick = "return PrintPanel();" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
                            Style="float: right" onclick="btnSave_Click"  />
                    </div>

                     <div class="col-sm-2">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </div>

 </div>
 
  
</asp:Content>
