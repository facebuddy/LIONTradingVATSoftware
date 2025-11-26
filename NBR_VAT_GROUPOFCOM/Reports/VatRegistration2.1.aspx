<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_VatRegistration2_1, App_Web_o1josinq" %>


 <%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
   
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <style type="text/css">
        .style1
        {
            width: 549px;
        }
        .style2
        {
            width: 549px;
            height: 23px;
        }
        .style3
        {
            height: 23px;
        }
        .style4
        {
            height: 22px;
        }
        .style6
        {
            width: 72px;
        }
        .style7
        {
            height: 22px;
        }
        .style10
        {
            width: 116px;
        }
        .style11
        {
            width: 195px;
        }
        .style13
        {
            width: 221px;
        }
        .style14
        {
            width: 318px;
        }
        .style15
        {
            width: 115px;
        }
        .style16
        {
            width: 358px;
        }
        .style17
        {
            width: 171px;
        }
        .style18
        {
            width: 110px;
        }
        .style19
        {
            width: 419px;
        }
        .style20
        {
            height: 22px;
            width: 419px;
        }
        .style21
        {
            height: 22px;
            width: 214px;
        }
        .style27
        {
            width: 218px;
        }
        .style28
        {
            width: 182px;
        }
        .style30
        {
            width: 85px;
        }
                
        .test
        {
            width: 183px;
        }
        .style33
        {
            width: 30%;
            height: 37px;
        }
        .style34
        {
            width: 2%;
            height: 37px;
        }
        .style35
        {
            height: 37px;
        }
    </style>

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
    </script>
 </asp:Content>


 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>

<body>
<asp:Panel id="pnlContents" runat = "server">
  
    <div class="container-fluid" style="padding: 2%">
        <div class="row">
            <p style="text-align: center">
                গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
            <p style="text-align: center">
                জাতীয় রাজস্ব বোর্ড</p>
            <p style="text-align: center">
                মূল্য সংযোজন কর</p>
          <%--  <p style="text-align: center">
                [বিধি
            </p>--%>
            <p style="border: 1px solid #000; float: right; margin-right: 15px">
                মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                    font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                    font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                    text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                    background-color: rgb(255, 255, 255); display: inline !important; float: none;">২</span>.১</p>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                        1.Write Here
                    </th>
                </tr>
                <tr>
                    <td class="style33">
                        Organization Name
                    </td>
                    <td class="style34">
                    </td>
                    <td class="style35">
                        <div style="width: 70%; border: 1px; border-style: solid; float:left">
                            <asp:DropDownList ID="drpOrganizationName" runat="server" Height="25px" Width="100%">
                            </asp:DropDownList>
                        </div>
                        <div style="width: 29%; border: 1px; border-style: solid; float:right" >
                        <asp:Button ID="btnReport" runat="server" Text="Show" style="font-weight:bold" 
                                OnClick="btnReport_Click" Width="64px" />
                        <asp:Button ID="btncsv" runat="server" style="font-weight:bold" Text="CSV" 
                                OnClick="btncsv_Click" Width="64px" Visible ="false" />
                        <asp:Button ID="btnPrint" runat="server" style="font-weight:bold" Text="Print" OnClientClick = "return PrintPanel();"
                                 Width="64px"  Visible ="false"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        E-TIN
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblEtin" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                        3.Address
                    </th>
                </tr>
                <tr>
                    <td class="style1" align="center">
                        <strong>Town Address</strong>
                    </td>
                    <td class="td-width-2">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Holding Number
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownHolding" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Road Number
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownRoadNumber" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Block/Area
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownBlock" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        District
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownDistrict" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Sub-District
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownUpazila" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Postal Code
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownPostCode" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Moza Name
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownMozName" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Phone
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownPhone" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Mobile Phone
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownMobilePhone" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Website
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownWebsite" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Fax
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownFax" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Email
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTownEmail" />
                    </td>
                </tr>
                <tr>
                    <td class="style1" align="center">
                        <strong>Village Address</strong>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Para/Moholla
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillagePara_Moholla" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Village
                    </td>
                    <td class="style3">
                    </td>
                    <td class="style3">
                        <asp:Label runat="server" ID="lblVillageVillage" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Thana
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillageThana" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        District
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillageDistrict" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Sub-District
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillageUpazila" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Postal Code
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillagePostCode" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Moza Name
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillageMozName" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Phone
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillagePhone" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Mobile Phone
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillagemobilePhone" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Website
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillageWebsite" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Fax
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillageFax" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Email
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVillageEmail" />
                    </td>
                </tr>
            </table>
            <div>
                <table class="table table-bordered" style="width: 100%">
                    <tr>
                        <th colspan="6" scope="colgroup" style="text-align: center; background-color: #cccccc"
                            class="style4">
                            4. Branch unit Address
                        </th>
                    </tr>
                    <tr>
                        <td class="style6" style="width:5%" align="center">
                            <strong>Count</strong>
                        </td>
                        <td class="style7" style="width:70%" align="center" colspan="3">
                            <strong>Address With Moza</strong>
                        </td>
                        <td class="style7" style="width:25%" align="center" colspan="2">
                            <strong>Mobile/Phone/Email</strong>
                        </td>
                    </tr>
                    <tr>
                        <asp:Label runat="server" ID="lblBranchUnitAdd"></asp:Label></tr>
                    <%-------------------    --%>
                </table>
            </div>
            <div>
                <table class="table table-bordered" style="width: 100%">
                    <tr>
                        <th colspan="5" scope="colgroup" style="text-align: center; background-color: #cccccc"
                            class="style4">
                            5. Bank Account Details
                        </th>
                    </tr>
                    <tr>
                        <td class="style10" align="center">
                            <strong>Count</strong>
                        </td>
                        <td class="style11" align="center">
                            <strong>Account Name</strong>
                        </td>
                        <td class="style14" align="center">
                            <strong>Account Number</strong>
                        </td>
                        <td class="style13" align="center">
                            <strong>Bank Name</strong>
                        </td>
                        <td align="center" class="style15">
                            <strong>Branch</strong>
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
            <div>
                <table class="table table-bordered" style="width: 100%">
                    <tr>
                        <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                            6. Yearly Turnover
                        </th>
                    </tr>
                    <tr>
                        <td class="td-width-30">
                            Amount
                        </td>
                        <td class="td-width-2">
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblTaka" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td-width-30">
                            In Written
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblTakaInWritten" />
                        </td>
                    </tr>
                </table>
                <table class="table table-bordered" style="width: 100%">
                    <tr>
                        <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                            class="style4">
                            7. Registration Type
                        </th>
                    </tr>
                    <tr>
                        <td class="style17">
                            Registration Type
                        </td>
                        <td class="style16">
                            <asp:Label runat="server" ID="lblRegistrationType" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        8. Vat Deducted At Source
                    </th>
                </tr>
                <tr>
                    <td class="style17">
                        Vat Deducted At Source
                    </td>
                    <td class="style16">
                        <asp:Label runat="server" ID="lblVatDeductedAtSource" />
                    </td>
                </tr>
                <tr>
                    <td class="style17">
                        &nbsp;
                    </td>
                    <td class="style16">
                        <asp:Label runat="server" ID="lblVatDeductedAtSourceCode" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        9. Type Of Business
                    </th>
                </tr>
                <tr>
                    <td class="style17">
                        Type Of Business
                    </td>
                    <td class="style16">
                        <asp:Label runat="server" ID="lblTypeOfBusiness" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        10. Other Tax Collection
                    </th>
                </tr>
                <tr>
                    <td class="style17">
                        Other Tax Collection
                    </td>
                    <td class="style16">
                        <asp:Label runat="server" ID="lblOtherTaxCollection" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        11. Registration Date
                    </th>
                </tr>
                <tr>
                    <td class="style17">
                        Registration Date
                    </td>
                    <td class="style16">
                        <asp:Label runat="server" ID="lblRegistrationDate" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        12. Nature Of Application
                    </th>
                </tr>
                <tr>
                    <td class="style17">
                        Nature Of Application
                    </td>
                    <td class="style16">
                        <asp:Label runat="server" ID="lblNatureOfApplication" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="4" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        13. Application Type
                    </th>
                </tr>
                <tr>
                    <td class="style18">
                        Application Type
                    </td>
                    <td class="style19">
                        <asp:Label runat="server" ID="lblApplicationType" />
                    </td>
                </tr>
                <tr>
                    <td class="style18" align="center">
                        <strong>Count</strong>
                    </td>
                    <td class="style20" align="center" colspan="1">
                        <strong>Organization Name</strong>
                    </td>
                    <td class="style21" align="center" colspan="">
                        <strong>Branch Name</strong>
                    </td>
                    <td class="style7" align="center" colspan="">
                        <strong>Old BIN Number</strong>
                    </td>
                </tr>
                <tr>
                    <asp:Label runat="server" ID="lblShowNatureOfApplication"></asp:Label></tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="6" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        14. Owner Information
                    </th>
                </tr>
                <tr>
                    <td class="style18" align="center">
                        <strong>Count</strong>
                    </td>
                    <td class="style27" align="center" colspan="1">
                        <strong>Name</strong>
                    </td>
                    <td class="style28" align="center" colspan="">
                        <strong>Designation</strong>
                    </td>
                    <td class="style30" align="center">
                        <strong>Share%</strong>
                    </td>
                    <td class="style7" align="center" colspan="2">
                        <strong>Introduce information</strong>
                    </td>
                </tr>
                <tr>
                    <asp:Label runat="server" ID="lblShowOwnerInformation"></asp:Label></tr>
                
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        15. Business process Activities
                    </th>
                </tr>
                <tr>
                    <td class="style17">
                        Business process Activities
                    </td>
                    <td class="style16">
                        <asp:Label runat="server" ID="lblBusinessProcessActivities" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                        class="style4">
                        16. Economical process Activities
                    </th>
                </tr>
                <tr>
                    <td class="style17">
                        Economical process Activities
                    </td>
                    <td class="style16">
                        <asp:Label runat="server" ID="lblEconomicalPActivities" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="col-sm-2">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
      
    </div>
    <div class="col-sm-2">
      
      
    </div>

   </asp:Panel>
</body>
</html>
</asp:Content>
