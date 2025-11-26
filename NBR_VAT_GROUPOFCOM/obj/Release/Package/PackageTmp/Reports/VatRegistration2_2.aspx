<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_VatRegistration2_2, App_Web_pj2ymx2u" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
     <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
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
        
        .test
        {
            width: 183px;
        }
        .style18
        {
            width: 233px;
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
                            background-color: rgb(255, 255, 255); display: inline !important; float: none;">২</span>.২</p>
                </div>
                <div>
                    <table class="table table-bordered" style="width: 100%">
                        <tr>
                            <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                                1.Write Here
                            </th>
                        </tr>
                        <tr style = "background-color :White">
                            <td class="td-width-30">
                                Organization Name
                            </td>
                            <td class="td-width-2">
                            </td>
                            <td>
                                <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                                    <asp:DropDownList ID="drpOrganizationName" runat="server" Width="100%" 
                                        Height="25px" AutoPostBack="True" 
                                        onselectedindexchanged="drpOrganizationName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div style="width: 29%; border: 1px; border-style: solid; float: right; font-weight: bold">
                                    <asp:Button ID="btnReport" runat="server" Text="Show" OnClick="btnReport_Click"
                                        Width="64px" />
                                    <asp:Button ID="btncsv" runat="server" Text="CSV" OnClick="btncsv_Click" Width="64px"  Visible ="false"/>
                                    <asp:Button ID="btnPrint" runat="server" OnClick="btncsv_Click" Text="Print" OnClientClick = "return PrintPanel();" 
                                        Width="64px" Visible ="false"/>
                                </div>
                            </td>
                        </tr>

                        <tr style = "background-color :White">
                            <td class="td-width-30">
                                Branch Name
                            </td>
                            <td class="td-width-2">
                            </td>
                            <td>
                                <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                                    <asp:DropDownList ID="drpBranchName" runat="server" Width="100%" Height="25px">
                                    </asp:DropDownList>
                                </div>
                                <div style="width: 29%; border: 1px; border-style: solid; float: right; font-weight: bold">
                                </div>
                            </td>
                        </tr>

                        <tr style = "background-color :White">
                            <td>
                               Organization E-TIN
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
                        <tr >
                            <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                class="style4">
                                2. Branch unit Name
                            </th>
                        </tr>
                        <tr style = "background-color :White">
                            <td class="style17">
                               <%-- Name--%>
                            </td>
                            <td class="style16">
                                <asp:Label runat="server" ID="lblBranchUnitName"  Visible = "false"/>
                            </td>
                            
                        </tr>
                        <tr style = "background-color:White">
                                <asp:Label runat="server" ID="lblBranchDetails"></asp:Label>
                         </tr>
                    </table>
                </div>
                <div>
                    <table class="table table-bordered" style="width: 100%">
                        <tr>
                            <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                class="style4">
                                3. Turnover
                            </th>
                        </tr>
                        <tr style = "background-color :White">
                            <td class="style17">
                                Amount
                            </td>
                            <td class="style16">
                                <asp:Label runat="server" ID="lblAmount" />
                            </td>
                        </tr>
                        <tr style = "background-color :White">
                            <td class="style17">
                                In Written
                            </td>
                            <td class="style16">
                                <asp:Label runat="server" ID="lblInWritten" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table class="table table-bordered" style="width: 100%">
                        <tr>
                            <th colspan="2" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                class="style4">
                                4. Registration Date
                            </th>
                        </tr>
                        <tr style = "background-color :White">
                            <td class="style17">
                                Date
                            </td>
                            <td class="style16">
                                <asp:Label runat="server" ID="lblRegistrationDate" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table class="table table-bordered" style="width: 100%; border-bottom: 1px">
                        <tr>
                            <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                                5.Address
                            </th>
                        </tr>
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
                            <td class="style1">
                                Road Number
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblTownRoadNumber" />
                            </td>
                        </tr style = "background-color :White">
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
                            <td class="style1">
                                District
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblTownDistrict" />
                            </td>
                        </tr >
                        <tr style = "background-color :White">
                            <td class="style1">
                                Sub-District
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblTownUpazila" />
                            </td>
                        </tr >
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
                            <td class="style2">
                                Village
                            </td>
                            <td class="style3">
                            </td>
                            <td class="style3">
                                <asp:Label runat="server" ID="lblVillageVillage" />
                            </td>
                        </tr>
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
                            <td class="style1">
                                Sub-District
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblVillageUpazila" />
                            </td>
                        </tr style = "background-color :White">
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White">
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
                        <tr style = "background-color :White"> 
                            <td class="style1">
                                Email
                            </td>
                            <td>
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
                                    6. Bank Account Details
                                </th>
                            </tr>
                            <tr style = "background-color :White">
                               

                                <td class="style10" align="center">
                                    <strong>Count</strong>
                                </td>

                                 <td class="style18" align="center">
                                    <strong> Branch Name</strong>
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
                            <tr style = "background-color:White">
                                <asp:Label runat="server" ID="lblBankInfoShow"></asp:Label>
                                </tr>
                            
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-sm-2">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>
             <uc2:MsgBox ID="msgBox" runat="server" />
        </asp:Panel>
    </body>
    </html>
</asp:Content>
