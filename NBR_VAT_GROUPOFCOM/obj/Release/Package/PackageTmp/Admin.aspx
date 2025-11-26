<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Admin, App_Web_qr4mw4bg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
     <style>
        .list-group-item:not(.active) { background-color: #ffffff; }
        .list-group-item:not(.active):hover { background-color: #f2f2f2 !important; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading"> Control Panel</div>
        <div class="panel-body">
            <div class="list-group col-md-2 col-sm-4">
                <a class="list-group-item active">User / Basic Setup</a>
                
                <asp:HyperLink class="list-group-item"   ID="HyperLink2" NavigateUrl="~/UI/UserSetup/Add_User.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> User Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink3" NavigateUrl="~/UI/UserSetup/AdminUserPermission.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> User Privilege</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink35" NavigateUrl="~/bss_branch_control.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Business Unit Privilege</asp:HyperLink>
               
                <asp:HyperLink class="list-group-item"   ID="HyperLink41" NavigateUrl="~/UI/Admin/ApproverSetup.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Approver Stage Set up</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink33" NavigateUrl="~/Admin_Dashboard.aspx" runat="server">DashboardVTR</asp:HyperLink>--%>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink5" NavigateUrl="~/UI/Admin/SetCustomer.aspx" runat="server">Customer Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink6" NavigateUrl="~/UI/Others/Add_Trans_Party.aspx" runat="server">Supplier Setup</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink6" NavigateUrl="~/UI/Others/Add_Trans_Party.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Party/Client Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink7" NavigateUrl="~/UI/Admin/SetChallanNo.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Challan Book Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLinkPMP" NavigateUrl="~/UI/Admin/Payment_Method_Permission_SetUp.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Payment Method Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink30" NavigateUrl="~/UI/Admin/Add_Department.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Department Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink31" NavigateUrl="~/UI/Admin/Add_Designation.aspx"  runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Designation Setup</asp:HyperLink>
            </div>
            <div class="list-group col-md-2 col-sm-4">
                <a class="list-group-item active">Operation Setup</a>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink1" NavigateUrl="~/UI/Admin/Company_Registration.aspx" runat="server">Organization</asp:HyperLink>--%>


                    <asp:HyperLink class="list-group-item"   ID="HyperLink18" NavigateUrl="~/UI/Admin/VatRegistration_2.1.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> মূল্য সংযোজন ও টার্ণওভার কর তালিকাভুক্তির আবেদনপত্র (মূসক ২.১)</asp:HyperLink>
                    <%--<asp:HyperLink class="list-group-item" ID="HyperLink23" NavigateUrl="~/UI/Admin/VatBranchRegistration_2.2.aspx" runat="server">মূল্য সংযোজন করের অধীন শাখা ইউনিট নিবন্ধনের আবেদনপত্র</asp:HyperLink>--%>
                    <asp:HyperLink class="list-group-item"   ID="HyperLink34" NavigateUrl="~/UI/Admin/BookingInformation.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Room Booking Information</asp:HyperLink>
                
               
                <asp:HyperLink class="list-group-item"   ID="HyperLink32" NavigateUrl="~/UI/Admin/SetBaseDataMaster.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Master Base Data</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink8" NavigateUrl="~/UI/Admin/SetBaseData.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Base Data</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink1" NavigateUrl="~/UI/Admin/BackUP.aspx"  runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Back UP</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink5" NavigateUrl="~/UI/Admin/Add_ClosingVATSD.aspx"  runat="server"><i class="fa fa-arrow-circle-right" style="color:green;"></i>VAT & SD Closing</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink38" NavigateUrl="~/UI/Admin/VATSDAdjustment18.6.aspx"  runat="server"><i class="fa fa-arrow-circle-right" style="color:green;"></i>SD & VAT Previous Current Adjustment (18.6)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink36" NavigateUrl="~/UI/Purchase/Prev_LocalPurchase.aspx"  runat="server"><i class="fa fa-arrow-circle-right" style="color:green;"></i>Previous Transaction</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink37" NavigateUrl="~/UI/Admin/Party_Balance_Setup.aspx"  runat="server"><i class="fa fa-arrow-circle-right" style="color:green;"></i>Party Balance Setup</asp:HyperLink>
            </div>
            <div class="list-group col-md-2 col-sm-4">
                <a class="list-group-item active">Location Setup</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink9" NavigateUrl="~/UI/Admin/Add_Country.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Country</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink10" NavigateUrl="~/UI/Admin/Add_Division.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Division</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink11" NavigateUrl="~/UI/Admin/SetDistrict.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> District</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink12" NavigateUrl="~/UI/Admin/SetUpazila.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Upazila</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink13" NavigateUrl="~/UI/Admin/SetUnionWard.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Union/Ward</asp:HyperLink>
            </div>
            <div class="list-group col-md-2 col-sm-4">
                <a class="list-group-item active">NBR Setup</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink14" NavigateUrl="~/UI/Admin/Vat_Commissionerate.aspx"
                    runat="server" Visible = "false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Commissionerate</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink26" NavigateUrl="~/UI/Admin/Commissionerate.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Commissionerate</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink15" NavigateUrl="~/UI/Admin/Vat_Division.aspx"
                    runat="server" Visible = "false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> VAT Division</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink27" NavigateUrl="~/UI/Admin/Vat_Division_New.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> VAT Division</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink16" NavigateUrl="~/UI/Admin/Vat_Circle.aspx"
                    runat="server" Visible = "false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Circle</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink28" NavigateUrl="~/UI/Admin/Vat_Circle_New.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Circle New</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink17" NavigateUrl="~/UI/Admin/Vat_Area.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Area</asp:HyperLink>
               <%-- <asp:HyperLink class="list-group-item" ID="HyperLink18" NavigateUrl="~/UI/Others/DADO.aspx"
                    runat="server">DEDO</asp:HyperLink>--%>
            </div>
            <div class="list-group col-md-3 col-sm-4">
                <a class="list-group-item active">Financial Setup</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink19" NavigateUrl="~/UI/Admin/Bank_Setup.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Bank</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink20" NavigateUrl="~/UI/Admin/Bank_Branch_Setup.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Bank Branch</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink21" NavigateUrl="~/UI/Admin/Add_Org_Bank_Account.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Bank Account</asp:HyperLink>
                     <asp:HyperLink class="list-group-item"   ID="HyperLink33" NavigateUrl="~/UI/Admin/VDS_Monitoring.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> উৎসে কর কর্তন মনিটরিং</asp:HyperLink>
                
                <asp:HyperLink class="list-group-item"   ID="HyperLink29" NavigateUrl="~/UI/Admin/Rebate_Monitoring.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> রেয়াত মনিটরিং</asp:HyperLink>

                 <asp:HyperLink class="list-group-item"   ID="HyperLink42" NavigateUrl="~/UI/Admin/RebateAdjustmentPurchase.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> রেয়াত  সমন্বয় (ক্রয়)</asp:HyperLink> 

                 <asp:HyperLink class="list-group-item"   ID="HyperLink39" NavigateUrl="~/UI/Admin/RebateAdjustment.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> রেয়াত সমন্বয়</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"   ID="HyperLink40" NavigateUrl="~/UI/Admin/GiftVATAdjustment.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Gift/Discount সমন্বয়</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink22" NavigateUrl="~/UI/Admin/TreasuryChallan_6.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> চালান ফরম (টি.আর. ফর্ম নং-৬)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink23" NavigateUrl="~/UI/Admin/Import_AIT_Refund_4.1.aspx"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> আমদানি পর্যায়ে পরিশোধিত অগ্রীম কর ফেরত</asp:HyperLink>

                    <asp:HyperLink class="list-group-item"   ID="HyperLink4" NavigateUrl="~/UI/Admin/Import_AIT_Refund_4.1.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> আমদানি পর্যায়ে পরিশোধিত অগ্রীম কর ফেরত প্রাপ্তির আবেদন</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink24" NavigateUrl="~/UI/Admin/SupplDutyAdjApp_7.1.aspx" 
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> সম্পূরক শুল্ক সমন্বয়ের আবেদনপত্র (মূসক-৭.১)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink25" NavigateUrl="~/UI/Admin/Add_Org_Item_Turnover.aspx" Visible = "false"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Yearly Turnover</asp:HyperLink>
            </div>
            <div class="clearfix">
            </div>
            <%--<div class="col-lg-12 col-md-12 col-sm-12">
                <h4>
                    <i class="fa fa-info-circle"></i>Control Panel Panel is sub-divided into 5 unique
                    setup categories for aiding the Admin. They are as listed below:</h4>
                <ul>
                    <li><b>User Setup:</b> Here he/she can create new users and alter or limit their access
                        control to KGCVAT. </li>
                    <li><b>Operation Setup:</b> He/she would be able to add a new organization, add or edit
                        Challan Books necessary for Musak 6.2, add new business party/client and pre-set
                        default time for product/service delivery.</li>
                    <li><b>Location Setup:</b> He/she would be able to alter/add any hierarchy of locations
                        whenever amendments are made.</li>
                    <li><b>NBR Setup:</b> He/she would be able to alter/add any hierarchy of VAT locations
                        whenever mandated by NBR.
                    </li>
                    <li><b>Financial Setup:</b> He/she would be able to add necessary organizational bank
                        details, deposit Treasury and enter probable yearly turnover for individual items/services.</li>
                </ul>
            </div>--%>
        </div>
    </div>
</asp:Content>
