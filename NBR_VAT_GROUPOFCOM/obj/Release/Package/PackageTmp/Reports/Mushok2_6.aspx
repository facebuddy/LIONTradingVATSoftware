<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok2_6, App_Web_pj2ymx2u" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
                        গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                    <p style="text-align: center">
                        জাতীয় রাজস্ব বোর্ড</p>
                    <p style="border: 1px solid #000; float: right; margin-right: 15px">
                        মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                            font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                            font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                            text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                            background-color: rgb(255, 255, 255); display: inline !important; float: none;">২.৬</span></p>
                </div>
                <div style="height: 20px">
                </div>
                <div class="row">
                    <p style="text-align: center">
                        <b><u>নিবন্ধন/তালিকাভুক্তি পরবর্তী তথ্যের পরিবর্তন বা নূতন তথ্য সংযোজন কমিশনারকে অবহিতকরণ</u></b>
                    </p>
                    <p style="text-align: center">
                        [বিধি ১২ এর উপ-বিধি (২) দ্রষ্টব্য]</p>
                    >
                </div>
                <div style="height: 10px">
                </div>
                <div>
                    <table class="table
                            table-bordered" style="width: 100%">
                        <tr>
                            <td>
                                ব্যবসায় সনাক্তকরণ সংখ্যা
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblBIN" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                আবেদনকারীর নাম
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblNameApplicant" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                তথ্য পরিবর্তনের তারিখ
                            </td>
                            <td>
                            </td>
                            <td>
                                <div style="width: 88%; float: left">
                                    <asp:TextBox ID="txtInformationChangeDate" runat="server" type="text" Width="500px"
                                        onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"
                                        placeholder="Enter Application Date"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtInformationChangeDate"
                                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                        ErrorMessage="Invalid date format." CssClass="litMessage" />
                                </div>
                                <div style="width: 11; float: right">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                আবেদন দাখিলের তারিখ
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtApplicationSubmitionDate" runat="server" type="text" Width="500px"
                                    onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"
                                    placeholder="Rejection Date"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtApplicationSubmitionDate"
                                    ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                    ErrorMessage="Invalid date format." CssClass="litMessage" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <div>
                        <table class="table table-bordered" style="width: 100%">
                            <tr>
                                <th colspan="6" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                    class="style4">
                                    (১) তথ্য পরিবর্তনের ক্ষেত্রে ব্যবহার্য
                                </th>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 33%" align="center">
                                    <strong>তথ্যের শিরোনাম</strong>
                                </td>
                                <td class="style7" style="width: 33%" align="center" colspan="3">
                                    <strong>বর্তমান তথ্য</strong>
                                </td>
                                <td class="style7" style="width: 33%" align="center" colspan="2">
                                    <strong>পরিবর্তিত তথ্য</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 33%" align="center">
                                    <strong>
                                        <asp:DropDownList ID="drpInformationHeadline" runat="server" ReadOnly="true" class="drop-down"
                                            data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpInformationHeadline_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </strong>
                                </td>
                                <td class="style7" style="width: 33%" align="center" colspan="3">
                                    <strong>
                                        <asp:DropDownList ID="drpPresentInformation" runat="server" ReadOnly="true" class="drop-down"
                                            data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </strong>
                                </td>
                                <td class="style7" style="width: 33%" align="center" colspan="2">
                                    <strong>
                                        <asp:DropDownList ID="drpChangedInformation" runat="server" ReadOnly="true" class="drop-down"
                                            data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="lblBranchUnitAdd"></asp:Label></tr>
                            <%-------------------    --%>
                        </table>
                        <div style="height: 30px">
                        </div>
                    </div>
                    <div>
                        <table class="table table-bordered" style="width: 100%">
                            <tr>
                                <th colspan="6" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                    class="style4">
                                    (২) নূতন তথ্য সংযোজনের ক্ষেত্রে ব্যবহার্য
                                </th>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 49%" align="center">
                                    <strong>তথ্যের শিরোনাম</strong>
                                </td>
                                <td class="style7" style="width: 49%" align="center" colspan="3">
                                    <strong>নূতন সংযোজিত তথ্য</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 49%" align="center">
                                    <strong>
                                        <asp:DropDownList ID="drpTwoInformationHeadline" runat="server" ReadOnly="true" class="drop-down"
                                            data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </strong>
                                </td>
                                <td class="style7" style="width: 49%" align="center" colspan="3">
                                    <strong>
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtTwoNewAddedInformation"
                                            placeholder="Enter Information"></asp:TextBox></strong>
                                </td>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="Label1"></asp:Label></tr>
                            <%-------------------    --%>
                        </table>
                        <div style="height: 30px">
                        </div>
                    </div>
                    <div>
                        <table class="table table-bordered" style="width: 100%">
                            <tr>
                                <th colspan="6" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                    class="style4">
                                    (৩) তথ্য বিয়োজনের ক্ষেত্রে ব্যবহার্য
                                </th>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 50%" align="center">
                                    <strong>তথ্যের শিরোনাম</strong>
                                </td>
                                <td class="style7" style="width: 50%" align="center" colspan="3">
                                    <strong>বিয়োজিত তথ্য</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 50%" align="center">
                                    <strong>
                                        <asp:DropDownList ID="drpThreeInformationHeadline" runat="server" ReadOnly="true"
                                            class="drop-down" data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </strong>
                                </td>
                                <td class="style7" style="width: 50%" align="center" colspan="3">
                                    <strong>
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtThreeDeletedInformation"
                                            placeholder="Enter Information"></asp:TextBox></strong>
                                </td>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="Label2"></asp:Label></tr>
                            <%-------------------    --%>
                        </table>
                        <div style="height: 30px">
                        </div>
                    </div>
                    <div>
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
    </asp:Panel>
     

     <div class="container-fluid" style="padding: 2%">
     <div style="height: 30px">
        <asp:Button ID="printButton" runat="server" Text="Print" Width="72px" Font-Bold="True"
            Style="float: right" OnClientClick="return PrintPanel();" OnClick="printButton_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
            Style="float: right" OnClick="btnSave_Click" />
    </div>

    <div class="col-sm-2">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
    </div>
     </div>
</asp:Content>
